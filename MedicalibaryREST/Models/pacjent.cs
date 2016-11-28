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

        [Column(TypeName = "numeric")]
        public decimal? pesel { get; set; }

        public int? numer_koperty { get; set; }

        public int? ilosc_dodatkowych_parametrow { get; set; }

        public virtual lekarz lekarz { get; set; }

        public virtual magazyn magazyn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wizyta> wizyta { get; set; }
    }
}
