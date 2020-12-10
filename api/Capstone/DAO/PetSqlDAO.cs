using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PetSqlDAO: IPetDAO
    {
        private readonly string connectionString;

        public PetSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Pet AddPet(Pet newPet)
        {
            {

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        
                        
                        SqlCommand cmd = new SqlCommand("insert into Pet (Owner_ID,Pet_Name,Species,Breed,Size,Personality) values (@userID,@petName,@species,@breed,@size,@personality)", conn);
                        cmd.Parameters.AddWithValue("@userID", newPet.Owner_ID);
                        cmd.Parameters.AddWithValue("@petName", newPet.Pet_Name);
                        cmd.Parameters.AddWithValue("@species", newPet.Species);
                        cmd.Parameters.AddWithValue("@breed", newPet.Breed);
                        cmd.Parameters.AddWithValue("@size", newPet.Size);
                        cmd.Parameters.AddWithValue("@personality", newPet.Personality);
                        newPet.Pet_ID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (SqlException)
                {
                    throw;
                }

                return newPet;
            }
        }

        public bool DeletePet(int id)
        {
            SqlCommand cmd = new SqlCommand("update Pet set Is_Active = 0 where Pet_ID = @petID);
            cmd.Parameters.AddWithValue("@petID", id.pet_id);
        }

        public List<Pet> GetPets()
        {
            return new NotImplementedException();
        }

        public Pet UpdatePet(Pet updatePet)
        {
            {

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        
                        SqlCommand cmd = new SqlCommand("update Pet set Pet_Name = @petName, Species = @species, Breed = @breed, Size = @size, Personality = @personality where Pet_ID = @petID");
                        cmd.Parameters.AddWithValue("@petID", updatePet.Pet_ID);
                        cmd.Parameters.AddWithValue("@petName", updatePet.Pet_Name);
                        cmd.Parameters.AddWithValue("@species", updatePet.Species);
                        cmd.Parameters.AddWithValue("@breed", updatePet.Breed);
                        cmd.Parameters.AddWithValue("@size", updatePet.Size);
                        cmd.Parameters.AddWithValue("@personality", updatePet.Personality);
                        updatePet.Pet_ID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                catch (SqlException)
                {
                    throw;
                }

                return updatePet;
            }
        }
