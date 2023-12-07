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
    /// Логика взаимодействия для EditHall.xaml
    /// </summary>
    public partial class EditHall : Window
    {
        cinema_DBEntities _entities;
        int selected = -1;
        public EditHall()
        {
            InitializeComponent();
            _entities = new cinema_DBEntities();
            Name_CB.ItemsSource = _entities.Films.ToList();
            Cinema_CB.ItemsSource = _entities.Cinemas.ToList();
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
                Hall table = Name_CB.SelectedItem as Hall;      // вытаскиваем клиента из списка ComboBox`a

                // изменяем данные выбраного маршрута
                _entities.Halls.Find(table.id).name = Name_TB.Text;
                _entities.Halls.Find(table.id).type = Type_TB.Text;
                _entities.Halls.Find(table.id).capacity = int.Parse(Capacity_TB.Text);
                _entities.Halls.Find(table.id).id_cinema = selected;

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
            ID_TB.Text = ((Hall)(Name_CB.SelectedItem)).id.ToString();
            Name_TB.Text = ((Hall)(Name_CB.SelectedItem)).name;
            Type_TB.Text = ((Hall)(Name_CB.SelectedItem)).type;
            Capacity_TB.Text = ((Hall)(Name_CB.SelectedItem)).capacity.ToString();
            Cinema_CB.SelectedItem = ((Hall)(Name_CB.SelectedItem)).Cinema;
        }
        private void Cinema_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected = -1;
            if (Cinema_CB.SelectedIndex == -1) return;
            selected = ((Cinema)Cinema_CB.SelectedItem).id;
        }
    }
}
