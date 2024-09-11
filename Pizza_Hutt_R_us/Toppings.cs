using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Hutt_R_us
{
    public class Toppings : INotifyPropertyChanged
    {

        public int ID { get; set; }
        private string name { get; set; }      

        private decimal price { get; set; }

        private int _quantity = 1; // sætter default item til 1 
        public string Name
        {
            get => name;
            set
            {
                name = value;

            }
        }   

        public decimal Price
        {
            get => price;
            set
            {
                price = value;

            }
        }
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

        public Toppings(int ID, string name, int quantiy , decimal price)
        {
            this.ID = ID;
            this.Name = name;
            this.Quantiy = quantiy;
            this.Price = price;
    
        }


    }
}

