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
    [RoutePrefix("magazyn")]
    public class MagazynController : ApiController
    {
        Model_Medicalibary_v1 db = new Model_Medicalibary_v1();
        //lista
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        public IHttpActionResult Magazyny(int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.magazyn.Select(e => new MagazynDTO()
            {
                lekarz = lid,
                id = e.id,
                nazwa = e.nazwa,
                max_rozmiar = e.max_rozmiar,
                priorytet = e.priorytet
            }
            ).Where(e => e.lekarz == lid).ToList();

            List<MagazynWyslijDTO> lista = new List<MagazynWyslijDTO>();

            foreach (var list in result)
            {
                lista.Add(new MagazynWyslijDTO()
                {
                    id = list.id,
                    nazwa = list.nazwa,
                    max_rozmiar = list.max_rozmiar,
                    priorytet = list.priorytet
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
        public IHttpActionResult Magazyn(int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = db.magazyn.Select(e => new MagazynDTO()
            {
                lekarz = lid,
                id = e.id,
                nazwa = e.nazwa,
                max_rozmiar = e.max_rozmiar,
                priorytet = e.priorytet
            }
            ).Where(e => e.lekarz == lid && e.id == id).ToList();

            List<MagazynWyslijDTO> lista = new List<MagazynWyslijDTO>();

            foreach (var list in result)
            {
                lista.Add(new MagazynWyslijDTO()
                {
                    id = list.id,
                    nazwa = list.nazwa,
                    max_rozmiar = list.max_rozmiar,
                    priorytet = list.priorytet
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
        public IHttpActionResult Nowy(MagazynNowyDTO viewModel, int lid)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (db.magazyn.Any(e => e.nazwa == viewModel.nazwa))
                return Conflict();

            var magazyn = new magazyn()
            {
                nazwa = viewModel.nazwa,
                max_rozmiar = viewModel.max_rozmiar,
                priorytet = viewModel.priorytet,
                id_lekarz = lid
            };

            db.magazyn.Add(magazyn);

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

        //Update/Replace
        [HttpPut]
        [Route("zmiana/{lid:int:min(1)}/{id:int:min(1)}")]
        public IHttpActionResult Zmien(MagazynNowyDTO viewModel, int lid, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!db.magazyn.Any(e => e.id == id))
                return NotFound();

            magazyn result = db.magazyn.FirstOrDefault(e => e.id == id && e.id_lekarz == lid);

            result.max_rozmiar = viewModel.max_rozmiar;
            result.nazwa = viewModel.nazwa;
            result.priorytet = viewModel.priorytet;
            
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
