using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using demoPoC.ViewModels;
using demoPoC.Models;

namespace demoPoC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsistDetailPage : ContentPage
    {

        private ConsistDetailViewModel consistDetailViewModel;

        public ConsistDetailPage(Consist consistSelected)
        {
            InitializeComponent();

            BindingContext = consistDetailViewModel = new ConsistDetailViewModel();
            consistDetailViewModel.SetData(consistSelected);


        }

        //public ObservableCollection<string> Items { get; set; }

        //public ConsistDetailPage()
        //{
        //    InitializeComponent();

        //    Items = new ObservableCollection<string>
        //    {
        //        "Item 1",
        //        "Item 2",
        //        "Item 3",
        //        "Item 4",
        //        "Item 5"
        //    };

        //    BindingContext = this;
        //}

        //async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem == null)
        //        return;

        //    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

        //    //Deselect Item
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}