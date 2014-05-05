using System;
using System.Collections.Generic;
using System.Linq;
using ConstChile.Indicators;
using ConstChile.Sii;
using NUnit.Framework;

namespace ConstChile.Test
{
    public class Given_UFScraper_For_Year_1994_In_Old_Format
    {
        private UFScraper scraper;

        [SetUp]
        public void CreateScraper()
        {
            scraper = new UFScraper(1994);
        }
        
        [Test]
        public void Extract_returns_365_indicators()
        {
            scraper.Extract();
            Assert.AreEqual(365, scraper.UFs.Count);
        }

        [Test]
        public void Uf_of_5_of_april_is_10782_09(){
            
            scraper.Extract();
            UF uf5OfApril = (UF)scraper.UFs.Where(it => it.Date == new DateTime(1994, 4, 5)).FirstOrDefault();
            Assert.That(uf5OfApril.Value, Is.EqualTo(10782.09m));

        }
    }
}
