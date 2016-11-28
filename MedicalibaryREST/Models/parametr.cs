namespace MedicalibaryREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("parametr")]
    public partial class parametr
    {
        public int id { get; set; }

        public int? id_lekarz { get; set; }

        [StringLength(1)]
        public string typ { get; set; }

        [StringLength(50)]
        public string nazwa { get; set; }

        [StringLength(50)]
        public string wartosc_domyslna { get; set; }

        public virtual lekarz lekarz { get; set; }
    }
}
