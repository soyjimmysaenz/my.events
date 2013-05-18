using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EventosImportantes.Web.API.Contracts;
using EventosImportantes.Web.API.Models.Database;

namespace EventosImportantes.Web.API.Models.Repositories
{ 
    public class EventoRepository : IEventoRepository
    {
        EventosContext context = new EventosContext();

        public IQueryable<Evento> All
        {
            get { return context.Eventos; }
        }

        public IQueryable<Evento> AllIncluding(params Expression<Func<Evento, object>>[] includeProperties)
        {
            IQueryable<Evento> query = context.Eventos;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Evento Find(int id)
        {
            return context.Eventos.Find(id);
        }

        public void InsertOrUpdate(Evento evento)
        {
            if (evento.Id == default(int)) {
                // New entity
                context.Eventos.Add(evento);
            } else {
                // Existing entity
                context.Entry(evento).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var evento = context.Eventos.Find(id);
            context.Eventos.Remove(evento);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    
}