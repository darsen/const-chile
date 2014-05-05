using System;
using System.Collections.Generic;
using System.Globalization;
using ConstChile.Html;
using ConstChile.Indicators;

namespace ConstChile.Sii
{

    public enum Column {  UTM = 1, UTA, IPCPunto, IPC, IPCAcumuladoAno, IPCAcumulado12Meses }

    public class MonthlyScraper : IndicatorScraper
    {

        public IList<UTM> UTMs;
        public IList<UTA> UTAs;
        public IList<IPCPunto> IPCPuntos;
        public IList<IPC> IPCs;
        public IList<IPCAcumuladoAno> IPCAcumuladoAnos;
        public IList<IPCAcumulado12Meses> IPCAcumulado12Meses;
        public MonthlyScraper(int year) : base(year)
        {
            UTMs = new List<UTM>(12);
            UTAs = new List<UTA>(12);
            IPCPuntos = new List<IPCPunto>(12);
            IPCs = new List<IPC>(12);
            IPCAcumuladoAnos = new List<IPCAcumuladoAno>(12);
            IPCAcumulado12Meses = new List<IPCAcumulado12Meses>(12);

            OldTableLayout = new TableLayout
            {
                XPathTemplate = "//*[@border=\"1\"]/tr[row]/td[column]",
                RowOffset = 3,
                RowCount = 12,
                ColumnOffset = 2,
                ColumnCount = 6
            };
            UrlTemplate = "http://www.sii.cl/pagina/valores/utm/utmYEAR.htm";
            InitializeTableScraper();
        }    

        public override Indicator CreateIndicator(Cell cell, string cleanValue)
        {
            if (cell.Column == (int)Column.UTM)
            {
                return new UTM {Date = Date(cell), Value = Value(cleanValue)};
            }
            if (cell.Column == (int)Column.UTA)
            {
                return new UTA {Date = Date(cell), Value = Value(cleanValue)};
            }
            if (cell.Column == (int)Column.IPCPunto)
            {
                return new IPCPunto() {Date = Date(cell), Value = Value(cleanValue)};

            }
            if (cell.Column == (int)Column.IPC) 
            {
                return new IPC() {Date = Date(cell), Value = Value(cleanValue)};
            }
            if (cell.Column == (int)Column.IPCAcumuladoAno)
            {
                return new IPCAcumuladoAno() {Date = Date(cell), Value = Value(cleanValue)};
            }
            if (cell.Column == (int)Column.IPCAcumulado12Meses)
            {
                return new IPCAcumulado12Meses() {Date = Date(cell), Value = Value(cleanValue)};
            }
            return null;
        }

        private static decimal Value(string cleanValue)
        {
            return Decimal.Parse(cleanValue, NumberStyles.Number, new CultureInfo("es-CL"));
        }

        private DateTime Date(Cell cell)
        {
            return new DateTime(Year, cell.Column - CurrentLayout().ColumnOffset + 1,
                                cell.Row - CurrentLayout().RowOffset + 1);
        }

        public override void Add(Indicator indicator)
        {
            if (indicator is UTM)
            {
                UTMs.Add((UTM)indicator);
            }
            if (indicator is UTA)
            {
                UTAs.Add((UTA)indicator);
            }
            if (indicator is IPCPunto)
            {
                IPCPuntos.Add((IPCPunto)indicator);
            }
            if (indicator is IPC)
            {
                IPCs.Add((IPC)indicator);
            }
            if (indicator is IPCAcumuladoAno)
            {
                IPCAcumuladoAnos.Add((IPCAcumuladoAno)indicator);
            }
            if (indicator is IPCAcumulado12Meses)
            {
                IPCAcumulado12Meses.Add((IPCAcumulado12Meses)indicator);
            }
        }

    }
}