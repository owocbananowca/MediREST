using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MedicalibaryREST.DTO
{
    public class DaneModyfikacjiWyslijDTO
    {
        public int id { get; set; }

        public int? id_modyfikacja { get; set; }

        [StringLength(50)]
        public string nazwa_danej { get; set; }

        [StringLength(50)]
        public string stara_wartosc { get; set; }

        [StringLength(50)]
        public string nowa_wartosc { get; set; }
    }
}