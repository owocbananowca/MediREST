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
        /*
        // wszystkie lekarza
        [HttpGet]
        [Route("lista/{lid:int:min(1)}")]
        // wszystkie dla modyfikacji
        [HttpGet]
        [Route("lista/{lid:int:min(1)}/{mid:int:min(1)")]
        // jedno o id
        [HttpGet]
        [Route("{lid:int:min(1)}/{id:int:min(1)}")]
        // post
        [HttpPost]
        [Route("{lid:int:min(1)}/nowy")]
        // put 
        [HttpPut]
        [Route("zmiana/{lid:int:min(1)}/{id:int:min(1)}")]

        */
    }
}
