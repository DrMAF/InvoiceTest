namespace Core.Domain
{
    public class Product : BaseEntity
    {
        public virtual ICollection<ProductUnit>? ProductUnits { get; set; }
    }
}
