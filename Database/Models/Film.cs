using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class Film
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; }

        public string Title { get; set; }

        public DateTime DateOfProduction { get; set; } = DateTime.Now;

        public virtual ICollection<Person> Cast { get; set; }

    }
}
