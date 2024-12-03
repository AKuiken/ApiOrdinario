using System.ComponentModel.DataAnnotations;

namespace OrdinarioAPIPOO.Models
{
    public class Poster
    {
        [Key]
        public int Id { get; set; } // ID para base de datos local

        [Required]
        public string ?Title { get; set; } // Título de la película

        public string ?Year { get; set; } // Año de lanzamiento

        public string ?Genre { get; set; } // Género de la película

        public string ?Director { get; set; } // Director de la película

        public string ?Actors { get; set; } // Actores principales

        public string ?Plot { get; set; } // Sinopsis

        public string ?PosterUrl { get; set; } // URL del póster

        public string ?imdbRating { get; set; } // Calificación en IMDB
    }
}
