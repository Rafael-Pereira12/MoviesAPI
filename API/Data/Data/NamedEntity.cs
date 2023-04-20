using System;

namespace BeeEngineering.Learning.MoviesApp.Data.Base
{
    public abstract class NamedEntity : Entity
    {
        public string Name { get; set; }

        public NamedEntity(string _Name)
        {
            Name = _Name;
        }
    }
}