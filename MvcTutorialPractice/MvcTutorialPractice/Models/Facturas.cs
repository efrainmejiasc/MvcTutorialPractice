using System;
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
        public string Numero { get; set;}

        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string RazonSocial { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Rif { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
    }
}