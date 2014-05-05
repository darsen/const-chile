using System;
using System.Collections.Generic;
using System.Globalization;
using ConstChile.Html;
using ConstChile.Indicators;

namespace ConstChile.Sii
{
    public class DolarScraper : IndicatorScraper
    {
        public IList<Dolar> Dolars;
        public DolarScraper(int year)
            : base(year)
        {   
            Dolars = new List<Dolar>(366);            
            OldTableLayout = new TableLayout
            {
                XPathTemplate = "//*[@border=\"1\"]/tr[row]/td[column]",
                RowOffset = 2,
                RowCount = 31,
                ColumnOffset = 2,
                ColumnCount = 12
            };
            UrlTemplate = "http://www.sii.cl/pagina/valores/dolar/dolarYEAR.htm";
            InitializeTableScraper();
        }

        public override Indicator CreateIndicator(Cell cell, string cleanValue)
        {
            return new Dolar()
            {
                Date = new DateTime(Year, cell.Column - CurrentLayout().ColumnOffset + 1, cell.Row - CurrentLayout().RowOffset + 1),
                Value = Decimal.Parse(cleanValue, NumberStyles.Number, new CultureInfo("es-CL"))
            };
        }

        public override void Add(Indicator indicator)
        {
            Dolars.Add((Dolar)indicator);
        }
    }



}