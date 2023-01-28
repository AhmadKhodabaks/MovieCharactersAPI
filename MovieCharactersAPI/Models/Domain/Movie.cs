using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MovieCharactersAPI.Models.Domain
{
    [Table("Movie")]
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MaxLength(30)]
        public string Genre { get; set; }

        [Required]
        public string ReleaseYear { get; set; }

        [Required]
        [MaxLength(20)]
        public string Director { get; set; }

        [Url]
        public string PictureURL { get; set; }

        [Url]
        public string TrailerURl { get; set; }

        //Foreign keys
        public int FranchiseId { get; set; }

        //Navigation properties
        public Franchise Franchise { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
