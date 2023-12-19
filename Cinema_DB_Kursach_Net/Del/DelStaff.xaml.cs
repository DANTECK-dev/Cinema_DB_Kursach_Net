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
    /// Логика взаимодействия для DelStaff.xaml
    /// </summary>
    public partial class DelStaff : Window
    {
        Cinema_DataBaseEntities _entities;
        public DelStaff()
        {
            InitializeComponent();
            _entities = new Cinema_DataBaseEntities();       // вытаскиваем всю БД
            Name_CB.ItemsSource = _entities.Staffs.ToList();      // вытаскиваем список клиентов из БД
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.Staffs.Remove(((Staff)(Name_CB.SelectedItem)));       // удаление клиента из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленого пользователя
                Name_CB.SelectedItem = null;
                ID_TB.Text = "";
                Post_TB.Text = "";
                Contact_TB.Text = "";
                Cinema_TB.Text = "";

                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                Name_CB.ItemsSource = _entities.Staffs.ToList();      // обновляем список клиентов
            }
            catch (Exception ex)        // обработка ошибок
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Name_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            if (Name_CB.SelectedItem == null) return;

            // обновляем данные в полях если выбран другой пользователь
            ID_TB.Text = ((Staff)(Name_CB.SelectedItem)).id.ToString();
            Post_TB.Text = ((Staff)(Name_CB.SelectedItem)).post.ToString();
            Contact_TB.Text = ((Staff)(Name_CB.SelectedItem)).contact;
            Cinema_TB.Text = ((Staff)(Name_CB.SelectedItem)).Cinema.name;
        }
    }
}
