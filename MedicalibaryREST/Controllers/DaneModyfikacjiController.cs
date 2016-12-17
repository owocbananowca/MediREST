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
    [RoutePrefix("danemodyfikacji")]
    public class DaneModyfikacjiController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();

        // wszystkie lekarza
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult DaneModyfikacji(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.dane_modyfikacji.Select(e => new DaneModyfikacjiDTO()
            {
                id = e.id,
                id_modyfikacja = e.id_modyfikacja,
                id_lekarz = e.id_lekarz,
                nazwa_danej = e.nazwa_danej,
                stara_wartosc = e.stara_wartosc,
                nowa_wartosc = e.nowa_wartosc
            }
            ).Where(e => e.id_lekarz == lid).ToList();

            List<DaneModyfikacjiWyslijDTO> lista = new List<DaneModyfikacjiWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new DaneModyfikacjiWyslijDTO()
                {
                    id = e.id,
                    id_modyfikacja = e.id_modyfikacja,
                    nazwa_danej = e.nazwa_danej,
                    stara_wartosc = e.stara_wartosc,
                    nowa_wartosc = e.nowa_wartosc
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        // wszystkie dla modyfikacji
        [HttpGet]
        [Route("lista/{lid:int:min(1)}/{mid:int:min(1)}")]
        public IHttpActionResult DaneDlaModyfikacji(int lid, int mid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.dane_modyfikacji.Select(e => new DaneModyfikacjiDTO()
            {
                id = e.id,
                id_modyfikacja = e.id_modyfikacja,
                id_lekarz = e.id_lekarz,
                nazwa_danej = e.nazwa_danej,
                stara_wartosc = e.stara_wartosc,
                nowa_wartosc = e.nowa_wartosc
            }
            ).Where(e => e.id_lekarz == lid && e.id_modyfikacja == mid).ToList();

            List<DaneModyfikacjiWyslijDTO> lista = new List<DaneModyfikacjiWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new DaneModyfikacjiWyslijDTO()
                {
                    id = e.id,
                    id_modyfikacja = e.id_modyfikacja,
                    nazwa_danej = e.nazwa_danej,
                    stara_wartosc = e.stara_wartosc,
                    nowa_wartosc = e.nowa_wartosc
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        // jedno o id
        [HttpGet]
        [Route("{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Modyfikacja(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.dane_modyfikacji.Select(e => new DaneModyfikacjiDTO()
            {
                id = e.id,
                id_modyfikacja = e.id_modyfikacja,
                id_lekarz = e.id_lekarz,
                nazwa_danej = e.nazwa_danej,
                stara_wartosc = e.stara_wartosc,
                nowa_wartosc = e.nowa_wartosc
            }
            ).Where(e => e.id_lekarz == lid && e.id == id).ToList();

            List<DaneModyfikacjiWyslijDTO> lista = new List<DaneModyfikacjiWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new DaneModyfikacjiWyslijDTO()
                {
                    id = e.id,
                    id_modyfikacja = e.id_modyfikacja,
                    nazwa_danej = e.nazwa_danej,
                    stara_wartosc = e.stara_wartosc,
                    nowa_wartosc = e.nowa_wartosc
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        // post
        [HttpPost]
        [Route("{lid:int:min(1)}/nowy")]
        public IHttpActionResult Nowy(DaneModyfikacjiNoweDTO e2, int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //if (!db.modyfikacja.Any(e => e.id == e2.id_modyfikacja))
            //    return Conflict();

            var daneMod = new dane_modyfikacji()
            {
                id_modyfikacja = e2.id_modyfikacja,
                id_lekarz = lid,
                nazwa_danej = e2.nazwa_danej,
                stara_wartosc = e2.stara_wartosc,
                nowa_wartosc = e2.nowa_wartosc
            };

            db.dane_modyfikacji.Add(daneMod);

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
        // put
        [HttpPut]
        [Route("zmiana/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Zmien(DaneModyfikacjiNoweDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.dane_modyfikacji.Any(e => e.id == id))
                return NotFound();

            dane_modyfikacji result = db.dane_modyfikacji.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            result.id_modyfikacja = viewModel.id_modyfikacja;
            result.nazwa_danej = viewModel.nazwa_danej;
            result.stara_wartosc = viewModel.stara_wartosc;
            result.nowa_wartosc = viewModel.nowa_wartosc;

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

            if (!db.dane_modyfikacji.Any(e => e.id == id))
                return NotFound();

            dane_modyfikacji result = db.dane_modyfikacji.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            db.dane_modyfikacji.Remove(result);
            
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
