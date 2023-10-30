using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public int UserID
        {
            get
            {
                try
                {
                    if(HttpContext.User.FindFirstValue("Id") == null)
                        return 0;

                    return int.Parse(HttpContext.User.FindFirstValue("Id"));
                }
                catch (Exception ex)
                {
                    //ex.LogError();
                    return 0;
                }
            }
        }
    }
}