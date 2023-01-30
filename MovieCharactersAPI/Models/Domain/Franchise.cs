using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MovieCharactersAPI.Models.Domain
{
    [Table("Franchise")]
    public class Franchise
    {
        public int FranchiseId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Description { get; set; }

        //Navigation property
        public ICollection<Movie>? Movies { get; set; }
    }
}
