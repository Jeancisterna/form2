using Microsoft.Build.Framework;
using Xunit;
using Xunit.Sdk;
using System.ComponentModel.DataAnnotations;
namespace form.Models
{
    public class Form
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El campo nombre es requerido")]
        public string Nombre { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El campo apellido es requerido")]
        public string Apellido { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El campo Correo es requerido")]
        public string Correo { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "El campo Calendario es requerido")]
        public string Calendario { get; set; }
    }
}
