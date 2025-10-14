using SimpleServiceInvoice.Models;

namespace SimpleServiceInvoice.ViewModels
{
    public class InvoiceViewModel
    {
        public Provider Provider { get; set; }
        public Customer Customer { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Terms { get; set; }
        public List<InvoiceItemViewModel> Items { get; set; } = new List<InvoiceItemViewModel>();
    }

    public class InvoiceItemViewModel
    {
        public int Id { get; set; }
        public ProviderService Service { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total
        {
            get { return Quantity * UnitPrice; }
        }
    }
}
