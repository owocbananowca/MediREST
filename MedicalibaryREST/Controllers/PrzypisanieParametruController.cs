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
    [RoutePrefix("przypisanie")]
    public class PrzypisanieParametruController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();
        // wszystkie lekarz
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult przypisania(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.przypisanie_parametru.Select(e => new Przypisanie_ParametruDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_pacjent = e.id_pacjent,
                id_parametr = e.id_parametr,
                wartosc = e.wartosc
            }).Where(e => e.id_lekarz == lid).ToList();

            List<Przypisanie_ParametruWyslijDTO> lista = new List<Przypisanie_ParametruWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new Przypisanie_ParametruWyslijDTO()
                {
                    id = e.id,
                    id_pacjent = e.id_pacjent,
                    id_parametr = e.id_parametr,
                    wartosc = e.wartosc
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        // wszystkie pacjent
        [HttpGet]
        [Route("listapopacjencie/{lid:int:min(1)}/{pid:int:min(1)}")]
        public IHttpActionResult przypisaniaPacjenta(int lid, int pid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.przypisanie_parametru.Select(e => new Przypisanie_ParametruDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_pacjent = e.id_pacjent,
                id_parametr = e.id_parametr,
                wartosc = e.wartosc
            }).Where(e => e.id_lekarz == lid && e.id_pacjent == pid).ToList();

            List<Przypisanie_ParametruWyslijDTO> lista = new List<Przypisanie_ParametruWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new Przypisanie_ParametruWyslijDTO()
                {
                    id = e.id,
                    id_pacjent = e.id_pacjent,
                    id_parametr = e.id_parametr,
                    wartosc = e.wartosc
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //o id
        [HttpGet]
        [Route("listapoid/{lid:int:min(1)}/{iid:int:min(1)}")]
        public IHttpActionResult przypisanie(int lid, int iid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.przypisanie_parametru.Select(e => new Przypisanie_ParametruDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_pacjent = e.id_pacjent,
                id_parametr = e.id_parametr,
                wartosc = e.wartosc
            }).Where(e => e.id_lekarz == lid && e.id == iid).ToList();

            List<Przypisanie_ParametruWyslijDTO> lista = new List<Przypisanie_ParametruWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new Przypisanie_ParametruWyslijDTO()
                {
                    id = e.id,
                    id_pacjent = e.id_pacjent,
                    id_parametr = e.id_parametr,
                    wartosc = e.wartosc
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        // dodaj
        [HttpPost]
        [Route("{lid:int:min(1)}/nowy")]
        public IHttpActionResult Nowy(Przypisanie_ParametruNowyDTO viewModel, int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var parametrprzypis = new przypisanie_parametru()
            {
                id_lekarz = lid,
                id_pacjent = viewModel.id_pacjent,
                id_parametr = viewModel.id_parametr,
                wartosc = viewModel.wartosc
            };

            db.przypisanie_parametru.Add(parametrprzypis);

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
        // zmien wartosc po id
        [HttpPut]
        [Route("zmiana/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Zmien(Przypisanie_ParametruNowyDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.przypisanie_parametru.Any(e => e.id == id))
                return NotFound();

            przypisanie_parametru list = db.przypisanie_parametru.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            list.wartosc = viewModel.wartosc;
            list.id_pacjent = viewModel.id_pacjent;
            list.id_parametr = viewModel.id_parametr;

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

            przypisanie_parametru result = db.przypisanie_parametru.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            db.przypisanie_parametru.Remove(result);

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
