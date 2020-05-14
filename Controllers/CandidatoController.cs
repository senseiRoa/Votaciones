using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Demokratianweb.Data.Entities;
using Demokratianweb.Data.Infraestructure;
using Demokratianweb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demokratianweb.Controllers
{
    // [Authorize(Roles = "Admin,Moderador")]
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;


        private readonly CandidatoRepository _entityRepository;

        private readonly ILogger<CandidatoController> _logger;

        public CandidatoController(ILogger<CandidatoController> logger, UserManager<ApplicationUser> userManager,
            CandidatoRepository entityRepository

            )
        {
            _logger = logger;
            _userManager = userManager;
            _entityRepository = entityRepository;

        }


        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var entityList = this._entityRepository.GetAll()
                    .OrderBy(i => i.Nombre);
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



        [HttpPost]
        public ActionResult Post(CandidatoEntity entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                var response = this._entityRepository.Insert(entity);
                if (response)
                {
                    return Ok(new { status = true, message = entity });
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
        public ActionResult Put(CandidatoEntity entity)
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
