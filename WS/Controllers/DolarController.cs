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
    [RoutePrefix("api/Dolar")]
    public class DolarController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/Dolar
        public IQueryable<Dolar> GetDolars()
        {
            return db.Dolars;
        }

        // GET api/Dolar/5
        [ResponseType(typeof(IList<Dolar>))]
        public async Task<IHttpActionResult> GetDolar(string id)
        {
            DateTime date;
            int year;
            IList<Dolar> Dolars = null;
            Dolars = new List<Dolar>(1);
            if (DateTime.TryParse(id, out date))
            {
                var Dolar = await db.Dolars.FindAsync(date);
                Dolars.Add(Dolar);
            }
            else
            {
                int.TryParse(id, out year);
                Dolars = await db.Dolars.Where(it => it.Date.Year == year).ToListAsync();
            }

            if (Dolars.Count == 0)
            {
                return NotFound();
            }

            return Ok(Dolars);
        }

        // GET api/Dolar/year/month
        [HttpGet]
        [ResponseType(typeof(IList<Dolar>))]
        [Route("{year}/{month}")]
        public async Task<IHttpActionResult> GetDolar(int year, int month)
        {
            var Dolars = await db.Dolars.Where(it => it.Date.Year == year && it.Date.Month == month).ToListAsync();
            if (Dolars == null)
            {
                return NotFound();
            }
            return Ok(Dolars);
        }

        // GET api/Dolar/year
        [HttpGet]
        [ResponseType(typeof(Dolar))]
        [Route("{year}/{month}/{day}")]
        public async Task<IHttpActionResult> GetDolar(int year, int month, int day)
        {
            var Dolars = await db.Dolars.Where(it => it.Date.Year == year && it.Date.Month == month && it.Date.Day == day).FirstOrDefaultAsync();
            if (Dolars == null)
            {
                return NotFound();
            }

            return Ok(Dolars);
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