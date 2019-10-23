using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Services;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        
        // GET: api/Student
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<StudentVm>> Get()
        {
            return await _studentService.GetAllStudentsAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST: api/Student
        [HttpPost]
        [Route("CreateNewStudentAsync")]
        public async Task<StudentVm> CreateNewStudentAsync([FromBody] NewStudentVm studentVm)
        {
            return await _studentService.CreateNewStudentAsync(studentVm);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
