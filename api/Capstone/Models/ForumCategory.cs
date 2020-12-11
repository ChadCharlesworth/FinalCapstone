using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ForumCategory
    {
        
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public ForumCategory(int categoryID, string name, DateTime createdDate)
        {
            CategoryID = categoryID;

            Name = name;

            CreatedDate = createdDate;
        }

        public ForumCategory()
        {

        }
    }
}
