using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IProfileDAO
    {
        Profile GetProfile(int userID);

        List<Profile> GetAllUsers();

        Profile UpdateProfile(Profile updatedProfile);

        bool DeleteProfile(int id);
    }
}
