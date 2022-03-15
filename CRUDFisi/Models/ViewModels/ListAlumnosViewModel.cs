using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDFisi.Models.ViewModels
{
    public class ListAlumnosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Codigo { get; set; }
    }
}