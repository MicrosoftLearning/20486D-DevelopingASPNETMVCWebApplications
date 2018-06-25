using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExample.Models;

namespace EntityFrameworkExample.Repositories
{
    public interface IRepository
    {
        IEnumerable<Person> GetPeople();
        void CreatePerson();
        void DeletePerson(int id);
        void UpdatePerson(int id);
    }
}
