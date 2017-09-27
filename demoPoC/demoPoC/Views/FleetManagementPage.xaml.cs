using demoPoC.Models;
using demoPoC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace demoPoC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FleetManagementPage : ContentPage
	{
        //private ConsistDetailViewModel consistDetailViewModel;
        public FleetManagementPage()//Consist consistSelected)
        {
            InitializeComponent();
            BindingContext = new ConsistViewModel(Navigation);
            //BindingContext = consistDetailViewModel = new ConsistDetailViewModel();
            //consistDetailViewModel.SetData(consistSelected);
            //BindingContext = new ConsistViewModel();
        }

        //public FleetManagementPage()
        //{
        //    InitializeComponent();
        //    BindingContext = new ConsistViewModel();
        //}
    }
}