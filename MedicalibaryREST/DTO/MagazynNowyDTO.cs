using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalibaryREST.DTO
{
    public class MagazynNowyDTO
    {
        public string nazwa { get; set; }
        public int? max_rozmiar { get; set; }
        public int? priorytet { get; set; }
        //public int lekarz { get; set; }
    }
}