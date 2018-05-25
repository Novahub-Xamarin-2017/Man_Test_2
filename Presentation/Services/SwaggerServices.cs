using System.Collections.Generic;
using System.Net;
using Android.Util;
using Newtonsoft.Json;
using Presentation.Models;
using RestSharp;

namespace Presentation.Services
{
    public class SwaggerServices
    {
        private const string RootUrl = "https://sdt-event-app.scapp.io";

        private readonly RestClient client = new RestClient(RootUrl);

        public SwaggerServices()
        {
            SimpleJson.SimpleJson.CurrentJsonSerializerStrategy = new CamelCaseSerializerStrategy();
        }

        public List<OwtTile> GetOwtTiles()
        {
            var request = new RestRequest("/api/OwtTile", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<OwtTile>>(response.Content);
        }

        public List<Story> GetStories()
        {
            var request = new RestRequest("/api/Story", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<List<Story>>(response.Content);
        }

        public bool PostContact(Contact contact)
        {
            var request = new RestRequest("/api/Contact", Method.POST);
            request.AddHeader("Content-Type", "application/json-patch+json");
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(contact);
            var response = client.Execute(request);
            Log.Info("ResponseContent", response.Content);
            return response.StatusCode.Equals(HttpStatusCode.OK);
        }
    }
}