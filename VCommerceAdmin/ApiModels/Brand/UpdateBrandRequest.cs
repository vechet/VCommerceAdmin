using System.ComponentModel.DataAnnotations;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class UpdateBrandRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg", ".gif" })]
        public IFormFile Photo { get; set; }
        public short StatusId { get; set; }
    }
}