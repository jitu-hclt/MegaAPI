using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ModelDTOs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MegaLTAPI1.Controllers
{
    [ApiController]
    //Automatic validation - but it can check only for null values
    [Route("api/[controller]")]
    [Authorize]
    [EnableCors()]
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;

        public GradeController(IService service)
        {
            _gradeService = service.GradeService;
        }

        // GET: api/grade
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gradeService.GetGrades());

        }


        // GET api/grade/5       
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var grade = _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return BadRequest(new { ErrorMesssage = "This Id does not exist." });
            }
            else
            {
                return Ok(grade);
            }

        }

        // POST api/grade
        [HttpPost]        
        public IActionResult Create([FromBody] GradeDTO grade)
        {
            _gradeService.CreateGrade(grade);
            _gradeService.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = grade.Id }, grade);
            //return Created(new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{grade.Id}"), grade);
        }

        // PUT api/grade/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GradeDTO grade)
        {

            if (_gradeService.CheckIfGradeExists(grade.Id))
            {
                _gradeService.UpdateGrade(grade);
                _gradeService.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Id is not valid");
            }

        }

        // DELETE api/grade/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var grade = _gradeService.GetGradeById(id);

            if (grade == null)
            {
                return BadRequest("Provided Id does not exist");
            }
            _gradeService.DeleteGrade(grade);
            _gradeService.SaveChanges();
            return Ok();
        }
    }
}

