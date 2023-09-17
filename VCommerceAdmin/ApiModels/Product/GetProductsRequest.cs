﻿using System.ComponentModel;

namespace VCommerceAdmin.ApiModels
{
    public class GetProductsRequest
    {
        [DefaultValue(false)]
        public bool ShowAllRecord { get; set; } = false;
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}