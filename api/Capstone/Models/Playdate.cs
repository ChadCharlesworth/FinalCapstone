﻿using System;
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
        public string Date_Time { get; set; }
        [Required]
        public int Creator_User_ID { get; set; }
        public int Number_Of_Attendees { get; set; }
        [Required]
        public bool Is_Private { get; set; }
        public Dictionary<int, string> Pet_Approval_Status { get; set; } = new Dictionary<int, string>();
        public List<int> Attending { get; set; } = new List<int>();
        public List<int> Pending { get; set; } = new List<int>();
        public List<int> Declined { get; set; } = new List<int>();
    }
}
