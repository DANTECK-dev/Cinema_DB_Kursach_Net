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
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        Cinema_DataBaseEntities _entities;
        public EditClient(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            Name_CB.ItemsSource = _entities.Clients.ToList();
        }
        private void Change(object sender, TextChangedEventArgs e)      // функция очищения текста статуса исполнения запроса
        {
            if (Status != null)
                Status.Content = "";
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса
            try
            {
                Client client = (Client)(Name_CB.SelectedItem);      // вытаскиваем клиента из списка ComboBox`a

                // изменяем данные выбраного маршрута
                _entities.Clients.Find(client.id).name = Name_TB.Text;
                _entities.Clients.Find(client.id).surname = Surname_TB.Text;
                _entities.Clients.Find(client.id).contact = Contact_TB.Text;

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
            ID_TB.Text = ((Client)(Name_CB.SelectedItem)).id.ToString();
            Name_TB.Text = ((Client)(Name_CB.SelectedItem)).name;
            Surname_TB.Text = ((Client)(Name_CB.SelectedItem)).surname;
            Contact_TB.Text = ((Client)(Name_CB.SelectedItem)).contact;
        }
    }
}
