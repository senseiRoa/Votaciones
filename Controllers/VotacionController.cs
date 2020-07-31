using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Demokratianweb.Data.Entities;
using Demokratianweb.Data.Infraestructure;
using Demokratianweb.Models;
using Demokratianweb.Service;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Demokratianweb.Data.Enums.HelpConstantes;

namespace Demokratianweb.Controllers
{
    // roa    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class VotacionController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RondaVotacionService _rondaVotacionService;

        private VotacionRepository _votacionRepository { get; }
        private VotacionService _votacionService { get; }

        private readonly ILogger<VotacionController> _logger;
        public VotacionController(ILogger<VotacionController> logger, UserManager<ApplicationUser> userManager,
            VotacionRepository votacionRepository, VotacionService votacionService, RondaVotacionService rondaVotacionService

            )
        {
            _logger = logger;
            _userManager = userManager;
            _votacionRepository = votacionRepository;
            _votacionService = votacionService;
            _rondaVotacionService = rondaVotacionService;

        }


        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {

                this._votacionService.UpdateStatus();


                var entityList = this._votacionRepository.GetAll()
                    .OrderByDescending(i => i.fechaCreacion);


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
        [Route("{id}")]
        public ActionResult Put(VotacionEntity entity, Guid id)
        {
            try
            {
                var validation = this._votacionService.validateEntity(entity);
                if (!validation)
                {
                    throw new Exception("Datos incompletos para registrar la Votación");
                }

                entity.Estado = DateTime.Compare(DateTime.Now, entity.fechaInicial) >= 0 && DateTime.Compare(DateTime.Now, entity.fechaFinal) <= 0 ? EstadoVotacion.Abierta : EstadoVotacion.Cerrada;

                var response = this._votacionRepository.Update(id, entity);
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

        [HttpPut]
        [Route("ActualizacionEstado")]
        public ActionResult UpdateStatus()
        {
            try
            {
                var count = this._votacionService.UpdateStatus();
                return Ok(new { status = true, message = $"Se actualizó {count} registro(s)" });
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


        [HttpPost]
        [Route("{id}/reporte")]
        [AllowAnonymous]

        public FileStreamResult GerReporte(Guid id)
        {

            MemoryStream ms = new MemoryStream();

            //get votacion
            var votacion = this._votacionRepository.FindBy(x => x.Id.Equals(id)).FirstOrDefault();
            if (votacion == null)
            {
                throw new Exception("Votación invalida");
            }

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.A4);
            // Indicamos donde vamos a guardar el documento
            //PdfWriter writer = PdfWriter.GetInstance(doc,
            //                            new FileStream(@"Z:\servidor\prueba.pdf", FileMode.Create));

            PdfWriter writer1 = PdfWriter.GetInstance(doc, ms);

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Reporte votacion " + votacion.Descripcion);
            doc.AddCreator("CSJ");

            // Abrimos el archivo
            doc.Open();

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Resultados por ronda para la votación " + votacion.Descripcion));
            doc.Add(Chunk.Newline);
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 8, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            iTextSharp.text.Font _HeaderFont = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12, iTextSharp.text.Font.NORMAL, BaseColor.Blue);



            var rondas = this._votacionService.GetAllRondas(id);
            foreach (var itemRonda in rondas)
            {
                var resultadosRonda = this._rondaVotacionService.Result(itemRonda.Id);

                //Agregando informacion
                doc.Add(Chunk.Newline);
                doc.Add(new Paragraph("Ronda: " + itemRonda.Descripcion));
                doc.Add(new Paragraph("Total votos: " +resultadosRonda.TotalVotos));
                doc.Add(Chunk.Newline);
                // Configuramos el título de las columnas de la tabla
                PdfPTable tablaRonda = new PdfPTable(2);
                tablaRonda.WidthPercentage = 100;

                PdfPCell clCandidato = new PdfPCell(new Phrase("Candidato", _HeaderFont));
                clCandidato.BorderWidth = 0;
                clCandidato.BorderWidthBottom = 0.75f;

                PdfPCell clVoto = new PdfPCell(new Phrase("Votos", _HeaderFont));
                clVoto.BorderWidth = 0;
                clVoto.BorderWidthBottom = 0.75f;

                // Añadimos las celdas a la tabla
                tablaRonda.AddCell(clCandidato);
                tablaRonda.AddCell(clVoto);

               var  clvacia = new PdfPCell(new Phrase("", _standardFont));
                clvacia.BorderWidth = 0;

                tablaRonda.AddCell(clvacia);
                tablaRonda.AddCell(clvacia);

                foreach (var itemResultado in resultadosRonda.resultados)
                {
                    //agregar valores
                    clCandidato = new PdfPCell(new Phrase(itemResultado.candidato, _standardFont));
                    clCandidato.BorderWidth = 0;

                    clVoto = new PdfPCell(new Phrase(itemResultado.votos+"", _standardFont));
                    clVoto.BorderWidth = 0;

                    // Añadimos las celdas a la tabla
                    tablaRonda.AddCell(clCandidato);
                    tablaRonda.AddCell(clVoto);
                }
                //  añadimos la tabla al documento PDF y cerramos el documento
                doc.Add(tablaRonda);

            }
            doc.Close();
            writer1.Close();

            ms.Position = 0;
            return new FileStreamResult(ms, "application/pdf");
        }


    }

}

