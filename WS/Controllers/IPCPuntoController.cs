using ConstChile.Indicators;
using ConstChile.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Cors;

namespace WS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/IPCPunto")]
    public class IPCPuntoController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/IPCPunto
        public IQueryable<IPCPunto> GetIPCPuntos()
        {
            return db.IPCPuntos;
        }

        // GET api/IPCPunto/5
        [ResponseType(typeof(IList<IPCPunto>))]
        public async Task<IHttpActionResult> GetIPCPunto(string id)
        {
            DateTime date;
            int year;
            IList<IPCPunto> IPCPuntos = null;
            IPCPuntos = new List<IPCPunto>(1);
            if (DateTime.TryParse(id, out date))
            {
                var IPCPunto = await db.IPCPuntos.FindAsync(date);
                IPCPuntos.Add(IPCPunto);
            }
            else
            {
                int.TryParse(id, out year);
                IPCPuntos = await db.IPCPuntos.Where(it => it.Date.Year == year).ToListAsync();
            }

            if (IPCPuntos.Count == 0)
            {
                return NotFound();
            }

            return Ok(IPCPuntos);
        }

        // GET api/IPCPunto/year/month
        [HttpGet]
        [ResponseType(typeof(IList<IPCPunto>))]
        [Route("{year}/{month}")]
        public async Task<IHttpActionResult> GetIPCPunto(int year, int month)
        {
            var IPCPuntos = await db.IPCPuntos.Where(it => it.Date.Year == year && it.Date.Month == month).ToListAsync();
            if (IPCPuntos == null)
            {
                return NotFound();
            }
            return Ok(IPCPuntos);
        }

        // GET api/IPCPunto/year
        [HttpGet]
        [ResponseType(typeof(IPCPunto))]
        [Route("{year}/{month}/{day}")]
        public async Task<IHttpActionResult> GetIPCPunto(int year, int month, int day)
        {
            var IPCPuntos = await db.IPCPuntos.Where(it => it.Date.Year == year && it.Date.Month == month && it.Date.Day == day).FirstOrDefaultAsync();
            if (IPCPuntos == null)
            {
                return NotFound();
            }

            return Ok(IPCPuntos);
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