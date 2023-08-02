using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Task.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            var mytask = new HttpClient().GetStringAsync("https://www.google.com"); //GetStringAsync herhangi url'deki datayı string getiriyor

            var data = await mytask;

            return Ok(data);
        }

    }
}
