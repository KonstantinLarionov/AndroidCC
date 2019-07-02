using CleancashChat2.Model.Modules;
using CleancashChat2.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.DataGrid;

namespace CleancashChat2.Presenter
{
    class LoaderDialogsP
    {
        private Datebase_Dialogs db;
        public LoaderDialogsP()
        {
            db = new Datebase_Dialogs();
            db.InitialConnect();
        }

        private void AsyncDialogsTake(ListView data)
        {
          
            List<Dialog> dialogs = db.GetDialogs();
            string[] dataarr = new string[dialogs.Count];
            for (int i = 0; i < dialogs.Count; i++)
            {
                dataarr[i] = dialogs[i].Header.ID;
            }
            
            data.ItemsSource = dataarr;
            //Thread.Sleep(3000);
            //AsyncDialogsTake(data);
        }

        public void GetDialog(ListView data)
        {
            AsyncDialogsTake(data);
            //Task t1 = new Task(() =>
            //{
            //    AsyncDialogsTake(data);
            //});
            //t1.Start();
        }
    }
}
