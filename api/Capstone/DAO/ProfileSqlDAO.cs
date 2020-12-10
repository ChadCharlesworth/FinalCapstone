using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.DAO
{
    public class ProfileSqlDAO : IProfileDAO
    {
        private readonly string connectionString;

        public ProfileSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Profile AddProfile(Profile newProfile)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string commandString = "update users set First_Name = @firstName, Last_Name = @lastName where user_id = @userID;";

                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.Parameters.AddWithValue("@firstName", newProfile.First_Name);
                    command.Parameters.AddWithValue("@lastName", newProfile.Last_Name);
                    command.Parameters.AddWithValue("@userID", newProfile.user_id);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            //Add address, pets, and playdates in Vue after adding profile, in the same Vue method based on the returned userID or petID

            return GetProfile(newProfile.username);
        }

        public bool DeleteProfile(int id)
        {
            bool isDeleted = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string commandString = "select Address_ID from Address_User where User_ID = @userID";

                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.Parameters.AddWithValue("@userID", id);

                    int addressID = Convert.ToInt32(command.ExecuteScalar());

                    TransactionScope transaction = new TransactionScope();

                    try
                    {
                        commandString = "update users set Is_Active = 0 where user_id = @userID";
                        command.CommandText = commandString;
                        command.Parameters.AddWithValue("@userID", id);

                        int userRowsAffected = command.ExecuteNonQuery();

                        commandString = "update address set Is_Active = 0 where Address_ID = @addressID";
                        command.CommandText = commandString;
                        command.Parameters.AddWithValue("@addressID", addressID);

                        int addressRowsAffected = command.ExecuteNonQuery();

                        if (userRowsAffected == 1 && addressRowsAffected > 0)
                        {
                            transaction.Complete();
                            isDeleted = true;
                        }
                        else
                        {
                            transaction.Dispose();
                        }

                    }
                    catch (Exception e)
                    {
                        transaction.Dispose();
                        throw e;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return isDeleted;
        }

        public List<Profile> GetAllUsers()
        {
            List<Profile> allUsers = new List<Profile>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string commandString = "select First_Name,Last_Name,user_id,user_role,username from users where Is_Active = 1;";

                    SqlCommand command = new SqlCommand(commandString, connection);

                    SqlDataReader userReader = command.ExecuteReader();

                    while (userReader.Read())
                    {
                        Profile profile = new Profile
                        {
                            First_Name = Convert.ToString(userReader["First_Name"]),
                            Last_Name = Convert.ToString(userReader["Last_Name"]),
                            user_id = Convert.ToInt32(userReader["user_id"]),
                            user_role = Convert.ToString(userReader["user_role"]),
                            username = Convert.ToString(userReader["username"])
                        };

                        allUsers.Add(profile);

                        int iterator = 0;
                        foreach (Profile profileUser in allUsers)
                        {
                            commandString = $"select Pet_ID from Pet where Owner_ID = @userID{iterator} and Is_Active = 1;";
                            command.CommandText = commandString;
                            command.Parameters.AddWithValue($"@userID{iterator}", profileUser.user_id);

                            SqlDataReader petReader = command.ExecuteReader();

                            while (petReader.Read())
                            {
                                profileUser.Pet_Ids.Add(Convert.ToInt32(petReader["Pet_ID"]));
                            }
                            iterator++;
                        }

                        foreach (Profile profileUser in allUsers)
                        {
                            commandString = $"select Address.Address_ID from Address join Address_User on Address.Address_ID = Address_User.Address_ID where User_ID = @userID{iterator} and Is_Active = 1;";
                            command.CommandText = commandString;
                            command.Parameters.AddWithValue($"@userID{iterator}", profileUser.user_id);

                            SqlDataReader addressReader = command.ExecuteReader();

                            while (addressReader.Read())
                            {
                                profileUser.Address_Ids.Add(Convert.ToInt32(addressReader["Address_ID"]));
                            }
                            iterator++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return allUsers;
        }

        public Profile GetProfile(string username)
        {
            Profile profile = new Profile();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string commandString = "select First_Name,Last_Name,user_id,user_role from users where Is_Active = 1 and username = @username;";

                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.Parameters.AddWithValue("@username", username);

                    SqlDataReader userReader = command.ExecuteReader();

                    while (userReader.Read())
                    {
                        profile = new Profile
                        {
                            First_Name = Convert.ToString(userReader["First_Name"]),
                            Last_Name = Convert.ToString(userReader["Last_Name"]),
                            user_id = Convert.ToInt32(userReader["user_id"]),
                            user_role = Convert.ToString(userReader["user_role"]),
                            username = username
                        };

                        //Adding Pet IDs to profile 
                        commandString = $"select Pet_ID from Pet where Owner_ID = @userID and Is_Active = 1;";
                        command.CommandText = commandString;
                        command.Parameters.AddWithValue($"@userID", profile.user_id);

                        SqlDataReader petReader = command.ExecuteReader();

                        while (petReader.Read())
                        {
                            profile.Pet_Ids.Add(Convert.ToInt32(petReader["Pet_ID"]));
                        }

                        //Adding address IDs to profile
                        commandString = $"select Address.Address_ID from Address join Address_User on Address.Address_ID = Address_User.Address_ID where User_ID = @userID and Is_Active = 1;";
                        command.CommandText = commandString;

                        SqlDataReader addressReader = command.ExecuteReader();

                        while (addressReader.Read())
                        {
                            profile.Address_Ids.Add(Convert.ToInt32(addressReader["Address_ID"]));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return profile;
        }

        public Profile UpdateProfile(Profile updatedProfile)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string commandString = "update users set First_Name = @firstName, Last_Name = @lastName where user_id = @userID;";

                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.Parameters.AddWithValue("@firstName", updatedProfile.First_Name);
                    command.Parameters.AddWithValue("@lastName", updatedProfile.Last_Name);
                    command.Parameters.AddWithValue("@userID", updatedProfile.user_id);

                    command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            //Update Address in Vue in the same Vue method
            //Update Pet in Vue in the same Vue method

            return updatedProfile;
        }
    }
}
