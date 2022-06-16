using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebEconomyAPI.DTO;

namespace WebEconomyAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetUser(UserDTO userDTO)
        {
            UserDTO User = null;

            using (WebEconomyAPI.Models.EconomyEntities db = new WebEconomyAPI.Models.EconomyEntities())
            {
                User = db.User.Where(x => x.email.Equals(userDTO.email) && x.password.Equals(userDTO.password)).Select(x => new UserDTO()
                {
                    id = x.id,
                    email = x.email,
                    name = x.name,
                    password = x.password,
                    phone = x.phone,
                    Project = (ICollection<ProjectDTO>)x.Project,
                }).FirstOrDefault();

            }

            if (User == null)
                return NotFound();
            return Ok(User);
        }
        [HttpPost]
        public IHttpActionResult Add(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (WebEconomyAPI.Models.EconomyEntities db = new Models.EconomyEntities())
            {
                var UserDTOO = new Models.User();
                UserDTOO.email = userDTO.email;
                UserDTOO.name = userDTO.name;
                UserDTOO.phone = userDTO.phone;
           //     UserDTOO.Project = (ICollection<Models.Project>)userDTO.Project;
                UserDTOO.password = userDTO.password;
                db.User.Add(UserDTOO);
                db.SaveChanges();

                
            }
            return Ok("Successfully added record");
        }

    }
}
