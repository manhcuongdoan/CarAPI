using System;
using System.ComponentModel.DataAnnotations;

namespace CarAPI.Models
{
    public class CarSpecification
    {
        [Key]
        public int CarId { get; set; }
        
        public string CarName { get; set; }
        
        public int CarTypeId { get; set; }
        public DateTime DateCreateAt { get; set; }
        public string CarUrl { get; set; }
        public CarType CarType { get; }
    }
}