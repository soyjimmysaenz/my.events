using System;
using System.Data.Entity;

namespace EventosImportantes.Web.API.Models.Database
{
    public class EventosDbInitializer:DropCreateDatabaseIfModelChanges<EventosContext>
    {
        protected override void Seed(EventosContext context)
        {
            context.Eventos.Add(new Evento()
                {
                    Nombre = "Graduación UCA 2013",
                    Descripcion = "Graduación de los alumnos UCA de todas las carreras",
                    FechaRealizacion = new DateTime(2013, 5, 31, 16, 0, 0),
                    Importancia = 10,
                    Lugar = "Crowne Plaza, Managua"
                });

            context.Eventos.Add(new Evento()
            {
                Nombre = "FLISOL 2013",
                Descripcion = "Festival del Software Libre",
                FechaRealizacion = new DateTime(2013, 5, 5, 8, 0, 0),
                Importancia = 7,
                Lugar = "Cultura Quilombo, Managua"
            });

            context.Eventos.Add(new Evento()
            {
                Nombre = "Final de la Champions League 2013",
                Descripcion = "Bayern VS Borussia",
                FechaRealizacion = new DateTime(2013, 5, 25, 12, 30, 0),
                Importancia = 5,
                Lugar = "Wembley Stadium, Inglaterra"
            });

            base.Seed(context);
        }
    }
}