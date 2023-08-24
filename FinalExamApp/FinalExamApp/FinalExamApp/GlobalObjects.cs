using System;
using System.Collections.Generic;
using System.Text;
using FinalExamApp.Models;

namespace FinalExamApp
{
    public static class GlobalObjects
    {
        //definimos las propiedades de codificación de los json
        //que usaré en los modelos
        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        public static UserDTO MyLocalUser = new UserDTO();
    }
}
