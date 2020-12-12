using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.DAO
{
    public class PetSqlDAO : IPetDAO
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
            bool isDeleted = true;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    TransactionScope transaction = new TransactionScope();


                    try
                    {
                        SqlCommand cmd = new SqlCommand("update Pet set Is_Active = 0 where Pet_ID = @petID", conn);
                        cmd.Parameters.AddWithValue("@petID", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            isDeleted = true;
                            transaction.Complete();
                        }
                        else
                        {
                            transaction.Dispose();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Dispose();
                        throw;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return isDeleted;
        }
        public List<Pet> GetPets()
        {
            List<Pet> returnPets = new List<Pet>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select Pet_ID,Owner_ID,Pet_Name,Species,Breed,Size,Personality from Pet where Is_Active = 1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Pet pet = new Pet();
                            pet.Owner_ID = Convert.ToInt32(reader["Owner_ID"]);
                            pet.Pet_Name = Convert.ToString(reader["Pet_Name"]);
                            pet.Species = Convert.ToString(reader["Species"]);
                            pet.Breed = Convert.ToString(reader["Breed"]);
                            pet.Size = Convert.ToString(reader["Size"]);
                            pet.Personality = Convert.ToString(reader["Personality"]);
                            returnPets.Add(pet);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return returnPets;
        }
        public Pet UpdatePet(Pet updatePet)
        {
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("update Pet set Pet_Name = @petName, Species = @species, Breed = @breed, Size = @size, Personality = @personality where Pet_ID = @petID", conn);
                        cmd.Parameters.AddWithValue("@petID", updatePet.Pet_ID);
                        cmd.Parameters.AddWithValue("@petName", updatePet.Pet_Name);
                        cmd.Parameters.AddWithValue("@species", updatePet.Species);
                        cmd.Parameters.AddWithValue("@breed", updatePet.Breed);
                        cmd.Parameters.AddWithValue("@size", updatePet.Size);
                        cmd.Parameters.AddWithValue("@personality", updatePet.Personality);
                        updatePet.Pet_ID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return updatePet;
            }
        }
    } 
}

