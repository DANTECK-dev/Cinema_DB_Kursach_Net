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
    /// Логика взаимодействия для FilmSessions.xaml
    /// </summary>
    public partial class FilmSessions : Window
    {
        Cinema_DataBaseEntities _entities;
        string Selected_MovieName = null;
        List<Film_Sessions_Result> list;
        public FilmSessions(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            FillComboBox(MovieName_CB, _entities.Full_Ticket.ToList(), x => x.name);
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

            list = _entities.Film_Sessions(Selected_MovieName).ToList();

            if (Selected_MovieName != null)
                list = list.Where(x => x.name == Selected_MovieName).ToList();

            int count = _DataGrid.Items.Count;
            for (int i = 0; i < count; i++)
                _DataGrid.Items.RemoveAt(0);
            for (int i = 0; i < list.Count; i++)
                _DataGrid.Items.Add(list[i]);

            Sessions_L.Content = "Найдено " + list.Count + " сеансов";
        }

        private void MovieName_CB_DropDownClosed(object sender, EventArgs e)
        {
            Selected_MovieName = Select(MovieName_CB);
            Update();
        }
    }
}
