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
        bool PostCategory(ForumCategory category);
        bool UpdateCategory(ForumCategory updatedCategory);
        bool DeactivateCategory(ForumCategory deletedCategory);
        List<ForumMessage> GetAllMessages();
        bool PostMessage(ForumMessage newMessage);
        bool UpdateMessage(ForumMessage updatedMessage);
        bool DeactivateMessage(ForumMessage deletedMessage);
        List<ForumResponse> GetAllResponses();
        bool PostResponse(ForumResponse newResponse);
        bool UpdateResponse(ForumResponse updatedResponse);
        bool DeactivateResponse(ForumResponse deletedResponse);
    }
}
