using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Playdate
    {
        public int Playdate_ID { get; set; }
        [Required]
        public int Address_ID { get; set; }
        [Required]
        public DateTime Date_Time { get; set; }
        [Required]
        public int Creator_User_ID { get; set; }
        [Required]
        public int Number_Of_Attendees { get; set; }
        [Required]
        public int Is_Private { get; set; }
    }
}
