using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTutorialPractice.EngineProyect;
using MvcTutorialPractice.Models.DbTable;
using MvcTutorialPractice.Models.Context;
using MvcTutorialPractice.Models.DbProcedure;


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

        [HttpGet]
        public ActionResult ExportExcel(int k = 0)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExportExcel()
        {
            string data = Request.Form.ToString();
            List<FacturaData> MyList = new List<FacturaData>();
            if (data == "GetData=")
            {
                MyList = Metodo.ObtenerFacturaMasDetalle();
                ViewBag.Message = "Invoice List Total" + MyList.Count.ToString();
                return View(MyList);
            }
            else if (data == "ExportData=")
            {
                MyList = Metodo.ObtenerFacturaMasDetalle();
                bool r = Metodo.ExportarExcel(MyList);
                if (r)
                {
                    ViewBag.Message = "Sucessfull Export";
                    return View(MyList);
                }
            }

            return View();
        }


    }
}