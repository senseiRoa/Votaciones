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
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Demokratianweb.Service;
using System.Text.Encodings.Web;

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


        private readonly IEmailSender _emailSender;
        private readonly IHostingEnvironment _env;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            UserManager<ApplicationUser> userManager,
            IHubContext<NotifyHub, ITypedHubClient> hubContext,
            IEmailSender emailSender, IHostingEnvironment env

            )
        {
            _logger = logger;
            _userManager = userManager;
            this._hubContext = hubContext;
            _emailSender = emailSender;
            _env = env;
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
        [Route("testPush")]
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

        [HttpPost]
        [Route("{id}/sendMailForgotPassword")]
        public async Task<List<string>> Post([FromBody]List<string> emails, Guid id)
        {
            this._logger.LogInformation("envio masivo recuperacion de contraseña");
            if (!id.Equals(Guid.Parse("0935dfb5-f1c0-4f4e-b297-e3e1a7714673")))
            {
                return null;
            }
            string retMessage = string.Empty;
            List<string> result = new List<string>();

            try
            {
                foreach (var item in emails)
                {
                    var user = await _userManager.FindByEmailAsync(item);
                    if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        result.Add($"{item} no se encuentra o hubo un error");


                    }
                    else
                    {
                        this._logger.LogInformation("forgot password to " + item);
                        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page("/Account/ResetPassword", pageHandler: null, values: new { area = "Identity", code }, protocol: Request.Scheme);

                        var htmlText = LoadHtmlTemplate.loadtemplate(this._env.WebRootPath, HtmlTemplate.ForgotPassword);

                        htmlText = htmlText
                            .Replace("{link}", HtmlEncoder.Default.Encode(callbackUrl))
                            .Replace("{user}", user.UserName);


                        await _emailSender.SendEmailAsync(item, "Recuperación de Contraseña Demokratian Web", htmlText);
                    }
                }
            }
            catch (Exception e)
            {
                result.Add(e.ToString());
            }
            return result;
        }
    }
}
