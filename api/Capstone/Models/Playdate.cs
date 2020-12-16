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
        public int Address_ID { get; set; }
        public DateTime Date_Time { get; set; }
        public int Creator_User_ID { get; set; }
        public int Number_Of_Attendees { get; set; }
        public bool Is_Private { get; set; }
        public List<int> Attending { get; set; } = new List<int>();
        public List<int> Pending { get; set; } = new List<int>();
        public List<int> Declined { get; set; } = new List<int>();
        public string Street_Address_1 { get; set; }
        public string Street_Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Date_Time_String { get; set; }
        public string Approval_Status { get; set; }
        public string Pet_Name { get; set; }
        public int Pet_ID { get; set; }
    }
}
