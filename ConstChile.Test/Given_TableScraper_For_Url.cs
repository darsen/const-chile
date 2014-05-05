using ConstChile.Html;
using NUnit.Framework;

namespace ConstChile.Test
{
    public class Given_TableScraper_For_Url
    {
        private TableScraper scraper;

        [SetUp]
        public void CreateYear2013Scraper()
        {
            scraper = new TableScraper("http://www.sii.cl/pagina/valores/uf/uf2013.htm",
                                       new TableLayout
                                           {
                                               XPathTemplate = "//*[@id=\"contenido\"]/table/tbody/tr[row]/td[column]",
                                               RowOffset = 1,
                                               RowCount = 1,
                                               ColumnOffset = 31,
                                               ColumnCount = 12
                                           });
            scraper.Load();
        }

        [Test]
        public void Loads_url()
        {
            Assert.True(scraper.HtmlDocument.DocumentNode.InnerHtml.Contains("Unidad de Fomento (UF) del año 2013"));
        }
    }
}