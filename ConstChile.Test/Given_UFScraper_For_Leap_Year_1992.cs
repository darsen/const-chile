using System;
using System.Linq;
using ConstChile.Sii;
using NUnit.Framework;

namespace ConstChile.Test
{
    public class Given_UFScraper_For_Leap_Year_1992
    {
        private UFScraper scraper;

        [SetUp]
        public void CreateScraper()
        {
            scraper = new UFScraper(1992);
        }
        
        [TestCase(1, 1, 8288.69)]
        [TestCase(1, 31, 8378.50)]
        [TestCase(12, 1, 9296.51)]
        [TestCase(12, 31, 9423.56)]
        public void Extract_returns_correct_border_indicators(int month, int day, decimal amount)
        {
            scraper.Extract();
            var result = scraper.UFs.Where(it => it.Date == new DateTime(1992, month, day)).FirstOrDefault();
            Assert.AreEqual(amount, result.Value);
        }

        [Test]
        public void Extract_returns_exact_number_of_indicators()
        {
            scraper.Extract();
            Assert.That(scraper.UFs.Count, Is.EqualTo(366));
        }

    }
}
