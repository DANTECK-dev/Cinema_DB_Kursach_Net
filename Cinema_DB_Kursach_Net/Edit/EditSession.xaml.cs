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
using System.Windows.Shapes;

namespace Cinema_DB_Kursach_Net
{
    /// <summary>
    /// Логика взаимодействия для EditSession.xaml
    /// </summary>
    public partial class EditSession : Window
    {
        Cinema_DataBaseEntities _entities;
        int selected_hall = -1;
        int selected_film = -1;
        public EditSession(Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            Date_CB.ItemsSource = _entities.Sessions.ToList();
            Hall_CB.ItemsSource = _entities.Halls.ToList();
            Film_CB.ItemsSource = _entities.Films.ToList();
        }
        private void Change(object sender = null, TextChangedEventArgs e = null)
        {
            if (Status != null)
                Status.Content = "";
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            try
            {
                Session table = Date_CB.SelectedItem as Session;      // вытаскиваем клиента из списка ComboBox`a

                // изменяем данные выбраного маршрута
                _entities.Sessions.Find(table.id).date = DateTime.Parse(Date_TB.Text);
                _entities.Sessions.Find(table.id).duration = int.Parse(Duration_TB.Text);
                _entities.Sessions.Find(table.id).id_hall = selected_hall;
                _entities.Sessions.Find(table.id).id_film = selected_film;

                _entities.SaveChanges();         // сохраняем изменения в БД
                Status.Content = "Запись успешно измененна";        // выводим текст об успешном выполнении запроса
            }
            catch (Exception ex)
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Date_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";
            if (Date_CB.SelectedItem == null) return;
            ID_TB.Text = ((Session)(Date_CB.SelectedItem)).id.ToString();
            Date_TB.Text = ((Session)(Date_CB.SelectedItem)).date.ToString();
            Duration_TB.Text = ((Session)(Date_CB.SelectedItem)).duration.ToString();
            Hall_CB.SelectedItem = ((Session)(Date_CB.SelectedItem)).Hall;
            Film_CB.SelectedItem = ((Session)(Date_CB.SelectedItem)).Film;
        }

        private void Hall_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected_hall = -1;
            if (Hall_CB.SelectedIndex == -1) return;
            selected_hall = ((Hall)Hall_CB.SelectedItem).id;
        }
        private void Film_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected_film = -1;
            if (Film_CB.SelectedIndex == -1) return;
            selected_film = ((Film)Film_CB.SelectedItem).id;
        }
    }
}
