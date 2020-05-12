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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Demokratianweb.Controllers
{
    // roa    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class VotacionController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;


        private VotacionRepository _votacionRepository { get; }
        private VotacionService _votacionService { get; }

        private readonly ILogger<VotacionController> _logger;

        public VotacionController(ILogger<VotacionController> logger, UserManager<ApplicationUser> userManager,
            VotacionRepository votacionRepository, VotacionService votacionService

            )
        {
            _logger = logger;
            _userManager = userManager;
            _votacionRepository = votacionRepository;
            _votacionService = votacionService;

        }


        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var entityList = this._votacionRepository.GetAll();
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

                var entity = this._votacionRepository.Get(id);
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
                var entity = this._votacionService.GetAllCandidatosByVotacionId(id);
                return Ok(new { status = true, message = entity });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }
        [HttpGet]
        [Route("{id}/votantes")]
        public ActionResult getVotantes(Guid id)
        {
            try
            {
                var entity = this._votacionService.GetAllVotantesByVotacionId(id);
                return Ok(new { status = true, message = entity });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }


        [HttpPost]
        public ActionResult Post(VotacionWrapper entity)
        {
            try
            {
                var rta = this._votacionService.AddVotacion(entity);
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
                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpPut]
        public ActionResult Put(VotacionEntity entity)
        {
            try
            {
                var response = this._votacionRepository.Update(entity);
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
                var response = this._votacionRepository.Delete(id);
                return Ok(new { status = true, message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = true, message = ex.Message });
            }

        }
    }
}
