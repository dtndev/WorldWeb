namespace WorldWeb.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Planet
    {
        public static readonly Planet None = new NullPlanet();

        private readonly HashSet<Continent> continents = new HashSet<Continent>();

        public Planet(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public IEnumerable<Continent> Continents => new ReadOnlyCollection<Continent>(this.continents.ToList());

        public virtual void AddContinent(Continent continent)
        {
            if(this.continents.Add(continent))
            {
                continent.Planet = this;
            }
        }

        public virtual void RemoveContinent(Continent eurasia)
        {
            this.continents.Remove(eurasia);
            eurasia.Planet = None;
        }

        public class NullPlanet : Planet
        {
            public NullPlanet()
                : base("None")
            {
            }

            public override void AddContinent(Continent continent)
            {
            }

            public override void RemoveContinent(Continent eurasia)
            {
            }
        }
    }
}