using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS
{
    class Card
    {
        private string cons = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public int Id { get; set; }
        public string CardNo { get; set; }
        public List<Card> GetCardList()
        {
            SqlConnection connection = new SqlConnection(cons);
            string query = "SELECT Id, CardNo FROM Cards";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Card> cards = new List<Card>();
            while (reader.Read())
            {
                Card card=new Card();
                card.Id = (int)reader["Id"];
                card.CardNo =reader["CardNo"].ToString();
                cards.Add(card);

            }
            connection.Close();
            return cards;
        }
    }
}
