using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCharactersAPI.Models.Domain
{
    [Table("Character")]
    public class Character
    {
        public int CharacterId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string Alias { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Url]
        public string PictureURL { get; set; }

        //Navigation Properties
        public ICollection<Movie> Movies { get; set; }

    }


    public enum Gender
    {
        Male,
        Female
    }
}
