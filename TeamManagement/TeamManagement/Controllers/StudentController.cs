using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeamManagement.DTO;
using TeamManagement.Models;

namespace TeamManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly FPTUProjectContext _context;

        public StudentController(FPTUProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var student = _context.Students.ToList();
            return Ok(student);
        }

        [HttpGet("id")]
        public IActionResult GetById(string id)
        {
            var student = _context.Students.SingleOrDefault(st => st.StuId == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student studentDTO)
        {
            try
            {
               var st = _context.Students.SingleOrDefault(st => st.StuId == studentDTO.StuId);
                if(st == null) {
                    var student = new Student
                    {
                        StuId = studentDTO.StuId,
                        StuName = studentDTO.StuName,
                        StuEmail = studentDTO.StuEmail,
                        StuPhone = studentDTO.StuPhone,
                        DateOfBirth = studentDTO.DateOfBirth,
                        StuGender = studentDTO.StuGender,
                    };
                    _context.Students.Add(student);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        Success = true,
                        Data = student
                    });
                }
                return BadRequest();
                
                
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("id")]
        public IActionResult Update(string id, StudentDTO stu)
        {

            var student = _context.Students.SingleOrDefault(st => st.StuId == id);
            if (student != null)
            {
                student.StuName = stu.StuName;
                student.StuEmail = stu.StuEmail;
                student.StuPhone = stu.StuPhone;
                student.DateOfBirth = stu.DateOfBirth;
                student.StuGender = stu.StuGender;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();


        }

        [HttpDelete("id")]
        public IActionResult Delete(string id)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(st => st.StuId == id);
                if (student == null)
                {
                    return NotFound();
                }
                _context.Students.Remove(student);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
