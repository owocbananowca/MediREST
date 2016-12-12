using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MedicalibaryREST.DTO
{
    public class Przypisanie_ParametruNowyDTO
    {
        public int? id_pacjent { get; set; }

        public int? id_parametr { get; set; }

        [StringLength(50)]
        public string wartosc { get; set; }
    }
}