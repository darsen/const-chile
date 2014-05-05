using System;
using System.Collections.Generic;
using System.Linq;
using ConstChile.Indicators;
using ConstChile.Persistance;

namespace ConstChile.Sii
{
    public class HistoricScraper
    {
        public List<UF> UFs { get; set; }
        public List<Dolar> Dolars { get; set; }
        public List<UTM> UTMs { get; set; }
        public List<UTA> UTAs { get; set; }
        public List<IPCPunto> IPCPuntos { get; set; }
        public List<IPC> IPCs { get; set; }
        public List<IPCAcumuladoAno> IPCAcumuladoDelAno { get; set; }
        public List<IPCAcumulado12Meses> IPCAcumulado12UltimosMeses { get; set; }

        int StartYear { get; set; }
        int EndYear { get; set; }
        public HistoricScraper()
        {
            int monthlyIndicators = 12 * 26;
            StartYear = 1990;
            EndYear = DateTime.Now.Year+1;
            UFs = new List<UF>(366*26);
            Dolars = new List<Dolar>(366*26);
            UTMs = new List<UTM>(monthlyIndicators);
            UTAs = new List<UTA>(monthlyIndicators);
            IPCPuntos = new List<IPCPunto>(monthlyIndicators);
            IPCs = new List<IPC>(monthlyIndicators);
            IPCAcumuladoDelAno = new List<IPCAcumuladoAno>(monthlyIndicators);
            IPCAcumulado12UltimosMeses = new List<IPCAcumulado12Meses>(monthlyIndicators);
            
        }

        public void ExtractAll()
        {
            using (var context = new IndicatorsContext())
            {
                if (ScrapingForTheFirstTime(context))
                {
                    ScrapeCompleteHistory();
                }
                else
                {
                    ScrapeCurrentAndNextYear();
                }
                context.UFs.AddRange(UFs);
                context.SaveChanges();
                context.Dolars.AddRange(Dolars);
                context.SaveChanges();
                context.UTMs.AddRange(UTMs);
                context.SaveChanges();
                context.UTAs.AddRange(UTAs);
                context.SaveChanges();
                context.IPCPuntos.AddRange(IPCPuntos);
                context.SaveChanges();
                context.IPCs.AddRange(IPCs);
                context.SaveChanges();
                context.IPCAcumulados12Meses.AddRange(IPCAcumulado12UltimosMeses);
                context.SaveChanges();
                context.IPCAcumuladoAnos.AddRange(IPCAcumuladoDelAno);
                context.SaveChanges();
            }

        }

        private static bool ScrapingForTheFirstTime(IndicatorsContext context)
        {
            return context.UFs.Any();
        }

        private void ScrapeCurrentAndNextYear()
        {
            foreach (var year in Enumerable.Range(StartYear, EndYear - StartYear))
            {
                var ufScraper = new UFScraper(year);
                ufScraper.Extract();
                UFs.AddRange(ufScraper.UFs);

                var dolarScraper = new DolarScraper(year);
                dolarScraper.Extract();
                Dolars.AddRange(dolarScraper.Dolars);

                var monthlyScraper = new MonthlyScraper(year);
                monthlyScraper.Extract();

                UTMs.AddRange(monthlyScraper.UTMs);
                UTAs.AddRange(monthlyScraper.UTAs);
                IPCPuntos.AddRange(monthlyScraper.IPCPuntos);
                IPCs.AddRange(monthlyScraper.IPCs);
                IPCAcumulado12UltimosMeses.AddRange(monthlyScraper.IPCAcumulado12Meses);
                IPCAcumuladoDelAno.AddRange(monthlyScraper.IPCAcumuladoAnos);
            }
        }

        private void ScrapeCompleteHistory()
        {
            foreach (var year in Enumerable.Range(EndYear, 1))
            {
                var ufScraper = new UFScraper(year);
                ufScraper.Extract();
                UFs.AddRange(ufScraper.UFs);

                var dolarScraper = new DolarScraper(year);
                dolarScraper.Extract();
                Dolars.AddRange(dolarScraper.Dolars);
            }
        }
    }
}
