﻿using ConstChile.Indicators;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace ConstChile.Persistance
{
    [DbConfigurationType(typeof(ConstChileDbConfiguration))] 
    public class IndicatorsContext : DbContext
    {
        public IndicatorsContext()
            : base("Server=tcp:vcery1gqes.database.windows.net,1433;Database=ConstChile;User ID=LnkCampaigner@vcery1gqes;Password=CocaCola123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")   
        {
            Debug.Write("Connection String:" + Database.Connection.ConnectionString);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IndicatorsContext>());            
        }

        public virtual IDbSet<UF> UFs { get; set; }
        public DbSet<Dolar> Dolars { get; set;}
        public DbSet<UTA> UTAs { get; set; }
        public DbSet<UTM> UTMs { get; set; }
        public DbSet<IPCPunto> IPCPuntos { get; set; }
        public DbSet<IPC> IPCs { get; set; }
        public DbSet<IPCAcumuladoAno> IPCAcumuladoAnos { get; set; }
        public DbSet<IPCAcumulado12Meses> IPCAcumulados12Meses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
        }

        public virtual bool Empty() {
           return  !UFs.Any(); 
        }
    }
}
