﻿using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class GetBrandsResponse : BaseResponse, IPageResponse
    {
        public List<BrandsResponse> Brands { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public GetBrandsResponse(List<BrandsResponse> brands, PageResponse pageResponse, int code, string msg) 
        {
            Brands = brands;
            Page = pageResponse.Page;
            PageSize = pageResponse.PageSize;
            TotalPages = pageResponse.TotalPages;
            TotalRecords = pageResponse.TotalRecords;
            Code = code;
            Message = msg;
        }

        public GetBrandsResponse(List<BrandsResponse> brands, int code, string msg)
        {
            Brands = brands;
            Code = code;
            Message = msg;
        }
    }

    public class BrandsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public string? Photo { get; set; }
        public string CreatedByUser { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
        public string CreatedDate { get; set; } = null!;
        public string? ModifiedByUser { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public short StatusId { get; set; }
        public string StatusName { get; set; } = null!;
    }
}