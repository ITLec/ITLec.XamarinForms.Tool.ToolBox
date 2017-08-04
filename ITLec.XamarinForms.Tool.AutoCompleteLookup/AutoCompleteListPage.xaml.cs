using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ITLec.XamarinForms.Tool.AutoCompleteLookup
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutoCompleteListPage : ContentPage
    {

        IEnumerable<AutoCompleteListItem> AllListItems = new List<AutoCompleteListItem>();
        IEnumerable<AutoCompleteListItem> FilteredListItems = new List<AutoCompleteListItem>();

        public event Action<object, AutoCompleteArgs> Closing;
        AutoCompleteListItem selectedItem;

        public AutoCompleteListPage(List<AutoCompleteListItem> listItems)
        {

            InitializeComponent();
            AllListItems = listItems;
            FilteredListItems = AllListItems;
            listView.ItemsSource = FilteredListItems;
        }


        private async void mainLV_ItemSelected(object sender, ItemTappedEventArgs selectedItemChangedEventArgs)
        {
            selectedItem = (AutoCompleteListItem)selectedItemChangedEventArgs.Item;
            await Navigation.PopModalAsync(true);

            AutoCompleteArgs aca = new AutoCompleteArgs();
            aca.SelectedItem = selectedItem;
            Closing?.Invoke(sender, aca);
        }

        void txtFilterOnTextChanged(object sender, EventArgs eevent)
        {
            FilteredListItems = AllListItems.Where(e => e.DisplayText.ToLower().Contains(txtFilter.Text.ToLower()));

            listView.ItemsSource = FilteredListItems;
        }

        public AutoCompleteListPage()
        {
            InitializeComponent();
        }
    }
}
