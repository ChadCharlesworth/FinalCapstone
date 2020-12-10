﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IAddressDAO
    {
        List<Address> getAddresses();
        Address addAddress(Address newAddress, int userID);
        Address updateAddress(Address revisedAddress);
        bool deleteAddress(int id);

    }
}
