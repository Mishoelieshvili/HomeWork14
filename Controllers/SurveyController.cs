using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Week14.Model;

namespace Week14.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SurveyController : Controller
    {
        private static List<Respondent> _respondents = new List<Respondent> {
            new Respondent()
            {
                Firstname ="Nick",
                Lastname ="White",
                Id = 1,

            },
            new Respondent()
            {
                Firstname ="Tom",
                Lastname ="Crown",
                Id = 2,

            },
            new Respondent()
            {
               Firstname ="Sam",
               Lastname ="Woods",
               Id = 3,
            }
            };

        [HttpPost]
        public IActionResult AddRespondent(Respondent respondent)
        {
            _respondents.Add(respondent);
            return Ok();
        }
      
        [HttpGet]
        public IActionResult GetAllRespondents()
        {
            return Ok(_respondents);
        }

        [HttpGet("{id}")]
        public IActionResult GetRespondentById(int id)
        {
            if (id < 0 || id >= _respondents.Count)
            {
                return NotFound($"Respondent with id {id} not found.");
            }

            var respondent = _respondents[id];
            return Ok(respondent);
        }

       


        [HttpDelete("deleteuser/{id}")]
        public IActionResult DeleteRespondent(int id)
        {
            if (id < 0 || id >= _respondents.Count)
            {
                return BadRequest("Invalid index");
            }

            _respondents.RemoveAt(id);

            return Ok(_respondents);
        }

        [HttpPut("updateuser/{id}")]
        public IActionResult UpdateRespondent(int id, Respondent respondent)
        {
            if (id < 0 || id >= _respondents.Count)
            {
                return BadRequest("Invalid index");
            }

            var validator = new PersonValidator();
            var validationResult = validator.Validate(respondent);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(errors);
            }

            _respondents[id] = respondent;

            return Ok(_respondents);
        }
    }
}

