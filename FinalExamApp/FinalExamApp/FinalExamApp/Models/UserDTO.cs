using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalExamApp.Models
{
    public class UserDTO
    {
        [Newtonsoft.Json.JsonIgnore]
        public RestRequest Request { get; set; }

        public int IDUsuario { get; set; }

        public string NombreUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Telefono { get; set; }

        public string Contrasennia { get; set; }

        public int Contador { get; set; }

        public string CorreoRespaldo { get; set; }

        public string DescripcionTrabajo { get; set; }

        public int EstadoUsuarioID { get; set; }
        public string Estado { get; set; }

        public int PaisID { get; set; }
        public string NombrePais { get; set; }

        public int UsuarioRolID { get; set; }
        public string UsuarioRol { get; set; }
        public bool UsuarioSeleccionado { get; set; }
    }
}
