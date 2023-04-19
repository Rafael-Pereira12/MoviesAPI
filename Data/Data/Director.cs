using BeeEngineering.Learning.MoviesApp.Data.Base;
using System;

namespace BeeEngineering.Learning.MoviesApp.Data
{

	public class Director : NamedEntity
	{
		public DateTime? BirthDate { get; set; }

		public IEnumerable <Movie>? Movies { get; set; }
		
		public Director(DateTime _BirthDate, string _Name) : base(_Name)
		{
			BirthDate = _BirthDate;
		}
	}
}
