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
        int selected_film = -1;
        int selected_client = -1;
        int selected_session = -1;
        Film film;
        Session session;
        List<Film> films;
        List<Session> sessions;

        public AddTicket(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            AddRangeFilms((new Cinema_DataBaseEntities()).Films.ToList());
            AddRangeSessions((new Cinema_DataBaseEntities()).Sessions.ToList());

            Client empty = new Client();
            empty.id = 0;
            empty.name = "Нет";
            List<Client> clients = new List<Client>();
            clients.Add(empty);
            clients.AddRange((new Cinema_DataBaseEntities()).Clients.ToList());
            AddRangeClients(clients);

            
        }
        private void AddRangeClients(List<Client> list)
        {
            Client_CB.Items.Clear();
            foreach (var item in list)
            {
                Client_CB.Items.Add(item);
            }
        }
        private void AddRangeSessions(List<Session> list)
        {
            session = Session_CB.SelectedItem as Session;
            Session_CB.Items.Clear();
            Session tmp = new Session();
            tmp.id = 0;
            tmp.date = new DateTime();
            //Session_CB.Items.Add(tmp);
            foreach (var item in list)
            {
                Session_CB.Items.Add(item);
            }
        }
        private void AddRangeFilms(List<Film> list)
        {
            film = Film_CB.SelectedItem as Film;
            Film_CB.Items.Clear();
            Film tmp = new Film();
            tmp.id = 0;
            tmp.name = "Нет";
            //Film_CB.Items.Add(tmp);
            foreach (var item in list)
            {
                Film_CB.Items.Add(item);
            }
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
                if (selected_client == 0) table.id_client = null;
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
        private void Film_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected_film = -1;
            if (Film_CB.SelectedIndex == -1) return;
            selected_film = ((Film)Film_CB.SelectedItem).id;
            //if (session != null && session.id == 0) AddRangeSessions((new Cinema_DataBaseEntities()).Sessions.ToList());
            //else
            //{
                AddRangeSessions((new Cinema_DataBaseEntities()).Sessions
                    .Where(x => x.id_film == ((Film)Film_CB.SelectedItem).id).ToList());
                if (session != null) Session_CB.SelectedValue = session.id;
            //}
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
            //if  (film != null && film.id == 0) AddRangeFilms((new Cinema_DataBaseEntities()).Films.ToList());
            //else
            //{
                AddRangeFilms((new Cinema_DataBaseEntities()).Films
                    .Where(x => x.id == ((Session)Session_CB.SelectedItem).id_film).ToList());
                if (film != null) Film_CB.SelectedValue = film.id;
            //}
        }

        private void Clear_Film_B_Click(object sender, RoutedEventArgs e)
        {
            AddRangeFilms((new Cinema_DataBaseEntities()).Films.ToList());
        }

        private void Clear_Session_B_Click(object sender, RoutedEventArgs e)
        {
            AddRangeSessions((new Cinema_DataBaseEntities()).Sessions.ToList());
        }
    }
}
