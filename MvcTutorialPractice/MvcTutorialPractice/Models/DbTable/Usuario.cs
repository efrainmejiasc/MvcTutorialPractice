using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTutorialPractice.Models.DbTable
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        [Index("IX_Usuarios", IsUnique = true, Order = 1)]
        public string UserName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string Password { get; set; }
    }
}