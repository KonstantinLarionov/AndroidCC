using CleancashChat2.Model.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleancashChat2.Model.Modules
{
    class Datebase_Messages
    {
        //TODO: Переделать под REST
        protected string connection { get; set; }
        protected MySqlConnection myConnection;
        MySqlConnectionStringBuilder mysqlCSB;

        public Datebase_Messages()
        {
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "82.221.136.4";
            mysqlCSB.Database = "cleancas_connectionBox";
            mysqlCSB.UserID = "cleancas_dev_cry";
            mysqlCSB.Password = "eO95*ubSdv;d";
        }

        public string InitialConnect()
        {
            try
            {
                myConnection = new MySqlConnection();
                myConnection.ConnectionString = mysqlCSB.ConnectionString;
                myConnection.Open();
                return "Successfuly Connect DataBase!";
            }
            catch (Exception e)
            {
                return "Connect Faild!" + "\n" + e.Message.ToString();
            }
        }

        public List<Message> GetMessages(string id)
        {
            int status = 0;
            string text = "SELECT * FROM messages_mychat WHERE id_dialog='"+id+"' ORDER BY id ASC";
            MySqlCommand myCommand = new MySqlCommand(text, myConnection);
            MySqlDataReader reader = myCommand.ExecuteReader();
            List<Message> messages = new List<Message>();
            while (reader.Read())
            {
                messages.Add(new Message()
                {
                    //DateTime = Convert.ToDateTime(reader["date"].ToString()),
                    Text = reader["text"].ToString(),
                    To = reader["_to"].ToString(),
                    From = reader["_from"].ToString()
                }) ;
            }
            reader.Close();
            return messages;
        }

    }
}
