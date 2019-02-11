using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcTutorialPractice.Models.DbProcedure
{
    public class RegisterData
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        [DisplayName("Confirmar Password")]// Texto visible para la etiqueta
        public string Confirmar_Password { get; set; }
    }
}