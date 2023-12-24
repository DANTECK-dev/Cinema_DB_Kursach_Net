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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Cinema_DB_Kursach_Net
{
    /// <summary>
    /// Логика взаимодействия для AddTicket.xaml
    /// </summary>
    public partial class AddTicket : Window
    {
        Cinema_DataBaseEntities _entities;
        int selected_session = -1;
        int selected_client = -1;

        public AddTicket(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
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
            try
            {

                Ticket table = new Ticket();

                table.price = int.Parse(Price_TB.Text);
                table.status = (string)Status_L.Content;
                if (selected_client == -1) table.id_client = null;
                else table.id_client = selected_client;
                table.id_session = selected_session;

                _entities.Tickets.Add(table);
                _entities.SaveChanges();
                Status.Content = "Запись успешно добавлена";

            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void Client_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Change();
            Client_CB.SelectedItem = null;
            Client_CB.SelectedIndex = -1;
            selected_client = -1;
            Status_L.Content = "свободно";
        }
    }
}
