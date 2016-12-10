namespace MedicalibaryREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class dane_modyfikacji
    {
        public int id { get; set; }

        public int? id_modyfikacja { get; set; }

        public int? id_lekarz { get; set; }

        [StringLength(1)]
        public string nazwa_danej { get; set; }

        [StringLength(1)]
        public string stara_wartosc { get; set; }

        [StringLength(1)]
        public string nowa_wartosc { get; set; }

        public virtual lekarz lekarz { get; set; }

        public virtual modyfikacja modyfikacja { get; set; }
    }
}
