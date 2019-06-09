using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DatabaseKinomaniak") { }

        public virtual DbSet<Film> Films { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<PersonFilm> PersonFilms { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }


    }
}
