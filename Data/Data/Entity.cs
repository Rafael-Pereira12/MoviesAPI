using System.ComponentModel.DataAnnotations;

namespace BeeEngineering.Learning.MoviesApp.Data.Base
{
    public abstract class Entity
    {
		    [Key]
		    public int Id { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdateAt { get; set; }
            public DateTime DeletedAt { get; set; }
            public virtual bool IsDeleted => DeletedAt != DateTime.MinValue;
            public Guid Uuid { get; set; }
    }
}
