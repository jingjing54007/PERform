using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Viewmodels
{
    public class HomeViewModel
    {
        private static HomeViewModel instance;

        private HomeViewModel() { }

        public static HomeViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HomeViewModel();
                }

                return instance;
            }
        }
    }
}
