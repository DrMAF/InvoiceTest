namespace Core.ViewModels.Responses.Invoices
{
    public class InvoiceVM
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public List<InvoiceItemVM>? Items { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? Total { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? Net { get; set; }
    }
}
