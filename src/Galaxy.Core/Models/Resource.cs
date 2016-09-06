namespace Galaxy.Core.Models
{
    public class Resource
    {
        public string Name { get; private set; }

        public string Units { get; private set; }

        public float Credits { get; private set; }

        public Resource(string name, string units, float credits)
        {
            this.Name = name;
            this.Units = units;
            this.Credits = credits;
        }
    }
}