using ConstChile.Sii;
using NUnit.Framework;

namespace ConstChile.Test
{
    public class Given_HistoricScraper
    {
        HistoricScraper historicScraper;

        [SetUp]
        public void CreateScraper()
        {
            historicScraper = new HistoricScraper();
        }


        //[Ignore]
        [Test]
        public void Extacts_All()
        {
            historicScraper.ExtractAll();            
            Assert.True(historicScraper.UFs.Count == 0 || historicScraper.UFs.Count > 8894);
        }

    }
}
