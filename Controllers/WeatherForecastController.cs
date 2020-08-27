using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Demokratianweb.HubRT;
using Demokratianweb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;


namespace Demokratianweb.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            UserManager<ApplicationUser> userManager,
            IHubContext<NotifyHub, ITypedHubClient> hubContext

            )
        {
            _logger = logger;
            _userManager = userManager;
            this._hubContext = hubContext;

        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            // var info = User.Identity.Name;
            // var roles = User.Claims.Where(i => i.Type == ClaimTypes.Role).ToList();
            //var x = _userManager.GetUserId(User);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userId2 = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var x2 = await _userManager.FindByIdAsync(userId);


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => rng.Next(-20, 55).ToString())
            .ToArray();
        }

        [HttpPost]
        public string Post([FromBody]Message msg)
        {
            string retMessage = string.Empty;
            try
            {
                _hubContext.Clients.All.NotificarNuevaRonda(msg);

                msg.rondaId = Guid.NewGuid().ToString();
                _hubContext.Clients.All.NotificarVoto(msg);
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}
