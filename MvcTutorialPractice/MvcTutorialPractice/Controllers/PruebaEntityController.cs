using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTutorialPractice.EngineProyect;
using MvcTutorialPractice.Models.DbTable;
using MvcTutorialPractice.Models.Context;

namespace MvcTutorialPractice.Controllers
{
    public class PruebaEntityController : Controller
    {
        private Engine Metodo = new Engine();

        public ActionResult Factura()
        {
            Factura F = new Factura();
            F.Fecha = DateTime.UtcNow;
            return View(F);
        }

        public ActionResult FacturaDetalle()
        {
            if (System.Web.HttpContext.Current.Session["NumeroFactura"] != null)
            {
                FacturaDetalle F = new FacturaDetalle();
                F.Numero = System.Web.HttpContext.Current.Session["NumeroFactura"].ToString();
                return View(F);
            }
            else
            { 
               return View();
            }
        }

        [HttpPost]
        public ActionResult Factura(Factura model)
        {
             Metodo.CrearFactura(model);
             return RedirectToAction("FacturaDetalle", "PruebaEntity");
        }

        [HttpPost]
        public ActionResult FacturaDetalle(FacturaDetalle model)
        {
            Metodo.CrearFacturaDetalle(model);
            return View();
        }

        public ActionResult FacturaList()
        {
            return View(Metodo.ObtenerTodasFacturas());
        }

        public ActionResult FacturaDetalleList ()
        {
            //string numero =  this.RouteData.Values["numero"].ToString();
            string numero = Request["numero"];
            return View(Metodo.ObtenerTodasFacturasDetalles(numero));
        }


    }
}