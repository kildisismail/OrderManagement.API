using System;

namespace OrderManagement.API.Entities.Base
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
    }
}
