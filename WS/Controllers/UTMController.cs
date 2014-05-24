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

    [RoutePrefix("api/UTM")]
    public class UTMController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/UTM
        public IQueryable<UTM> GetUTMs()
        {
            return db.UTMs;
        }

        // GET api/UTM/5
        [ResponseType(typeof(IList<UTM>))]
        public async Task<IHttpActionResult> GetUTM(string id)
        {
            DateTime date;
            int year;
            IList<UTM> UTMs = null;
            UTMs = new List<UTM>(1);
            if (DateTime.TryParse(id, out date))
            {
                var UTM = await db.UTMs.FindAsync(date);
                UTMs.Add(UTM);
            }
            else
            {
                int.TryParse(id, out year);
                UTMs = await db.UTMs.Where(it => it.Date.Year == year).ToListAsync();
            }

            if (UTMs.Count == 0)
            {
                return NotFound();
            }

            return Ok(UTMs);
        }

        // GET api/UTM/year/month
        [HttpGet]
        [ResponseType(typeof(IList<UTM>))]
        [Route("{year}/{month}")]
        public async Task<IHttpActionResult> GetUTM(int year, int month)
        {
            var UTMs = await db.UTMs.Where(it => it.Date.Year == year && it.Date.Month == month).ToListAsync();
            if (UTMs == null)
            {
                return NotFound();
            }
            return Ok(UTMs);
        }

        // GET api/UTM/year
        [HttpGet]
        [ResponseType(typeof(UTM))]
        [Route("{year}/{month}/{day}")]
        public async Task<IHttpActionResult> GetUTM(int year, int month, int day)
        {
            var UTMs = await db.UTMs.Where(it => it.Date.Year == year && it.Date.Month == month).FirstOrDefaultAsync();
            if (UTMs == null)
            {
                return NotFound();
            }

            return Ok(UTMs);
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