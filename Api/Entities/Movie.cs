using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Movie
    {
        [Column("Pelicula Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Imagen")]
        [Required]
        public string Imagen { get; set; }

        [Column("Titulo")]
        [Required]
        [MaxLength(250)]
        public string Titulo { get; set; }

        [Column("Fecha de Estreno")]
        [Required]
        public DateTime FechaEstreno { get; set; }

        [Column("Caificacion")]
        [Required]
        public int Calficacion { get; set; }

        [ForeignKey("Personaje Id")]
        [Column("Personajes Asociados")]
        public virtual Character PersonajesAsociados { get; set; }
    }
}
