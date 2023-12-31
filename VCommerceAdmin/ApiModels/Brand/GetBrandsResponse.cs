﻿using VCommerceAdmin.Helpers;

namespace VCommerceAdmin.ApiModels
{
    public class GetBrandsResponse : BaseResponse, IPageResponse
    {
        public List<BrandsResponse> Brands { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public GetBrandsResponse(List<BrandsResponse> brands, PageResponse pageResponse, int code, string msg) 
        {
            Brands = brands;
            PageNumber = pageResponse.PageNumber;
            PageSize = pageResponse.PageSize;
            TotalPages = pageResponse.TotalPages;
            TotalRecords = pageResponse.TotalRecords;
            ErrorCode = code;
            ErrorMessage = msg;
        }

        public GetBrandsResponse(List<BrandsResponse> brands, int code, string msg)
        {
            Brands = brands;
            ErrorCode = code;
            ErrorMessage = msg;
        }
    }

    public class BrandsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public string? Photo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public short StatusId { get; set; }
        public string StatusName { get; set; } = null!;
    }
}