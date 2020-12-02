using Alexinea.FastMember;
using FastMemberUT.Models;
using Xunit;

namespace FastMemberUT
{
    [Trait("FastMemberUT", "ValueGetSet")]
    public class ValueGetSetTests
    {
        [Fact(DisplayName = "Value getting test")]
        public void ValueGettingTest()
        {
            var city = new NiceCity
            {
                Name = "Shanghai",
                Country = Country.China,
                Day = "1949-05-27",
                Gdp = 100000
            };

            Assert.Equal("Shanghai", city.GetPropertyValue(typeof(NiceCity), "Name"));
            Assert.Equal(Country.China, city.GetPropertyValue(typeof(NiceCity), "Country"));
            Assert.Equal("1949-05-27", city.GetPropertyValue(typeof(NiceCity), "Day"));
            Assert.Equal(null, city.GetPropertyValue(typeof(NiceCity), "Gdp"));
            Assert.Equal(100000, city.GetPropertyValue(typeof(NiceCity), "Gdp", true));
            Assert.Equal(null, city.GetPropertyValue(typeof(NiceCity), "Population"));
            Assert.Equal(999L, city.GetPropertyValue(typeof(NiceCity), "Population", true));

            Assert.Equal("Shanghai", city.GetPropertyValue("Name"));
            Assert.Equal(Country.China, city.GetPropertyValue("Country"));
            Assert.Equal("1949-05-27", city.GetPropertyValue("Day"));
            Assert.Equal(null, city.GetPropertyValue("Gdp"));
            Assert.Equal(100000, city.GetPropertyValue("Gdp", true));
            Assert.Equal(null, city.GetPropertyValue("Population"));
            Assert.Equal(999L, city.GetPropertyValue("Population", true));

            Assert.Equal("Shanghai", city.GetPropertyValue(x => x.Name));
            Assert.Equal(Country.China, city.GetPropertyValue(x => x.Country));
            Assert.Equal("1949-05-27", city.GetPropertyValue(x => x.Day));
            Assert.Equal(null, city.GetPropertyValue(x => x.Gdp));
            Assert.Equal(100000, city.GetPropertyValue(x => x.Gdp, true));
        }

        [Fact(DisplayName = "Value setting test")]
        public void ValueSettingTest()
        {
            var city = new NiceCity();

            city.SetPropertyValue(typeof(NiceCity), "Name", "Tokyo");
            city.SetPropertyValue(typeof(NiceCity), "Country", Country.Japan);
            city.SetPropertyValue(typeof(NiceCity), "Day", "2020-01-01");
            city.SetPropertyValue(typeof(NiceCity), "Gdp", 100);
            city.SetPropertyValue(typeof(NiceCity), "Population", 500);

            Assert.Equal("Tokyo", city.GetPropertyValue(typeof(NiceCity), "Name"));
            Assert.Equal(Country.Japan, city.GetPropertyValue(typeof(NiceCity), "Country"));
            Assert.Equal("2020-01-01", city.GetPropertyValue(typeof(NiceCity), "Day"));
            Assert.Equal(0, city.GetPropertyValue(typeof(NiceCity), "Gdp", true));
            Assert.Equal(999L, city.GetPropertyValue(typeof(NiceCity), "Population", true));

            city.SetPropertyValue(typeof(NiceCity), "Gdp", 100, true);
            city.SetPropertyValue(typeof(NiceCity), "Population", 500, true);

            Assert.Equal(100, city.GetPropertyValue(typeof(NiceCity), "Gdp", true));
            Assert.Equal(999L, city.GetPropertyValue(typeof(NiceCity), "Population", true));

            city.SetPropertyValue("Name", "Chengdu");
            city.SetPropertyValue("Country", Country.China);
            city.SetPropertyValue("Day", "2077-01-01");
            city.SetPropertyValue("Gdp", 1000, true);
            city.SetPropertyValue("Population", 5000, true);
            
            Assert.Equal("Chengdu", city.GetPropertyValue(typeof(NiceCity), "Name"));
            Assert.Equal(Country.China, city.GetPropertyValue(typeof(NiceCity), "Country"));
            Assert.Equal("2077-01-01", city.GetPropertyValue(typeof(NiceCity), "Day"));
            Assert.Equal(1000, city.GetPropertyValue(typeof(NiceCity), "Gdp", true));
            Assert.Equal(999L, city.GetPropertyValue(typeof(NiceCity), "Population", true));
            
            city.SetPropertyValue("Name", "Nagoya");
            city.SetPropertyValue("Country", Country.Japan);
            city.SetPropertyValue("Day", "2099-01-01");
            city.SetPropertyValue("Gdp", 1001, true);
            city.SetPropertyValue("Population", 5001, true);
            
            Assert.Equal("Nagoya", city.GetPropertyValue(typeof(NiceCity), "Name"));
            Assert.Equal(Country.Japan, city.GetPropertyValue(typeof(NiceCity), "Country"));
            Assert.Equal("2099-01-01", city.GetPropertyValue(typeof(NiceCity), "Day"));
            Assert.Equal(1001, city.GetPropertyValue(typeof(NiceCity), "Gdp", true));
            Assert.Equal(999L, city.GetPropertyValue(typeof(NiceCity), "Population", true));

        }
    }
}