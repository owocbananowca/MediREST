namespace MedicalibaryREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("wizyta")]
    public partial class wizyta
    {
        public int id { get; set; }

        public int? id_lekarz { get; set; }

        public int? id_pacjent { get; set; }

        [Column(TypeName = "date")]
        public DateTime? data_wizyty { get; set; }

        [StringLength(255)]
        public string komentarz { get; set; }

        [Column(TypeName = "date")]
        public DateTime? koniec_wizyty { get; set; }

        public virtual lekarz lekarz { get; set; }

        public virtual pacjent pacjent { get; set; }
    }
}
