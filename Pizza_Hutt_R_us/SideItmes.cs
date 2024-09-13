
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Hutt_R_us
{
        public class Sides : INotifyPropertyChanged
        {
            private int _quantity = 1; // sætter default item til 1 


            public string Name { get; set; }
            public decimal Price { get; set; }


            public int Quantiy //gøre så quantity updater og pricen updater
            {
                get => _quantity;
                set
                {
                    if (_quantity != value)
                    {
                        _quantity = value;
                        OnPropertyChanged(nameof(Quantiy));
                        OnPropertyChanged(nameof(TotalPrice));
                    }
                }
            }
            public decimal TotalPrice { get { return Price * _quantity; } } //lægger pricen sammen med quaintyoty

            public event PropertyChangedEventHandler PropertyChanged; //når noget ændres tager den fadt i det og displayer det

            protected virtual void OnPropertyChanged(string propertyName) //ja update display også
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

        }

    }
