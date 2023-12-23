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
    /// Логика взаимодействия для EditStaff.xaml
    /// </summary>
    public partial class EditStaff : Window
    {
        Cinema_DataBaseEntities _entities;
        int selected = -1;
        public EditStaff(Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
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
                Staff table = Name_CB.SelectedItem as Staff;      // вытаскиваем клиента из списка ComboBox`a

                // изменяем данные выбраного маршрута
                _entities.Staffs.Find(table.id).name = Name_TB.Text;
                _entities.Staffs.Find(table.id).surname = Surname_TB.Text;
                _entities.Staffs.Find(table.id).post = Post_TB.Text;
                _entities.Staffs.Find(table.id).contact = Contact_TB.Text;
                _entities.Staffs.Find(table.id).id_cinema = selected;

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
            ID_TB.Text = ((Staff)(Name_CB.SelectedItem)).id.ToString();
            Name_TB.Text = ((Staff)(Name_CB.SelectedItem)).name;
            Surname_TB.Text = ((Staff)(Name_CB.SelectedItem)).surname;
            Post_TB.Text = ((Staff)(Name_CB.SelectedItem)).post.ToString();
            Contact_TB.Text = ((Staff)(Name_CB.SelectedItem)).contact.ToString();
            Cinema_CB.SelectedItem = ((Staff)(Name_CB.SelectedItem)).Cinema;
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
