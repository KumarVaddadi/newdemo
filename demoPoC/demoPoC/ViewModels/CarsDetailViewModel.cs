using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demoPoC.Models;
using MvvmHelpers;

namespace demoPoC.ViewModels
{
    public class CarsDetailViewModel: BaseViewModel
    {
        private Car _cars;

        public Car _Cars
        {
            get { return _cars; }
            set { SetProperty(ref _cars, value); }
        }

        public CarsDetailViewModel()
        {


        }

        public void SetData(Car cars)
        {
            _Cars = cars;


        }
    }
}
