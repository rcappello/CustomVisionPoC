using System.Text.Json.Serialization;

namespace CustomVisionEngine.Shared.Models
{
    internal class ImageTagPrediction
    {
        public Guid TagId { get; set; }

        [JsonPropertyName("tagName")]
        public string Tag { get; set; }

        [JsonPropertyName("probability")]
        public double Probability { get; set; }
    }
}
