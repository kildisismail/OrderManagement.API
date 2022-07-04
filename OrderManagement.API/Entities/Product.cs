using OrderManagement.API.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.API.Entities
{
    public class Product:BaseEntity
    {
        public string BarcodeNumber { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
    }
}
