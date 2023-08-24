using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Xamarin.Forms.Shapes;

namespace FinalExamApp.Models
{
    public class User
    {
        public RestRequest Request { get; set; }
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string UserPassword { get; set; }

        public int StrikeCount { get; set; }

        public string BackUpEmail { get; set; }

        public string JobDescription { get; set; }

        public int UserStatusId { get; set; }

        public int CountryId { get; set; }

        public int UserRoleId { get; set; }

        public virtual Country Country { get; set; }

        public virtual UserRole UserRole { get; set; }

        public virtual UserStatus UserStatus { get; set; }


        public async Task<List<User>> GetAllUserAsync()
        {
            try
            {
                //Usaremos el prefijo de la ruta del API que se indica en
                //Services\APIConnection para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar.

                string RouteSufix = string.Format("Users");

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //Agregamos el mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                //Ejecutar la llamada del API
                RestResponse response = await client.ExecuteAsync(Request);

                //Saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<User>>(response.Content);

                    return list;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }
    }
}
