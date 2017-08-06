using ITLec.XamarinForms.Tool.AutoCompleteLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ITLec.XamarinForms.Tool.ToolBox
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            var items = new List<AutoCompleteListItem>();
            items.Add(new AutoCompleteListItem { DisplayText = "Key1", Value = "Value1" });
            items.Add(new AutoCompleteListItem { DisplayText = "Key2", Value = "Value2" });
            items.Add(new AutoCompleteListItem { DisplayText = "Key3", Value = "Value3" });

            keyAutoCompleteLookup.ItemsSource = items;
        }

        async void btnRunProgressBar_OnClick(object sender, EventArgs eevent)
        {
            List<AdvancedProgressBar.TaskItem> tskItems = new List<AdvancedProgressBar.TaskItem>();

            for (int i = 0; i < 600; i++)
            {
                tskItems.Add(new AdvancedProgressBar.TaskItem { Task = new Task(() => { YourCode(); }), TaskName = "Task#: " + i.ToString(), Wieght = 100 });
            }
            advancedProgressBar.TaskItems = tskItems;
            advancedProgressBar.IsDisplayActivityIndicator = true;
            await advancedProgressBar.Run();
        }

        private void YourCode()
        {
        //    throw new NotImplementedException();
        }
    }
}
