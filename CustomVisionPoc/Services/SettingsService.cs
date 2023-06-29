namespace CustomVisionPoc.Services
{
    public class SettingsService : ISettingsService
    {
        public SettingsService()
        {
        }

        public string Region
        {
            get => Preferences.Get(nameof(Region), null);
            set => Preferences.Set(nameof(Region), value);
        }

        public string ProjectName
        {
            get => Preferences.Get(nameof(ProjectName), null);
            set => Preferences.Set(nameof(ProjectName), value);
        }

        public string PredictionKey
        {
            get => Preferences.Get(nameof(PredictionKey), null);
            set => Preferences.Set(nameof(PredictionKey), value);
        }

        public string IterationId
        {
            get => Preferences.Get(nameof(IterationId), Guid.Empty.ToString("D"));
            set => Preferences.Set(nameof(IterationId), value);
        }
    }
}
