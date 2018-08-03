using Microsoft.AspNetCore.Mvc;
using Model.Charge;
using Model.Entities;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebAPI.Controllers
{
    [Route("le/person")]
    public class PersonController : Controller
    {
        private readonly IPersonMongoDal _personMongoDal;
        private const string personCollection = "Person";

        public PersonController(IPersonMongoDal personMongoDal) => 
            _personMongoDal = personMongoDal;

        [HttpPost("seed")]
        public IActionResult Seed()
        {
            _personMongoDal.InsertData(personCollection, PersonData.Seed());
            return Json(new { menssage = "Load data success"});
        }

        [HttpGet("find")]
        public IActionResult FindPerson(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Name invalid");

            Expression<Func<Person, bool>> filter = x => x.Name.ToLower().Contains(name.ToLower());
            Expression<Func<Person, object>> order = x => x.Age;

            var data = _personMongoDal.ListData(personCollection, filter, order);
            return Json(new { data });
        }

        [HttpGet("list")]
        public IActionResult GetData()
        {
            var data = _personMongoDal.ListData(personCollection, x => x.Age);
            return Json(new { data });
        }

        [HttpGet("clean")]
        public IActionResult Clean()
        {
            _personMongoDal.ClearDataBase(personCollection);
            return Json(new { message = "Database cleaned with success" });
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody]Person person)
        {
            var dictionary = new Dictionary<string, object>
            {
                { nameof(person.Name), person.Name },
                {nameof(person.Age), person.Age },
                { nameof(person.VIP), person.VIP }
            };

            _personMongoDal.UpdateOne(personCollection, dictionary, person.Id);
            return Json(new { message = "Updated with success" });
        }

        [HttpPut("update/many")]
        public IActionResult Update([FromBody]ICollection<Person> people)
        {
            _personMongoDal.UpdateMany(people);
            return Json(new { message = "Updated with success" });
        }
    }
}
