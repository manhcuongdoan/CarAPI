using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarAPI.Models
{
    public class CarType
    {
        [Key]
        public int CarTypeId { get; set; }
        public string CarTypeName { get; set; }

        public List<CarSpecification> CarSpecification { get; }
    }
}