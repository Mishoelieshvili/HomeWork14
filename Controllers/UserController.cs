using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using FluentValidation;
using Week14.Model;

namespace Week14.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : Controller
        {
        [HttpPost("adduser")]
        public IActionResult CreateUser(Respondent user)
        {
            var validator = new PersonValidator();
            FluentValidation.Results.ValidationResult result = validator.Validate(user);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors[0].ErrorMessage);
            }

            var userList = new List<Respondent> {
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

                var myUser = new Respondent()
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Id = user.Id,

                };
                userList.Add(myUser);

                if (userList.Count == 3)
                {
                    return BadRequest("Sorry, user was not added");
                }
                else
                {
                    return Ok(userList);
                }

            }
        }
}

