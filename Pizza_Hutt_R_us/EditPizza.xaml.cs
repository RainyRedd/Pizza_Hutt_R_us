using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pizza_Hutt_R_us
{
    /// <summary>
    /// Interaction logic for EditPizza.xaml
    /// </summary>
    public partial class EditPizza : Window
    {
        private Pizzas _pizza;
        private Action<Pizzas> _onSaveCallback;

        public ObservableCollection<Toppings> toppings { get; set; } = new();
        public ObservableCollection<Toppings> toppingsadded { get; set; } = new();
        public EditPizza(Pizzas pizza, Action<Pizzas> onSave)
        {
            Dal dal = new Dal();
            dal.ReadformJson();
            toppings = dal.GetToppings();
            InitializeComponent();
            
            _pizza = pizza;
            toppingsadded = pizza.toppings;
            _onSaveCallback = onSave; // Store the callback

            DataContext = this;
            PizzaNameTextBlock.Text = $"Pizza Name: {_pizza.Name}";
            UpdateTotalPrice();
        }

        private void Delete_Topping(object sender, RoutedEventArgs e)
        {
            Toppings topping = ((Button)sender).DataContext as Toppings;

            if (topping != null)
            {

                topping.Quantiy--;

                if (topping.Quantiy <= 0)
                {
                    toppingsadded.Remove(topping);
                }
            }


            UpdateTotalPrice();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _onSaveCallback?.Invoke(_pizza); 
            this.Close(); 
        }

        private void Toppingsadd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ToppingsAdd.SelectedItem is Toppings selectedTopping)
            {
                AddOrUpdateSides(new Toppings(selectedTopping.ID, selectedTopping.Name, selectedTopping.Quantiy, selectedTopping.Price));
                UpdateTotalPrice();
            }
        }

        private void Toppings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ToppingsAdd.SelectedItem is Toppings selectedTopping)
            {
                AddOrUpdateSides(new Toppings(selectedTopping.ID, selectedTopping.Name, selectedTopping.Quantiy, selectedTopping.Price));
                UpdateTotalPrice();
            }
        }
        private void Receipt_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void AddOrUpdateSides(Toppings newItem) //Updater Quanitity og tilføger il recite hvis item ikke er det på
        {
            var existingItem = toppingsadded.FirstOrDefault(item => item.Name == newItem.Name);
            if (existingItem != null)
            {
                existingItem.Quantiy++;
            }
            else
            {
                toppingsadded.Add(newItem);
            }
        }
        //-----------------------------------------Updater pricen i boxen
        private void UpdateTotalPrice() //updater pricen i bånden i text boxen
        {
            decimal toppingstotal = toppingsadded.Sum(item => item.TotalPrice);
            decimal Basepizza = 40;
            Price.Text = $"Total Price: {toppingstotal + Basepizza:C}";
        }

        private void Toppings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
