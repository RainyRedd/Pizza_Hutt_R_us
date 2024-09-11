using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pizza_Hutt_R_us
{
    public class Pizzas : INotifyPropertyChanged
    {
        public ObservableCollection<Toppings> toppings { get; set; }
        public int ID { get; set; }
        private string name { get; set; }

        private decimal basePrice = 40m;  

        public decimal BasePrice
        {
            get => basePrice;
            set
            {
                if (basePrice != value)
                {
                    basePrice = value;
                    OnPropertyChanged(nameof(Price)); 
                }
            }
        }
        private string description 
        { 
            get
            {
                StringBuilder sb = new StringBuilder("Lækker pizza med ");
                foreach (var item in toppings)
                {
                    sb.Append(item.Name);
                    sb.Append(", ");
                }
                return sb.ToString();
            }
        }
        
        private decimal price { get; }

        private int _quantity = 1; // sætter default item til 1

        public string Name
        {
            get => name;
            set
            {
                name = value;

            }
        }


        public string Description

        {
            get => description;

           
        }


        public decimal Price
        {
            get
            {
                decimal toppingsCost = toppings?.Sum(t => t.Price * t.Quantiy) ?? 0; 
                return BasePrice + toppingsCost; 
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

        public Pizzas(int id, string name, decimal price, string description, int quantity, ObservableCollection<Toppings> toppings)
        {
            this.ID = id;
            this.Name = name;
            this.BasePrice = basePrice;
            this._quantity = quantity;
            this.toppings = new ObservableCollection<Toppings>(toppings.Select(t => new Toppings(t.ID, t.Name, t.Quantiy, t.Price)));
        }

        

    }
}

