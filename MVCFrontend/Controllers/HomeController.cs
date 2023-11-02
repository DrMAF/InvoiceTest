using Microsoft.AspNetCore.Mvc;
using MVCFrontend.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.ViewModels.Invoices;
using Core.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;

namespace MVCFrontend.Controllers
{
    //[Authorize]
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

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> InvoicesList()
        {
            var response = await _httpClient.GetAsync($"Invoices/GetInvoices");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error Index: {response.StatusCode}");
            }

            var invoices = await response.Content.ReadFromJsonAsync<IEnumerable<InvoiceVM>>();

            return View(invoices);
        }

        public async Task<IActionResult> CreateInvoice()
        {
            var storeRespons = await _httpClient.GetAsync($"Stores/GetStores");

            if (!storeRespons.IsSuccessStatusCode)
            {
                throw new Exception($"Error CreateInvoice=> GetStores: {storeRespons.StatusCode}");
            }

            var stores = await storeRespons.Content.ReadFromJsonAsync<List<StoreVM>>();

            var storesList = stores?.Select(store => new SelectListItem()
            {
                Text = store.StoreName,
                Value = store.Id.ToString()
            }).ToList();

            storesList?.Insert(0, new SelectListItem()
            {
                Text = "--اختر--",
                Value = "0"
            });

            ViewBag.StoresList = storesList;


            var response = await _httpClient.GetAsync($"Products/GetProducts");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error CreateInvoice=> GetProducts: {response.StatusCode}");
            }

            var products = await response.Content.ReadFromJsonAsync<List<ProductVM>>();

            var productsList = products?.Select(product => new SelectListItem()
            {
                Text = product.ProductName,
                Value = product.Id.ToString()
            }).ToList();

            productsList?.Insert(0, new SelectListItem()
            {
                Text = "--اختر--",
                Value = "0"
            });

            ViewBag.ProductsList = productsList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice(InvoiceVM model)
        {
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
