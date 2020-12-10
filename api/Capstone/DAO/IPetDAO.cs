using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IPetDAO
    {
        List<Pet> GetPets();
        Pet AddPet(Pet newPet);
        Pet UpdatePet(Pet updatePet);
        bool DeletePet(int id); 

    }
}
