﻿namespace Core.ViewModels.Responses.Products
{
    public class ProductVM
    {
        public int? Id { get; set; }
        public string? ProductName { get; set; }
        public List<ProductUnitVM>? ProductUnits { get; set; }
    }
}
