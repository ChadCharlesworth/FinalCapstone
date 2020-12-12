using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IAddressDAO
    {
        List<Address> GetAddresses();
        Address AddAddress(Address newAddress, int userID);
        Address UpdateAddress(Address revisedAddress);
        bool DeleteAddress(int id);

    }
}
