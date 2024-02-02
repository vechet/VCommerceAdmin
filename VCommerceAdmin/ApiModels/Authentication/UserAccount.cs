using System.Text.Json.Serialization;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class UserAccount
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}