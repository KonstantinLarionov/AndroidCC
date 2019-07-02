using CleancashChat2.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AdminCleanCash
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public string[] Phones { get; set; }
        private LoaderDialogsP dialogsP = null;
        public MainPage()
        {
            InitializeComponent();
         
            dialogsP = new LoaderDialogsP();
            dialogsP.GetDialog(phonesList);
        }

        private void dialogs_selected(object sender, SelectedItemChangedEventArgs e)
        {
            // TODO: Передать ID диалога
            if (e.SelectedItem != null)
            {
                Messages messages = new Messages(e.SelectedItem.ToString());
                this.Content = messages;
            }
        }
    }
}
