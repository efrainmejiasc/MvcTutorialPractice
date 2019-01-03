using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTutorialPractice.Models
{
    public class ShowData
    {
        public class Telefono
        {
            public string Id { get; set; }

            public string Marca { get; set; }

            public string Modelo { get; set; }
        }

        public List<Telefono> ListaTelefono()
        {
           List<Telefono> Lista = new List<Telefono>();
           Telefono Elemento = new Telefono
            {
                Id = "001",
                Marca ="Sansung",
                Modelo = "J2"
            };
            Lista.Add(Elemento);
            Elemento = new Telefono
            {
                Id = "002",
                Marca = "Sansung",
                Modelo = "J4"
            };
            Lista.Add(Elemento);
            Elemento = new Telefono
            {
                Id = "003",
                Marca = "Sansung",
                Modelo = "J5"
            };
            Lista.Add(Elemento);
            return Lista;
        }
    }
}