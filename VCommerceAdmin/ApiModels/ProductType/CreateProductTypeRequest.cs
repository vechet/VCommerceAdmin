﻿namespace VCommerceAdmin.ApiModels
{
    public class CreateProductTypeRequest
    {
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public short StatusId { get; set; }
    }
}