using Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class CharacterCreateDto
    {
        [Required]
        public string Imagen { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public int Peso { get; set; }

        [Required]
        public string Historia { get; set; }

        public virtual Movie PeliculasAsociadas { get; set; }
    }
}
