namespace MedicalibaryREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("modyfikacja")]
    public partial class modyfikacja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modyfikacja()
        {
            dane_modyfikacji = new HashSet<dane_modyfikacji>();
        }

        public int id { get; set; }

        public int? id_lekarz { get; set; }

        public int? id_wersji { get; set; }

        [StringLength(1)]
        public string obiekt { get; set; }

        public int? id_obiekt { get; set; }

        [StringLength(1)]
        public string operaca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dane_modyfikacji> dane_modyfikacji { get; set; }

        public virtual lekarz lekarz { get; set; }

        public virtual wersja wersja { get; set; }
    }
}
