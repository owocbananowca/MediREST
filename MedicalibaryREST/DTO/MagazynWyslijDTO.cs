using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalibaryREST.DTO
{
    public class MagazynWyslijDTO
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public int? max_rozmiar { get; set; }
        public int? priorytet { get; set; }
    }
}