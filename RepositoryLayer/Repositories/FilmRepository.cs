using DatabaseLayer.Context;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class FilmRepository
    {
        DatabaseContext db = new DatabaseContext();

        public void Add(Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
        }
        public ICollection<Film> GetAllFilms()
        {
           return db.Films.ToList();
        }
    }
}
