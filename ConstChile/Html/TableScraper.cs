using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace ConstChile.Html
{
    public class TableScraper
    {
        private TableLayout tableLayout;
        private bool NotFound;
        public string Url { get; set; }
        public string XPathTemplate { get; set; }
        public CellReading CellReader { get; set; }
        public HtmlDocument HtmlDocument { get; set; }

        public delegate void CellReading(Cell cell);

        public TableScraper(string url, TableLayout tableLayout)
        {
            Url = url;
            this.tableLayout = tableLayout;
        }

        public void Load()
        {
            var htmlWeb = new HtmlWeb();
            HtmlDocument = htmlWeb.Load(Url);
            Skip404(htmlWeb);
            StripComments();
        }

        private void StripComments()
        {
            if (HtmlDocument.DocumentNode.SelectNodes("//comment()") == null)
            {
                return;
            }
            foreach (HtmlNode comment in HtmlDocument.DocumentNode.SelectNodes("//comment()"))
            {
                comment.ParentNode.RemoveChild(comment);
            }
        }

        private void Skip404(HtmlWeb htmlWeb)
        {
            if (htmlWeb.StatusCode == HttpStatusCode.NotFound)
            {
                NotFound = true;
            }
        }

        public void Extract()
        {
            if (NotFound)
            {
                return;
            }
            foreach (Cell cell in tableLayout)
            {
                HtmlNodeCollection cellNodes =
                    HtmlDocument.DocumentNode.SelectNodes(cell.Expression());
                if (cellNodes!=null && cellNodes.Count > 0)
                {
                    cell.Value = cellNodes.FirstOrDefault().InnerText;
                    CellReader(cell);
                }
            }
        }
    }
}