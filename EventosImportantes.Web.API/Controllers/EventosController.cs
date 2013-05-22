using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using EventosImportantes.Web.API.Contracts;
using EventosImportantes.Web.API.Models;
using EventosImportantes.Web.API.Models.Repositories;

namespace EventosImportantes.Web.API.Controllers
{
    public class EventosController : ApiController
    {
		private readonly IEventoRepository eventoRepository;
        
        public EventosController() : this(new EventoRepository())
        {
        }

        public EventosController(IEventoRepository eventoRepository)
        {
			this.eventoRepository = eventoRepository;
        }

        //
        // GET: /api/eventos/

        public IEnumerable<Evento> Get()
        {
            Thread.Sleep(1000); // sólo para efectos de demo
            return eventoRepository.All;
        }
         
        //
        // GET: /api/eventos/5

        public Evento Get(int id)
        {
            return eventoRepository.Find(id);
        }

        //
        // POST: api/eventos/
        public HttpResponseMessage Post(Evento evento)
        {
            eventoRepository.InsertOrUpdate(evento);
            eventoRepository.Save();
            var response = Request.CreateResponse(HttpStatusCode.Created, evento);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new {id = evento.Id}));
            return response;
        }

        //
        // PUT: api/eventos/5
        public HttpResponseMessage Put(Evento evento)
        {
            eventoRepository.InsertOrUpdate(evento);
            eventoRepository.Save();
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        //
        // DELETE: api/eventos/5
        public HttpResponseMessage Delete(int id)
        {
            eventoRepository.Delete(id);
            eventoRepository.Save();

            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
         
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                eventoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

