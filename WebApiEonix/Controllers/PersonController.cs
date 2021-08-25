using Core.Repositories;
using GlobalSettings = Eonix.Configuration.GlobalSettings;
using Core.EonixDBContext;
using Microsoft.AspNetCore.Mvc;
using Core.Models.Serialization;
using System.Threading.Tasks;
using System;

namespace Api.Controllers
{
    [Route("person-Controller")]
    public class PersonController : BaseController
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository,
                                GlobalSettings globalSettings,
                                EonixContext eonixContext): base(globalSettings, eonixContext)
        {
            _personRepository = personRepository; 
        }
        [HttpPost("add-person")]
        public async Task AddPerson(Person person)
        {
            await _personRepository
                    .AddPerson(person);
        }
        [HttpPost("update-person")]
        public async Task UpdatePerson(Guid oldPersonID, [FromBody]Person newPerson)
        {
            await _personRepository
                    .UpdatePerson(oldPersonID, newPerson);
        }
        [HttpPost("delete-person")]
        public async Task DeletePerson(Person person)
        {
            await _personRepository
                    .DeletePerson(person);
        }
        [HttpGet("get-person-by-id")]
        public async Task<IActionResult> GetPersonByID(Person person)
        {
           var result = await _personRepository.GetPersonByID(person);
            return Json(result);
        }
        [HttpGet("get-many-person")]
        public async Task<IActionResult> GetManyPerson(string name, string firstName)
        {
            var results = await _personRepository.GetManyPerson(name, firstName);
            return Json(results);

        }
    }
}
