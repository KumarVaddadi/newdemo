using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoPoC.Models;
using System.Collections.ObjectModel;
using demoPoC.Views;
using System.Windows.Input;
using Xamarin.Forms;
using demoPoC.Services;
using demoPoC.Constants;
using System.Diagnostics;

namespace demoPoC.ViewModels
{
    public class ConsistViewModel: BaseViewModel
    {
        private Consist _consistSelected;
        public ObservableCollection<Consist> _Consist { get; set; }

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


        ICommand getConsistCommand;
        public ICommand GetConsistCommand =>
            getConsistCommand ??
            (getConsistCommand = new Command(async () => await GetConsist()));

        public INavigation _navigation;

        public ConsistViewModel()
        {
            _Consist = new ObservableCollection<Consist>();
            GetConsist();
        }
        public ConsistViewModel(INavigation navigation)
        {
            _Consist = new ObservableCollection<Consist>();
            GetConsist();
            _navigation = navigation;
        }
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy = false; }
            set { isBusy = value; OnPropertyChanged(); }
        }
        private async Task GetConsist()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                var consistService = new ConsistService();
                string url = string.Format("{0}{1}{2}", ServerConstants.Endpoint, ServerConstants.METHOD_GET_METHOD, "?fleetName=AC3K1_10");
                var items = await consistService.GetConsistAsync(url);
                _Consist.Clear();
                foreach (var item in items)
                    _Consist.Add(item);
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
