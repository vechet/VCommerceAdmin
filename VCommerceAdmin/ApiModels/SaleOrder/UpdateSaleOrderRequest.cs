using System.Text.Json.Serialization;
using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class UpdateSaleOrderRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        [AllowedExtensions(new string[] { ".png", ".jpg", ".jpeg", ".gif" })]
        public IFormFile? Photo { get; set; }
        [JsonIgnore]
        internal string? PhotoName { get; set; }
        public short StatusId { get; set; }
    }
}