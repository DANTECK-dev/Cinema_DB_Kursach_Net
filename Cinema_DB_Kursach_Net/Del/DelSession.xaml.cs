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
    /// Логика взаимодействия для DelSession.xaml
    /// </summary>
    public partial class DelSession : Window
    {
        cinema_DBEntities _entities;
        public DelSession()
        {
            InitializeComponent();
            _entities = new cinema_DBEntities();       // вытаскиваем всю БД
            Date_CB.ItemsSource = _entities.Sessions.ToList();      // вытаскиваем список клиентов из БД
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.Sessions.Remove(((Session)(Date_CB.SelectedItem)));       // удаление клиента из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленого пользователя
                Date_CB.SelectedItem = null;
                ID_TB.Text = "";
                Duration_TB.Text = "";
                Hall_TB.Text = "";
                Film_TB.Text = "";

                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                Date_CB.ItemsSource = _entities.Sessions.ToList();      // обновляем список клиентов
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
            if (Date_CB.SelectedItem == null) return;

            // обновляем данные в полях если выбран другой пользователь
            ID_TB.Text = ((Session)(Date_CB.SelectedItem)).id.ToString();
            Duration_TB.Text = ((Session)(Date_CB.SelectedItem)).duration.ToString();
            Hall_TB.Text = ((Session)(Date_CB.SelectedItem)).Hall.name;
            Film_TB.Text = ((Session)(Date_CB.SelectedItem)).Film.name;
        }
    }
}
