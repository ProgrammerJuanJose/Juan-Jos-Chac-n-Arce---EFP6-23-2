using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace FinalExamApp.Models
{
    public class Ask
    {
        public RestRequest Request { get; set; }
        public long AskId { get; set; }

        public DateTime Date { get; set; }

        public string Ask1 { get; set; }

        public int UserId { get; set; }

        public int AskStatusId { get; set; }

        public bool? IsStrike { get; set; }

        public string ImageUrl { get; set; }

        public string AskDetail { get; set; }


        public virtual AskStatus AskStatus { get; set; }

        public virtual User User { get; set; }

        public async Task<bool> AddAskAsync()
        {
            try
            {

                string RouteSufix = string.Format("Users");

                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //Agregamos el mecanismo de seguridad, en este caso API key
                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);

                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                string SerializedModel = JsonConvert.SerializeObject(this);
                Request.AddBody(SerializedModel, GlobalObjects.MimeType);

                //Ejecutar la llamada del API
                RestResponse response = await client.ExecuteAsync(Request);

                //Saber si las cosas salieron bien
                HttpStatusCode statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
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
