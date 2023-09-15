namespace VCommerceAdmin.ApiModels
{
    public class GetCategoriesRequest
    {
        public int ParentId { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}