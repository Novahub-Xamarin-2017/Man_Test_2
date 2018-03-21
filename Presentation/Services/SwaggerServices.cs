using System.Collections.Generic;
using Newtonsoft.Json;
using Presentation.Models;
using RestSharp;

namespace Presentation.Services
{
    public class SwaggerServices
    {
        private const string RootUrl = "https://sdt-event-app.scapp.io";

        private readonly RestClient client = new RestClient(RootUrl);

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
    }
}