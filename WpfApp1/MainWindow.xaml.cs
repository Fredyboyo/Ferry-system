using BusinessLogic.BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Linq;
using System.Windows.Input;
using System.Windows.Data;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // --------------------------------------------------------- Init
        private List<Ferry> ferries;
        private Ferry selectedFerry;
        private Passenger selectedPassenger;
        private Car selectedCar;
        public MainWindow()
        {
            InitializeComponent();
            CBPassengerSex.ItemsSource = Enum.GetValues(typeof(Sex));
            ReloadFerries();
        }

        // ---------------------------------------------------------- MISC

        private void ReloadFerries()
        {
            ferries = BLL.GetFerries();
            LBFerries.ItemsSource = ferries.ConvertAll(f => f.ferryID + " | " + f.name);
            if (LBFerries.SelectedIndex == -1)
            {
                LBPassengers.ItemsSource = null;
                LBCars.ItemsSource = null;
                selectedPassenger = null;
                selectedCar = null;
                TBFerryName.Clear();
                TBPassengerName.Clear();
                CBPassengerSex.SelectedIndex = -1;
                CBPassengerCar.SelectedIndex = -1;
                return;
            }
            selectedFerry = ferries[LBFerries.SelectedIndex];

            TBFerryName.Text = selectedFerry.name;
            LBPassengers.ItemsSource = selectedFerry.passengers.ConvertAll(p => p.passengerID + " | " + p.name);
            LBPassengers.SelectedIndex = -1;
            LBCars.ItemsSource = selectedFerry.cars.ConvertAll(car => car.carID + " | ");
            LBCars.SelectedIndex = -1;
            List<string> strings = new List<string> { "None" };
            strings.AddRange(selectedFerry.cars.ConvertAll(c => c.carID.ToString()));

            CBPassengerCar.ItemsSource = strings;
        }

        private void ChoseFerry(object sender, SelectionChangedEventArgs e)
        {
            ReloadFerries();
        }

        private void PassengerSelected(object sender, RoutedEventArgs e)
        {
            if (LBPassengers.SelectedIndex == -1)
            {
                selectedPassenger = null;
                TBPassengerName.Clear();
                CBPassengerSex.SelectedIndex = -1;
                CBPassengerCar.SelectedIndex = -1;
                return;
            }
            selectedPassenger = selectedFerry.passengers[LBPassengers.SelectedIndex];

            TBPassengerName.Text = selectedPassenger.name;

            CBPassengerSex.SelectedIndex = (int)selectedPassenger.sex;
            Car car = selectedFerry.cars.SingleOrDefault(c => c.passengers.Any(p => p.passengerID == selectedPassenger.passengerID));
            CBPassengerCar.SelectedValue = (car != null ? car.carID.ToString() : "None");
        }
        private void CarSelected(object sender, RoutedEventArgs e)
        {
            if (LBCars.SelectedIndex == -1)
            {
                return;
            }
            selectedCar = selectedFerry.cars[LBCars.SelectedIndex];
        }

        // --------------------------------------------------------- Add

        private void AddFerry(object sender, RoutedEventArgs e)
        {
            if (TBNewFerryName.Text.Length > 0)
            {
                BLL.AddFerry(new Ferry(TBNewFerryName.Text));
                TBNewFerryName.Clear();
                ReloadFerries();
            }
        }
        private void AddPassenger(object sender, RoutedEventArgs e)
        {
            if (selectedFerry == null)
            {
                return;
            }
            BLL.AddPassenger(new Passenger(), selectedFerry.ferryID,0);
            ReloadFerries();
            LBPassengers.SelectedIndex = LBPassengers.Items.Count - 1;
        }
        private void AddCar(object sender, RoutedEventArgs e)
        {
            if (selectedFerry == null)
            {
                return;
            }
            BLL.AddCar(new Car(), selectedFerry.ferryID);
            ReloadFerries();
        }

        // --------------------------------------------------------- Update

        private void UpdateFerry(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter || selectedFerry == null)
            {
                return;
            }
            selectedFerry.name = ((TextBox)sender).Text;
            if (selectedFerry.name.Length > 0)
            {
                BLL.UpdateFerry(selectedFerry);
                ReloadFerries();
            }
        }
        private void UpdatePassenger(object sender, RoutedEventArgs e)
        {
            if (selectedPassenger == null)
            {
                return;
            }
            selectedPassenger.name = TBPassengerName.Text;
            selectedPassenger.sex = (Sex)Enum.Parse(typeof(Sex), CBPassengerSex.Text);
            string s = CBPassengerCar.Text;
            if (s == "None")
            {
                s = "0";
            }
            BLL.UpdatePassenger(selectedPassenger, int.Parse(s));
            ReloadFerries();
        }

        // --------------------------------------------------------- Delete

        private void DeleteFerry(object sender, RoutedEventArgs e)
        {
            if (selectedFerry == null)
            {
                return;
            }
            BLL.DeleteFerry(selectedFerry.ferryID);
            LBFerries.SelectedIndex = -1;
            selectedFerry = null;
            ReloadFerries();
        }

        private void DeletePassenger(object sender, RoutedEventArgs e)
        {
            if (selectedPassenger == null)
            {
                return;
            }
            BLL.DeletePassenger(selectedPassenger.passengerID);
            selectedFerry = null;
            ReloadFerries();
        }

        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            if (selectedCar == null)
            {
                return;
            }
            BLL.DeleteCar(selectedCar.carID);
            selectedCar = null;
            ReloadFerries();
        }
    }
}
