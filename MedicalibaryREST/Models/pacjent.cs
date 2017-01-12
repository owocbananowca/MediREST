namespace MedicalibaryREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pacjent")]
    public partial class pacjent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pacjent()
        {
            przypisanie_parametru = new HashSet<przypisanie_parametru>();
            wizyta = new HashSet<wizyta>();
        }

        public int id { get; set; }

        public int? id_lekarz { get; set; }

        public int? id_magazyn { get; set; }

        public bool? aktywny { get; set; }

        [StringLength(50)]
        public string imie { get; set; }

        [StringLength(50)]
        public string nazwisko { get; set; }
        [StringLength(11)]
        public string pesel { get; set; }

        public int? numer_koperty { get; set; }

        public int? ilosc_dodatkowych_parametrow { get; set; }

        public virtual lekarz lekarz { get; set; }

        public virtual magazyn magazyn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<przypisanie_parametru> przypisanie_parametru { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wizyta> wizyta { get; set; }
    }
}
