namespace WorldWeb.Domain
{
    using System.Collections.Generic;

    public class Planet
    {
        private readonly ContinentSet continents = new ContinentSet();

        public Planet(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public IEnumerable<Continent> Continents => this.continents.AllContinents;

        public void AddContinent(Continent continent)
        {
            this.continents.Add(continent);
        }
    }
}