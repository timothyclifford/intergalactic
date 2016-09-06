namespace Galaxy.Core.Models
{
    public class ResourceQuestion : IQuestion
    {
        public string Units { get; private set; }

        public string Resource { get; private set; }

        public ResourceQuestion(string units, string resource)
        {
            this.Units = units;
            this.Resource = resource;
        }
    }
}