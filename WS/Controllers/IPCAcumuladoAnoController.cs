using ConstChile.Indicators;
using ConstChile.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace WS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/IPCAcumuladoAno")]
    public class IPCAcumuladoAnoController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/IPCAcumuladoAno
        public IQueryable<IPCAcumuladoAno> GetIPCAcumuladoAnos()
        {
            return db.IPCAcumuladoAnos;
        }

        // GET api/IPCAcumuladoAno/5
        [ResponseType(typeof(IList<IPCAcumuladoAno>))]
        public async Task<IHttpActionResult> GetIPCAcumuladoAno(string id)
        {
            DateTime date;
            int year;
            IList<IPCAcumuladoAno> IPCAcumuladoAnos = null;
            IPCAcumuladoAnos = new List<IPCAcumuladoAno>(1);
            if (DateTime.TryParse(id, out date))
            {
                var IPCAcumuladoAno = await db.IPCAcumuladoAnos.FindAsync(date);
                IPCAcumuladoAnos.Add(IPCAcumuladoAno);
            }
            else
            {
                int.TryParse(id, out year);
                IPCAcumuladoAnos = await db.IPCAcumuladoAnos.Where(it => it.Date.Year == year).ToListAsync();
            }

            if (IPCAcumuladoAnos.Count == 0)
            {
                return NotFound();
            }

            return Ok(IPCAcumuladoAnos);
        }

        // GET api/IPCAcumuladoAno/year/month
        [HttpGet]
        [ResponseType(typeof(IList<IPCAcumuladoAno>))]
        [Route("{year}/{month}")]
        public async Task<IHttpActionResult> GetIPCAcumuladoAno(int year, int month)
        {
            var IPCAcumuladoAnos = await db.IPCAcumuladoAnos.Where(it => it.Date.Year == year && it.Date.Month == month).ToListAsync();
            if (IPCAcumuladoAnos == null)
            {
                return NotFound();
            }
            return Ok(IPCAcumuladoAnos);
        }

        // GET api/IPCAcumuladoAno/year
        [HttpGet]
        [ResponseType(typeof(IPCAcumuladoAno))]
        [Route("{year}/{month}/{day}")]
        public async Task<IHttpActionResult> GetIPCAcumuladoAno(int year, int month, int day)
        {
            var IPCAcumuladoAnos = await db.IPCAcumuladoAnos.Where(it => it.Date.Year == year && it.Date.Month == month).FirstOrDefaultAsync();
            if (IPCAcumuladoAnos == null)
            {
                return NotFound();
            }

            return Ok(IPCAcumuladoAnos);
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