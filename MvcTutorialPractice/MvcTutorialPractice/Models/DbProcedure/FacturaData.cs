using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTutorialPractice.Models.DbTable;

namespace MvcTutorialPractice.Models.DbProcedure
{
    public class FacturaData
    {
        public List<Factura> Factura { get; set; }

        public List<FacturaDetalle> FacturaDetalle { get; set; }
    }
}