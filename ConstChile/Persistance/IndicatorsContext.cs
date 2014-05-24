﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstChile.Indicators;

namespace ConstChile.Persistance
{
    [DbConfigurationType(typeof(ConstChileDbConfiguration))] 
    public class IndicatorsContext : DbContext
    {
        public IndicatorsContext()
            : base("Data Source=localhost; Database=ConstChile;Integrated Security=True;")   
        {
            Debug.Write("Connection String:" + Database.Connection.ConnectionString);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<IndicatorsContext>());            
        }

        public DbSet<UF> UFs { get; set; }
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
    }
}
