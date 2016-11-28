namespace MedicalibaryREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("zasada")]
    public partial class zasada
    {
        public int id { get; set; }

        public int? id_lekarz { get; set; }

        public int? id_magazyn { get; set; }

        [StringLength(50)]
        public string nazwa_atrybutu { get; set; }

        [StringLength(50)]
        public string operacja_porownania { get; set; }

        [StringLength(50)]
        public string wartosc_porownania { get; set; }

        public bool? spelnialnosc_operacji { get; set; }

        public virtual lekarz lekarz { get; set; }

        public virtual magazyn magazyn { get; set; }
    }
}
