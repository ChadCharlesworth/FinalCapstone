﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.DAO
{
    public class AddressSqlDAO : IAddressDAO
    {
        private readonly string connectionString;

        public AddressSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Address> getAddresses()
        {
            List<Address> returnAddresses = new List<Address>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select Address_ID,Street_Address_1,Street_Address_2,City,State,Zip from address where Is_Active = 1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Address address = new Address();
                            address.Address_ID = Convert.ToInt32(reader["Address_ID"]);
                            address.Street_Address_1 = Convert.ToString(reader["Street_Address_1"]);
                            address.Street_Address_2 = Convert.ToString(reader["Street_Address_2"]);
                            address.City = Convert.ToString(reader["City"]);
                            address.State = Convert.ToString(reader["State"]);
                            address.Zip = Convert.ToString(reader["Zip"]);
                            returnAddresses.Add(address);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return returnAddresses;
        }


        public Address addAddress(Address newAddress, int userID)
        {
            Address address = new Address();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("insert into address (Street_Address_1,Street_Address_2,City,State,Zip) values (@streetAddress1,@streetAddress2,@city,@state,@zip); select SCOPE_IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@streetAddress1", newAddress.Street_Address_1);
                    cmd.Parameters.AddWithValue("@streetAddress2", newAddress.Street_Address_2);
                    cmd.Parameters.AddWithValue("@city", newAddress.City);
                    cmd.Parameters.AddWithValue("@state", newAddress.State);
                    cmd.Parameters.AddWithValue("@zip", newAddress.Zip);

                    int addressID = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.CommandText = "insert into Address_User(User_ID, Address_ID) values(@userID, @addressID)"; 
                    cmd.Parameters.AddWithValue("@userID", userID);
                    cmd.Parameters.AddWithValue("@addressID", addressID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return address;
        }


        public Address updateAddress(Address updatedAddress)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("update Address set Street_Address_1 = @streetAddress1,Street_Address_2 = @streetAddress2,City = @city,State = @state,Zip = @zip where Address_ID = @addressID", conn);
                    cmd.Parameters.AddWithValue("@streetAddress1", updatedAddress.Street_Address_1);
                    cmd.Parameters.AddWithValue("@streetAddress2", updatedAddress.Street_Address_2);
                    cmd.Parameters.AddWithValue("@city", updatedAddress.City);
                    cmd.Parameters.AddWithValue("@state", updatedAddress.State);
                    cmd.Parameters.AddWithValue("@zip", updatedAddress.Zip);

                    cmd.Parameters.AddWithValue("@addressID", updatedAddress.Address_ID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return updatedAddress;
        }



        public bool deleteAddress(int id)
        {
            bool isDeleted = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    TransactionScope transaction = new TransactionScope();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("update Address set Is_Active = 0 where Address_ID = @addressID", conn);
                        cmd.Parameters.AddWithValue("@addressID", id);

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
    }
}
     


      
        

       