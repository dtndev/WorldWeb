namespace WorldWeb.Domain
{
    using System.Collections.Generic;

    public class Continent
    {
        private readonly ContinentSet componentContinents = new ContinentSet();

        public Continent(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public IEnumerable<Continent> ComponentContinents => this.componentContinents.AllContinents;

        public void AddComponentContinent(Continent continent)
        {
            this.componentContinents.Add(continent);
        }

        internal void AddToSet(HashSet<Continent> allContinents)
        {
            if (allContinents.Add(this))
            {
                foreach (var component in this.ComponentContinents)
                {
                    component.AddToSet(allContinents);
                }
            }
        }
    }
}