using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Genre
    {
        [Column("Genero Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Nombre")]
        [Required]
        public string Nombre { get; set; }

        [Column("Imagen")]
        [Required]
        public string Imagen { get; set; }

        [Column("Peliculas Asociadas")]
        [ForeignKey("Pelicula Id")]
        public Movie PeliculasAsociadas { get; set; }
    }
}
