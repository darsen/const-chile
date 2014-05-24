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

    [RoutePrefix("api/UTA")]
    public class UTAController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/UTA
        public IQueryable<UTA> GetUTAs()
        {
            return db.UTAs;
        }

        // GET api/UTA/5
        [ResponseType(typeof(IList<UTA>))]
        public async Task<IHttpActionResult> GetUTA(string id)
        {
            DateTime date;
            int year;
            IList<UTA> UTAs = null;
            UTAs = new List<UTA>(1);
            if (DateTime.TryParse(id, out date))
            {
                var UTA = await db.UTAs.FindAsync(date);
                UTAs.Add(UTA);
            }
            else
            {
                int.TryParse(id, out year);
                UTAs = await db.UTAs.Where(it => it.Date.Year == year).ToListAsync();
            }

            if (UTAs.Count == 0)
            {
                return NotFound();
            }

            return Ok(UTAs);
        }

        // GET api/UTA/year/month
        [HttpGet]
        [ResponseType(typeof(IList<UTA>))]
        [Route("{year}/{month}")]
        public async Task<IHttpActionResult> GetUTA(int year, int month)
        {
            var UTAs = await db.UTAs.Where(it => it.Date.Year == year && it.Date.Month == month).ToListAsync();
            if (UTAs == null)
            {
                return NotFound();
            }
            return Ok(UTAs);
        }

        // GET api/UTA/year
        [HttpGet]
        [ResponseType(typeof(UTA))]
        [Route("{year}/{month}/{day}")]
        public async Task<IHttpActionResult> GetUTA(int year, int month, int day)
        {
            var UTAs = await db.UTAs.Where(it => it.Date.Year == year && it.Date.Month == month).FirstOrDefaultAsync();
            if (UTAs == null)
            {
                return NotFound();
            }

            return Ok(UTAs);
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