using CleancashChat2.Model.Objects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CleancashChat2.Model.Modules
{
    class Datebase_Sender
    {
        //TODO: Переделать под REST
        protected string connection { get; set; }
        protected MySqlConnection myConnection;
        MySqlConnectionStringBuilder mysqlCSB;

        public Datebase_Sender()
        {
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "82.221.136.4";
            mysqlCSB.Database = "cleancas_connectionBox";
            mysqlCSB.UserID = "cleancas_dev_cry";
            mysqlCSB.Password = "eO95*ubSdv;d";
            mysqlCSB.CharacterSet = "UTF-8";
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

        public async void SetMessages(Message message)
        {
            var uri = "http://cleancash.net/model/api/mobile/api_chat.php?mobile&methode=SendMessages&id_dialog=" + message.ID_Dialog + "&text=" + message.Text+ "&adm=sergey";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);
            //string text = "INSERT INTO messages_mychat SET date='"+DateTime.Now.ToString()+"', id_dialog='"+message.ID_Dialog+"', text='"+message.Text+"', _from='admin', _to='"+message.To+"'";
            //MySqlCommand myCommand = new MySqlCommand(text, myConnection);
            //MySqlDataReader reader = myCommand.ExecuteReader();
            //reader.Close();
        }

    }
}
