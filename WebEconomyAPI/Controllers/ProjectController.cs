using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebEconomyAPI.DTO;
using WebEconomyAPI.Models;

namespace WebEconomyAPI.Controllers
{
    public class ProjectController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetByUserId(int UserId)
        {
            List<ProjectDTO> projects = new List<ProjectDTO>();
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                List<Project> projectsOrg = null;
                projectsOrg = db.Project.Where(x => x.userId == UserId).ToList();
                projectsOrg.ForEach(x =>
                {
                    ProjectDTO projectDTO = new ProjectDTO();
                    projectDTO.userId = x.userId;
                    projectDTO.id = x.id;

                    projectDTO.name = x.name;
                    projectDTO.creation = x.creation;
                    projectDTO.type = x.type;

                    projects.Add(projectDTO);
                });
            }

            if (projects.Count == 0)
            {
                return Ok("{you don't have projects}");
            }

            return Ok(projects);
        }
        [HttpPost]
        public IHttpActionResult Add(ProjectDTO projectDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                var Project =new Models.Project();

                Project.creation = projectDTO.creation;
                Project.name = projectDTO.name;
                Project.type=projectDTO.type;
                Project.userId = projectDTO.userId;
                
                db.Project.Add(Project);
                db.SaveChanges();


            }
            return Ok("Successfully added record");
        }
    }
}
