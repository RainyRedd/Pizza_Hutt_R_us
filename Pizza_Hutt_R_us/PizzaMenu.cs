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
        public class PizzaMenu
        {
            public ObservableCollection<Pizzas> pizzaer = new ObservableCollection<Pizzas>();
            //public PizzaMenu()
            //{
            //    pizzaer.Add(new Pizzas(1, "Margurite", 60, "Cheese", 1, new ObservableCollection<Toppings>
            //    {
            //        new Toppings(1, "Cheese", 1, 5),
            //        new Toppings(3, "Sause",1, 5)

            //    }));
            //    pizzaer.Add(new Pizzas(2, "Meat Lover", 60, "Meaty", 1, new ObservableCollection<Toppings>
            //    {
            //        new Toppings(1, "Cheese", 1, 5),
            //        new Toppings(3, "Sause",1, 5),
            //        new Toppings(4, "Kebab",1 , 5),
            //        new Toppings(5, "Peparioni",1 ,5),
            //        new Toppings(6, "Ham",1 ,5)

            //}));
            //    pizzaer.Add(new Pizzas(3, "Costom Pizza", 60, "Build Youre Own!", 1, new ObservableCollection<Toppings>
            //    {


            //    }));



            //}

        }

    }
}
