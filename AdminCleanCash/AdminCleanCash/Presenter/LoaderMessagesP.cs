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

        public LoaderMessagesP()
        {
            db = new Datebase_Messages();
            db.InitialConnect();
        }

        private void AsyncMessagesTake(ListView dataGrid, string id)
        {
            now_id = id;
            List<Message> messages = db.GetMessages(id);
            string[] text = new string[messages.Count];
            for (int i = 0; i < messages.Count; i++)
            {
                text[i] = messages[i].Text;
            }
            Device.BeginInvokeOnMainThread(() => {
                dataGrid.ItemsSource = text;
            });
           
            Thread.Sleep(3000);
            AsyncMessagesTake(dataGrid, id);
        }

        public void GetMessages(ListView dataGrid, string item)
        {
            //if (mainTask == null)
            //{
            //    Header hed = item;
            //    if (hed != null)
            //    {
                    Task t1 = new Task(() =>
                    {
                        mainTask = Thread.CurrentThread;

                        //now_name = hed.NameUser;
                        AsyncMessagesTake(dataGrid, item);
                    });
            t1.Start();
            //    }
            //}
            //else
            //{
            //    mainTask.Abort();
            //    mainTask = null;
            //    Header hed = item;
            //    if (hed != null)
            //    {
            //        Task t1 = new Task(() =>
            //        {
            //            mainTask = Thread.CurrentThread;

            //            now_name = hed.NameUser;
            //            AsyncMessagesTake(dataGrid, hed.ID);
            //        });
            //        t1.Start();
            //    }
            //}

        }
    }
}
