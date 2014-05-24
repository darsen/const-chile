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

    [RoutePrefix("api/UF")]
    public class UFController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/UF
        public IQueryable<UF> GetUFs()
        {
            return db.UFs;
        }

        // GET api/UF/5
        [ResponseType(typeof(IList<UF>))]
        public async Task<IHttpActionResult> GetUF(string id)
        {
            DateTime date;
            int year;
            IList<UF> ufs = null;
            ufs = new List<UF>(1);
            if (DateTime.TryParse(id, out date))
            {
                var uf = await db.UFs.FindAsync(date);
                ufs.Add(uf);
            }
            else { 
                int.TryParse(id, out year);
                ufs = await db.UFs.Where(it => it.Date.Year == year).ToListAsync();
            }

            if (ufs.Count == 0)
            {
                return NotFound();
            }

            return Ok(ufs);
        }

        // GET api/UF/year/month
        [HttpGet]
        [ResponseType(typeof(IList<UF>))]
        [Route("{year}/{month}")] 
        public async Task<IHttpActionResult> GetUF(int year, int month)
        {
            var ufs = await db.UFs.Where(it => it.Date.Year == year && it.Date.Month == month).ToListAsync();
            if (ufs == null)
            {
                return NotFound();
            }
            return Ok(ufs);
        }

        // GET api/UF/year
        [HttpGet]
        [ResponseType(typeof(UF))]
        [Route("{year}/{month}/{day}")]
        public async Task<IHttpActionResult> GetUF(int year, int month, int day)
        {
            var ufs = await db.UFs.Where(it => it.Date.Year == year && it.Date.Month == month && it.Date.Day == day).FirstOrDefaultAsync();
            if (ufs == null)
            {
                return NotFound();
            }

            return Ok(ufs);
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