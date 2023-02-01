using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.DTO.Franchise
{
    /// <summary>
    /// Data transfer object for Franchise editing.
    /// </summary>
    public class FranchiseEditDTO
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
