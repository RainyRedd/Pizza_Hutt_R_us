using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Hutt_R_us
{
    internal partial class Dal
    {
        public class AccompanimentsMenu
        {
            public ObservableCollection<Accompaniments> accompaniments = new ObservableCollection<Accompaniments>();
            public AccompanimentsMenu()
            {
                accompaniments.Add(new Accompaniments(1, "Cola", 12));
                accompaniments.Add(new Accompaniments(2, "Pepsi", 12));
                accompaniments.Add(new Accompaniments(3, "Monster", 20));
                accompaniments.Add(new Accompaniments(4, "Pomfritter", 35));
            }

        }

    }
}
