namespace Core.ViewModels.Responses.Products
{
    public class ProductUnitVM
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }
        public decimal? Price { get; set; }
    }
}
