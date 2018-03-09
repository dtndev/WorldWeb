namespace WorldWeb.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Continent
    {
        private readonly HashSet<Continent> componentContinents = new HashSet<Continent>();

        public Continent(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public IEnumerable<Continent> ComponentContinents => new ReadOnlyCollection<Continent>(this.componentContinents.ToList());

        public void AddComponentContinent(Continent continent)
        {
            this.componentContinents.Add(continent);
        }
    }
}