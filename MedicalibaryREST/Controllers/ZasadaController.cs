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
    [RoutePrefix("zasada")]
    public class ZasadaController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();

        //lista
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult Zasady(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.zasada.Select(e => new ZasadaDTO()
            {
                id_lekarz = e.id_lekarz,
                id = e.id,
                id_magazynu = e.id_magazyn,
                nazwa_atrybutu = e.nazwa_atrybutu,
                operacja_porownania = e.operacja_porownania,
                wartosc_porownania = e.wartosc_porownania,
                spelnialnosc_operacji = e.spelnialnosc_operacji
            }
            ).Where(e => e.id_lekarz == lid).ToList();

            List<ZasadaWyslijDTO> lista = new List<ZasadaWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new ZasadaWyslijDTO()
                {
                    id = e.id,
                    id_magazynu = e.id_magazynu,
                    nazwa_atrybutu = e.nazwa_atrybutu,
                    operacja_porownania = e.operacja_porownania,
                    wartosc_porownania = e.wartosc_porownania,
                    spelnialnosc_operacji = e.spelnialnosc_operacji
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //jeden
        [HttpGet]
        [Route("lista/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Zasada(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.zasada.Select(e => new ZasadaDTO()
            {
                id_lekarz = e.id_lekarz,
                id = e.id,
                id_magazynu = e.id_magazyn,
                nazwa_atrybutu = e.nazwa_atrybutu,
                operacja_porownania = e.operacja_porownania,
                wartosc_porownania = e.wartosc_porownania,
                spelnialnosc_operacji = e.spelnialnosc_operacji
            }
            ).Where(e => e.id_lekarz == lid && e.id == id).ToList();

            List<ZasadaWyslijDTO> lista = new List<ZasadaWyslijDTO>();

            foreach (var e in result)
            {
                lista.Add(new ZasadaWyslijDTO()
                {
                    id = e.id,
                    id_magazynu = e.id_magazynu,
                    nazwa_atrybutu = e.nazwa_atrybutu,
                    operacja_porownania = e.operacja_porownania,
                    wartosc_porownania = e.wartosc_porownania,
                    spelnialnosc_operacji = e.spelnialnosc_operacji
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //dodawanie
        [HttpPost]
        [Route("{lid:int:min(1)}/nowy")]
        public IHttpActionResult Nowy(ZasadaNowaDTO viewModel, int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (db.zasada.Any(e => e.nazwa_atrybutu == viewModel.nazwa_atrybutu &&
                e.operacja_porownania == viewModel.operacja_porownania &&
                e.wartosc_porownania == viewModel.wartosc_porownania &&
                e.spelnialnosc_operacji == viewModel.spelnialnosc_operacji &&
                e.id_magazyn == viewModel.id_magazynu &&
                e.id_lekarz == lid))
                return Conflict();

            var zasada = new zasada()
            {
                nazwa_atrybutu = viewModel.nazwa_atrybutu,
                operacja_porownania = viewModel.operacja_porownania,
                wartosc_porownania = viewModel.wartosc_porownania,
                spelnialnosc_operacji = viewModel.spelnialnosc_operacji,
                id_lekarz = lid,
                id_magazyn = viewModel.id_magazynu
            };

            db.zasada.Add(zasada);

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
        [Route("zmiana/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Zmien(ZasadaNowaDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.zasada.Any(e => e.id == id))
                return NotFound();

            zasada result = db.zasada.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            result.id_magazyn = viewModel.id_magazynu;
            result.nazwa_atrybutu = viewModel.nazwa_atrybutu;
            result.operacja_porownania = viewModel.operacja_porownania;
            result.wartosc_porownania = viewModel.wartosc_porownania;
            result.spelnialnosc_operacji = viewModel.spelnialnosc_operacji;

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

            if (!db.zasada.Any(e => e.id == id))
                return NotFound();

            zasada result = db.zasada.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            db.zasada.Remove(result);

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
