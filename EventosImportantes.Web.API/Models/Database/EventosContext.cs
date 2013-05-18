using System.Data.Entity;

namespace EventosImportantes.Web.API.Models.Database
{
    public class EventosContext:DbContext
    {
        public DbSet<Evento> Eventos { get; set; }

        public EventosContext()
            : base("name=DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().ToTable("Eventos");
            base.OnModelCreating(modelBuilder);
        }
    }
}