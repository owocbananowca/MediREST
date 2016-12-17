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
    [RoutePrefix("parametr")]
    public class ParametrController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();
        //lista wszystkich
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult Parametry(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.parametr.Select(e => new ParametrDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                nazwa = e.nazwa,
                typ = e.typ,
                wartosc_domyslna = e.wartosc_domyslna
            }).Where(e => e.id_lekarz == lid).ToList();

            List<ParametrNowyWyslij> lista = new List<ParametrNowyWyslij>();

            foreach (var e in result)
            {
                lista.Add(new ParametrNowyWyslij()
                {
                    id = e.id,
                    nazwa = e.nazwa,
                    typ = e.typ,
                    wartosc_domyslna = e.wartosc_domyslna
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //jeden
        [HttpGet]
        [Route("{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Parametr(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.parametr.Select(e => new ParametrDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                nazwa = e.nazwa,
                typ = e.typ,
                wartosc_domyslna = e.wartosc_domyslna
            }).Where(e => e.id_lekarz == lid && e.id == id).ToList();

            List<ParametrNowyWyslij> lista = new List<ParametrNowyWyslij>();

            foreach (var e in result)
            {
                lista.Add(new ParametrNowyWyslij()
                {
                    id = e.id,
                    nazwa = e.nazwa,
                    typ = e.typ,
                    wartosc_domyslna = e.wartosc_domyslna
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //dodaj
        [HttpPost]
        [Route("{lid:int:min(1)}/nowy")]
        public IHttpActionResult Nowy(ParametrNowyDTO viewModel, int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            /*
            if (db.pacjent.Any(e => e.pesel == viewModel.pesel))
                return Conflict();
            */
            var parametr = new parametr()
            {
                id_lekarz = viewModel.id_lekarz,
                nazwa = viewModel.nazwa,
                typ = viewModel.typ,
                wartosc_domyslna = viewModel.wartosc_domyslna
            };

            db.parametr.Add(parametr);

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
        //zmien
        [HttpPut]
        [Route("zmiana/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Zmien(ParametrNowyDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.parametr.Any(e => e.id == id))
                return NotFound();

            parametr parametr = db.parametr.FirstOrDefault(e=>e.id == id && e.id_lekarz == lid);

            parametr.nazwa = viewModel.nazwa;
            parametr.typ = viewModel.typ;
            parametr.wartosc_domyslna = viewModel.wartosc_domyslna;

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
        [Route("usun/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult usun(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.parametr.Any(e => e.id == id))
                return NotFound();

            parametr result = db.parametr.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            db.parametr.Remove(result);

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
