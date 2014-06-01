using ConstChile.Persistance;
using ConstChile.Sii;
using Moq;
using NUnit.Framework;

namespace ConstChile.Test
{
    public class Given_HistoricScraper
    {
        private Mock<HistoricScraper> moqScraper;
        public Mock<IndicatorsContext> moqContext;

        [SetUp]
        public void CreateScraper()
        {
             
            moqScraper = new Mock<HistoricScraper>();
            moqContext = new Mock<IndicatorsContext>();
            moqScraper.Setup(it => it.CreateContext()).Returns(moqContext.Object);
            moqScraper.Setup(it => it.RemoveDuplicates(It.IsAny<IndicatorsContext>()));
            moqScraper.Setup(it => it.PersistHistory(It.IsAny<IndicatorsContext>()));
        }

        [Test]
        public void When_Scraping_For_First_Time_Then_Scrapes_Complete_History() 
        {
            moqContext.Setup(it => it.Empty()).Returns(true);
            moqScraper.Object.ExtractAll();
            moqScraper.Verify(it => it.ScrapeCompleteHistory(), Times.Once);
            moqScraper.Verify(it => it.ScrapeCurrentAndNextYear(), Times.Never);
            moqScraper.Verify(it => it.RemoveDuplicates(It.IsAny<IndicatorsContext>()), Times.Once);
            moqScraper.Verify(it => it.PersistHistory(It.IsAny<IndicatorsContext>()), Times.Once);
        }

        [Test]
        public void When_Scraped_Before_Then_Scrapes_Current_And_Next_Year()
        {
            moqContext.Setup(it => it.Empty()).Returns(false);
            moqScraper.Object.ExtractAll();
            moqScraper.Verify(it => it.ScrapeCompleteHistory(), Times.Never);
            moqScraper.Verify(it => it.ScrapeCurrentAndNextYear(), Times.Once);
            moqScraper.Verify(it => it.RemoveDuplicates(It.IsAny<IndicatorsContext>()), Times.Once);
            moqScraper.Verify(it => it.PersistHistory(It.IsAny<IndicatorsContext>()), Times.Once);
        }
    }
}
