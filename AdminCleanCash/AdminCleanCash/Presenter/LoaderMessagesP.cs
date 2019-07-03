using CleancashChat2.Model.Modules;
using CleancashChat2.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CleancashChat2.Presenter
{
    class LoaderMessagesP
    {
        private Datebase_Messages db;
        private Thread mainTask;
        public static string now_id;
        public static string now_name;
        private string[] buffer = new string[] { "" };

        public LoaderMessagesP()
        {
            db = new Datebase_Messages();
            db.InitialConnect();
        }

        private async void AsyncMessagesTake(ListView dataGrid, string id)
        {
            now_id = id;
            List<Message> messages = await db.GetMessages(id);
            string[] text = new string[messages.Count];
            for (int i = 0; i < messages.Count; i++)
            {
                text[i] = messages[i].Text;
            }

            if (buffer.Length != text.Length)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    dataGrid.ItemsSource = text;
                    
                    buffer = text;
                });
            }
            Thread.Sleep(3000);
            AsyncMessagesTake(dataGrid, id);
        }

        public void GetMessages(ListView dataGrid, string item)
        {
            Task t1 = new Task(() =>
            {
                mainTask = Thread.CurrentThread;

                //now_name = hed.NameUser;
                AsyncMessagesTake(dataGrid, item);
            });
            t1.Start();
        }
    }
}
