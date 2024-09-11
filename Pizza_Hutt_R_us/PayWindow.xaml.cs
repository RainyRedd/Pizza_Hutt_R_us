using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class PayWindow : Window
    {
        public ObservableCollection<Pizzas> ReceiptPizza { get; set; } = new();
        public ObservableCollection<Sides> ReceiptSides { get; set; } = new();

        public PayWindow(ObservableCollection<Pizzas> items, ObservableCollection<Sides> sides)
        {
            InitializeComponent();

            ReceiptPizza = items;
            ReceiptSides = sides;

            Update();
        }

        private void Update()
        {
           
            var combinedReceipt = new ObservableCollection<object>();

         
            foreach (var pizza in ReceiptPizza)
            {
                combinedReceipt.Add(pizza);
            }

        
            foreach (var side in ReceiptSides)
            {
                combinedReceipt.Add(side);
            }

          
            ReceiptPay.ItemsSource = combinedReceipt;

           
            decimal totalPricePizzas = ReceiptPizza.Sum(item => item.TotalPrice);
            decimal totalPriceSides = ReceiptSides.Sum(side => side.TotalPrice);

            
            TotalPriceTextBlock.Text = $"Total Price: {totalPricePizzas + totalPriceSides:C}";
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            ReceiptPizza.Clear();
            ReceiptSides.Clear();

            ReceiptPay.ItemsSource = null;


            TotalPriceTextBlock.Text = $"Thank you for buying food with us";

        }

        private void Receipt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
