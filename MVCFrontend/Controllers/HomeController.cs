using Core.ViewModels.Responses.Invoices;
using Microsoft.AspNetCore.Mvc;
using MVCFrontend.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;

namespace MVCFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7018/api/") };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"Invoices/GetInvoices");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error Index: {response.StatusCode}");
            }

            var invoices = await response.Content.ReadFromJsonAsync<IEnumerable<InvoiceVM>>();

            return View(invoices);
        }

        public IActionResult CreateInvoice()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(InvoiceVM model)
        {
            model = new InvoiceVM
            {
                StoreId = 1,
                Date = DateTime.Now,
                TaxPercent = 10,
                Items = new List<InvoiceItemVM> { new InvoiceItemVM { ProductUnitId = 1, Price = 200, Quantity = 3, Discount = 3 } },
                TotalDiscount = 20
            };

            var modelJson = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, Application.Json);

            var response = await _httpClient.PostAsync($"Invoices/AddInvoice", modelJson);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error CreateInvoice: {response.StatusCode}");
            }

            var invoiceId = await response.Content.ReadFromJsonAsync<int>();

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
