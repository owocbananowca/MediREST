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
    [RoutePrefix("lekarz")]
    public class LekarzController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();

        [HttpGet]
        [Route("lista")]
        public IHttpActionResult Lekarze()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.lekarz.Select(e => new LekarzDTO()
            {
                Id = e.id,
                Nazwa = e.nazwa
            }
            ).ToList();

            if (result == null)
                return NotFound();

            JsonConvert.SerializeObject(result);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        public IHttpActionResult Lekarz(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.lekarz.Select(e => new LekarzDTO()
            {
                Id = e.id,
                Nazwa = e.nazwa
            }).Where(e => e.Id == id).ToList();

            if (result == null)
                return NotFound();

            JsonConvert.SerializeObject(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("nowy")]
        public IHttpActionResult Nowy(LekarzNowyDTO viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (db.lekarz.Any(e => e.nazwa == viewModel.Nazwa))
                return Conflict();

            var lekarz = new lekarz()
            { 
                nazwa = viewModel.Nazwa
            };

            db.lekarz.Add(lekarz);

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

        [HttpPut]
        [Route("zmien")]
        public IHttpActionResult Zmien(LekarzNowyDTO viewModel, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!db.lekarz.Any(e => e.id == id))
                return NotFound();


            lekarz result = db.lekarz.FirstOrDefault(e => e.id == id);


            result.nazwa = viewModel.Nazwa;

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
