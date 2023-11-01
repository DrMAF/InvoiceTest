using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Domain;
using Core.Interfaces.Services;
using Core.ViewModels.Invoices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : BaseController
    {
        readonly IBaseService<Invoice> _invoiceService;
        readonly IBaseService<InvoiceItem> _invoiceItemService;
        readonly IBaseService<ProductUnit> _productUnitService;
        readonly IBaseService<Unit> _unitService;
        readonly IBaseService<Product> _productService;

        public InvoicesController(IBaseService<Invoice> invoiceService, IBaseService<InvoiceItem> invoiceItemService,
        IBaseService<Product> productService, IBaseService<Unit> unitService, IBaseService<ProductUnit> productUnitService)
        {
            _invoiceService = invoiceService;
            _invoiceItemService = invoiceItemService;
            _productUnitService = productUnitService;
            _unitService = unitService;
            _productService = productService;
        }

        [AllowAnonymous]
        [HttpGet("GetInvoices")]
        public IActionResult GetInvoices(int? id, int? productId)
        {
            try
            {
                IEnumerable<Invoice> invoices;
                List<InvoiceVM> invoicesVM = new List<InvoiceVM>();
                List<string> includes = new List<string> { "Store", "InvoiceItems", "InvoiceItems.ProductUnit", "InvoiceItems.ProductUnit.Unit", "InvoiceItems.ProductUnit.Product" };

                if (id.HasValue && id.Value > 0)
                {
                    invoices = _invoiceService.Get(inv => inv.Id == id.Value, includes);
                }
                else if (productId.HasValue && productId.Value > 0)
                {
                    invoices = _invoiceService.Get(inv => inv.InvoiceItems != null && inv.InvoiceItems.Any(item => item.ProductUnit != null && item.ProductUnit.ProductId == productId), includes);
                }
                else
                {
                    invoices = _invoiceService.GetAll(includes);
                }

                invoicesVM = invoices.Select(inv => new InvoiceVM
                {
                    Id = inv.Id,
                    StoreId = inv.StoreId,
                    StoreName = inv.Store?.NameAr,
                    TotalDiscount = inv.TotalDiscount,
                    Total = inv.Total,
                    TaxPercent = inv.TaxPercent,
                    Net = inv.Net,
                    Date = inv.Date,
                    Items = inv.InvoiceItems?.Select(invItm => new InvoiceItemVM
                    {
                        Id = invItm.Id,
                        InvoiceId = inv.Id,
                        ProductId = invItm.ProductUnit?.ProductId,
                        UnitId = invItm.ProductUnit?.UnitId,
                        ProductName = invItm.ProductUnit?.Product?.NameAr,
                        UnitName = invItm.ProductUnit?.Unit?.NameAr,
                        Price = invItm.Price,
                        Quantity = invItm.Quantity,
                        Total = invItm.Total,
                        Discount = invItm.Discount,
                        Net = invItm.Net,
                    }).ToList()
                }).ToList();

                return Ok(invoicesVM);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("AddInvoice")]
        public IActionResult AddInvoice([FromBody] InvoiceVM model)
        {
            try
            {
                var invoice = new Invoice
                {
                    StoreId = model.StoreId,
                    Date = model.Date,
                    TaxPercent = model.TaxPercent,
                    CreatorId = UserId
                };

                var invId = _invoiceService.Add(invoice);

                decimal totalDiscount = 0;
                decimal net = 0;

                if (model.Items != null && model.Items.Any())
                {
                    foreach (var item in model.Items)
                    {
                        var invoiceItem = new InvoiceItem
                        {
                            InvoiceId = invId,
                            ProductUnitId = item.ProductUnitId.Value,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            Total = item.Quantity * item.Price,
                            Discount = item.Discount,
                            Net = (item.Quantity * item.Price) - (item.Discount.HasValue ? item.Discount.Value : 0)
                        };

                        int invoiceItemId = _invoiceItemService.Add(invoiceItem);

                        totalDiscount += invoiceItem.Discount.HasValue ? invoiceItem.Discount.Value : 0;
                        net += invoiceItem.Net.HasValue ? invoiceItem.Net.Value : 0;
                    }
                }

                invoice.TotalDiscount = totalDiscount;
                invoice.Total = net;
                invoice.Net = ((invoice.TaxPercent / 100) * invoice.Total) + invoice.Total;

                _invoiceService.Update(invoice);

                return Ok(invId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}