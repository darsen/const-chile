using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConstChile.Sii;

namespace WS.Controllers
{
    public class HistoryController : ApiController
    {
        [HttpGet]
        public void Scrape()
        {
            var historicScraper = new HistoricScraper();
            historicScraper.ExtractAll();
        }
    }
}
