using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ForumMessage
    {
        public int MessageID { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public ForumMessage(int messageID, int categoryID, int userID, string title, string body, DateTime createdDate, bool isActive)
        {
            MessageID = messageID;

            CategoryID = categoryID;

            UserID = userID;

            Title = title;

            Body = body;

            CreatedDate = createdDate;

            IsActive = isActive;
        }
        public ForumMessage()
        {

        }
    }
}
