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
    /// Логика взаимодействия для DelClient.xaml
    /// </summary>
    public partial class DelClient : Window
    {
        Cinema_DataBaseEntities _entities;
        public DelClient(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;     // вытаскиваем всю БД
            Client_CB.ItemsSource = _entities.Clients.ToList();      // вытаскиваем список клиентов из БД
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.Clients.Remove(((Client)(Client_CB.SelectedItem)));       // удаление клиента из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленого пользователя
                Client_CB.SelectedItem = null;
                ID_TB.Text = "";
                Contact_TB.Text = "";

                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                Client_CB.ItemsSource = _entities.Clients.ToList();      // обновляем список клиентов
            }
            catch (Exception ex)        // обработка ошибок
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Client_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            if (Client_CB.SelectedItem == null) return;

            // обновляем данные в полях если выбран другой пользователь
            ID_TB.Text = ((Client)(Client_CB.SelectedItem)).id.ToString();
            Contact_TB.Text = ((Client)(Client_CB.SelectedItem)).contact;
        }
    }
}
