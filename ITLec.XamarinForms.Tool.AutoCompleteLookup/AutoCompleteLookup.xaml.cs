using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ITLec.XamarinForms.Tool.AutoCompleteLookup
{
    public partial class AutoCompleteLookup : ContentView
    {
        public AutoCompleteLookup()
        {
            InitializeComponent();
        }

        public AutoCompleteListItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                txt.Text = selectedItem.DisplayText;
            }
        }
        AutoCompleteListItem selectedItem;


        public static BindableProperty ItemsSourceProperty =
    BindableProperty.Create<AutoCompleteLookup, List<AutoCompleteListItem>>(o => o.ItemsSource, default(List<AutoCompleteListItem>), propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, List<AutoCompleteListItem> oldValue, List<AutoCompleteListItem> newValue)
        {
         //   throw new NotImplementedException();
        }

        public List<AutoCompleteListItem> ItemsSource
        {
            get
            {
                var retList = (List<AutoCompleteListItem>)GetValue(ItemsSourceProperty);
                return retList;
            }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private async void OnOpenListViewPage(object sender, EventArgs e)
        {


            var page = new AutoCompleteListPage(ItemsSource);
            page.Closing += AutoComplete;
            await Navigation.PushModalAsync(page);
        }

        private void AutoComplete(object sender, AutoCompleteArgs e)
        {
            if (e != null && e.SelectedItem != null)
            {
                SelectedItem = e.SelectedItem;
            }
        }
    }
}
