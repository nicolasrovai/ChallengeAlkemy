using Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.MovieDTOs
{
    public class MovieCreateDto
    { 
        [Required]
        public string Imagen { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public DateTime FechaEstreno { get; set; }

        [Required]
        public int Calficacion { get; set; }

        public virtual Character PersonajesAsociados { get; set; }
    }
}
