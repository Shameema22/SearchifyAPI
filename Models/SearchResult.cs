using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SearchifyAPI.Models
{
    public class SearchResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
        public required string SearchKeys { get; set; }
    }
}
