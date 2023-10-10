using CustomVisionEngine.Exceptions;
using CustomVisionEngine.Shared.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CustomVisionEngine.Shared
{
    public class OnlineClassifierImplementation : IOnlineClassifier
    {
        private string predictionKey;
        private HttpClient client;

        public Task InitializeAsync(string serviceName, string predictionKey, string predictionServiceName)
        {
            this.predictionKey = predictionKey;
            var uri = string.Format(predictionServiceName, serviceName);

            client = new HttpClient
            {
                BaseAddress = new Uri(uri.EndsWith("/") ? uri : uri += "/")
            };

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Recognition>> RecognizeAsync(string iterationName, Guid projectId, Stream image)
        {
            var request = CreatePredictRequest(iterationName, projectId);

            request.Content = new StreamContent(image);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var predictions = await SendRequestAsync<ImagePredictionResult>(request);
            var results = predictions.Predictions.Select(p => new Recognition
            {
                Tag = p.Tag,
                Probability = p.Probability,
                Description = $"{p.Tag}: {p.Probability:P1}"
            }).OrderByDescending(o => o.Probability)
                .ThenBy(o => o.Tag)
                .ToList();

            return results;
        }

        public async Task<IEnumerable<Recognition>> RecognizeAsync(string serviceName, string predictionKey, string iterationName, Guid projectId, Stream image, string customVisionEndpoint)
        {
            await InitializeAsync(serviceName, predictionKey, customVisionEndpoint);
            var results = await RecognizeAsync(iterationName, projectId, image);

            return results;
        }

        private HttpRequestMessage CreatePredictRequest(string iterationName, Guid projectId)
        {
            var endpoint = $"prediction/{projectId}/detect/iterations/{iterationName}/image";
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Headers.Add("Prediction-Key", predictionKey);

            return request;
        }

        private async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContentString = await response.Content.ReadAsStringAsync();
                var content = JsonSerializer.Deserialize<T>(responseContentString);

                return content;
            }
            else
            {
                var exception = new ClassifierException(response.ReasonPhrase);
                throw exception;
            }
        }
    }
}
