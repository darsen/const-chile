using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ConstChile.Indicators;
using ConstChile.Persistance;

namespace WS.Controllers
{
    public class UFController : ApiController
    {
        private IndicatorsContext db = new IndicatorsContext();

        // GET api/UF
        public IQueryable<UF> GetUFs()
        {
            return db.UFs;
        }

        // GET api/UF/5
        [ResponseType(typeof(UF))]
        public async Task<IHttpActionResult> GetUF(DateTime id)
        {
            UF uf = await db.UFs.FindAsync(id);
            if (uf == null)
            {
                return NotFound();
            }

            return Ok(uf);
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