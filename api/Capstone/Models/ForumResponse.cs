using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ForumResponse
    {
        public int ResponseID { get; set; }
        public int UserID { get; set; }
        public int MessageID { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public ForumResponse(int responseID, int userID, int messageID, string body, DateTime createdDate, bool isActive)
        {
            ResponseID = responseID;

            UserID = userID;

            MessageID = messageID;

            Body = body;

            CreatedDate = createdDate;

            IsActive = isActive;
        }
        public ForumResponse()
        {

        }
    }
}
