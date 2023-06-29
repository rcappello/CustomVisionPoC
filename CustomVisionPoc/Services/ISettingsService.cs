namespace CustomVisionPoc.Services
{
    public interface ISettingsService
    {
        string PredictionServiceName { get; set; }

        string IterationName { get; set; }

        string PredictionKey { get; set; }

        string ProjectId { get; set; }
    }
}
