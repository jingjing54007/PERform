using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PERform.Viewmodels
{
    public class ModifierViewModel
    {
        private static ModifierViewModel instance;

        private ModifierViewModel() { }

        public static ModifierViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModifierViewModel();
                }

                return instance;
            }
        }
    }
}
