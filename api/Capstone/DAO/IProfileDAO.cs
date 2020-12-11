using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IProfileDAO
    {
        Profile GetProfile(string username);

        List<Profile> GetAllUsers();

        Profile AddProfile(Profile newProfile);

        Profile UpdateProfile(Profile updatedProfile);

        bool DeleteProfile(int id);
    }
}
