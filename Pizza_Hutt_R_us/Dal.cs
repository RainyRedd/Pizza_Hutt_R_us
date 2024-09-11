using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pizza_Hutt_R_us
{
    internal partial class Dal
    {
        

        PizzaMenu pizzaMenu = new PizzaMenu();

        AccompanimentsMenu accompanimentsMenu = new AccompanimentsMenu();

        ToppingsMenu toppingsMenu = new ToppingsMenu();


        public ObservableCollection<Pizzas> GetPizzas() //laver listen af pizzanerne
        {
            ObservableCollection<Pizzas> Plist = new ObservableCollection<Pizzas>();
            foreach (Pizzas p in pizzaMenu.pizzaer)
            {
                Plist.Add(new Pizzas(p.ID, p.Name, p.Price, p.Description, p.Quantiy , p.toppings));
            }
            return Plist;
        }

        public ObservableCollection<Accompaniments> GetAccompaniments()  //laver sides listen
        { 
         
            ObservableCollection<Accompaniments> Alist = new ObservableCollection<Accompaniments>(); 

            foreach (Accompaniments p in accompanimentsMenu.accompaniments)
            {
                Alist.Add(new Accompaniments(p.ID, p.Name, p.Cost));
            }
            return Alist;
        }

        public ObservableCollection<Toppings> GetToppings()
        {
            ObservableCollection<Toppings> Tlist = new ObservableCollection<Toppings>();

            foreach (Toppings p in toppingsMenu.toppings)
            {
                Tlist.Add(new Toppings(p.ID, p.Name, p.Quantiy , p.Price));
            }
            return Tlist;

        }
    }
}
