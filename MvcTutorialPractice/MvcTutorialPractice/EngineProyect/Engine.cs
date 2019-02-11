using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTutorialPractice.Models.Context;
using MvcTutorialPractice.Models.DbTable;

namespace MvcTutorialPractice.EngineProyect
{
    public class Engine
    {
        public List<Factura> ObtenerTodasFacturas()
        {
            using (var db = new DbContexto())
            {
                return db.Factura.ToList();
            }
        }

        public List<FacturaDetalle> ObtenerTodasFacturasDetalles(string n)
        {
            using (var db = new DbContexto())
            {
                return  db.FacturaDetalle.Where(s => s.Numero == n).ToList(); 
            }
        }

        public void CrearFactura(Factura model)
        {
            using (var db = new DbContexto())
            {
                db.Factura.Add(model);
                db.SaveChanges();
                System.Web.HttpContext.Current.Session["NumeroFactura"] = model.Numero;
            }
        }

        public void CrearFacturaDetalle(FacturaDetalle model)
        {
            using (var db = new DbContexto())
            {
                db.FacturaDetalle.Add(model);
                db.SaveChanges();
            }
        }
    }
}