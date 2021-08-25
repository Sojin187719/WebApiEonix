using Core.Models.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.EonixDBContext;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.Implementation
{
    class PersonRepository : IPersonRepository
    {
        private readonly EonixContext _context;
        public PersonRepository(EonixContext context)
        {
            _context = context;
        }
        public async Task<Person> AddPerson(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task DeletePerson(Person person)
        {
            var result = await _context.Persons.SingleOrDefaultAsync(p => p.Id == person.Id);
            if (result == null) return;
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetManyPerson(string name, string firstName)
        {
                return await _context.Persons.Where(e => name == null || e.Name.Trim().Contains(name))
                                            .Where(e => firstName == null || e.FirstName.Trim().Contains(firstName)).ToListAsync();
        }

        public async Task<Person> GetPersonByID(Person person)
        {
            return await _context.Persons.SingleOrDefaultAsync(p => p.Id == person.Id);
        }

        public async Task UpdatePerson(Guid oldPersonID, Person newPerson)
        {
            var result = await _context.Persons.SingleOrDefaultAsync(p => p.Id == oldPersonID);
            if (result == null) return;
            result.Name = newPerson.Name;
            result.FirstName = newPerson.FirstName;
            await _context.SaveChangesAsync();
        }
    }
}
