using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcTutorialPractice.Models.Context;
using MvcTutorialPractice.Models.DbTable;
using MvcTutorialPractice.Models.DbProcedure;
using Excel = Microsoft.Office.Interop.Excel;

namespace MvcTutorialPractice.EngineProyect
{
    public class Engine
    {
        public List<Models.DbTable.Factura> ObtenerTodasFacturas()
        {
            using (var db = new DbContexto())
            {
                return db.Factura.ToList();
            }
        }

        public List<Models.DbTable.FacturaDetalle> ObtenerTodasFacturasDetalles(string n)
        {
            using (var db = new DbContexto())
            {
                return  db.FacturaDetalle.Where(s => s.Numero == n).ToList(); 
            }
        }

        public void CrearFactura(Models.DbTable.Factura model)
        {
            using (var db = new DbContexto())
            {
                db.Factura.Add(model);
                db.SaveChanges();
                System.Web.HttpContext.Current.Session["NumeroFactura"] = model.Numero;
            }
        }

        public void CrearFacturaDetalle(Models.DbTable.FacturaDetalle model)
        {
            using (var db = new DbContexto())
            { 
                db.FacturaDetalle.Add(model);
                db.SaveChanges();
            }
        }

        public List<FacturaData> ObtenerFacturaMasDetalle()
        {
            List<FacturaData> MyList = new List<FacturaData>();
           
            using (var db = new DbContexto())
            {
              var lista =  (from f in db.Factura join fd in db.FacturaDetalle on f.Numero equals fd.Numero orderby f.Numero ascending select new { f,fd }).ToList();
             for (int i = 0; i <= lista.Count - 1; i++)
             {
                    FacturaData Item = new FacturaData();
                    Item.Id = lista[i].f.Id;
                    Item.Numero = lista[i].f.Numero;
                    Item.RazonSocial = lista[i].f.RazonSocial;
                    Item.Rif = lista[i].f.Rif;
                    Item.Fecha = lista[i].f.Fecha;
                    Item.CodigoProducto = lista[i].fd.CodigoProducto;
                    Item.Producto = lista[i].fd.Producto;
                    Item.Cantidad = lista[i].fd.Cantidad;
                    Item.PrecioUnidad = lista[i].fd.PrecioUnidad;
                    Item.SubTotal = lista[i].fd.Subtotal;
                    Item.Total = lista[i].f.Total;

                    MyList.Insert(i, Item);
                }
            }
  
            return MyList ;
        }

        public bool ExportarExcel(List <FacturaData> MyList)
        {
            bool  resultado = false;
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            try
            {
                worksheet.Cells[1, 1] = "Id";
                worksheet.Cells[1, 2] = "Numero";
                worksheet.Cells[1, 3] = "Razon Social";
                worksheet.Cells[1, 4] = "Rif";
                worksheet.Cells[1, 5] = "Fecha";
                worksheet.Cells[1, 6] = "Codigo Producto";
                worksheet.Cells[1, 7] = "Producto";
                worksheet.Cells[1, 8] = "Cantidad Producto";
                worksheet.Cells[1, 9] = "Precio Unidad";
                worksheet.Cells[1, 10] = "SubTotal";
                worksheet.Cells[1, 11] = "Total";
                int row = 2;

                foreach (var I in MyList)
                {
                    //FORMAT CONTENT
                    worksheet.Range["A" + row.ToString(), "k" + row.ToString()].Font.Color = System.Drawing.Color.Black;
                    worksheet.Range["A" + row.ToString(), "k" + row.ToString()].Font.Size = 10;

                    worksheet.Cells[row, 1] = I.Id;
                    worksheet.Cells[row, 2] = I.Numero;
                    worksheet.Cells[row, 3] = I.RazonSocial;
                    worksheet.Cells[row, 4] = I.Rif;
                    worksheet.Cells[row, 5] = I.Fecha.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 6] = I.CodigoProducto;
                    worksheet.Cells[row, 7] = I.Producto;
                    worksheet.Cells[row, 8] = I.Cantidad;
                    worksheet.Cells[row, 9] = I.PrecioUnidad;
                    worksheet.Cells[row, 10] = I.SubTotal;
                    worksheet.Cells[row, 11] = I.Total;
                 
                    row++;
                }
                resultado = true;
            }
            catch
            {
                
            }
         

            worksheet.get_Range("A1", "K1").EntireColumn.AutoFit();
            //FORMAT HEAD
            var head = worksheet.get_Range("A1", "K1");
            head.Font.Bold = true;
            head.Font.Color = System.Drawing.Color.Green;
            head.Font.Size = 12;
         

            application.Columns.AutoFit();
            application.Rows.AutoFit();

            workbook.SaveAs(@"C:\Users\Public\Documents\MyDemo.xlsx");
            workbook.Close();
            application.Quit();
          

            return resultado;
        }
    }
}