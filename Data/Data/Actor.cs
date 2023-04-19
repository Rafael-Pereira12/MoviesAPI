using BeeEngineering.Learning.MoviesApp.Data.Base;
using System;

namespace BeeEngineering.Learning.MoviesApp.Data
{

	public class Actor : NamedEntity
	{
		public DateTime? BirthDate { get; set; }

        public IEnumerable<MovieActor>? Movies	{ get; set; }

        public Actor(DateTime _BirthDate, string _Name) : base(_Name) 
		{
			BirthDate = _BirthDate;
		}
	
	}
}
