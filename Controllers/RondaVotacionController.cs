using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Demokratianweb.Data.Entities;
using Demokratianweb.Data.Infraestructure;
using Demokratianweb.Models;
using Demokratianweb.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Demokratianweb.Controllers
{
    // roa    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RondaVotacionController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private RondaVotacionRepository _entityRepository { get; }
        private RondaVotacionService _rondaVotacionService { get; }

        private readonly ILogger<RondaVotacionController> _logger;

        public RondaVotacionController(ILogger<RondaVotacionController> logger, UserManager<ApplicationUser> userManager,
            RondaVotacionRepository entityRepository, RondaVotacionService rondaVotacionService
            )
        {
            _logger = logger;
            _userManager = userManager;
            _entityRepository = entityRepository;
            _rondaVotacionService = rondaVotacionService;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var entityList = this._entityRepository.GetAll();
                return Ok(new { status = true, message = entityList });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var entity = this._entityRepository.Get(id);
                return Ok(new { status = true, message = entity });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpGet]
        [Route("votacion/{id}")]
        public ActionResult GetAllByVotacionId(Guid id)
        {
            try
            {
                var entity = this._entityRepository
                    .FindBy(i => i.IdVotacion.Equals(id))
                    .OrderByDescending(i => i.fechaCreacion)
                    .ToList();

                return Ok(new { status = true, message = entity });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpGet]
        [Route("{id}/candidatos")]
        public ActionResult GetCandidatos(Guid id)
        {
            try
            {
                var entity = this._rondaVotacionService.GetAllCandidatosByRondaId(id);
                return Ok(new { status = true, message = entity });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpGet]
        [Route("{id}/resultados")]
        public ActionResult GetResultado(Guid id)
        {
            try
            {
                var resultados = this._rondaVotacionService.Result(id);
                return Ok(new { status = true, message = resultados });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult Post(RondaVotacionWrapper entity)
        {
            try
            {
                this._logger.LogInformation("se va a registrar una ronda " + JsonConvert.SerializeObject(entity));
                var rta = this._rondaVotacionService.AddRondaVotacion(entity);

                if (rta)
                {
                    return Ok(new { status = true, message = rta });
                }
                else
                {
                    return BadRequest(new { status = false, message = "Error creando el objeto" });
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error registrando una ronda->" + ex.Message);
                return BadRequest(new { status = true, message = ex.Message });
            }

        }


        [HttpPost]
        [Route("voto")]
        public ActionResult PostVoto(VotoWrapper entity)
        {
            try
            {
                this._logger.LogInformation("se va a registrar un voto " + JsonConvert.SerializeObject(entity));
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var rta = this._rondaVotacionService.AddVoto(entity, Guid.Parse(userId));
                if (rta)
                {
                    return Ok(new { status = true, message = rta });
                }
                else
                {
                    return BadRequest(new { status = false, message = "Error creando el objeto" });
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error registrando un voto-> " + ex.Message);
                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpPut]
        public ActionResult Put(RondaVotacionEntity entity)
        {
            try
            {
                var response = this._entityRepository.Update(entity);
                if (response)
                {
                    return Ok(new { status = true, message = entity });
                }
                else
                {
                    return BadRequest(new { status = false, message = "Error actualizando el objeto" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var response = this._entityRepository.Delete(id);
                return Ok(new { status = true, message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = true, message = ex.Message });
            }

        }
    }
}
