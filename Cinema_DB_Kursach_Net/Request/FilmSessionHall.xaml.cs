using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для FilmSessionHall.xaml
    /// </summary>
    public partial class FilmSessionHall : Window
    {
        Cinema_DataBaseEntities _entities;
        string Selected_Hall_Name = null;
        string Selected_Hall_Type = null;
        string Selected_Hall_Capacity = null;
        string Selected_Film_Name = null;
        string Selected_Film_Genre = null;
        string Selected_Film_Country = null;
        string Selected_Film_Age = null;
        string Selected_Date = null;
        string Selected_Duration = null;
        List<Film_Session_Hall> list;

        public FilmSessionHall()
        {
            InitializeComponent();
            _entities = new Cinema_DataBaseEntities();
            Update();

            FillComboBox(Hall_Name_CB,        _entities.Film_Session_Hall.ToList(), x => x.hall_name);
            FillComboBox(Hall_Type_CB,        _entities.Film_Session_Hall.ToList(), x => x.type);
            FillComboBox(Hall_Capacity_CB,    _entities.Film_Session_Hall.ToList(), x => x.capacity);
            FillComboBox(Film_Name_CB,        _entities.Film_Session_Hall.ToList(), x => x.fIlm_name);
            FillComboBox(Film_Genre_CB,       _entities.Film_Session_Hall.ToList(), x => x.genre);
            FillComboBox(Film_Country_CB,     _entities.Film_Session_Hall.ToList(), x => x.country);
            FillComboBox(Film_Age_CB,         _entities.Film_Session_Hall.ToList(), x => x.age_rating);
            FillComboBox(Date_CB,             _entities.Film_Session_Hall.ToList(), x => x.date);
            FillComboBox(Duration_CB,         _entities.Film_Session_Hall.ToList(), x => x.duration);
        }
        private void FillComboBox<T>(ComboBox comboBox, List<Film_Session_Hall> film_Session_Halls, Func<Film_Session_Hall, T> selector)
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

            list = _entities.Film_Session_Hall.ToList();
            if( Selected_Hall_Name != null)         list = list.Where(x=>x.hall_name                == Selected_Hall_Name)      .ToList();
            if( Selected_Hall_Type != null)         list = list.Where(x=>x.type                     == Selected_Hall_Type)      .ToList();
            if( Selected_Hall_Capacity != null)     list = list.Where(x=>x.capacity.ToString()      == Selected_Hall_Capacity)  .ToList();
            if( Selected_Film_Name != null)         list = list.Where(x=>x.fIlm_name                == Selected_Film_Name)      .ToList();
            if( Selected_Film_Genre != null)        list = list.Where(x=>x.genre                    == Selected_Film_Genre)     .ToList();
            if( Selected_Film_Country != null)      list = list.Where(x=>x.country                  == Selected_Film_Country)   .ToList();
            if( Selected_Film_Age != null)          list = list.Where(x=>x.age_rating               == Selected_Film_Age)       .ToList();
            if( Selected_Date != null)              list = list.Where(x=>x.date.ToString()          == Selected_Date)           .ToList();
            if( Selected_Duration != null)          list = list.Where(x => x.duration.ToString()    == Selected_Duration)       .ToList();

            int count = _DataGrid.Items.Count;
            for (int i = 0; i < count; i++)
                _DataGrid.Items.RemoveAt(0);
            for (int i = 0; i < list.Count; i++)
                _DataGrid.Items.Add(list[i]);

            //_DataGrid.DataContext = list;
            //_DataGrid.Items.Clear();
            //_DataGrid.Items.Re
            //_DataGrid.ItemsSource = filtered.ToList();
        }
        private void Clear_Selected(ComboBox comboBox)
        {
            comboBox.SelectedItem = null;
            comboBox.SelectedIndex = -1;
            Update();
        }
        private void Hall_Name_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Hall_Name = Select(Hall_Name_CB);
            Update();
        }
        private void Hall_Type_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Hall_Type = Select(Hall_Type_CB);
            Update();
        }
        private void Hall_Capacity_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Hall_Capacity = Select(Hall_Capacity_CB);
            Update();
        }
        private void Film_Name_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Film_Name = Select(Film_Name_CB);
            Update();
        }
        private void Film_Genre_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Film_Genre = Select(Film_Genre_CB);
            Update();
        }
        private void Film_Country_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Film_Country = Select(Film_Country_CB);
            Update();
        }
        private void Film_Age_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Film_Age = Select(Film_Age_CB);
            Update();
        }
        private void Date_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Date = Select(Date_CB);
            Update();
        }
        private void Duration_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_Duration = Select(Duration_CB);
            Update();
        }
        private void Hall_Name_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Hall_Name = null;
            Clear_Selected(Hall_Name_CB);
        }
        private void Hall_Type_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Hall_Type = null;
            Clear_Selected(Hall_Type_CB);
        }
        private void Hall_Capacity_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Hall_Capacity = null;
            Clear_Selected(Hall_Capacity_CB);
        }
        private void Film_Name_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Film_Name = null;
            Clear_Selected(Film_Name_CB);
        }
        private void Film_Genre_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Film_Genre = null;
            Clear_Selected(Film_Genre_CB);
        }
        private void Film_Country_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Film_Country = null;
            Clear_Selected(Film_Country_CB);
        }
        private void Film_Age_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Film_Age = null;
            Clear_Selected(Film_Age_CB);
        }
        private void Date_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Date = null;
            Clear_Selected(Date_CB);
        }
        private void Duration_Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Selected_Duration = null;
            Clear_Selected(Duration_CB);
        }
    }
}
