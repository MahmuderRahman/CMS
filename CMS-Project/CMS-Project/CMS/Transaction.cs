using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS
{
    class Transaction
    {
        private string cons = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public int Id { get; set; }
        public int CardId { get; set; }
        public string CardNo { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }


        public string SaveTransaction(Transaction transaction)
        {
            SqlConnection connection=new SqlConnection(cons);
            string query = "INSERT INTO Transactions  (CardId,UserId,Amount,Description,Date) VALUES('"+transaction.CardId+"','"+transaction.UserId+"','"+transaction.Amount+"','"+transaction.Description+"','"+transaction.Date+"')";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            int rowAff = command.ExecuteNonQuery();
            connection.Close();
            string msg = " ";
            if (rowAff > 0)
            {
                msg = "Successfully";
            }
            else
            {
                msg = "Failed";
            }
            return msg;
        }


        public List<Transaction> GetTransactionList()
        {
            SqlConnection connection = new SqlConnection(cons);
            string query = "SELECT trn.Id, trn.Date,trn.Amount,trn.Description,usr.Name,trn.UserId,crd.Id as CardId, crd.CardNo FROM Transactions trn JOIN Users usr ON trn.UserId=usr.Id JOIN Cards crd ON trn.CardId=crd.Id";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Transaction> transactions = new List<Transaction>();
            while (reader.Read())
            {
                Transaction transaction = new Transaction();
                transaction.Id = (int)reader["Id"];
                transaction.CardId = (int)reader["CardId"];
                transaction.CardNo = reader["CardNo"].ToString();
                transaction.UserId = (int)reader["UserId"];
                transaction.UserName = reader["Name"].ToString();
                transaction.Amount = (decimal)reader["Amount"];
                transaction.Description = reader["Description"].ToString();
                transaction.Date = (DateTime)reader["Date"];
                transactions.Add(transaction);

            }
            connection.Close();
            return transactions;
        }

        public string DeleteTransaction(int id)
        {
            SqlConnection connection = new SqlConnection(cons);
            string query = "DELETE FROM Transactions WHERE Id="+id;
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAff = command.ExecuteNonQuery();
            connection.Close();
            string msg = " ";
            if (rowAff > 0)
            {
                msg = "Successfully Deleted";
            }
            else
            {
                msg = "Failed";
            }
            return msg;
        }

        public string UpdateTransaction(Transaction transaction)
        {
            SqlConnection connection = new SqlConnection(cons);
            string query = "UPDATE Transactions SET CardId='" + transaction.CardId + "',UserId='" + transaction.UserId + "', Amount='" + transaction.Amount + "',Description='" + transaction.Description + "',Date='"+transaction.Date+"' WHERE Id='" + transaction.Id + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAff = command.ExecuteNonQuery();
            connection.Close();
            string msg = " ";
            if (rowAff > 0)
            {
                msg = "Successfully Updated";
            }
            else
            {
                msg = "Failed";
            }
            return msg;
        }
    }
}
