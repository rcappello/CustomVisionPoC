namespace CustomVisionPoc.Services
{
    public class SettingsService : ISettingsService
    {
        public SettingsService()
        {
        }

        public string PredictionServiceName
        {
            get => Preferences.Get(nameof(PredictionServiceName), null);
            set => Preferences.Set(nameof(PredictionServiceName), value);
        }

        public string IterationName
        {
            get => Preferences.Get(nameof(IterationName), null);
            set => Preferences.Set(nameof(IterationName), value);
        }

        public string PredictionKey
        {
            get => Preferences.Get(nameof(PredictionKey), null);
            set => Preferences.Set(nameof(PredictionKey), value);
        }

        public string ProjectId
        {
            get => Preferences.Get(nameof(ProjectId), Guid.Empty.ToString("D"));
            set => Preferences.Set(nameof(ProjectId), value);
        }
    }
}
