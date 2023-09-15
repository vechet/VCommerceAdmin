namespace VCommerceAdmin.ApiModels
{
    public class CreatePaymentMethodRequest
    {
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public short StatusId { get; set; }
    }
}