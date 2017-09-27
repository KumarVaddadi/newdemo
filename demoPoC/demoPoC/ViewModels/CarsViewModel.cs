using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoPoC.Models;
using demoPoC.Services;
using demoPoC.Constants;
using demoPoC.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace demoPoC.ViewModels
{
    public class CarsViewModel : BaseViewModel
    {
        private Consist _consistSelected;
        public ObservableCollection<Car> _Cars { get; set; }

        public Consist ConsistSelected
        {
            get { return _consistSelected; }
            set
            {
                if (_consistSelected != value)
                {
                    _consistSelected = value;
                    if (_consistSelected != null)
                    {
                        _navigation.PushAsync(new ConsistDetailPage(_consistSelected));
                    }
                }
            }
        }


        ICommand getCarsCommand;
        public ICommand GetCarsCommand =>
            getCarsCommand ??
            (getCarsCommand = new Command(async () => await GetCars()));

        public INavigation _navigation;
        public CarsViewModel(INavigation navigation)
        {
            _Cars = new ObservableCollection<Car>();
            GetCars();
            _navigation = navigation;
        }
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }
        private async Task GetCars()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                var carsService = new CarServices();
                var items = await carsService.GetCarsAsync(string.Format("{0}{1}", ServerConstants.Endpoint, ServerConstants.METHOD_GET_METHOD));
                _Cars.Clear();
                foreach (var item in items)
                    _Cars.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
