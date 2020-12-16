using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPlaydateDAO
    {
        List<Playdate> GetAllPlaydates();
        Playdate CreatePlaydate(Playdate newPlaydate/*, int petID*/);
        Playdate UpdatePlaydate(Playdate updatedPlaydate);
        Playdate UpdatePlaydateByPetID(Playdate updatedPlaydate, int petID);
        bool DeletePlaydate(int playdateID);
        List<Playdate> GetPlaydatesByPetOwner(int ownerID);

    }
}
