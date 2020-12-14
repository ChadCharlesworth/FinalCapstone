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
        [Required]
        public DateTime CreatedDate { get; set; }

        public ForumMessage(int messageID, int userID, string title, string body, DateTime createdDate)
        {
            MessageID = messageID;

            UserID = userID;

            Message_Title = title;

            Message_Body = body;

            CreatedDate = createdDate;
        }
        public ForumMessage()
        {

        }
    }
}
