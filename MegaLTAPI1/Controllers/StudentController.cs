using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ModelDTOs.Models;
using MegaLTAPI1.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MegaLTAPI1.Controllers
{
    [ApiController]
    //Automatic validation - but it can check only for null values
    [Route("api/[controller]")]
    //[Authorize]

    //[TypeFilter(typeof(MyActionFilterAttribute))]
    
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IService service)
        {
            _studentService = service.StudentService;
        }

        // GET: api/student
        [HttpGet]
        [ResponseCache(Duration =30)]
        public IActionResult Get()
        {
            return Ok(_studentService.GetStudents());

        }


        // GET api/student/5       
        [HttpGet("{id}")]
        [MyActionFilter]
        public IActionResult Get(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return BadRequest(new { ErrorMesssage = "This Id does not exist." });
            }
            else
            {
                return Ok(student);
            }

        }

        // POST api/student
        [HttpPost]        
        public IActionResult Create([FromBody] StudentDTO student)
        {
            _studentService.CreateStudent(student);
            _studentService.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
            //return Created(new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{student.Id}"), student);
        }

        // PUT api/student/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentDTO student)
        {

            if (_studentService.CheckIfStudentExists(student.Id))
            {
                _studentService.UpdateStudent(student);
                _studentService.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Id is not valid");
            }

        }

        // DELETE api/student/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student == null)
            {
                return BadRequest("Provided Id does not exist");
            }
            _studentService.DeleteStudent(student);
            _studentService.SaveChanges();
            return Ok();
        }
    }
}

