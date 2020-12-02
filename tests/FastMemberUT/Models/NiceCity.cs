namespace FastMemberUT.Models
{
    public class NiceCity
    {
        public string Name { get; set; }

        public Country Country { get; set; }

        public string Day;

        internal int Gdp { get; set; }

        private long Population { get; set; } = 999;
    }

    public enum Country
    {
        China,
        Japan,
    }
}