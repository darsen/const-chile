using System;
using System.Collections.Generic;
using System.Linq;
using ConstChile.Indicators;
using ConstChile.Persistance;
using System.Data.Entity;

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
            using (var context = CreateContext())
            {
                if (ScrapingForTheFirstTime(context))
                {
                    ScrapeCompleteHistory();
                }
                else
                {
                    ScrapeCurrentAndNextYear();
                }
                RemoveDuplicates(context);
                PersistHistory(context);
            }

        }

        public virtual IndicatorsContext CreateContext()
        {
            return new IndicatorsContext();
        }

        public virtual void RemoveDuplicates(IndicatorsContext context)
        {
            UFs.RemoveAll(it => context.UFs.Any(saved => it.Date==saved.Date));
            Dolars.RemoveAll(it => context.Dolars.Any(saved => it.Date == saved.Date));
            UTMs.RemoveAll(it => context.UTMs.Any(saved => it.Date == saved.Date));
            UTAs.RemoveAll(it => context.UTAs.Any(saved => it.Date == saved.Date));
            IPCPuntos.RemoveAll(it => context.IPCPuntos.Any(saved => it.Date == saved.Date));
            IPCs.RemoveAll(it => context.IPCs.Any(saved => it.Date == saved.Date));
            IPCAcumulado12UltimosMeses.RemoveAll(it => context.IPCAcumulados12Meses.Any(saved => it.Date == saved.Date));
            IPCAcumuladoDelAno.RemoveAll(it => context.IPCAcumuladoAnos.Any(saved => it.Date == saved.Date));
        }

        public virtual void PersistHistory(IndicatorsContext context)
        {
            ((DbSet<UF>)context.UFs).AddRange(UFs);
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

        private bool ScrapingForTheFirstTime(IndicatorsContext context)
        {                        
            return context.Empty();
        }

        public virtual void ScrapeCompleteHistory()
            
        {
            foreach (var year in Enumerable.Range(StartYear, EndYear - StartYear))
            {
                Scrape(year);
            }
        }

        public virtual void ScrapeCurrentAndNextYear()
        {
            foreach (var year in Enumerable.Range(EndYear - 1, 1))
            {
                Scrape(year);
            }
        }

        private void Scrape(int year)
        {
            var ufScraper = new UFScraper(year);
            ufScraper.Extract();
            UFs.AddRange(ufScraper.UFs);

            var dolarScraper = new DolarScraper(year);
            dolarScraper.Extract();
            Dolars.AddRange(dolarScraper.Dolars);

            //TODO: Scrape more historic data
            if (year > 2006)
            {
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


    }
}
