using System;
using System.Collections.Generic;
using System.Globalization;
using ConstChile.Html;
using ConstChile.Indicators;

namespace ConstChile.Sii
{
    public class UFScraper : IndicatorScraper
    {

        public IList<UF> UFs;
        public UFScraper(int year)
            : base(year)
        {
            UFs =new List<UF>(366);
            OldTableLayout = new TableLayout
            {
                XPathTemplate = "//*[@border=\"1\"]/tr[row]/td[column]",
                RowOffset = 3,
                RowCount = 31,
                ColumnOffset = 2,
                ColumnCount = 12
            };
            UrlTemplate = "http://www.sii.cl/pagina/valores/uf/ufYEAR.htm";
            InitializeTableScraper();
        }    

        public override Indicator CreateIndicator(Cell cell, string cleanValue)
        {
            return new UF
            {
                Date = new DateTime(Year, cell.Column - CurrentLayout().ColumnOffset + 1, cell.Row - CurrentLayout().RowOffset + 1),
                Value = Decimal.Parse(cleanValue, NumberStyles.Number, new CultureInfo("es-CL"))
            };
        }

        public override void Add(Indicator indicator)
        {
            UFs.Add((UF)indicator);
        }
    }
}