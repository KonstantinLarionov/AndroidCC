using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CleancashChat2.Model.Objects;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

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

        public async Task<List<Dialog>> GetDialogsAsync()
        {
            var uri = "http://cleancash.net/model/api/mobile/api_chat.php?mobile&methode=GetDialogs";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray ja = JArray.Parse(responseBody);
            List<Dialog> dialogs = new List<Dialog>();
            foreach (var item in ja)
            {
                dialogs.Add(new Dialog { Header = new Header {  ID = item["id"].ToString()} });
            }
          
            return dialogs;
        }

     
    }
}
