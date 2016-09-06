namespace Galaxy.Core.Models
{
    public class Unit
    {
        public string Name { get; private set; }

        public Symbol Symbol { get; private set; }

        public Unit(string name, Symbol symbol)
        {
            this.Name = name;
            this.Symbol = symbol;
        }
    }
}