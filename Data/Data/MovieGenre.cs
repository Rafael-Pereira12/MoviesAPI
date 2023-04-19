using BeeEngineering.Learning.MoviesApp.Data.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeEngineering.Learning.MoviesApp.Data
{
    public class MovieGenre : Entity
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }

        [ForeignKey(nameof(Genre))]
        public int? GenreId { get; set; }
        public virtual Genre? Genre { get; set; }

        public MovieGenre()
        {
        }
    }

}