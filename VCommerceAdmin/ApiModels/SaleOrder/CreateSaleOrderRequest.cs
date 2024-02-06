using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class CreateSaleOrderRequest
    {
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg", ".gif" })]
        public IFormFile? Photo { get; set; }
        [JsonIgnore]
        internal string? PhotoName { get; set; }
        public short StatusId { get; set; }
    }
}