using Newtonsoft.Json;

namespace Presentation.Models
{
    public class Story
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("documentUrl")]
        public string DocumentUrl { get; set; }

        [JsonProperty("documentName")]
        public string DocumentName { get; set; }
    }
}