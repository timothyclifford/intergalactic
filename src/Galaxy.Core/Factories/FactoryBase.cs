namespace Galaxy.Core.Factories
{
    public abstract class FactoryBase<T>
    {
        protected readonly string _pattern;

        public FactoryBase(string pattern)
        {
            _pattern = pattern;
        }

        /// <summary>
        /// Creates object from string input
        /// </summary>
        /// <param name="input">
        /// The raw string input
        /// </param>
        /// <returns>
        /// The populated object
        /// </returns>
        public abstract T Create(string input);
    }
}