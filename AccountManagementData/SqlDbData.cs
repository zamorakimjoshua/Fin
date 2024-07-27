using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassroomManagementModels;

namespace ClassroomManagementData
{
    public class SqlDbData
    {
        static string connectionString
        = "Data Source =LAPTOP-QQJD4TKI\\SQLEXPRESS; Initial Catalog = Class; Integrated Security = True;";
        //= "Server = tcp:20.2.138.171,1433; Database = Class; User Id = sa; Password = bsitinteg21!";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT prof, roomNum, status FROM integs";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                string prof = reader["prof"].ToString();
                string roomNum = reader["roomNum"].ToString();
                string status = reader["status"].ToString();

                User readUser = new User();
                readUser.prof = prof;
                readUser.roomNum = roomNum;
                readUser.status = status;

                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public int AddUser(string prof, string roomNum, string status)
        {
            int success;

            string insertStatement = "INSERT INTO integs VALUES (@prof, @roomNum, @status)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@prof", prof);
            insertCommand.Parameters.AddWithValue("@roomNum", roomNum);
            insertCommand.Parameters.AddWithValue("@status", status);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;

        }

        public int UpdateUser(string prof, string roomNum, string status)
        {
            int success;

            string updateStatement = $"UPDATE integs SET roomNum = @roomNum WHERE ign = @ign";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@roomNum", roomNum);
            updateCommand.Parameters.AddWithValue("@peof", prof);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;

        }

        public int DeleteUser(string prof)
        {
            int success;

            string deleteStatement = $"DELETE FROM integs WHERE ign = @prof";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@prof", prof);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}