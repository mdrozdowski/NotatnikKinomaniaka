using DatabaseLayer.Context;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class PersonRepository
    {
        DatabaseContext db = new DatabaseContext();

        public void Add(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }

    }
}
