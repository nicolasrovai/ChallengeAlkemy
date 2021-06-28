using Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.MovieDTOs
{
    public class MovieUpdateDto
    {
        public string Imagen { get; set; }

        public string Titulo { get; set; }

        public DateTime FechaEstreno { get; set; }

        public int Calficacion { get; set; }

        public virtual Character PersonajesAsociados { get; set; }
    }
}
