﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTutorialPractice.Models
{
    public class Facturas
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        [Required]
        public string Numero { get; set;}

        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        [Required]
        public string RazonSocial { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string Rif { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public Decimal Totalotal { get; set; }
    }
}