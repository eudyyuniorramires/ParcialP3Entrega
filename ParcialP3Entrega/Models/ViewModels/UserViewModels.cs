using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParcialP3Entrega.Models.ViewModels
{
    public class QueryViewModels
    {
        public int _Id { get; set; }

        public string _Email { get; set; }

        public int? _Edad { get; set; }

    }


    public class AddUserViewModels
    {
        [Required]
        [Display(Name ="Nombre Usuario")]
        public string _Nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100,ErrorMessage ="Digite un correo", MinimumLength = 6)]
        [Display(Name = "Ingrese el correo")]
        public string _Correo { get; set; }

        [Required]
        [Display(Name = "Ingrese la Clave")]
        public string _Clave { get; set; }

        [Required]
        [Display(Name = "Confirme la clave")]
        public string _ClaveConfirma { get; set; }

        [Required]
        [Display(Name = "Ingrese la edad")]
        public int? _Edad { get; set; }

    }


    public class EditUserViewModels
    {
        public int _Id { get; set; }

        [Required]
        [Display(Name = "Nombre Usuario")]
        public string _Nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Digite un correo", MinimumLength = 6)]
        [Display(Name = "Ingrese el correo")]
        public string _Correo { get; set; }

        [Required]
        [Display(Name = "Ingrese la Clave")]
        public string _Clave { get; set; }

        [Required]
        [Display(Name = "Confirme la clave")]
        public string _ClaveConfirma { get; set; }

        [Required]
        [Display(Name = "Ingrese la edad")]
        public int ?_Edad { get; set; }

    }
}