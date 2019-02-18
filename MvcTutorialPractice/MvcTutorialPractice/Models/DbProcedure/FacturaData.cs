using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTutorialPractice.Models.DbTable;

namespace MvcTutorialPractice.Models.DbProcedure
{
    public class FacturaData
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public string RazonSocial { get; set; }

        public string Rif { get; set; }

        public DateTime Fecha { get; set; }

        public string CodigoProducto { get; set; }

        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public double PrecioUnidad { get; set; }

        public double SubTotal { get; set; }

        public double Total { get; set; }

    }
}