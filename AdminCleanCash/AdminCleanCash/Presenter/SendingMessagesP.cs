using CleancashChat2.Model.Modules;
using CleancashChat2.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CleancashChat2.Presenter
{
    class SendingMessagesP
    {
        private Datebase_Sender db;
        public SendingMessagesP()
        {
            db = new Datebase_Sender();
            db.InitialConnect();
        }

        public void Send(Entry tb)
        {
            if (tb.Text != null)
            {
                if (tb.Text != "")
                {
                    Message message = new Message()
                    {
                        ID_Dialog = LoaderMessagesP.now_id,
                        Text = tb.Text,
                        To = LoaderMessagesP.now_name
                    };
                    tb.Text = "";
                    db.SetMessages(message);
                }
            }
        }
    }
}
