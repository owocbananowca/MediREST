﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicalibaryREST.DTO
{
    public class LekarzNowyDTO
    {
        [StringLength(50)]
        public string Nazwa { get; set; }
        [StringLength(255)]
        public string Haslo { get; set; }
    }
}