namespace WorldWeb.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Planet
    {
        private readonly HashSet<Continent> continents = new HashSet<Continent>();

        public Planet(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public IEnumerable<Continent> Continents => new ReadOnlyCollection<Continent>(this.continents.ToList());

        public void AddContinent(Continent continent)
        {
            this.continents.Add(continent);
        }
    }
}