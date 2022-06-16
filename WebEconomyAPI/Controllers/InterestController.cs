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
    public class InterestController : ApiController
    {

        [HttpGet]
        public IHttpActionResult GetByProjectId(int ProjectId)
        {
            List<InterestDTO> InterestDTOs = new List<InterestDTO>();
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                List<Interest> InterestDTO = null;
                InterestDTO = db.Interest.Where(x => x.projectId == ProjectId).ToList();
                InterestDTO.ForEach(x =>
                {
                    InterestDTO interest = new InterestDTO()
                    {
                        end = x.end,
                        projectId = x.projectId,
                        flowType = x.flowType,
                        future = x.future,
                        id = x.id,
                        initial = x.initial,
                        present = x.present,
                        rate = x.rate,
                        totalPeriod = x.totalPeriod,
                        

                    };

                    InterestDTOs.Add(interest);
                });
            }


            return Ok(InterestDTOs);
        }
        [HttpPost]
        public IHttpActionResult Add(InterestDTO InterestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                var interest = new Models.Interest()
                {
                    end = InterestDTO.end,
                    projectId = InterestDTO.projectId,
                    flowType = InterestDTO.flowType,
                    future = InterestDTO.future,
                    id = InterestDTO.id,
                    initial = InterestDTO.initial,

                    present = InterestDTO.present,
                    rate = InterestDTO.rate,
                    totalPeriod = InterestDTO.totalPeriod,


                };

                db.Interest.Add(interest);
                db.SaveChanges();


            }
            return Ok("Successfully added record");
        }
    }
}
