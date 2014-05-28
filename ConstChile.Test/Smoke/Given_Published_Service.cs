using ConstChile.Indicators;
using NUnit.Framework;
using System.Net;
using System.Web.Script.Serialization;



namespace ConstChile.Test.Smoke
{
    public class Given_Published_Service
    {

        [Test]
        public void When_March_1st_UF_Obained_Returns_23510_14()
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString("http://ws.empoweragile.cl/api/UF/2014/3/1");              
                UF uf = new JavaScriptSerializer().Deserialize<UF>(json);
                Assert.That(uf.Value, Is.EqualTo(23510.14m));
            }
        }

        [Test]
        public void When_March_UF_Obained_Returns_31_Indicators()
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString("http://ws.empoweragile.cl/api/UF/2014/3");
                var ufs = new JavaScriptSerializer().Deserialize<System.Collections.Generic.List<UF>>(json);
                Assert.That(ufs.Count, Is.EqualTo(31));
            }

        }
    }
}

