using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class PersonFilm
    {
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        [ForeignKey("Film")]
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonFilmId { get; set; }
    }
}
