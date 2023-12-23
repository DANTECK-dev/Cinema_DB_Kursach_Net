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
        Cinema_DataBaseEntities _entities;
        public MainWindow()
        {
            InitializeComponent();
            _entities = new Cinema_DataBaseEntities();
        }


        // VIEW
        private void OpenViewCinema(object sender, RoutedEventArgs e)
        {
            ViewCinema window = new ViewCinema(ref _entities);
            window.Show();
        }
        private void OpenViewClient(object sender, RoutedEventArgs e)
        {
            ViewClient window = new ViewClient(ref _entities);
            window.Show();
        }
        private void OpenViewFilm(object sender, RoutedEventArgs e)
        {
            ViewFilm window = new ViewFilm(ref _entities);
            window.Show();
        }
        private void OpenViewHall(object sender, RoutedEventArgs e)
        {
            ViewHall window = new ViewHall(ref _entities);
            window.Show();
        }
        private void OpenViewSession(object sender, RoutedEventArgs e)
        {
            ViewSession window = new ViewSession(ref _entities);
            window.Show();
        }
        private void OpenViewStaff(object sender, RoutedEventArgs e)
        {
            ViewStaff window = new ViewStaff(ref _entities);
            window.Show();
        }
        private void OpenViewTicket(object sender, RoutedEventArgs e)
        {
            ViewTicket window = new ViewTicket(ref _entities);
            window.Show();
        }


        //EDIT
        private void OpenEditClient(object sender, RoutedEventArgs e)
        {
            EditClient window = new EditClient(ref _entities);
            window.Show();
        }
        private void OpenEditFilm(object sender, RoutedEventArgs e)
        {
            EditFilm window = new EditFilm(ref _entities);
            window.Show();
        }
        private void OpenEditHall(object sender, RoutedEventArgs e)
        {
            EditHall window = new EditHall(ref _entities);
            window.Show();
        }
        private void OpenEditSession(object sender, RoutedEventArgs e)
        {
            EditSession window = new EditSession(ref _entities);
            window.Show();
        }
        private void OpenEditStaff(object sender, RoutedEventArgs e)
        {
            EditStaff window = new EditStaff(ref _entities);
            window.Show();
        }
        private void OpenEditTicket(object sender, RoutedEventArgs e)
        {
            EditTicket window = new EditTicket(ref _entities);
            window.Show();
        }


        // ADD
        private void OpenAddClient(object sender, RoutedEventArgs e)
        {
            AddClient window = new AddClient(ref _entities);
            window.Show();
        }
        private void OpenAddFilm(object sender, RoutedEventArgs e)
        {
            AddFilm window = new AddFilm(ref _entities);
            window.Show();
        }
        private void OpenAddHall(object sender, RoutedEventArgs e)
        {
            AddHall window = new AddHall(ref _entities);
            window.Show();
        }
        private void OpenAddSession(object sender, RoutedEventArgs e)
        {
            AddSession window = new AddSession(ref _entities);
            window.Show();
        }
        private void OpenAddStaff(object sender, RoutedEventArgs e)
        {
            AddStaff window = new AddStaff(ref _entities);
            window.Show();
        }
        private void OpenAddTicket(object sender, RoutedEventArgs e)
        {
            AddTicket window = new AddTicket(ref _entities);
            window.Show();
        }


        // DEL
        private void OpenDelClient(object sender, RoutedEventArgs e)
        {
            DelClient window = new DelClient(ref _entities);
            window.Show();
        }
        private void OpenDelFilm(object sender, RoutedEventArgs e)
        {
            DelFilm window = new DelFilm(ref _entities);
            window.Show();
        }
        private void OpenDelHall(object sender, RoutedEventArgs e)
        {
            DelHall window = new DelHall(ref _entities);
            window.Show();
        }
        private void OpenDelSession(object sender, RoutedEventArgs e)
        {
            DelSession window = new DelSession(ref _entities);
            window.Show();
        }
        private void OpenDelStaff(object sender, RoutedEventArgs e)
        {
            DelStaff window = new DelStaff(ref _entities);
            window.Show();
        }
        private void OpenDelTicket(object sender, RoutedEventArgs e)
        {
            DelTicket window = new DelTicket(ref _entities);
            window.Show();
        }


        // REQUEST
        private void OpenFilmSessions(object sender, RoutedEventArgs e)
        {
            FilmSessions window = new FilmSessions(ref _entities);
            window.Show();
        }
        private void OpenRevenue(object sender, RoutedEventArgs e)
        {
            Revenue window = new Revenue(ref _entities);
            window.Show();
        }
        private void OpenFullTicket(object sender, RoutedEventArgs e)
        {
            FullTicket window = new FullTicket(ref _entities);
            window.Show();
        }
        private void OpenFullSession(object sender, RoutedEventArgs e)
        {
            FullSession window = new FullSession(ref _entities);
            window.Show();
        }
        private void OpenFilmSessionHall(object sender, RoutedEventArgs e)
        {
            FilmSessionHall window = new FilmSessionHall(ref _entities);
            window.Show();
        }
    }
}
