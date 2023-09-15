using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class Configuration
{
    public short Id { get; set; }

    public string KeyName { get; set; } = null!;

    public string? Value { get; set; }

    public string? Memo { get; set; }

    public string? Type { get; set; }

    public string? Name { get; set; }
}
