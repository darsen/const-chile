using System;
using System.Collections.Generic;
using System.Linq;
using ConstChile.Indicators;
using ConstChile.Sii;
using NUnit.Framework;

namespace ConstChile.Test
{
    public class Given_MonthlyScraper_For_Year_2013
    {
        private MonthlyScraper scraper;

        [SetUp]
        public void CreateScraper()
        {
            scraper = new MonthlyScraper(2013);
            scraper.Extract();
        }
        
        [Test]
        public void Extract_returns_12_indicators()
        {
          
            Assert.AreEqual(12, scraper.UTMs.Count);
            Assert.AreEqual(12, scraper.UTAs.Count);
            Assert.AreEqual(12, scraper.IPCPuntos.Count);
            Assert.AreEqual(12, scraper.IPCs.Count);
            Assert.AreEqual(12, scraper.IPCAcumuladoAnos.Count);
            Assert.AreEqual(12, scraper.IPCAcumulado12Meses.Count);
        }

        [Test]
        public void Extract_returns_exact_January_UTM()
        {
            var utmJanuary = scraper.UTMs.Where(it => it.Date == new DateTime(2013, 1, 1)).FirstOrDefault();
            Assert.That(utmJanuary.Value, Is.EqualTo(40005m)); 
        }

        [Test]
        public void Extract_returns_exact_December_IPC_Acumulado_12_meses()
        {
            var ipcAcumulado12 = scraper.IPCAcumuladoAnos.Where(it => it.Date == new DateTime(2013, 12, 1)).FirstOrDefault();
            Assert.That(ipcAcumulado12.Value, Is.EqualTo(3.0m));
        }
    }
}
