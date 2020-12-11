using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ForumCategory
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public ForumCategory(int categoryID, string name, DateTime createdDate, bool isActive)
        {
            CategoryID = categoryID;

            Name = name;

            CreatedDate = createdDate;

            IsActive = isActive;
        }

        public ForumCategory()
        {

        }
    }
}
