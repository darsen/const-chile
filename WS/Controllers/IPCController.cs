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

    [RoutePrefix("api/IPC")]
    public class IPCController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/IPC
        public IQueryable<IPC> GetIPCs()
        {
            return db.IPCs;
        }

        // GET api/IPC/5
        [ResponseType(typeof(IList<IPC>))]
        public async Task<IHttpActionResult> GetIPC(string id)
        {
            DateTime date;
            int year;
            IList<IPC> IPCs = null;
            IPCs = new List<IPC>(1);
            if (DateTime.TryParse(id, out date))
            {
                var IPC = await db.IPCs.FindAsync(date);
                IPCs.Add(IPC);
            }
            else
            {
                int.TryParse(id, out year);
                IPCs = await db.IPCs.Where(it => it.Date.Year == year).ToListAsync();
            }

            if (IPCs.Count == 0)
            {
                return NotFound();
            }

            return Ok(IPCs);
        }

        // GET api/IPC/year/month
        [HttpGet]
        [ResponseType(typeof(IList<IPC>))]
        [Route("{year}/{month}")]
        public async Task<IHttpActionResult> GetIPC(int year, int month)
        {
            var IPCs = await db.IPCs.Where(it => it.Date.Year == year && it.Date.Month == month).ToListAsync();
            if (IPCs == null)
            {
                return NotFound();
            }
            return Ok(IPCs);
        }

        // GET api/IPC/year
        [HttpGet]
        [ResponseType(typeof(IPC))]
        [Route("{year}/{month}/{day}")]
        public async Task<IHttpActionResult> GetIPC(int year, int month, int day)
        {
            var IPCs = await db.IPCs.Where(it => it.Date.Year == year && it.Date.Month == month).FirstOrDefaultAsync();
            if (IPCs == null)
            {
                return NotFound();
            }

            return Ok(IPCs);
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