namespace MedicalibaryREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("magazyn")]
    public partial class magazyn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public magazyn()
        {
            pacjent = new HashSet<pacjent>();
            zasada = new HashSet<zasada>();
        }

        public int id { get; set; }

        public int? id_lekarz { get; set; }

        [StringLength(50)]
        public string nazwa { get; set; }

        public int? max_rozmiar { get; set; }

        public int? priorytet { get; set; }

        public virtual lekarz lekarz { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pacjent> pacjent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zasada> zasada { get; set; }
    }
}
