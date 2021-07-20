using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Referencias entity framework
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ControlBitacorasESFE.EL;
namespace ControlBitacorasESFE.DAL
{
    public class ProjectContext : DbContext
    {
        //Cadena de conexion a Sql Server
        const string connString = @"Data Source=DESKTOP-5HB08K0\SQLEXPRESS01; initial Catalog=ControlBitacoras; Integrated Security=True";

        public ProjectContext() : base(connString)
        {
            var ensureDLLIsCopied = SqlProviderServices.Instance;
            Database.SetInitializer<ProjectContext>(new CreateDatabaseIfNotExists<ProjectContext>());
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<EquipoArea> EquipoAreas { get; set; }
        public DbSet<Falla> Fallas { get; set; }
        public DbSet<Monitor> Monitors { get; set; }
        public DbSet<Mueble> Muebles { get; set; }
        public DbSet<Procesador> Procesadors { get; set; }
        public DbSet<PuestosTrabajo> PuestosTrabajos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TipoArea> TipoAreas { get; set; }
        public DbSet<TipoFalla> TipoFallas { get; set; }
        public DbSet<Ups> Upss { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}