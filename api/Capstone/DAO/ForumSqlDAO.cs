using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Capstone.DAO
{
    public class ForumSqlDAO : IForumDAO
    {
        private readonly string connectionString;
        public ForumSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool DeactivateMessage(int deletedMessageID)
        {
            bool worked = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    TransactionScope transaction = new TransactionScope();

                    try
                    {
                        SqlCommand command = new SqlCommand("update Forum_Message set Is_Active = 0 where Message_ID = @messageID", conn);
                        command.Parameters.AddWithValue("@messageID", deletedMessageID);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            worked = true;
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
            catch (Exception)
            {

                throw;
            }
            return worked;
        }

        public bool DeactivateResponse(int deletedResponseID)
        {
            bool worked = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    TransactionScope transaction = new TransactionScope();

                    try
                    {
                        SqlCommand command = new SqlCommand("update Forum_Response set Is_Active = 0 where Response_ID = @responseID", conn);
                        command.Parameters.AddWithValue("@responseID", deletedResponseID);

                        if (command.ExecuteNonQuery() == 1)
                        {
                            worked = true;
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
            catch (Exception)
            {

                throw;
            }
            return worked;
        }


        public List<ForumMessage> GetAllMessages()
        {
            List<ForumMessage> messages = new List<ForumMessage>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select Message_ID,User_ID,Message_Title,Message_Body,Created_Date from Forum_Message where Is_Active = 1", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        messages.Add(GetMessageFromReader(reader));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return messages;
        }

        public List<ForumResponse> GetAllResponses()
        {
            List<ForumResponse> responses = new List<ForumResponse>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select Response_ID,User_ID,Message_ID,Response_Body,Created_Date from Forum_Response where Is_Active = 1", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        responses.Add(GetResponseFromReader(reader));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return responses;
        }


        public ForumMessage PostMessage(ForumMessage newMessage)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("insert into Forum_Message (User_ID,Message_Title,Message_Body) values (@userID,@messageTitle,@messageBody); select scope_identity();", conn);
                    command.Parameters.AddWithValue("@userID", newMessage.UserID);
                    command.Parameters.AddWithValue("@messageTitle", newMessage.Message_Title);
                    command.Parameters.AddWithValue("@messageBody", newMessage.Message_Body);
                    newMessage.MessageID = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = $"select Created_Date from Forum_Message where Message_ID = {newMessage.MessageID}";
                    newMessage.CreatedDate = Convert.ToDateTime(command.ExecuteScalar());
                }
            }
            catch (Exception)
            {

                throw;
            }

            return newMessage;
        }

        public ForumResponse PostResponse(ForumResponse newResponse)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("insert into Forum_Response (User_ID,Message_ID,Response_Body) values (@userID,@messageID,@responseBody); select scope_identity();", conn);
                    command.Parameters.AddWithValue("@userID", newResponse.UserID);
                    command.Parameters.AddWithValue("@messageID", newResponse.MessageID);
                    command.Parameters.AddWithValue("@responseBody", newResponse.Body);
                    newResponse.ResponseID = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = $"select Created_Date from Forum_Response where Response_ID = {newResponse.ResponseID}";
                    newResponse.CreatedDate = Convert.ToDateTime(command.ExecuteScalar());

                }
            }
            catch (Exception)
            {

                throw;
            }

            return newResponse;
        }


        public ForumMessage UpdateMessage(ForumMessage updatedMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("update Forum_Message set User_ID = @userID,Message_Title = @messageTitle,Message_Body = @messageBody where Message_ID = @messageID", conn);
                    command.Parameters.AddWithValue("@userID", updatedMessage.UserID);
                    command.Parameters.AddWithValue("@messageTitle", updatedMessage.Message_Title);
                    command.Parameters.AddWithValue("@messageBody", updatedMessage.Message_Body);
                    command.Parameters.AddWithValue("@messageID", updatedMessage.MessageID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return updatedMessage;
        }

        public ForumResponse UpdateResponse(ForumResponse updatedResponse)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("update Forum_Response set User_ID = @userID,Message_ID = @messageID,Response_Body = @responseBody where Response_ID = @responseID", conn);
                    command.Parameters.AddWithValue("@userID", updatedResponse.UserID);
                    command.Parameters.AddWithValue("@messageID", updatedResponse.MessageID);
                    command.Parameters.AddWithValue("@responseBody", updatedResponse.Body);
                    command.Parameters.AddWithValue("@responseID", updatedResponse.ResponseID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return updatedResponse;
        }

        private ForumMessage GetMessageFromReader(SqlDataReader reader)
        {
            ForumMessage message = new ForumMessage()
            {
                MessageID = Convert.ToInt32(reader["Message_ID"]),
                UserID = Convert.ToInt32(reader["User_ID"]),
                Message_Title = Convert.ToString(reader["Message_Title"]),
                Message_Body = Convert.ToString(reader["Message_Body"]),
                CreatedDate = Convert.ToDateTime(reader["Created_Date"])
            };
            return message;
        }

        private ForumResponse GetResponseFromReader(SqlDataReader reader)
        {
            ForumResponse response = new ForumResponse()
            {
                ResponseID = Convert.ToInt32(reader["Response_ID"]),
                UserID = Convert.ToInt32(reader["User_ID"]),
                MessageID = Convert.ToInt32(reader["Message_ID"]),
                Body = Convert.ToString(reader["Response_Body"]),

                CreatedDate = Convert.ToDateTime(reader["Created_Date"]),
              

               // CreatedDate = Convert.ToDateTime(reader["Created_Date"])

            };

            return response;
        }
    }
}
