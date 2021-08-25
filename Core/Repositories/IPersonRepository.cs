using Core.Models.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> AddPerson(Person person);
        Task<List<Person>> GetManyPerson(string name, string firstName);
        Task<Person> GetPersonByID(Person person);
        Task UpdatePerson(Guid oldPersonID, Person newPerson);
        Task DeletePerson(Person person);
    }
}
