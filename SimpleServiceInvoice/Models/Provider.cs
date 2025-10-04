namespace SimpleServiceInvoice.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<ProviderService> Services { get; set; } = new List<ProviderService>();
    }

    public class ProviderService
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
