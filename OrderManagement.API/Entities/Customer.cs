using OrderManagement.API.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.API.Entities
{
    public class Customer : BaseEntity
    {
        [MaxLength(70)]
        public string UserName { get; set; }

        public string UserAddress { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
