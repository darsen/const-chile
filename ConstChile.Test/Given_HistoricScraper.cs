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


       // [Ignore]
        [Test]
        public void Extacts_a_lot_of_UFs()
        {
            historicScraper.ExtractAll();
            Assert.That(historicScraper.UFs.Count, Is.GreaterThan(8894));
        }

    }
}
