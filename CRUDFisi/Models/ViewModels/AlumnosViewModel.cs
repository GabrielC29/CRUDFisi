using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDFisi.Models.ViewModels
{
    public class AlumnosViewModel
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(20)]
        [Display(Name ="Apellido")]
        public string Apellido { get; set; }
        [Required]
        [StringLength(8)]
        [Display(Name ="Código")]
        public string Codigo { get; set; }

    }
}