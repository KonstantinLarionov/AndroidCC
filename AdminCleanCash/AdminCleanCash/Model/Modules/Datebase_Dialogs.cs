using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleancashChat2.Model.Objects;
using MySql.Data.MySqlClient;

namespace CleancashChat2.Model.Modules
{
    class Datebase_Dialogs
    { 
        //TODO: Переделать под REST
        protected string connection { get; set; }
        protected MySqlConnection myConnection;
        MySqlConnectionStringBuilder mysqlCSB;

        public Datebase_Dialogs()
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

        public List<Dialog> GetDialogs()
        {
            string text = "SELECT * FROM dialogs_mychat ORDER BY id DESC";
            MySqlCommand myCommand = new MySqlCommand(text, myConnection);
            MySqlDataReader reader = myCommand.ExecuteReader();
            List<Dialog> dialogs = new List<Dialog>();
            while (reader.Read())
            {
                dialogs.Add(new Dialog()
                {
                    Header = new Header() { NameUser = reader["user_1"].ToString(), ID = reader["id"].ToString() },
                    NewMessage = Convert.ToInt32( reader["have_new"])
                }) ;
            }
            reader.Close();
            return dialogs;
        }

     
    }
}
