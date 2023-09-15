using System;
using System.Collections.Generic;

namespace VCommerceAdmin.Models;

public partial class GlobalParam
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string KeyName { get; set; } = null!;

    public string? Type { get; set; }

    public int? Value1 { get; set; }

    public string? Value2 { get; set; }

    public string? Memo { get; set; }

    public short StatusId { get; set; }
}
