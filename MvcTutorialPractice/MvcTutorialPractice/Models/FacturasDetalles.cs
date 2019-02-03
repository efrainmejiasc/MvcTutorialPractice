using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTutorialPractice.Models
{
    public class FacturasDetalles
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        [Required]
        public string Numero { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string CodigoProducto { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string  Producto { get; set; }

        [Required]
        public Decimal PrecioUnidad { get; set; }

        [Required]
        public Decimal Subtotal { get; set; }
    }
}