namespace WorldWeb.Domain
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    internal class ContinentSet : HashSet<Continent>
    {
        /// <summary>
        /// Returns a readonly view of all the continents in this Set, including those that are not direct members of the set but are components of direct members
        /// </summary>
        internal IEnumerable<Continent> AllContinents
        {
            get
            {
                var allContinents = new HashSet<Continent>();

                foreach (var continent in this)
                {
                    continent.AddToSet(allContinents);
                }

                return new ReadOnlyCollection<Continent>(allContinents.ToList());
            }
        }
    }
}
