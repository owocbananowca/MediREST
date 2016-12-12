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
    public class WizytaController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();
        //lista wszystkich
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult Wizyty(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.wizyta.Select(e => new WizytaDTO()
            {
                id = e.id,
                id_lekarz = lid,
                id_pacjent = e.id_pacjent,
                data_wizyty = e.data_wizyty,
                komentarz = e.komentarz
            }
            ).Where(e => e.id_lekarz == lid).ToList();

            List<WizytaWyslijDTO> lista = new List<WizytaWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new WizytaWyslijDTO()
                {
                    id = e.id,
                    id_pacjent = e.id_pacjent,
                    data_wizyty = e.data_wizyty,
                    komentarz = e.komentarz
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }

        //lista pacjenta
        [HttpGet]
        [Route("lista/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult WizytyPacjenta(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.wizyta.Select(e => new WizytaDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_pacjent = e.id_pacjent,
                data_wizyty = e.data_wizyty,
                komentarz = e.komentarz
            }
            ).Where(e => e.id_lekarz == lid && e.id_pacjent == id).ToList();

            List<WizytaWyslijDTO> lista = new List<WizytaWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new WizytaWyslijDTO()
                {
                    id = e.id,
                    id_pacjent = e.id_pacjent,
                    data_wizyty = e.data_wizyty,
                    komentarz = e.komentarz
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //jedna
        [HttpGet]
        [Route("{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Wizyta(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.wizyta.Select(e => new WizytaDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_pacjent = e.id_pacjent,
                data_wizyty = e.data_wizyty,
                komentarz = e.komentarz
            }
            ).Where(e => e.id_lekarz == lid && e.id == id).ToList();

            List<WizytaWyslijDTO> lista = new List<WizytaWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new WizytaWyslijDTO()
                {
                    id = e.id,
                    id_pacjent = e.id_pacjent,
                    data_wizyty = e.data_wizyty,
                    komentarz = e.komentarz
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //post
        [HttpPost]
        [Route("{lid:int:min(1)}/nowa")]
        public IHttpActionResult Nowy(WizytaNowaDTO viewModel, int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (db.wizyta.Any(e => e.data_wizyty == viewModel.data_wizyty))
                return Conflict();

            var wizyta = new wizyta()
            {
                id_pacjent = viewModel.id_pacjent,
                data_wizyty = viewModel.data_wizyty,
                komentarz = viewModel.komentarz
            };

            db.wizyta.Add(wizyta);

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
        //put
        [HttpPut]
        [Route("zmiana/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Zmien(WizytaNowaDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.wizyta.Any(e => e.id == id))
                return NotFound();

            wizyta result = db.wizyta.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            result.data_wizyty = viewModel.data_wizyty;
            result.komentarz = viewModel.komentarz;
            //zmiana pacjenta?

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
        /// <summary>
        /// Dodawanie dodatkowej treści do komentarza
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="lid">Id lekarza</param>
        /// <param name="id">Id wizyty</param>
        /// <returns></returns>
        [HttpPut]
        [Route("dodajkomentarz/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult DodajDoKomentarza(WizytaNowaDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.wizyta.Any(e => e.id == id))
                return NotFound();

            wizyta result = db.wizyta.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            result.komentarz += viewModel.komentarz;

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
