using BeeEngineering.Learning.MoviesApp.Data.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeEngineering.Learning.MoviesApp.Data
{
    public class MovieActor : Entity
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }

        [ForeignKey(nameof(Actor))]
        public int? ActorId { get; set; }
        public virtual Actor? Actor { get; set; }
     
    }
}
