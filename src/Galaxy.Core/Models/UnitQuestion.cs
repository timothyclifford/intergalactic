namespace Galaxy.Core.Models
{
    public class UnitQuestion : IQuestion
    {
        public string Units { get; private set; }

        public UnitQuestion(string units)
        {
            this.Units = units;
        }
    }
}