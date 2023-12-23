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
    /// Логика взаимодействия для DelTicket.xaml
    /// </summary>
    public partial class DelTicket : Window
    {
        Cinema_DataBaseEntities _entities;
        public DelTicket(Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;    // вытаскиваем всю БД
            ID_CB.ItemsSource = _entities.Tickets.ToList();      // вытаскиваем список клиентов из БД
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.Tickets.Remove(((Ticket)(ID_CB.SelectedItem)));       // удаление клиента из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленого пользователя
                ID_CB.SelectedItem = null;
                Price_TB.Text = "";
                Status_TB.Text = "";
                Session_TB.Text = "";
                Client_TB.Text = "";

                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                ID_CB.ItemsSource = _entities.Tickets.ToList();      // обновляем список клиентов
            }
            catch (Exception ex)        // обработка ошибок
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ID_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            if (ID_CB.SelectedItem == null) return;

            // обновляем данные в полях если выбран другой пользователь
            Price_TB.Text = ((Ticket)(ID_CB.SelectedItem)).price.ToString();
            Status_TB.Text = ((Ticket)(ID_CB.SelectedItem)).status.ToString();
            Session_TB.Text = ((Ticket)(ID_CB.SelectedItem)).Session.date.ToString();
            Client_TB.Text = ((Ticket)(ID_CB.SelectedItem)).Client.name;
        }
    }
}
