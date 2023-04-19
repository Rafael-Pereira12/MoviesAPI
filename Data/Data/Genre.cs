using BeeEngineering.Learning.MoviesApp.Data.Base;
using System;

namespace BeeEngineering.Learning.MoviesApp.Data
{
	public class Genre: NamedEntity
	{
        public IEnumerable<MovieGenre>? Movies { get; set; }

        public Genre(string _Name) : base(_Name) 
		{
		}
	}

}
