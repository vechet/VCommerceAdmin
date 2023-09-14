using System.ComponentModel.DataAnnotations;

namespace VCommerceAdmin.ViewModels
{
    public class BrandViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string? Memo { get; set; }
        [Required]
        public string Status { get; set; } = null!;
    }
}
