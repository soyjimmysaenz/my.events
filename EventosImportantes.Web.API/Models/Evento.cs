using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventosImportantes.Web.API.Models
{
    public class Evento
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El tamaño máximo es 100")]
        public string Nombre { get; set; }
        [StringLength(300, ErrorMessage = "El tamaño máximo es 300")]
        public string Descripcion { get; set; }
        [Required]
        public DateTime FechaRealizacion { get; set; }
        [Range(1,10, ErrorMessage = "El rango debe estar entre 1 y 10")]
        public int Importancia { get; set; }
        [StringLength(50, ErrorMessage = "El tamaño máximo es 50")]
        public string Lugar { get; set; }
    }
}