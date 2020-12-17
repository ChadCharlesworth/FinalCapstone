using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Capstone.Models;

namespace Capstone.DAO
{
    public class PlaydateSqlDAO : IPlaydateDAO
    {
        private readonly string ConnectionString;

        public PlaydateSqlDAO(string dbConnectionString)
        {
            ConnectionString = dbConnectionString;
        }

        public Playdate CreatePlaydate(Playdate playdate/*, int petID*/)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Playdate (Address_ID,Date_Time,Creator_User_ID,Number_Of_Attendees,Is_Private) values (@addressID,@dateTime,@userID,@numberOfAttendees,@isPrivate);select SCOPE_IDENTITY();", conn);
                    cmd.Parameters.AddWithValue("@addressID", playdate.Address_ID);
                    cmd.Parameters.AddWithValue("@dateTime", playdate.Date_Time);
                    cmd.Parameters.AddWithValue("@userID", playdate.Creator_User_ID);
                    cmd.Parameters.AddWithValue("@numberOfAttendees", playdate.Number_Of_Attendees);
                    cmd.Parameters.AddWithValue("@isPrivate", playdate.Is_Private);
                    playdate.Playdate_ID = Convert.ToInt32(cmd.ExecuteScalar());

                    //cmd.CommandText = "insert into Playdate_Pet (Playdate_ID,Pet_ID,Approval_Status,Accepted) values (@playdateID,@petID,@approvalStatus,@accepted);";
                    //cmd.Parameters.AddWithValue("@playdateID", playdate.Playdate_ID);
                    //cmd.Parameters.AddWithValue("@petID", petID);
                    //cmd.Parameters.AddWithValue("@approvalStatus", playdate.Pet_Approval_Status[petID]);
                    //cmd.Parameters.AddWithValue("@accepted", playdate.Pet_Accepted_Status[petID]);
                    //cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return playdate;
        }

        public List<Playdate> GetAllPlaydates()
        {
            List<Playdate> allPlaydates = new List<Playdate>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select Playdate_ID, Address_ID,(convert(varchar, (date_time), 0)) as Date_Time,Creator_User_ID,Number_Of_Attendees,Is_Private from Playdate where Is_Active = 1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Playdate playdate = new Playdate();
                            playdate.Playdate_ID = Convert.ToInt32(reader["Playdate_ID"]);
                            playdate.Address_ID = Convert.ToInt32(reader["Address_ID"]);
                            playdate.Date_Time = Convert.ToDateTime(reader["Date_Time"]);
                            playdate.Creator_User_ID = Convert.ToInt32(reader["Creator_User_ID"]);
                            playdate.Number_Of_Attendees = Convert.ToInt32(reader["Number_Of_Attendees"]);
                            playdate.Is_Private = Convert.ToBoolean(reader["Is_Private"]);
                            allPlaydates.Add(playdate);

                        }
                    }
                    reader.Close();

                    int i = 0;
                    foreach (Playdate playdate in allPlaydates)
                    {
                        cmd.CommandText = $"select Approval_Status, Pet_ID from Playdate_Pet where Playdate_ID = @playdateID{i}";
                        cmd.Parameters.AddWithValue($"@playdateID{i}", playdate.Playdate_ID);
                        SqlDataReader playdateReader = cmd.ExecuteReader();
                        while (playdateReader.Read())
                        {
                            if (Convert.ToString(playdateReader["Approval_Status"]) == "Attending")
                            {
                                playdate.Attending.Add(Convert.ToInt32(playdateReader["Pet_ID"]));
                            }
                            else if (Convert.ToString(playdateReader["Approval_Status"]) == "Declined")
                            {
                                playdate.Declined.Add(Convert.ToInt32(playdateReader["Pet_ID"]));
                            }
                            else
                            {
                                playdate.Pending.Add(Convert.ToInt32(playdateReader["Pet_ID"]));
                            }
                        }
                        i++;
                        playdateReader.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return allPlaydates;
        }
        public Playdate GetPlaydate(int playdateID)
        {
            Playdate playdate = new Playdate();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select Address_ID,Date_Time,Creator_User_ID,Number_Of_Attendees,Is_Private where Playdate_ID = @playdateID", conn);
                    cmd.Parameters.AddWithValue("@playdateID", playdateID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            playdate.Playdate_ID = Convert.ToInt32(reader["Playdate_ID"]);
                            playdate.Street_Address_1 = Convert.ToString(reader["Street_Address_1"]);
                            playdate.Street_Address_2 = Convert.ToString(reader["Street_Address_2"]);
                            playdate.City = Convert.ToString(reader["City"]);
                            playdate.State = Convert.ToString(reader["State"]);
                            playdate.Zip = Convert.ToString(reader["Zip"]);
                            playdate.Pet_ID = Convert.ToInt32(reader["Pet_ID"]);
                            playdate.Date_Time_String = Convert.ToString(reader["Date_Time_String"]);
                            playdate.Approval_Status = Convert.ToString(reader["Approval_Status"]);
                            playdate.Pet_Name = Convert.ToString(reader["Pet_Name"]);
                            playdate.Creator_User_ID = Convert.ToInt32(reader["Creator_User_ID"]);
                            playdate.Is_Private = Convert.ToBoolean(reader["Is_Private"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return playdate;

        }

        public Playdate UpdatePlaydate(Playdate updatedPlaydate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("update Playdate set Address_ID = @addressID,Date_Time = @dateTime,Creator_User_ID = @userID,Number_Of_Attendees = @numberOfAttendees,Is_Private = @isPrivate where Playdate_ID = @playdateID", conn);
                    cmd.Parameters.AddWithValue("@addressID", updatedPlaydate.Address_ID);
                    cmd.Parameters.AddWithValue("@dateTime", updatedPlaydate.Date_Time);
                    cmd.Parameters.AddWithValue("@userID", updatedPlaydate.Creator_User_ID);
                    cmd.Parameters.AddWithValue("@numberOfAttendees", updatedPlaydate.Number_Of_Attendees);
                    cmd.Parameters.AddWithValue("@isPrivate", updatedPlaydate.Is_Private);
                    cmd.Parameters.AddWithValue("@playdateID", updatedPlaydate.Playdate_ID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return updatedPlaydate;
        }
        public Playdate UpdatePlaydateByPetID(Playdate updatedPlaydate, int petID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("insert into Playdate_Pet (Playdate_ID, Pet_ID, Approval_Status) values (@playdateID, @petID, @approvalStatus)", conn); 
                    cmd.Parameters.AddWithValue("@playdateID", updatedPlaydate.Playdate_ID);
                    cmd.Parameters.AddWithValue("@petID", petID);
                    if (updatedPlaydate.Attending.Contains(petID))
                    {
                        cmd.Parameters.AddWithValue("@approvalStatus", "Attending");
                    }
                    else if (updatedPlaydate.Declined.Contains(petID))
                    {
                        cmd.Parameters.AddWithValue("@approvalStatus", "Declined");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@approvalStatus", "Pending");
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return updatedPlaydate;
        }
        public bool DeletePlaydate(int playdateID)
        {
            bool isDeleted = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    TransactionScope transaction = new TransactionScope();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update Playdate set Is_Active = 0  where Playdate_ID = @playdateID", conn);
                        cmd.Parameters.AddWithValue("@playdateID", playdateID);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
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
        public List<Playdate> GetPlaydatesByPetOwner(int ownerID)
        {
            List<Playdate> allPlaydates = new List<Playdate>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"
                            select Playdate.Playdate_ID, Street_Address_1, Street_Address_2, City,State,Zip,playdate_pet.Pet_ID,
                            (convert(varchar, (date_time), 0)) as Date_Time_String,
                            Approval_Status, Pet_Name, Creator_User_ID, Is_Private
                            from Playdate 
                            join Playdate_Pet on Playdate.Playdate_ID = Playdate_Pet.Playdate_ID 
                            join Address on Address.Address_ID = Playdate.Address_ID 
                            join pet on pet.Pet_ID = Playdate_Pet.Pet_ID
                            where exists 
                            (select Playdate_ID, Pet_ID, Approval_Status from Playdate_Pet 
                            where Pet_ID in (select Pet_ID from Pet where Owner_ID = @ownerID))
                            and Owner_ID = @ownerID order by Date_Time
                            ", conn);
                    cmd.Parameters.AddWithValue("@ownerID", ownerID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Playdate playdate = new Playdate();
                            playdate.Playdate_ID = Convert.ToInt32(reader["Playdate_ID"]);
                            playdate.Street_Address_1 = Convert.ToString(reader["Street_Address_1"]);
                            playdate.Street_Address_2 = Convert.ToString(reader["Street_Address_2"]);
                            playdate.City = Convert.ToString(reader["City"]);
                            playdate.State = Convert.ToString(reader["State"]);
                            playdate.Zip = Convert.ToString(reader["Zip"]);
                            playdate.Pet_ID = Convert.ToInt32(reader["Pet_ID"]);
                            playdate.Date_Time_String = Convert.ToString(reader["Date_Time_String"]);
                            playdate.Approval_Status = Convert.ToString(reader["Approval_Status"]);
                            playdate.Pet_Name = Convert.ToString(reader["Pet_Name"]);
                            playdate.Creator_User_ID = Convert.ToInt32(reader["Creator_User_ID"]);
                            playdate.Is_Private = Convert.ToBoolean(reader["Is_Private"]);
                            allPlaydates.Add(playdate);

                        }
                    }


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return allPlaydates;

        }

    }
}
