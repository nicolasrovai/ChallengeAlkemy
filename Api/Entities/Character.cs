using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Character
    {
        [Column("Personaje Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Imagen")]
        [Required]
        public string Imagen { get; set; }

        [Column("Nombre")]
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Column("Edad")]
        [Required]
        public int Edad { get; set; }

        [Column("Peso")]
        [Required]
        public int Peso { get; set; }

        [Column("Historia")]
        [Required]
        [MaxLength(250)]
        public string Historia { get; set; }

        [Column("Peliculas Asociadas")]
        [ForeignKey("Pelicula Id")]
        public virtual Movie PeliculasAsociadas { get; set; }
    }
}
