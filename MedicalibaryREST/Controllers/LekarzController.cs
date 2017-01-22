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
                Nazwa = e.nazwa,
                Haslo = e.haslo
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
                Nazwa = e.nazwa,
                Haslo = e.haslo
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

            int random = 0;
            Random RNG = new Random();

            var result = db.lekarz.Select(e => new LekarzDTO()
            {
                Id = e.id
            }).ToList();

            List<int> ints = result.Select(e => e.Id).ToList();

            bool isNotInList = true;
            int temp = 0;//RNG.Next();

            while (isNotInList)
            {
                temp = RNG.Next();
                isNotInList = ints.IndexOf(temp) != -1;
                random = temp;
                if(ints.Count==0)
                {
                    isNotInList = true;
                }
            }

            var lekarz = new lekarz()
            {
                id = temp,
                nazwa = viewModel.Nazwa,
                haslo = viewModel.Haslo
            };
            string dane = lekarz.id.ToString() + " " + temp.ToString();

            db.lekarz.Add(lekarz);
            try
            {
                db.SaveChanges();
                return Ok();
            }
            catch
            {
                return Content(HttpStatusCode.PreconditionFailed, dane);
            }
        }

        [HttpPut]
        [Route("zmien/{id:int:min(1)}")]
        public IHttpActionResult Zmien(LekarzNowyDTO viewModel, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            if (!db.lekarz.Any(e => e.id == id))
                return NotFound();


            lekarz result = db.lekarz.FirstOrDefault(e => e.id == id);


            result.nazwa = viewModel.Nazwa;
            result.haslo = viewModel.Haslo;

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

        [HttpDelete]
        [Route("usun/{id:int:min(1)}")]
        public IHttpActionResult usun(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.lekarz.Any(e => e.id == id))
                return NotFound();

            lekarz result = db.lekarz.FirstOrDefault(e => e.id == id);

            db.lekarz.Remove(result);

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
