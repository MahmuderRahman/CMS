using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS
{
    class User
    {
        private string cons = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public int Id { get; set; }
        public string  Name { get; set; }

        public List<User> GetUserList()
        {
            SqlConnection connection = new SqlConnection(cons);
            string query = "SELECT Id, Name FROM Users";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user=new User();
                user.Id = (int)reader["Id"];
                user.Name = reader["Name"].ToString();
                users.Add(user);
            }
            connection.Close();
            return users;
        }
    }
}
