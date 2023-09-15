namespace VCommerceAdmin.Models;

public partial class ConfigurationParam
{
    public int Id { get; set; }

    public string ConfiguratonKeyType { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;
}