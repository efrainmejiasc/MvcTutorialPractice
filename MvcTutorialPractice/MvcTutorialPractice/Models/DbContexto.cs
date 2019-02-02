using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcTutorialPractice.Models
{
    public class DbContexto : DbContext
    {
        // Crear un constructor para la cadena de conexion 
        public DbContexto() : base ("MvcPractice") //Nombre de la cadena de conexion
        {

        }

        // 1. Ejecutar el comando enable-migrations 
        // 2. Ejecutar el comando update-database  o [ update-database -force para que no genere error despues de creada la DB]

        // Debe ser un DbSet de tipo del objeto clase (Factura) + el nombre de la tabla 
        public DbSet <Facturas> Factura { get; set; }
    }
}