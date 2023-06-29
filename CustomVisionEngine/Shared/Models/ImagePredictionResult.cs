using System.Text.Json.Serialization;

namespace CustomVisionEngine.Shared.Models
{
    internal class ImagePredictionResult
    {
        public Guid Id { get; set; }

        public Guid Project { get; set; }

        public Guid Iteration { get; set; }

        public DateTime Created { get; set; }

        [JsonPropertyName("predictions")]
        public IList<ImageTagPrediction> Predictions { get; set; }
    }
}
