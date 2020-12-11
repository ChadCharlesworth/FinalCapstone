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
        Playdate CreatePlaydate(Playdate playdate, int petID);
        Playdate UpdatePlaydate(Playdate playdate);
        bool DeletePlaydate(Playdate playdate);
    }
}
