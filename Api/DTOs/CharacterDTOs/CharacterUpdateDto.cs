using Api.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class CharacterUpdateDto
    {
     
        public string Imagen { get; set; }

 
        public string Nombre { get; set; }

 
        public int Edad { get; set; }

 
        public int Peso { get; set; }


        public string Historia { get; set; }

 
        public virtual Movie PeliculasAsociadas { get; set; }
    }
}
