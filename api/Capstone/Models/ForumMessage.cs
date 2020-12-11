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
        public int CategoryID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public ForumMessage(int messageID, int categoryID, int userID, string title, string body, DateTime createdDate)
        {
            MessageID = messageID;

            CategoryID = categoryID;

            UserID = userID;

            Title = title;

            Body = body;

            CreatedDate = createdDate;
        }
        public ForumMessage()
        {

        }
    }
}
