namespace WorldWeb.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Continent
    {
        private readonly HashSet<Continent> constituentContinents = new HashSet<Continent>();

        public Continent(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public IEnumerable<Continent> ConstituentContinents
        {
            get
            {
                var allConstituents = new HashSet<Continent>();
               
                foreach (var continent in this.constituentContinents)
                {
                    AddContinentToConstituentSet(continent, allConstituents);
                }

                return new ReadOnlyCollection<Continent>(allConstituents.ToList());
            }
        }

        public void AddConstituentContinent(Continent continent)
        {
            this.constituentContinents.Add(continent);
        }

        private static void AddContinentToConstituentSet(Continent continent, HashSet<Continent> constituentSet)
        {
            if (constituentSet.Add(continent))
            {
                foreach (var constituent in continent.ConstituentContinents)
                {
                    AddContinentToConstituentSet(constituent, constituentSet);
                }
            }
        }
    }
}