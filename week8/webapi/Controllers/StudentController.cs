using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Database;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _dbContext;

        public StudentController(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAllStudent()
        {
            var result = _dbContext.Students.ToList();
            return Ok(result);
        }


        [HttpGet("{studentId}")]
        public ActionResult<Student> GetStudent(int studentId)
        {
            var student = _dbContext.Students
                .SingleOrDefault(p => p.StudentId == studentId);

            if (student != null) {
                return student;
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            // return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);

            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
        }

        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent(int studentId)
        {
            var student = new Student { StudentId = studentId };

            _dbContext.Students.Attach(student);
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{productId}")]
        public ActionResult UpdateStudent(int studentId, Student studentUpdate)
        {
            var student = _dbContext.Students
                .SingleOrDefault(p => p.StudentId == studentId);

            if (student != null)
            {
                student.email_address= studentUpdate.email_address;
                student.StudentId = studentUpdate.StudentId;

                _dbContext.Update(student);

                _dbContext.SaveChanges();
            }

            return NoContent();
        }

     
    }
}
