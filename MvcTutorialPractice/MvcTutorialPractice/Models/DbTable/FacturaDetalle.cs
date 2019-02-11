using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTutorialPractice.Models.DbTable
{
    [Table("FacturaDetalle")]
    public class FacturaDetalle
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string Numero { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string CodigoProducto { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public double  PrecioUnidad { get; set; }

        [Required]
        public double  Subtotal { get; set; }

       /* //Propiedades navigacionales 
        public int FacturasId { get; set; }

        [ForeignKey("FacturasId")]
        public Factura Factura { get; set; }*/
    }
}