using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebEconomyAPI.DTO;
using WebEconomyAPI.Models;

namespace WebEconomyAPI.Controllers
{
    public class SerieController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetByProjectId(int ProjectId)
        {
            List<SerieDTO> SerieDTOs = new List<SerieDTO>();
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                List<Serie> SerieDTO = null;
                SerieDTO = db.Serie.Where(x => x.projectId == ProjectId).ToList();
                SerieDTO.ForEach(x =>
                {
                    SerieDTO SerieDTOO= new SerieDTO()
                    {
                        end = x.end,
                        projectId = x.projectId,
                        flowType = x.flowType,
                        future = x.future,
                        id = x.id,
                        initial = x.initial,
                        downPayment=x.downPayment,
                        finalPayment=x.finalPayment,
                        incremental=x.incremental,
                        quantity=x.quantity,
                        present = x.present,
                        rate = x.rate,
                        totalPeriod = x.totalPeriod,
                        type = x.type,


                    };

                    SerieDTOs.Add(SerieDTOO);
                });
            }


            return Ok(SerieDTOs);
        }
        [HttpPost]
        public IHttpActionResult Add(Serie SerieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                var Serie = new Models.Serie()
                {
                    end = SerieDTO.end,
                    projectId = SerieDTO.projectId,
                    flowType = SerieDTO.flowType,
                    future = SerieDTO.future,
                    id = SerieDTO.id,
                    initial = SerieDTO.initial,
                    downPayment = SerieDTO.downPayment,
                    finalPayment = SerieDTO.finalPayment,
                    incremental = SerieDTO.incremental,
                    quantity = SerieDTO.quantity,
                    present = SerieDTO.present,
                    rate = SerieDTO.rate,
                    totalPeriod = SerieDTO.totalPeriod,
                    type = SerieDTO.type,

                };

                db.Serie.Add(Serie);
                db.SaveChanges();


            }
            return Ok("Successfully added record");
        }
    }
}
