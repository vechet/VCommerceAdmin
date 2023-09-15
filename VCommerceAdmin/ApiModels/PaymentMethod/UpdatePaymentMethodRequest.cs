namespace VCommerceAdmin.ApiModels
{
    public class UpdatePaymentMethodRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Memo { get; set; }
        public short StatusId { get; set; }
    }
}