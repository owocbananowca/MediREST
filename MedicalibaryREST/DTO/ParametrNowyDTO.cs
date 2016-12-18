using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MedicalibaryREST.DTO
{
    public class ParametrNowyDTO
    {
        //public int? id_lekarz { get; set; }

        [StringLength(1)]
        public string typ { get; set; }

        [StringLength(50)]
        public string nazwa { get; set; }

        [StringLength(50)]
        public string wartosc_domyslna { get; set; }
    }
}