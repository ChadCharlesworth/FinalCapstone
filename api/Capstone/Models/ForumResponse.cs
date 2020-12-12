using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ForumResponse
    {
        public int ResponseID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int MessageID { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        
    }
}
