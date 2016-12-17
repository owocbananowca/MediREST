using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace MedicalibaryREST.DTO
{
    public class ModyfikacjaNowaDTO
    {
        public int? id_lekarz { get; set; }

        public int? id_wersji { get; set; }

        [StringLength(50)]
        public string obiekt { get; set; }

        public int? id_obiekt { get; set; }

        [StringLength(50)]
        public string operaca { get; set; }
    }
}