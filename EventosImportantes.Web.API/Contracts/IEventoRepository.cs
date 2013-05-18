using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EventosImportantes.Web.API.Models;

namespace EventosImportantes.Web.API.Contracts
{
    public interface IEventoRepository : IDisposable
    {
        IQueryable<Evento> All { get; }
        IQueryable<Evento> AllIncluding(params Expression<Func<Evento, object>>[] includeProperties);
        Evento Find(int id);
        void InsertOrUpdate(Evento evento);
        void Delete(int id);
        void Save();
    }
}
