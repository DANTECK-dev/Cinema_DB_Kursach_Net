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
    /// Логика взаимодействия для EditTicket.xaml
    /// </summary>
    public partial class EditTicket : Window
    {
        cinema_DBEntities _entities;
        int selected_client = -1;
        int selected_session = -1;
        public EditTicket()
        {
            InitializeComponent();
            _entities = new cinema_DBEntities();
            Session_CB.ItemsSource = _entities.Sessions.ToList();
            Client_CB.ItemsSource = _entities.Clients.ToList();
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
                Ticket table = Name_CB.SelectedItem as Ticket;      // вытаскиваем клиента из списка ComboBox`a

                // изменяем данные выбраного маршрута
                _entities.Tickets.Find(table.id).price = int.Parse(Price_TB.Text);
                _entities.Tickets.Find(table.id).status = Status_L.Content as string;
                _entities.Tickets.Find(table.id).id_session = selected_session;
                if (selected_client == 0) _entities.Tickets.Find(table.id).id_client = null;
                else _entities.Tickets.Find(table.id).id_client = selected_client;

                _entities.SaveChanges();         // сохраняем изменения в БД
                Status.Content = "Запись успешно измененна";        // выводим текст об успешном выполнении запроса
            }
            catch (Exception ex)
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Name_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";
            if (Name_CB.SelectedItem == null) return;
            ID_TB.Text = ((Ticket)(Name_CB.SelectedItem)).id.ToString();
            Price_TB.Text = ((Ticket)(Name_CB.SelectedItem)).price.ToString();
            Status_L.Content = ((Ticket)(Name_CB.SelectedItem)).status;
            Session_CB.SelectedItem = ((Ticket)(Name_CB.SelectedItem)).Session;
            Client_CB.SelectedItem = ((Ticket)(Name_CB.SelectedItem)).Client;
        }
        private void Client_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected_client = -1;
            if (Client_CB.SelectedIndex == -1) return;
            if (Client_CB.SelectedIndex == 0) Status_L.Content = "свободно";
            else Status_L.Content = "занято";
            selected_client = ((Client)Client_CB.SelectedItem).id;
        }
        private void Session_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected_session = -1;
            if (Session_CB.SelectedIndex == -1) return;
            selected_session = ((Session)Session_CB.SelectedItem).id;
        }

    }
}
