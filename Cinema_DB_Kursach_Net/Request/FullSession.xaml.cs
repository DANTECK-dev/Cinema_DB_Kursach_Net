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
    /// Логика взаимодействия для FullSession.xaml
    /// </summary>
    public partial class FullSession : Window
    {
        Cinema_DataBaseEntities _entities;
        string Selected_Cinema_Name = null;
        string Selected_Address = null;
        string Selected_Cinema_Contact = null;
        string Selected_Film_Name = null;
        string Selected_Genre = null;
        string Selected_Country = null;
        string Selected_Age_Rating = null;
        string Selected_Capacity = null;
        string Selected_Type = null;
        string Selected_Hall_Name = null;
        string Selected_Duration = null;
        string Selected_Date = null;
        string Selected_Price = null;
        string Selected_Status = null;
        string Selected_Client_Name = null;
        string Selected_Client_Surname = null;
        string Selected_Client_Contact = null;

        List<Full_Session> list;
        public FullSession(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            Update();

            FillComboBox(Cinema_Name_CB,      _entities.Full_Session.ToList(), x => x.cinema_name);
            FillComboBox(Address_CB,          _entities.Full_Session.ToList(), x => x.address);
            FillComboBox(Cinema_Contact_CB,   _entities.Full_Session.ToList(), x => x.cinema_contact);
            FillComboBox(Film_Name_CB,        _entities.Full_Session.ToList(), x => x.film_name);
            FillComboBox(Genre_CB,            _entities.Full_Session.ToList(), x => x.genre);
            FillComboBox(Country_CB,          _entities.Full_Session.ToList(), x => x.country);
            FillComboBox(Age_Rating_CB,       _entities.Full_Session.ToList(), x => x.age_rating);
            FillComboBox(Capacity_CB,         _entities.Full_Session.ToList(), x => x.capacity);
            FillComboBox(Type_CB,             _entities.Full_Session.ToList(), x => x.type);
            FillComboBox(Hall_Name_CB,        _entities.Full_Session.ToList(), x => x.hall_name);
            FillComboBox(Duration_CB,         _entities.Full_Session.ToList(), x => x.duration.ToString());
            FillComboBox(Date_CB,             _entities.Full_Session.ToList(), x => x.date.ToString());
            FillComboBox(Price_CB,            _entities.Full_Session.ToList(), x => x.price.ToString());
            FillComboBox(Status_CB,           _entities.Full_Session.ToList(), x => x.status);
            FillComboBox(Client_Name_CB,      _entities.Full_Session.ToList(), x => x.client_name);
            FillComboBox(Client_Surname_CB,   _entities.Full_Session.ToList(), x => x.cilent_surname);
            FillComboBox(Client_Contact_CB,   _entities.Full_Session.ToList(), x => x.client_contact);

        }
        private void FillComboBox<T>(ComboBox comboBox, List<Full_Session> film_Session_Halls, Func<Full_Session, T> selector)
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

            list = _entities.Full_Session.ToList();

            if (Selected_Cinema_Name        != null) list = list.Where(x => x.cinema_name           == Selected_Cinema_Name).ToList();
            if (Selected_Address            != null) list = list.Where(x => x.address               == Selected_Address).ToList();
            if (Selected_Cinema_Contact     != null) list = list.Where(x => x.cinema_contact        == Selected_Cinema_Contact).ToList();
            if (Selected_Film_Name          != null) list = list.Where(x => x.film_name             == Selected_Film_Name).ToList();
            if (Selected_Genre              != null) list = list.Where(x => x.genre                 == Selected_Genre).ToList();
            if (Selected_Country            != null) list = list.Where(x => x.country               == Selected_Country).ToList();
            if (Selected_Age_Rating         != null) list = list.Where(x => x.age_rating            == Selected_Age_Rating).ToList();
            if (Selected_Capacity           != null) list = list.Where(x => x.capacity.ToString()   == Selected_Capacity).ToList();
            if (Selected_Type               != null) list = list.Where(x => x.type                  == Selected_Type).ToList();
            if (Selected_Hall_Name          != null) list = list.Where(x => x.hall_name             == Selected_Hall_Name).ToList();
            if (Selected_Duration           != null) list = list.Where(x => x.duration.ToString()   == Selected_Duration).ToList();
            if (Selected_Date               != null) list = list.Where(x => x.date.ToString()       == Selected_Date).ToList();
            if (Selected_Price              != null) list = list.Where(x => x.price.ToString()      == Selected_Price).ToList();
            if (Selected_Status             != null) list = list.Where(x => x.status                == Selected_Status).ToList();
            if (Selected_Client_Name        != null) list = list.Where(x => x.client_name           == Selected_Client_Name).ToList();
            if (Selected_Client_Surname     != null) list = list.Where(x => x.cilent_surname        == Selected_Client_Surname).ToList();
            if (Selected_Client_Contact     != null) list = list.Where(x => x.client_contact        == Selected_Client_Contact).ToList();


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
        private void Cinema_Name_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Cinema_Name = Select(Cinema_Name_CB);
            Update();
        }

        private void Address_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Address = Select(Address_CB);
            Update();
        }

        private void Cinema_Contact_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Cinema_Contact = Select(Cinema_Contact_CB);
            Update();
        }

        private void Film_Name_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Film_Name = Select(Film_Name_CB);
            Update();
        }

        private void Genre_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Genre = Select(Genre_CB);
            Update();
        }

        private void Country_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Country = Select(Country_CB);
            Update();
        }

        private void Age_Rating_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Age_Rating = Select(Age_Rating_CB);
            Update();
        }

        private void Capacity_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Capacity = Select(Capacity_CB);
            Update();
        }

        private void Type_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Type = Select(Type_CB);
            Update();
        }

        private void Hall_Name_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Hall_Name = Select(Hall_Name_CB);
            Update();
        }

        private void Duration_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Duration = Select(Duration_CB);
            Update();
        }

        private void Date_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Date = Select(Date_CB);
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

        private void Client_Name_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Client_Name = Select(Client_Name_CB);
            Update();
        }

        private void Client_Surname_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Client_Surname = Select(Client_Surname_CB);
            Update();
        }

        private void Client_Contact_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Client_Contact = Select(Client_Contact_CB);
            Update();
        }
        private void Cinema_Name_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Cinema_Name = null;
            Clear_Selected(Cinema_Name_CB);
        }

        private void Address_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Address = null;
            Clear_Selected(Address_CB);
        }

        private void Cinema_Contact_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Cinema_Contact = null;
            Clear_Selected(Cinema_Contact_CB);
        }

        private void Film_Name_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Film_Name = null;
            Clear_Selected(Film_Name_CB);
        }

        private void Genre_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Genre = null;
            Clear_Selected(Genre_CB);
        }

        private void Country_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Country = null;
            Clear_Selected(Country_CB);
        }

        private void Age_Rating_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Age_Rating = null;
            Clear_Selected(Age_Rating_CB);
        }

        private void Capacity_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Capacity = null;
            Clear_Selected(Capacity_CB);
        }

        private void Type_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Type = null;
            Clear_Selected(Type_CB);
        }

        private void Hall_Name_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Hall_Name = null;
            Clear_Selected(Hall_Name_CB);
        }

        private void Duration_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Duration = null;
            Clear_Selected(Duration_CB);
        }

        private void Date_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Date = null;
            Clear_Selected(Date_CB);
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

        private void Client_Name_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Client_Name = null;
            Clear_Selected(Client_Name_CB);
        }

        private void Client_Surname_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Client_Surname = null;
            Clear_Selected(Client_Surname_CB);
        }

        private void Client_Contact_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Client_Contact = null;
            Clear_Selected(Client_Contact_CB);
        }
    }
}
