using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using demoPoC.Models;

namespace demoPoC.ViewModels
{
    public class ConsistDetailViewModel: BaseViewModel
    {
        private Consist _consist;

        public Consist _Consist
        {
            get { return _consist; }
            set { SetProperty(ref _consist, value); }
        }

        public ConsistDetailViewModel()
        {

            //Nothing is there in the Constructor
        }

        public void SetData(Consist consist)
        {
            _Consist = consist;


        }
    }
}
