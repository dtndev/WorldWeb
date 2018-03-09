namespace WorldWeb.Domain.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Xunit;

    public class CreatePlanetEarthWithContinents
    {
        [Fact]
        public void CreatePlanetEarth()
        {
            var earth = new Planet(Names.Earth);
            earth.Name.Should().Be(Names.Earth);
        }

        [Fact]
        public void CreateEarthWithContinents()
        {
            var earth = new Planet(Names.Earth);
            earth.AddContinent(new Continent(Names.Eurasia));
            earth.AddContinent(new Continent(Names.Antarctica));
            earth.AddContinent(new Continent(Names.Africa));
            earth.AddContinent(new Continent(Names.America));
            earth.AddContinent(new Continent(Names.Australia));

            earth.Continents.Count().Should().Be(5);
            earth.Continents.Count(c => c.Name == Names.Eurasia).Should().Be(1);
            earth.Continents.Count(c => c.Name == Names.Antarctica).Should().Be(1);
            earth.Continents.Count(c => c.Name == Names.Africa).Should().Be(1);
            earth.Continents.Count(c => c.Name == Names.America).Should().Be(1);
            earth.Continents.Count(c => c.Name == Names.Australia).Should().Be(1);
        }

        [Fact]
        public void CreateAfroEurasianCompositeContinent()
        {
            var europe = new Continent(Names.Europe);
            var asia = new Continent(Names.Asia);
            var africa = new Continent(Names.Africa);

            var eurasia = new Continent(Names.Eurasia);
            eurasia.AddComponentContinent(europe);
            eurasia.AddComponentContinent(asia);

            var afroEurasia = new Continent(Names.AfroEurasia);
            afroEurasia.AddComponentContinent(eurasia);
            afroEurasia.AddComponentContinent(africa);

            eurasia.ComponentContinents.Contains(europe).Should().BeTrue();
            eurasia.ComponentContinents.Contains(asia).Should().BeTrue();

            afroEurasia.ComponentContinents.Count().Should().Be(2);
            afroEurasia.ComponentContinents.Contains(eurasia).Should().BeTrue();
            afroEurasia.ComponentContinents.Contains(africa).Should().BeTrue();
            afroEurasia.ComponentContinents.Contains(europe).Should().BeFalse();
            afroEurasia.ComponentContinents.Contains(asia).Should().BeFalse();

            afroEurasia.AddComponentContinent(europe);
            afroEurasia.AddComponentContinent(asia);

            afroEurasia.ComponentContinents.Count().Should().Be(4);
        }

        [Fact]
        public void ContinentCantHaveSameComponentContinentTwice()
        {
            var europe = new Continent(Names.Europe);
            var asia = new Continent(Names.Asia);
            var africa = new Continent(Names.Africa);

            var eurasia = new Continent(Names.Eurasia);
            eurasia.AddComponentContinent(europe);
            eurasia.AddComponentContinent(asia);

            var afroEurasia = new Continent(Names.AfroEurasia);
            afroEurasia.AddComponentContinent(eurasia);
            afroEurasia.AddComponentContinent(africa);
            afroEurasia.AddComponentContinent(africa);
            afroEurasia.AddComponentContinent(europe);
            afroEurasia.AddComponentContinent(eurasia);

            afroEurasia.ComponentContinents.Count().Should().Be(3);
            afroEurasia.ComponentContinents.Contains(eurasia).Should().BeTrue();
            afroEurasia.ComponentContinents.Contains(africa).Should().BeTrue();
            afroEurasia.ComponentContinents.Contains(europe).Should().BeTrue();
            afroEurasia.ComponentContinents.Contains(asia).Should().BeFalse();
        }

        [Fact]
        public void EarthWithCompositeContinents()
        {
            var europe = new Continent(Names.Europe);
            var asia = new Continent(Names.Asia);
            var africa = new Continent(Names.Africa);

            var eurasia = new Continent(Names.Eurasia);
            eurasia.AddComponentContinent(europe);
            eurasia.AddComponentContinent(asia);

            var afroEurasia = new Continent(Names.AfroEurasia);
            afroEurasia.AddComponentContinent(eurasia);
            afroEurasia.AddComponentContinent(africa);

            var northAmerica = new Continent(Names.NorthAmerica);
            var southAmerica = new Continent(Names.SouthAmerica);

            var america = new Continent(Names.America);
            america.AddComponentContinent(northAmerica);
            america.AddComponentContinent(southAmerica);

            var australia = new Continent(Names.Australia);
            var oceania = new Continent(Names.Oceania);
            oceania.AddComponentContinent(australia);

            var antarctica = new Continent(Names.Antarctica);

            var earth = new Planet(Names.Earth);
            earth.AddContinent(afroEurasia);
            earth.AddContinent(america);
            earth.AddContinent(oceania);
            earth.AddContinent(antarctica);

            earth.Continents.Count().Should().Be(4);

            earth.AddContinent(africa);
            earth.AddContinent(eurasia);
            earth.AddContinent(europe);
            earth.AddContinent(asia);
            earth.AddContinent(northAmerica);
            earth.AddContinent(southAmerica);
            earth.AddContinent(australia);

            earth.Continents.Count().Should().Be(11);
        }

        [Fact]
        public void ContinentsKnowTheirParentPlanet()
        {
            var earth = new Planet(Names.Earth);
            var eurasia = new Continent(Names.Eurasia);

            earth.AddContinent(eurasia);

            eurasia.Planet.Should().Be(earth);
        }

        [Fact]
        public void ContinentCanBeRemovedFromPlanet()
        {
            var earth = new Planet(Names.Earth);
            var eurasia = new Continent(Names.Eurasia);

            earth.AddContinent(eurasia);
            earth.RemoveContinent(eurasia);

            earth.Continents.Contains(eurasia).Should().BeFalse();
            eurasia.Planet.Should().Be(Planet.None);
        }

        [Fact]
        public void NewContinentHasPlanetNone()
        {
            var eurasia = new Continent(Names.Eurasia);

            eurasia.Planet.Should().Be(Planet.None);
        }

        private static class Names
        {
            public const string Earth = "Earth";

            public const string Europe = "Europe";
            public const string Africa = "Africa";
            public const string Asia = "Asia";
            public const string NorthAmerica = "North America";
            public const string SouthAmerica = "South America";
            public const string Australia = "Australia";
            public const string Antarctica = "Antarctica";

            public const string Eurasia = "Eurasia";
            public const string AfroEurasia = "Afro-Eurasia";
            public const string America = "America";
            public const string Oceania = "Oceania";
        }
    }
}
