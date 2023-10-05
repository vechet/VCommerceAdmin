using System.Text.Json.Serialization;

namespace VCommerceAdmin.ApiModels.Authentication
{
    public class UserAccount
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Token { get; set; } = null!;
    }
}