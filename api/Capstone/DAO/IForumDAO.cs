using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IForumDAO
    {
        List<ForumMessage> GetAllMessages();
        ForumMessage PostMessage(ForumMessage newMessage);
        ForumMessage UpdateMessage(ForumMessage updatedMessage);
        bool DeactivateMessage(int deletedMessageID);
        List<ForumResponse> GetAllResponses();
        ForumResponse PostResponse(ForumResponse newResponse);
        ForumResponse UpdateResponse(ForumResponse updatedResponse);
        bool DeactivateResponse(int deletedResponseID);
        ForumMessage GetMessage(int id);
        ForumResponse GetResponse(int id);
    }
}
