using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using Newtonsoft.Json;


namespace Pizza_Hutt_R_us
{

    public partial class PizzaMenu : Window
    {
        public ObservableCollection<Pizzas> pizzas { get; set; } = new();
        public ObservableCollection<Accompaniments> accompaniments { get; set; } = new();        
        public ObservableCollection<Sides> ReceiptSides { get; set; } = new();
        public ObservableCollection<Pizzas> ReceiptPizza { get; set; } = new();


        public PizzaMenu()
        {
            Dal dal = new Dal();
            //dal.WritetoJson();
            dal.ReadformJson();
            pizzas = dal.GetPizzas();
            accompaniments = dal.GetAccompaniments();  
            
            ReceiptSides = new ObservableCollection<Sides>();
            InitializeComponent();
            DataContext = this;
        


        }


        //-------------------- føre items fra itmeslist over til recite 
        private void PayButton_Click(object sender, RoutedEventArgs e) //åbner pay window ingen function inu
        {
            var payWindow = new PayWindow(ReceiptPizza, ReceiptSides);
            payWindow.Show();
        }
        //----------------------- Cliker på item og køre function der tilføere og updater
        private void PizzaMenu1_SelectionChanged(object sender, SelectionChangedEventArgs e) //trygger updater den price on quantity på selected item
        {
            if (PizzaMenu1.SelectedItem is Pizzas selectedPizza)
            {
                AddOrUpdateItem(new Pizzas(selectedPizza.ID, selectedPizza.Name, selectedPizza.Price, selectedPizza.Description, selectedPizza.Quantiy , selectedPizza.toppings ));
                UpdateTotalPrice();
            }

        }
        //----------------------- Cliker på item og køre function der tilføere og updater
        private void SidesMenu_SelectionChanged(object sender, SelectionChangedEventArgs e) //trygger updater den price on quantity på selected item
        {
            if (SidesMenu.SelectedItem is Accompaniments selectedSide)
            {
                AddOrUpdateSides(new Sides { Name = selectedSide.Name, Price = selectedSide.Cost });
                UpdateTotalPrice();
            }

        }
        //------------------- clickker på item mouse down gøre man kan gøre det flere gange uden af skal trykke på noget andet føst
        private void PizzaMenu1_MouseDown(object sender, MouseButtonEventArgs e) //trygger updater den price on quantity på selected item
        {
            if (PizzaMenu1.SelectedItem is Pizzas selectedPizza)
            {
                AddOrUpdateItem(new Pizzas (selectedPizza.ID, selectedPizza.Name, selectedPizza.Price, selectedPizza.Description, selectedPizza.Quantiy, selectedPizza.toppings));
                UpdateTotalPrice();
            }
        }
        //------------------- clickker på item mouse down gøre man kan gøre det flere gange uden af skal trykke på noget andet føst
        private void SidesMenu_MouseDown(object sender, MouseButtonEventArgs e) //trygger updater den price on quantity på selected item
        {
            if (SidesMenu.SelectedItem is Accompaniments selectedSide)
            {
                AddOrUpdateSides(new Sides { Name = selectedSide.Name, Price = selectedSide.Cost });
                UpdateTotalPrice();
            }
        }
        //------------------------------- Pluser Quantiy up og tilgøre Item
        private void AddOrUpdateItem(Pizzas newItem)
        {
            var existingItem = ReceiptPizza.FirstOrDefault(item =>
                item.Name == newItem.Name &&
                item.Price == newItem.Price &&
                item.toppings.Count == newItem.toppings.Count &&
                item.toppings.All(topping => newItem.toppings.Any(nt => nt.Name == topping.Name))
            );

            if (existingItem != null)
            {
                
                existingItem.Quantiy++;
            }
            else
            {
                
                int newId = ReceiptPizza.Count > 0 ? ReceiptPizza.Max(p => p.ID) + 1 : 1;
                var clonedPizza = new Pizzas(newId, newItem.Name, newItem.Price, newItem.Description, 1,
                    new ObservableCollection<Toppings>(newItem.toppings.Select(t => new Toppings(t.ID, t.Name, t.Quantiy, t.Price))));

                ReceiptPizza.Add(clonedPizza);
            }
        }
        private void AddOrUpdateSides(Sides newItem) //Updater Quanitity og tilføger il recite hvis item ikke er det på
        {
            var existingItem = ReceiptSides.FirstOrDefault(item => item.Name == newItem.Name);
            if (existingItem != null)
            {
                existingItem.Quantiy++;
            }
            else
            {
                ReceiptSides.Add(newItem);
            }
        }
        //-----------------------------------------Updater pricen i boxen
        private void UpdateTotalPrice() //updater pricen i bånden i text boxen
        {
            decimal totalPricePizzas = ReceiptPizza.Sum(item => item.TotalPrice);
            decimal totalPriceSides = ReceiptSides.Sum(item => item.TotalPrice);
            TotalPriceTextBlock.Text = $"Total Price: { totalPricePizzas + totalPriceSides :C}";
        }

        private void Receipt_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Receipt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var selectedPizza = button.DataContext as Pizzas;
                if (selectedPizza != null)
                {
                    
                    var editPizzaWindow = new EditPizza(
                        new Pizzas(
                            selectedPizza.ID,
                            selectedPizza.Name,
                            selectedPizza.Price,
                            selectedPizza.Description,
                            selectedPizza.Quantiy,
                            new ObservableCollection<Toppings>(
                                selectedPizza.toppings.Select(t =>
                                    new Toppings(t.ID, t.Name, t.Quantiy, t.Price)) 
                            )
                        ),
                        editedPizza =>
                        {
                            
                            var originalPizza = ReceiptPizza.FirstOrDefault(p => p.ID == editedPizza.ID);
                            if (originalPizza != null)
                            {
                               
                                int index = ReceiptPizza.IndexOf(originalPizza);
                                ReceiptPizza[index] = editedPizza;
                            }
                            else
                            {
                               
                                ReceiptPizza.Add(editedPizza);
                            }

                            
                            UpdateTotalPrice();
                        }
                    );
                    editPizzaWindow.Show();
                    UpdateTotalPrice();
                }
                else
                {
                    MessageBox.Show("Unable to find the selected pizza.");
                }
            }
        }

        private void DeleteSides_Click(object sender, RoutedEventArgs e)
        {

            Sides side = ((Button)sender).DataContext as Sides;

            if (side != null)
            {

                side.Quantiy--;

                if (side.Quantiy <= 0)
                {
                    ReceiptSides.Remove(side);
                }
            }
            

            UpdateTotalPrice();
        }

        private void DeletePizza_Click(object sender, RoutedEventArgs e)
        {
            Pizzas Pizza = ((Button)sender).DataContext as Pizzas;

            if (Pizza != null)
            {

                Pizza.Quantiy--;

                if (Pizza.Quantiy <= 0)
                {
                    ReceiptPizza.Remove(Pizza);
                }
            }


            UpdateTotalPrice();
        }
    }
}
