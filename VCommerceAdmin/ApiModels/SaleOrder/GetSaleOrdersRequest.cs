using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VCommerceAdmin.ApiModels
{
    public class GetSaleOrdersRequest
    {
        [DefaultValue(false)]
        public bool isShowAll { get; set; } = false;
        [Range(1,9999)]
        public int Page { get; set; }
        [Range(1, 9999)]
        public int PageSize { get; set; }
    }
}