using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CleancashChat2.Presenter;

namespace AdminCleanCash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Messages : ContentView
    {
        private LoaderMessagesP loader = null;
        private SendingMessagesP senderr = null;

        public Messages(string id)
        {
            // TODO: Потоковое получение сообщений
            InitializeComponent();
            loader = new LoaderMessagesP();
            senderr = new SendingMessagesP();
            new System.Threading.Thread(new System.Threading.ThreadStart(() => {
                Device.BeginInvokeOnMainThread(() => {
                    loader.GetMessages(messagesBox, id);
                });
            })).Start();
        }

        private void send_click(object sender, EventArgs e)
        {
            senderr.Send(text);
        }
    }
}