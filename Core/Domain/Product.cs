namespace Core.Domain
{
    public class Product : BaseEntity
    {
        public ICollection<ProductUnit>? ProductUnits { get; set; }
    }
}
