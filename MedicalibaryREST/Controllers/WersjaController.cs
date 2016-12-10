using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicalibaryREST.Models;
using MedicalibaryREST.DTO;
using Newtonsoft.Json;

namespace MedicalibaryREST.Controllers
{
    [RoutePrefix("wersja")]
    public class WersjaController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();

        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult wersje(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.wersja.Select(e => new WersjaDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz
            }
            ).Where(e=> e.id_lekarz == lid).ToList();

            List<WersjaWyslij> list = new List<WersjaWyslij>();

            foreach (var e in result)
            {
                list.Add(new WersjaWyslij()
                {
                    id = e.id
                });
            }

            if (list == null)
                return NotFound();

            JsonConvert.SerializeObject(list);
            return Ok(list);
        }
        //post
        [HttpPost]
        [Route("{lid:int:min(1)}/nowa")]
        public IHttpActionResult Nowy(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var wersja = new wersja()
            {
                id_lekarz = lid
            };

            db.wersja.Add(wersja);

            try
            {
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return Content(HttpStatusCode.PreconditionFailed, "");
            }
        }
    }
}
