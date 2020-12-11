using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IForumDAO
    {
        List<ForumCategory> GetAllCategories();
        ForumCategory PostCategory(ForumCategory category);
        ForumCategory UpdateCategory(ForumCategory updatedCategory);
        bool DeactivateCategory(ForumCategory deletedCategory);
        List<ForumMessage> GetAllMessages();
        ForumMessage PostMessage(ForumMessage newMessage);
        ForumMessage UpdateMessage(ForumMessage updatedMessage);
        bool DeactivateMessage(ForumMessage deletedMessage);
        List<ForumResponse> GetAllResponses();
        ForumResponse PostResponse(ForumResponse newResponse);
        ForumResponse UpdateResponse(ForumResponse updatedResponse);
        bool DeactivateResponse(ForumResponse deletedResponse);
    }
}
