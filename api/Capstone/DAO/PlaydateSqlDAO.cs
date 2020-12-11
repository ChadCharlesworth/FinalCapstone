using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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

        public Playdate CreatePlaydate(Playdate playdate, int petID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Playdate (Address_ID,Date_Time,Creator_User_ID,Number_Of_Attendees,Is_Private) values (@addressID,@dateTime,@userID,@numberOfAttendees,@isPrivate)", conn);
                    cmd.Parameters.AddWithValue("@addressID", playdate.Address_ID);
                    cmd.Parameters.AddWithValue("@dateTime", playdate.Date_Time);
                    cmd.Parameters.AddWithValue("@userID", playdate.Creator_User_ID);
                    cmd.Parameters.AddWithValue("@numberOfAttendees", playdate.Number_Of_Attendees);
                    cmd.Parameters.AddWithValue("@isPrivate", playdate.Is_Private);

                    int playdateID = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.CommandText = "insert into Playdate_Pet (Playdate_ID,Pet_ID,Approval_Status,Accepted) values (@playdateID,@petID,@approvalStatus,@accepted);select SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("@playdateID", playdateID);
                    cmd.Parameters.AddWithValue("@petID", petID);
                    cmd.Parameters.AddWithValue("@approvalStatus", playdate.Approval_Status);
                    cmd.Parameters.AddWithValue("@accepted", playdate.Accepted);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            { throw e; }

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

                    SqlCommand cmd = new SqlCommand("select Playdate_ID, Address_ID,Date_Time,Creator_User_ID,Number_Of_Attendees,Is_Private from Playdate where Is_Active = 1", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows())
                    {
                        while (reader.Read())
                        {
                            Playdate playdate = new Playdate();
                            playdate.Playdate_ID = Convert.ToInt32(reader["Playdate_ID"]);
                            playdate.Address_ID = Convert.ToInt32(reader["Address_ID"]);
                            playdate.Date_Time = Convert.ToDateTime(reader["Date_Time"]);
                            playdate.Creator_User_ID = Convert.ToInt32(reader["Creator_User_ID"]);
                            playdate.Number_Of_Attendees = Convert.ToInt32(reader["Number_Of_Attendees"]);
                            playdate.Is_Private = Convert.ToInt32("Is_Private");
                            allPlaydates.Add(playdate);

                        }
                    }
                }
            }
            catch (Exception e)
            { throw e; }

            return allPlaydates;
        }

        public Playdate UpdatePlaydate(Playdate playdate)
        {
            throw new NotImplementedException();
        }
        public bool DeletePlaydate(Playdate playdate)
        {
            throw new NotImplementedException();
        }

    }
}
