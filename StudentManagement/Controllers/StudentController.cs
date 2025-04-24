using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models.Domain;
using StudentManagement.Models.Dto;
using StudentManagement.Repositories;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        private readonly StudentManagementDbContext dbContext;
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentController(StudentManagementDbContext dbContext,IStudentRepository studentRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        #region GetAll Students
        [HttpGet]
        [Authorize(Roles ="Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            var studentList = await studentRepository.GetAllAsync();
            
            return Ok(mapper.Map<List<StudentDto>>(studentList));
        }
        #endregion

        #region Get Student By ID
        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "Reader,Writer")]

        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var studentDomainModel = await studentRepository.GetByIdAsync(id);
            if (studentDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StudentDto>(studentDomainModel));
        }
        #endregion

        #region Create Student
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody]AddStudentRequestDto addStudentRequestDto)
        {
            var studentDomainModel = mapper.Map<Student>(addStudentRequestDto);
            await studentRepository.CreateAsync(studentDomainModel);
            return Ok(mapper.Map<AddStudentRequestDto>(studentDomainModel));
        }
        #endregion

        #region Update Student
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody]UpdateStudentRequestDto updateStudentRequestDto)
        {
            var studentDomainModel = mapper.Map<Student>(updateStudentRequestDto);
            studentDomainModel = await studentRepository.UpdateAsync(id, studentDomainModel);
            if(studentDomainModel== null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StudentDto>(studentDomainModel));
        }
        #endregion

        #region Delete Student
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var personDomainModel = await studentRepository.DeleteAsync(id);
            if (personDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StudentDto>(personDomainModel));
        }
        #endregion
    }
}
