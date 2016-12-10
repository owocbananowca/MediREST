namespace MedicalibaryREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class przypisanie_parametru
    {
        public int id { get; set; }

        public int? id_lekarz { get; set; }

        public int? id_pacjent { get; set; }

        public int? id_parametr { get; set; }

        [StringLength(50)]
        public string wartosc { get; set; }

        public virtual lekarz lekarz { get; set; }

        public virtual pacjent pacjent { get; set; }

        public virtual parametr parametr { get; set; }
    }
}
