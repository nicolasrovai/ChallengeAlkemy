using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.MovieDTOs
{
    public class MovieReadDto
    {
        public string Imagen { get; set; }

        public string Titulo { get; set; }

        public DateTime FechaEstreno { get; set; }
    }
}
