using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        public void ReadformJson()
        {
            string data = File.ReadAllText(AppContext.BaseDirectory + "data.json");
            PizzaMenu nyePizzaer = JsonConvert.DeserializeObject<PizzaMenu>(data);
            pizzaMenu = nyePizzaer;

            string dataside = File.ReadAllText(AppContext.BaseDirectory + "Sides.json");
            AccompanimentsMenu nyesides = JsonConvert.DeserializeObject<AccompanimentsMenu>(dataside);
            accompanimentsMenu = nyesides;

            string datatop = File.ReadAllText(AppContext.BaseDirectory + "toppings.json");
            ToppingsMenu nyetop = JsonConvert.DeserializeObject<ToppingsMenu>(datatop);
            toppingsMenu = nyetop;

        }
        public void WritetoJson()
        {
            //string json = JsonConvert.SerializeObject(pizzaMenu);
            //File.WriteAllText(AppContext.BaseDirectory + "data.json", json);

            //string jsontop = JsonConvert.SerializeObject(toppingsMenu);
            //File.WriteAllText(AppContext.BaseDirectory + "toppings.json", jsontop);

            //string jsonside = JsonConvert.SerializeObject(accompanimentsMenu);
            //File.WriteAllText(AppContext.BaseDirectory + "Sides.json", jsonside);

        }
    }
}
