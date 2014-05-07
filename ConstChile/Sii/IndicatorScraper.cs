using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ConstChile.Html;
using ConstChile.Indicators;

namespace ConstChile.Sii
{
    public abstract class IndicatorScraper
    {
        private const string YearTokenInPath = "YEAR";
        private const int YearNewLayoutAppeared = 2010;
        public string UrlTemplate { get; set; }
        public TableLayout NewTableLayout { get; set; }
        public TableLayout OldTableLayout { get; set; }
        public IndicatorScraper(int year)
        {
            Year = year;
            NewTableLayout = new TableLayout
            {
                XPathTemplate = "//*[@id=\"contenido\"]/table/tbody/tr[row]/td[column]",
                RowOffset = 1,
                RowCount = 31,
                ColumnOffset = 1,
                ColumnCount = 12
            };
        }

        public void InitializeTableScraper()
        {
            TableScraper = new TableScraper(Path(), CurrentLayout());
            TableScraper.CellReader += CellReading;
        }

        public int Year { get; set; }
        public TableScraper TableScraper { get; set; }

        private static string RemoveAllNBSPs(string value)
        {
            var cleaned = Regex.Replace(value.Trim(), "&nbsp;", String.Empty).Trim();
            return Regex.Replace(cleaned, "&gt;", String.Empty).Trim();
        }

        public TableLayout CurrentLayout()
        {
            if (Year < YearNewLayoutAppeared)
            {
                return OldTableLayout;
            }
            return NewTableLayout;
        }

        public void Extract()
        {
            TableScraper.Load();
            TableScraper.Extract();
        }

        public string Path()
        {
            return UrlTemplate.Replace(YearTokenInPath, Year.ToString());
        }

        public void CellReading(Cell cell)
        {
            string cleanValue = RemoveAllNBSPs(cell.Value);
            if (String.IsNullOrEmpty(cleanValue))
            {
                return;
            }
            var indicator = CreateIndicator(cell, cleanValue);
            Add(indicator);
            //Output array creation code with all values for a given year ideal for test-after
            try{
                Console.Write("new Dolar() { Date = new DateTime(" + Year + "," + (cell.Column -1) + "," + (cell.Row-1) + "), Value = " + indicator.Value + "m},");
            }catch{

            }
        }

        public abstract Indicator CreateIndicator(Cell cell, string cleanValue);
        public abstract void Add(Indicator indicator);

    }
}