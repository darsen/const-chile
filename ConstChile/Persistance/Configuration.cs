using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace ConstChile.Persistance
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            SetDefaultConnectionFactory(new SqlConnectionFactory("localdb\v11.0"));
            //SetDefaultConnectionFactory(new SqlConnectionFactory("Server=tcp:vcery1gqes.database.windows.net,1433;Database=ConstChile;User ID=LnkCampaigner@vcery1gqes;Password=CocaCola123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"));
            //SetDefaultConnectionFactory(new SqlConnectionFactory("Data Source=vcery1gqes.database.windows.net;Initial Catalog=ConstChile;Integrated Security=False;User ID=LnkCampaigner;Password=CocaCola123;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False"));            
        }
    } 
}
