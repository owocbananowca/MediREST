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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public parametr()
        {
            przypisanie_parametru = new HashSet<przypisanie_parametru>();
        }

        public int id { get; set; }

        public int? id_lekarz { get; set; }

        [StringLength(16)]
        public string typ { get; set; }

        [StringLength(50)]
        public string nazwa { get; set; }

        [StringLength(50)]
        public string wartosc_domyslna { get; set; }

        public string jednostka { get; set; }

        public virtual lekarz lekarz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<przypisanie_parametru> przypisanie_parametru { get; set; }
    }
}
