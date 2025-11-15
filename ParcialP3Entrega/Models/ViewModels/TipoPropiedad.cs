using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcialP3Entrega.Models.ViewModels
{
    public class TipoPropiedad
    {
        public int IdTipoPropiedad { get; set; }
        public string Descripcion { get; set; }
        public Boolean Activo { get; set; }
    }
}