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
    /// Логика взаимодействия для DelHall.xaml
    /// </summary>
    public partial class DelHall : Window
    {
        Cinema_DataBaseEntities _entities;
        public DelHall()
        {
            InitializeComponent();
            _entities = new Cinema_DataBaseEntities();       // вытаскиваем всю БД
            Name_CB.ItemsSource = _entities.Halls.ToList();      // вытаскиваем список клиентов из БД
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.Halls.Remove(((Hall)(Name_CB.SelectedItem)));       // удаление клиента из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленого пользователя
                Name_CB.SelectedItem = null;
                ID_TB.Text = "";
                Type_TB.Text = "";
                Capacity_TB.Text = "";
                Cinema_TB.Text = "";

                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                Name_CB.ItemsSource = _entities.Halls.ToList();      // обновляем список клиентов
            }
            catch (Exception ex)        // обработка ошибок
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Film_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            if (Name_CB.SelectedItem == null) return;

            // обновляем данные в полях если выбран другой пользователь
            ID_TB.Text = ((Hall)(Name_CB.SelectedItem)).id.ToString();
            Type_TB.Text = ((Hall)(Name_CB.SelectedItem)).type;
            Capacity_TB.Text = ((Hall)(Name_CB.SelectedItem)).capacity.ToString();
            Cinema_TB.Text = ((Hall)(Name_CB.SelectedItem)).Cinema.name;
        }
    }
}
