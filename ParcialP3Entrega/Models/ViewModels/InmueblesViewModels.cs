using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialP3Entrega.Models.ViewModels
{
    public class InmueblesViewModels
    {
        public int IdInmueble { get; set; }

        [Required]
        [StringLength(120)]
        public string NombreInmueble { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public int IdTipoPropiedad { get; set; }

        [Required]
        public string TipoPropiedad { get; set; }

        [Required]
        public int IdCondicion { get; set; }

        [Required]
        public string Condicion { get; set; }

        [Required]
        public int IdCiudad { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public double Precio { get; set; }

        [Required]
        public int Habitaciones { get; set; }

        [Required]
        public int Bathrooms { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public string TipoNegocio { get; set; }

        public List<InmuebleImagenes> Imagenes { get; set; }


    }
}