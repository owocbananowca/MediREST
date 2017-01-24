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
    [RoutePrefix("pacjent")]
    public class PacjentController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();
        //get list
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult Magazyny(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.pacjent.Select(e => new PacjentDTO()
            {
                id = e.id,
                id_magazyn = e.id_magazyn,
                aktywny = e.aktywny,
                imie = e.imie,
                nazwisko = e.nazwisko,
                pesel = e.pesel,
                numer_koperty = e.numer_koperty,
                ilosc_dodatkowych_parametrow = e.ilosc_dodatkowych_parametrow,
                id_lekarz = e.id_lekarz
            }).Where(e => e.id_lekarz == lid).ToList();

            List<PacjentWyslijDTO> lista = new List<PacjentWyslijDTO>();

            foreach (var list in result)
            {
                lista.Add(new PacjentWyslijDTO()
                {
                    id = list.id,
                    id_magazyn = list.id_magazyn,
                    aktywny = list.aktywny,
                    imie = list.imie,
                    nazwisko = list.nazwisko,
                    pesel = list.pesel,
                    numer_koperty = list.numer_koperty,
                    ilosc_dodatkowych_parametrow = list.ilosc_dodatkowych_parametrow
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //get one
        [HttpGet]
        [Route("{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Pacjent(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.pacjent.Select(e => new PacjentDTO()
            {
                id = e.id,
                id_magazyn = e.id_magazyn,
                aktywny = e.aktywny,
                imie = e.imie,
                nazwisko = e.nazwisko,
                pesel = e.pesel,
                numer_koperty = e.numer_koperty,
                ilosc_dodatkowych_parametrow = e.ilosc_dodatkowych_parametrow,
                id_lekarz = lid
            }
            ).Where(e => e.id_lekarz == lid && e.id == id).ToList();

            List<PacjentWyslijDTO> lista = new List<PacjentWyslijDTO>();

            foreach (var list in result)
            {
                lista.Add(new PacjentWyslijDTO()
                {
                    id = list.id,
                    id_magazyn = list.id_magazyn,
                    aktywny = list.aktywny,
                    imie = list.imie,
                    nazwisko = list.nazwisko,
                    pesel = list.pesel,
                    numer_koperty = list.numer_koperty,
                    ilosc_dodatkowych_parametrow = list.ilosc_dodatkowych_parametrow
                });
            }

            if (lista == null)
                return NotFound();

            JsonConvert.SerializeObject(lista);
            return Ok(lista);
        }
        //post
        [HttpPost]
        [Route("{lid:int:min(1)}/nowy")]
        public IHttpActionResult Nowy(PacjentNowyDTO viewModel, int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            //if (db.pacjent.Any(e => e.pesel == viewModel.pesel))
             //   return Conflict();

            var pacjent = new pacjent()
            {
                id_magazyn = viewModel.id_magazyn,
                aktywny = viewModel.aktywny,
                imie = viewModel.imie,
                nazwisko = viewModel.nazwisko,
                pesel = viewModel.pesel,
                numer_koperty = viewModel.numer_koperty,
                ilosc_dodatkowych_parametrow = viewModel.ilosc_dodatkowych_parametrow,
                id_lekarz = lid
            };

            db.pacjent.Add(pacjent);

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
        public IHttpActionResult Zmien(PacjentNowyDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.pacjent.Any(e => e.id == id))
                return NotFound();

            var result = db.pacjent.FirstOrDefault(e => e.id == id);// && e.id_lekarz == lid);

            if (result == null)
                return NotFound();

            result.id_magazyn = viewModel.id_magazyn;
            result.ilosc_dodatkowych_parametrow = viewModel.ilosc_dodatkowych_parametrow;
            result.imie = viewModel.imie;
            result.nazwisko = viewModel.nazwisko;
            result.numer_koperty = viewModel.numer_koperty;
            result.pesel = viewModel.pesel;
            result.aktywny = viewModel.aktywny;
            
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
        [Route("dodajparam/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult NowyParam(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.pacjent.Any(e => e.id == id))
                return NotFound();

            pacjent result = db.pacjent.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            result.ilosc_dodatkowych_parametrow += 1;
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
        [Route("odejmijparam/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult MniejParam(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.pacjent.Any(e => e.id == id))
                return NotFound();

            pacjent result = db.pacjent.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            result.ilosc_dodatkowych_parametrow -= 1;
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

            if (!db.pacjent.Any(e => e.id == id))
                return NotFound();

            pacjent result = db.pacjent.FirstOrDefault(e => e.id == id);// && e.id_lekarz == lid);

            db.pacjent.Remove(result);

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
