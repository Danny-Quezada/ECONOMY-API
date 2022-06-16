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
    public class AnnuityController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetByProjectId(int ProjectId)
        {
            List<AnnuityDTO> annuityDTOs = new List<AnnuityDTO>();
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                List<Annuity> annuityDTO = null;
                annuityDTO = db.Annuity.Where(x =>  x.projectId==ProjectId).ToList();
                annuityDTO.ForEach(x =>
                {
                    AnnuityDTO annuity = new AnnuityDTO()
                    {
                        end = x.end,
                        projectId = x.projectId,
                        flowType = x.flowType,
                        future = x.future,
                        id = x.id,
                        initial = x.initial,
                        payment = x.payment,
                        present = x.present,
                        rate = x.rate,
                        totalPeriod = x.totalPeriod,
                        type=x.type,
                        
                        
                    };
                    
                    annuityDTOs.Add(annuity);
                });
            }


            return Ok(annuityDTOs);
        }
        [HttpPost]
        public IHttpActionResult Add(AnnuityDTO annuityDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                var Annuity= new Models.Annuity();

                Annuity.end = annuityDTO.end;
                Annuity.initial = annuityDTO.initial;
                Annuity.future = annuityDTO.future;
                Annuity.present = annuityDTO.present;
                Annuity.projectId = annuityDTO.projectId;
                Annuity.rate = annuityDTO.rate;
                Annuity.totalPeriod = annuityDTO.totalPeriod;
                Annuity.type = annuityDTO.type;
                Annuity.payment = annuityDTO.payment;
                Annuity.flowType = annuityDTO.flowType;
                
                db.Annuity.Add(Annuity);
                db.SaveChanges();


            }
          
            return Ok("Successfully added record");
        }
    }
}
