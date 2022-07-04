using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.API.Entities.Base
{
    [Serializable]
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        //[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool Active { get; set; } = true;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
