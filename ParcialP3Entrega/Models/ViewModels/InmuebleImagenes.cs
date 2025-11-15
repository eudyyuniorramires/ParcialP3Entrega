using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParcialP3Entrega.Models.ViewModels
{
    public class InmuebleImagenes
    {
        public int IdInmueble { get; set; }
        public int IdFoto { get; set; }
        public byte[] Imagen { get; set; }
    }
}