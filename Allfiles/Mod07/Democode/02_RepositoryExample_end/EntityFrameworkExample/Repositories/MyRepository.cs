using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Data;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Repositories
{
    public class MyRepository : IRepository
    {
        private PersonContext _context;

        public MyRepository(PersonContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetPeople()
        {
            return _context.People.ToList();
        }

        public void CreatePerson()
        {
            _context.Add(new Person() { FirstName = "Robert ", LastName = "Berends", City = "Birmingham", Address = "2632 Petunia Way" });
            _context.SaveChanges();
        }

        public void UpdatePerson(int id)
        {
            var person = _context.People.SingleOrDefault(m => m.PersonId == id);
            person.FirstName = "Brandon";
            _context.Update(person);
            _context.SaveChanges();
        }

        public void DeletePerson(int id)
        {
            var person = _context.People.SingleOrDefault(m => m.PersonId == id);
            _context.People.Remove(person);
            _context.SaveChanges();
        }
    }
}
