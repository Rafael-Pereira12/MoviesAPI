using System;
using System.ComponentModel.DataAnnotations.Schema;
using BeeEngineering.Learning.MoviesApp.Data.Base;


namespace BeeEngineering.Learning.MoviesApp.Data
{
	public class Movie : Entity
	{
		public string Title { get; set; }

		public DateTime ReleaseDate { get; set; }

		[ForeignKey(nameof(Director))]
		public int? DirectorId { get; set; }
		public virtual Director? Director { get; set; }

		public IEnumerable<MovieGenre>? Genres { get; set; }

        public IEnumerable<MovieActor>? Actors { get; set; }

	}

}
