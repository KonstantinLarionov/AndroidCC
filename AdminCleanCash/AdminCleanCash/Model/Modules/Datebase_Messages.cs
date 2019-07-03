using CleancashChat2.Model.Objects;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public async Task<List<Message>> GetMessages(string id)
        {
            //int status = 0;
            //string text = "SELECT * FROM messages_mychat WHERE id_dialog='"+id+"' ORDER BY id ASC";
            //MySqlCommand myCommand = new MySqlCommand(text, myConnection);
            //MySqlDataReader reader = myCommand.ExecuteReader();
            var uri = "http://cleancash.net/model/api/mobile/api_chat.php?mobile&methode=GetMessages&id_dialog="+id;

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray ja = JArray.Parse(responseBody);
            List<Message> messages = new List<Message>();
            foreach (var item in ja)
            {
                messages.Add(new Message
                {
                    Text = item["text"].ToString(),
                    To = item["_to"].ToString(),
                    From = item["_from"].ToString()
                });
            }
            //while (reader.Read())
            //{
            //    messages.Add(new Message()
            //    {
            //        //DateTime = Convert.ToDateTime(reader["date"].ToString()),
            //        Text = reader["text"].ToString(),
            //        To = reader["_to"].ToString(),
            //        From = reader["_from"].ToString()
            //    }) ;
            //}
            //reader.Close();
            return messages;
        }

    }
}
