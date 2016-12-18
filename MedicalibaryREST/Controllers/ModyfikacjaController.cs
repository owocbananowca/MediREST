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
    [RoutePrefix("modyfikacja")]
    public class ModyfikacjaController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();

        // wszystkie lekarza
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult modyfikacjeLekarza(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.modyfikacja.Select(e => new ModyfikacjaDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_wersji = e.id_wersji,
                id_obiekt = e.id_obiekt,
                obiekt = e.obiekt,
                operaca = e.operaca
            }
            ).Where(e => e.id_lekarz == lid).ToList();

            List<ModyfikacjaWyslijDTO> list = new List<ModyfikacjaWyslijDTO>();

            foreach (var e in result)
            {
                list.Add(new ModyfikacjaWyslijDTO()
                {
                    id = e.id,
                    id_wersji = e.id_wersji,
                    id_obiekt = e.id_obiekt,
                    obiekt = e.obiekt,
                    operaca = e.operaca
                });
            }

            if (list == null)
                return NotFound();

            JsonConvert.SerializeObject(list);
            return Ok(list);
        }
        // wszystkie wersji
        [HttpGet]
        [Route("lista/{lid:int:min(1)}/wersja/{wid:int:min(1)}")]
        public IHttpActionResult modyfikacjeWersji(int lid, int wid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // Może coś nie pasować nam tutaj
            if (!db.modyfikacja.Any(e => e.id_wersji >= wid))
                return NotFound();

            var result = db.modyfikacja.Select(e => new ModyfikacjaDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_wersji = e.id_wersji,
                id_obiekt = e.id_obiekt,
                obiekt = e.obiekt,
                operaca = e.operaca
            }
            ).Where(e => e.id_lekarz == lid && e.id_wersji == wid).ToList();

            List<ModyfikacjaWyslijDTO> list = new List<ModyfikacjaWyslijDTO>();

            foreach (var e in result)
            {
                list.Add(new ModyfikacjaWyslijDTO()
                {
                    id = e.id,
                    id_wersji = e.id_wersji,
                    id_obiekt = e.id_obiekt,
                    obiekt = e.obiekt,
                    operaca = e.operaca
                });
            }

            if (list == null)
                return NotFound();

            JsonConvert.SerializeObject(list);
            return Ok(list);
        }
        // wszystkie do wersji (włącznie)
        [HttpGet]
        [Route("lista/{lid:int:min(1)}/{wid:int:min(1)}")]
        public IHttpActionResult modyfikacjeWersje(int lid, int wid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // Może coś nie pasować nam tutaj
            if (!db.modyfikacja.Any(e => e.id_wersji >= wid))
                return NotFound();
            // pobieramy wszystkie o wersji >= do zażądanej 
            var result = db.modyfikacja.Select(e => new ModyfikacjaDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_wersji = e.id_wersji,
                id_obiekt = e.id_obiekt,
                obiekt = e.obiekt,
                operaca = e.operaca
            }
            ).Where(e => e.id_lekarz == lid && e.id_wersji >= wid).ToList();

            List<ModyfikacjaWyslijDTO> list = new List<ModyfikacjaWyslijDTO>();

            foreach (var e in result)
            {
                list.Add(new ModyfikacjaWyslijDTO()
                {
                    id = e.id,
                    id_wersji = e.id_wersji,
                    id_obiekt = e.id_obiekt,
                    obiekt = e.obiekt,
                    operaca = e.operaca
                });
            }

            if (list == null)
                return NotFound();

            JsonConvert.SerializeObject(list);
            return Ok(list);
        }
        // o id
        [HttpGet]
        [Route("{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult modyfikacja(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            if (!db.modyfikacja.Any(e => e.id == id))
                return NotFound();

            var result = db.modyfikacja.Select(e => new ModyfikacjaDTO()
            {
                id = e.id,
                id_lekarz = e.id_lekarz,
                id_wersji = e.id_wersji,
                id_obiekt = e.id_obiekt,
                obiekt = e.obiekt,
                operaca = e.operaca
            }
            ).Where(e => e.id_lekarz == lid && e.id == id).ToList();

            List<ModyfikacjaWyslijDTO> list = new List<ModyfikacjaWyslijDTO>();

            foreach (var e in result)
            {
                list.Add(new ModyfikacjaWyslijDTO()
                {
                    id = e.id,
                    id_wersji = e.id_wersji,
                    id_obiekt = e.id_obiekt,
                    obiekt = e.obiekt,
                    operaca = e.operaca
                });
            }

            if (list == null)
                return NotFound();

            JsonConvert.SerializeObject(list);
            return Ok(list);
        }
        // dodaj
        [HttpPost]
        [Route("{lid:int:min(1)}/nowa")]
        public IHttpActionResult Nowy(int lid, ModyfikacjaNowaDTO e)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mod = new modyfikacja()
            {
                id_lekarz = lid,
                id_wersji = e.id_wersji,
                id_obiekt = e.id_obiekt,
                obiekt = e.obiekt,
                operaca = e.operaca
            };

            db.modyfikacja.Add(mod);

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
        // zmien po id PUT PUT PUT
        [HttpPut]
        [Route("zmiana/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Zmien(ModyfikacjaNowaDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.modyfikacja.Any(e => e.id == id))
                return NotFound();

            modyfikacja result = db.modyfikacja.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);
            
            result.id_obiekt = viewModel.id_obiekt;
            result.id_wersji = viewModel.id_wersji;
            result.obiekt = viewModel.obiekt;
            result.operaca = viewModel.operaca;

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

            if (!db.modyfikacja.Any(e => e.id == id))
                return NotFound();

            modyfikacja result = db.modyfikacja.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            db.modyfikacja.Remove(result);

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
