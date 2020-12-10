using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Profile
    {
        [Required]
        public string First_Name { get; set; }

        [Required]
        public string Last_Name { get; set; }
        
        public string user_role { get; set; }
        
        [Required]
        public int user_id { get; set; }
        
        [Required]
        public string username { get; set; }
        
        public List<int> Address_Ids { get; set; } = new List<int>();
        
        public List<int> Pet_Ids { get; set; } = new List<int>();
        
        public List<Playdate> Playdates { get; set; } = new List<Playdate>();
    }
}
