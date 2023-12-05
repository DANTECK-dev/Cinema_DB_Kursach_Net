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
            ViewClient window = new ViewClient();
            window.Show();
        }
        private void OpenViewFilm(object sender, RoutedEventArgs e)
        {
            ViewFilm window = new ViewFilm();
            window.Show();
        }
        private void OpenViewHall(object sender, RoutedEventArgs e)
        {
            ViewHall window = new ViewHall();
            window.Show();
        }
        private void OpenViewSession(object sender, RoutedEventArgs e)
        {
            ViewSession window = new ViewSession();
            window.Show();
        }
        private void OpenViewStaff(object sender, RoutedEventArgs e)
        {
            ViewStaff window = new ViewStaff();
            window.Show();
        }
        private void OpenViewTicket(object sender, RoutedEventArgs e)
        {
            ViewTicket window = new ViewTicket();
            window.Show();
        }


        //EDIT
        private void OpenEditClient(object sender, RoutedEventArgs e)
        {
            EditClient window = new EditClient();
            window.Show();
        }
        private void OpenEditFilm(object sender, RoutedEventArgs e)
        {
            EditFilm window = new EditFilm();
            window.Show();
        }
        private void OpenEditHall(object sender, RoutedEventArgs e)
        {
            EditHall window = new EditHall();
            window.Show();
        }
        private void OpenEditSession(object sender, RoutedEventArgs e)
        {
            EditSession window = new EditSession();
            window.Show();
        }
        private void OpenEditStaff(object sender, RoutedEventArgs e)
        {
            EditStaff window = new EditStaff();
            window.Show();
        }
        private void OpenEditTicket(object sender, RoutedEventArgs e)
        {
            EditTicket window = new EditTicket();
            window.Show();
        }


        // ADD
        private void OpenAddClient(object sender, RoutedEventArgs e)
        {
            AddClient window = new AddClient();
            window.Show();
        }
        private void OpenAddFilm(object sender, RoutedEventArgs e)
        {
            AddFilm window = new AddFilm();
            window.Show();
        }
        private void OpenAddHall(object sender, RoutedEventArgs e)
        {
            AddHall window = new AddHall();
            window.Show();
        }
        private void OpenAddSession(object sender, RoutedEventArgs e)
        {
            AddSession window = new AddSession();
            window.Show();
        }
        private void OpenAddStaff(object sender, RoutedEventArgs e)
        {
            AddStaff window = new AddStaff();
            window.Show();
        }
        private void OpenAddTicket(object sender, RoutedEventArgs e)
        {
            AddTicket window = new AddTicket();
            window.Show();
        }


        // DEL
        private void OpenDelClient(object sender, RoutedEventArgs e)
        {
            DelClient window = new DelClient();
            window.Show();
        }
        private void OpenDelFilm(object sender, RoutedEventArgs e)
        {
            DelFilm window = new DelFilm();
            window.Show();
        }
        private void OpenDelHall(object sender, RoutedEventArgs e)
        {
            DelHall window = new DelHall();
            window.Show();
        }
        private void OpenDelSession(object sender, RoutedEventArgs e)
        {
            DelSession window = new DelSession();
            window.Show();
        }
        private void OpenDelStaff(object sender, RoutedEventArgs e)
        {
            DelStaff window = new DelStaff();
            window.Show();
        }
        private void OpenDelTicket(object sender, RoutedEventArgs e)
        {
            DelTicket window = new DelTicket();
            window.Show();
        }
    }
}
