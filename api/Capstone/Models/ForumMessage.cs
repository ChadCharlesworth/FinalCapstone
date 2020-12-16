using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ForumMessage
    {
        public int MessageID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Message_Title { get; set; }
        public string Message_Body { get; set; }
        
        public string CreatedDate { get; set; }

        public ForumMessage()
        {

        }
    }
}
