namespace CustomVisionEngine.Shared.Models
{
    public class Recognition
    {
        public string Tag { get; set; }

        public double Probability { get; set; }

        public override string ToString()
        {
            return string.Format($"[Tag: {Tag}, Probability: {Probability}]");
        }
    }
}
