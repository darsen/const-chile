using ConstChile.Indicators;
using ConstChile.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WS.Controllers
{

    [RoutePrefix("api/IPCAcumulado12Meses")]
    public class IPCAcumulado12MesesController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/IPCAcumulado12Meses
        public IQueryable<IPCAcumulado12Meses> GetIPCAcumulado12Mesess()
        {
            return db.IPCAcumulados12Meses;
        }

        // GET api/IPCAcumulado12Meses/5
        [ResponseType(typeof(IList<IPCAcumulado12Meses>))]
        public async Task<IHttpActionResult> GetIPCAcumulado12Meses(string id)
        {
            DateTime date;
            int year;
            IList<IPCAcumulado12Meses> IPCAcumulado12Mesess = null;
            IPCAcumulado12Mesess = new List<IPCAcumulado12Meses>(1);
            if (DateTime.TryParse(id, out date))
            {
                var IPCAcumulado12Meses = await db.IPCAcumulados12Meses.FindAsync(date);
                IPCAcumulado12Mesess.Add(IPCAcumulado12Meses);
            }
            else
            {
                int.TryParse(id, out year);
                IPCAcumulado12Mesess = await db.IPCAcumulados12Meses.Where(it => it.Date.Year == year).ToListAsync();
            }

            if (IPCAcumulado12Mesess.Count == 0)
            {
                return NotFound();
            }

            return Ok(IPCAcumulado12Mesess);
        }

        // GET api/IPCAcumulado12Meses/year/month
        [HttpGet]
        [ResponseType(typeof(IList<IPCAcumulado12Meses>))]
        [Route("{year}/{month}")]
        public async Task<IHttpActionResult> GetIPCAcumulado12Meses(int year, int month)
        {
            var IPCAcumulado12Mesess = await db.IPCAcumulados12Meses.Where(it => it.Date.Year == year && it.Date.Month == month).ToListAsync();
            if (IPCAcumulado12Mesess == null)
            {
                return NotFound();
            }
            return Ok(IPCAcumulado12Mesess);
        }

        // GET api/IPCAcumulado12Meses/year
        [HttpGet]
        [ResponseType(typeof(IPCAcumulado12Meses))]
        [Route("{year}/{month}/{day}")]
        public async Task<IHttpActionResult> GetIPCAcumulado12Meses(int year, int month, int day)
        {
            var IPCAcumulado12Mesess = await db.IPCAcumulados12Meses.Where(it => it.Date.Year == year && it.Date.Month == month).FirstOrDefaultAsync();
            if (IPCAcumulado12Mesess == null)
            {
                return NotFound();
            }

            return Ok(IPCAcumulado12Mesess);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}