using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;

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

        [HttpGet("list")]
        public IActionResult GetData()
        {
            var data = _personMongoDal.ListData(personCollection);
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
