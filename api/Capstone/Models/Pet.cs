using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Pet
    {
        [Required]
        public int Owner_ID { get; set; }
        [Required]
        public string Pet_Name { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Size { get; set; }
        public string Personality { get; set; }
        public int Pet_ID { get; set; }
    }
}
