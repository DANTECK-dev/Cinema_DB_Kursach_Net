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
    /// Логика взаимодействия для FullTicket.xaml
    /// </summary>
    public partial class FullTicket : Window
    {
        Cinema_DataBaseEntities _entities;
        string Selected_MovieName = null;
        string Selected_Genre = null;
        string Selected_CountryProducer = null;
        string Selected_AgeRating = null;
        string Selected_Duration = null;
        string Selected_DateTime = null;
        string Selected_HallName = null;
        string Selected_HallType = null;
        string Selected_HallCapacity = null;
        string Selected_CinemaName = null;
        string Selected_Address = null;
        string Selected_Contact = null;
        string Selected_Price = null;
        string Selected_Status = null;
        string Selected_ClientName = null;
        string Selected_ClientSurname = null;
        string Selected_ClientContact = null;

        List<Full_Ticket> list;
        public FullTicket(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            FillComboBox(MovieName_CB,          _entities.Full_Ticket.ToList(), x => x.name);
            FillComboBox(Genre_CB,              _entities.Full_Ticket.ToList(), x => x.genre);
            FillComboBox(CountryProducer_CB,    _entities.Full_Ticket.ToList(), x => x.country);
            FillComboBox(AgeRating_CB,          _entities.Full_Ticket.ToList(), x => x.age_rating);
            FillComboBox(Duration_CB,           _entities.Full_Ticket.ToList(), x => x.duration);
            FillComboBox(DateTime_CB,           _entities.Full_Ticket.ToList(), x => x.date);
            FillComboBox(HallName_CB,           _entities.Full_Ticket.ToList(), x => x.hall_name);
            FillComboBox(HallType_CB,           _entities.Full_Ticket.ToList(), x => x.type);
            FillComboBox(HallCapacity_CB,       _entities.Full_Ticket.ToList(), x => x.capacity);
            FillComboBox(CinemaName_CB,         _entities.Full_Ticket.ToList(), x => x.cinema_name);
            FillComboBox(Address_CB,            _entities.Full_Ticket.ToList(), x => x.address);
            FillComboBox(Contact_CB,            _entities.Full_Ticket.ToList(), x => x.contact);
            FillComboBox(Price_CB,              _entities.Full_Ticket.ToList(), x => x.price);
            FillComboBox(Status_CB,             _entities.Full_Ticket.ToList(), x => x.status);
            FillComboBox(ClientName_CB,         _entities.Full_Ticket.ToList(), x => x.client_name);
            FillComboBox(ClientSurname_CB,      _entities.Full_Ticket.ToList(), x => x.surname);
            FillComboBox(ClientContact_CB,      _entities.Full_Ticket.ToList(), x => x.client_contact);

            Update();
        }
        private void FillComboBox<T>(ComboBox comboBox, List<Full_Ticket> film_Session_Halls, Func<Full_Ticket, T> selector)
        {
            var uniqueItems = new List<T> { }; // Добавляем "Пусто" (или default для типа T)
            uniqueItems.AddRange(film_Session_Halls.Select(selector).Distinct());

            comboBox.ItemsSource = uniqueItems;
        }
        private string Select(ComboBox comboBox)
        {
            if (comboBox.SelectedIndex == -1)
                return null;
            else
                return comboBox.Text;
        }
        private void Update()
        {

            list = _entities.Full_Ticket.ToList();

            if (Selected_MovieName != null)
                list = list.Where(x => x.name == Selected_MovieName).ToList();

            if (Selected_Genre != null)
                list = list.Where(x => x.genre == Selected_Genre).ToList();

            if (Selected_CountryProducer != null)
                list = list.Where(x => x.country == Selected_CountryProducer).ToList();

            if (Selected_AgeRating != null)
                list = list.Where(x => x.age_rating == Selected_AgeRating).ToList();

            if (Selected_Duration != null)
                list = list.Where(x => x.duration.ToString() == Selected_Duration).ToList();

            if (Selected_DateTime != null)
                list = list.Where(x => x.date.ToString() == Selected_DateTime).ToList();

            if (Selected_HallName != null)
                list = list.Where(x => x.hall_name == Selected_HallName).ToList();

            if (Selected_HallType != null)
                list = list.Where(x => x.type == Selected_HallType).ToList();

            if (Selected_HallCapacity != null)
                list = list.Where(x => x.capacity.ToString() == Selected_HallCapacity).ToList();

            if (Selected_CinemaName != null)
                list = list.Where(x => x.cinema_name == Selected_CinemaName).ToList();

            if (Selected_Address != null)
                list = list.Where(x => x.address == Selected_Address).ToList();

            if (Selected_Contact != null)
                list = list.Where(x => x.contact.ToString() == Selected_Contact).ToList();

            if (Selected_Price != null)
                list = list.Where(x => x.price.ToString() == Selected_Price).ToList();

            if (Selected_Status != null)
                list = list.Where(x => x.status == Selected_Status).ToList();

            if (Selected_ClientName != null)
                list = list.Where(x => x.client_name == Selected_ClientName).ToList();

            if (Selected_ClientSurname != null)
                list = list.Where(x => x.surname.ToString() == Selected_ClientSurname).ToList();

            if (Selected_ClientContact != null)
                list = list.Where(x => x.client_contact == Selected_ClientContact).ToList();



            int count = _DataGrid.Items.Count;
            for (int i = 0; i < count; i++)
                _DataGrid.Items.RemoveAt(0);
            for (int i = 0; i < list.Count; i++)
                _DataGrid.Items.Add(list[i]);
        }
        private void Clear_Selected(ComboBox comboBox)
        {
            comboBox.SelectedItem = null;
            comboBox.SelectedIndex = -1;
            Update();
        }
        private void MovieName_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_MovieName = Select(MovieName_CB);
            Update();
        }

        private void Genre_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Genre = Select(Genre_CB);
            Update();
        }

        private void CountryProducer_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_CountryProducer = Select(CountryProducer_CB);
            Update();
        }

        private void AgeRating_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_AgeRating = Select(AgeRating_CB);
            Update();
        }

        private void Duration_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Duration = Select(Duration_CB);
            Update();
        }

        private void DateTime_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_DateTime = Select(DateTime_CB);
            Update();
        }

        private void HallName_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_HallName = Select(HallName_CB);
            Update();
        }

        private void HallType_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_HallType = Select(HallType_CB);
            Update();
        }

        private void HallCapacity_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_HallCapacity = Select(HallCapacity_CB);
            Update();
        }

        private void CinemaName_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_CinemaName = Select(CinemaName_CB);
            Update();
        }

        private void Address_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Address = Select(Address_CB);
            Update();
        }

        private void Contact_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Contact = Select(Contact_CB);
            Update();
        }

        private void Price_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Price = Select(Price_CB);
            Update();
        }

        private void Status_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Status = Select(Status_CB);
            Update();
        }

        private void ClientName_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_ClientName = Select(ClientName_CB);
            Update();
        }

        private void ClientSurname_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_ClientSurname = Select(ClientSurname_CB);
            Update();
        }

        private void ClientContact_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_ClientContact = Select(ClientContact_CB);
            Update();
        }
        private void MovieName_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_MovieName = null;
            Clear_Selected(MovieName_CB);
        }

        private void Genre_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Genre = null;
            Clear_Selected(Genre_CB);
        }

        private void CountryProducer_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_CountryProducer = null;
            Clear_Selected(CountryProducer_CB);
        }

        private void AgeRating_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_AgeRating = null;
            Clear_Selected(AgeRating_CB);
        }

        private void Duration_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Duration = null;
            Clear_Selected(Duration_CB);
        }

        private void DateTime_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_DateTime = null;
            Clear_Selected(DateTime_CB);
        }

        private void HallName_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_HallName = null;
            Clear_Selected(HallName_CB);
        }

        private void HallType_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_HallType = null;
            Clear_Selected(HallType_CB);
        }

        private void HallCapacity_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_HallCapacity = null;
            Clear_Selected(HallCapacity_CB);
        }

        private void CinemaName_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_CinemaName = null;
            Clear_Selected(CinemaName_CB);
        }

        private void Address_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Address = null;
            Clear_Selected(Address_CB);
        }

        private void Contact_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Contact = null;
            Clear_Selected(Contact_CB);
        }

        private void Price_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Price = null;
            Clear_Selected(Price_CB);
        }

        private void Status_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Status = null;
            Clear_Selected(Status_CB);
        }

        private void ClientName_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_ClientName = null;
            Clear_Selected(ClientName_CB);
        }

        private void ClientSurname_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_ClientSurname = null;
            Clear_Selected(ClientSurname_CB);
        }

        private void ClientContact_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_ClientContact = null;
            Clear_Selected(ClientContact_CB);
        }

    }
}
