using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cinema_DB_Kursach_Net
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        // VIEW
        private void OpenViewCinema(object sender, RoutedEventArgs e)
        {
            ViewCinema window = new ViewCinema();
            window.Show();
        }
        private void OpenViewClient(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenViewFilm(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenViewHall(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenViewSession(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenViewStaff(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenViewTicket(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }


        //EDIT
        private void OpenEditClient(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenEditFilm(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenEditHall(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenEditSession(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenEditStaff(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenEditTicket(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }


        // ADD
        private void OpenAddClient(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenAddFilm(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenAddHall(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenAddSession(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenAddStaff(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenAddTicket(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }


        // DEL
        private void OpenDelClient(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenDelFilm(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenDelHall(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenDelSession(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenDelStaff(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
        private void OpenDelTicket(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
    }
}
