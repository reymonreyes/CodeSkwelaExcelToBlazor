namespace SimpleServiceInvoice.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Terms { get; set; }
        public decimal TaxRate { get; set; }
        public string InvoiceNumber { get; set; }
        public ICollection<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }

    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProviderServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
