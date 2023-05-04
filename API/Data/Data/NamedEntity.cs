using System;

namespace BeeEngineering.Learning.MoviesApp.Data.Base
{
    public abstract class NamedEntity : Entity
    {
        public string? Name { get; set; }

    }
}