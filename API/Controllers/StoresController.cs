using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Domain;
using Core.Interfaces.Services;
using Core.ViewModels.Invoices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : BaseController
    {
        readonly IBaseService<Store> _storeService;

        public StoresController(IBaseService<Store> storeService)
        {
            _storeService = storeService;
        }

        [AllowAnonymous]
        [HttpGet("GetStores")]
        public IActionResult GetStores()
        {
            try
            {
                return Ok(_storeService.GetAll().Select(st =>
                new StoreVM
                {
                    Id = st.Id,
                    StoreName = st.NameAr,
                    Location = st.Location
                }).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}