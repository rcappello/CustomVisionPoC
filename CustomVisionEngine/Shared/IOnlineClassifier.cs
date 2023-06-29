using CustomVisionEngine.Shared.Models;

namespace CustomVisionEngine.Shared
{
    public static class CustomVisionConstants
    {
        public const string DefaultEndpoint = "https://{0}.cognitiveservices.azure.com/customvision/v3.1/";
    }

    public interface IOnlineClassifier
    {
        Task InitializeAsync(string region, string predictionKey, string customVisionEndpoint = CustomVisionConstants.DefaultEndpoint);

        Task<IEnumerable<Recognition>> RecognizeAsync(string projectName, Guid iterationId, Stream image);

        Task<IEnumerable<Recognition>> RecognizeAsync(string region, string predictionKey, string projectName, Guid iterationId, Stream image, string customVisionEndpoint = CustomVisionConstants.DefaultEndpoint);
    }
}
