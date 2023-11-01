using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Domain;
using Core.Interfaces.Services;
using Core.ViewModels.Products;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        readonly IBaseService<Product> _productService;
        readonly IBaseService<ProductUnit> _productUnitService;

        public ProductsController(IBaseService<Product> productService, IBaseService<ProductUnit> productUnitService)
        {
            _productService = productService;
            _productUnitService = productUnitService;
        }

        [AllowAnonymous]
        [HttpGet("GetProducts")]
        public IActionResult GetProducts(int? id)
        {
            try
            {
                IEnumerable<Product> products;
                List<ProductVM> productsVM = new List<ProductVM>();
                List<string> includes = new List<string> { "ProductUnits" , "ProductUnits.Unit" };

                if (id.HasValue && id.Value > 0)
                {
                    products = _productService.Get(prod => prod.Id == id.Value, includes);
                }
                else
                {
                    products = _productService.GetAll(includes);
                }

                productsVM = products.Select(prod => new ProductVM
                {
                    Id = prod.Id,
                    ProductName = prod.NameAr,
                    ProductUnits = prod.ProductUnits?.Select(prodUnt => new ProductUnitVM
                    {
                        Id = prodUnt.Id,
                        ProductId = prodUnt.ProductId,
                        UnitId = prodUnt.UnitId,
                        ProductName = prod.NameAr,
                        UnitName = prodUnt.Unit?.NameAr,
                        Price = prodUnt.Price
                    }).ToList(),

                }).ToList();

                return Ok(productsVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetProductUnits")]
        public IActionResult GetProductUnits(int? id, int? productId)
        {
            try
            {
                IEnumerable<ProductUnit> productUnits;
                List<ProductUnitVM> productUnitsVM = new List<ProductUnitVM>();
                List<string> includes = new List<string> { "Product", "Unit" };

                if (id.HasValue && id.Value > 0)
                {
                    productUnits = _productUnitService.Get(prodUnt => prodUnt.Id == id, includes);
                }
                else if (productId.HasValue && productId.Value > 0)
                {
                    productUnits = _productUnitService.Get(prodUnt => prodUnt.ProductId == productId, includes).ToList();
                }
                else
                {
                    productUnits = _productUnitService.GetAll(includes);
                }

                productUnitsVM = productUnits.Select(prodUnt => new ProductUnitVM
                {
                    Id = prodUnt.Id,
                    ProductId = prodUnt.ProductId,
                    UnitId = prodUnt.UnitId,
                    ProductName = prodUnt.Product?.NameAr,
                    UnitName= prodUnt.Unit?.NameAr,
                    Price = prodUnt.Price
                }).ToList();

                return Ok(productUnitsVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}