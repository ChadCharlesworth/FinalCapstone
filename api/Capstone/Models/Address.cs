using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Address
    {
        public int Address_ID { get; set; }

        [Required]
        public string Street_Address_1 { get; set; }
        
        public string Street_Address_2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
