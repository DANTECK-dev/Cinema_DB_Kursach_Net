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
    /// Логика взаимодействия для DelFilm.xaml
    /// </summary>
    public partial class DelFilm : Window
    {
        Cinema_DataBaseEntities _entities;
        public DelFilm(Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;    // вытаскиваем всю БД
            Name_CB.ItemsSource = _entities.Films.ToList();      // вытаскиваем список клиентов из БД
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            Status.Content = "";      // очищение текста статуса исполнения запроса

            try
            {
                _entities.Films.Remove(((Film)(Name_CB.SelectedItem)));       // удаление клиента из БД
                _entities.SaveChanges();     // сохраняем изменения в БД

                // очищение полей от удаленого пользователя
                Name_CB.SelectedItem = null;
                ID_TB.Text = "";
                Genre_TB.Text = "";
                Country_TB.Text = "";
                Age_Rating_TB.Text = "";

                Status.Content = "Запись успешно удалена";        // выводим текст об успешном выполнении запроса
                Name_CB.ItemsSource = _entities.Films.ToList();      // обновляем список клиентов
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
            ID_TB.Text = ((Film)(Name_CB.SelectedItem)).id.ToString();
            Genre_TB.Text = ((Film)(Name_CB.SelectedItem)).genre;
            Country_TB.Text = ((Film)(Name_CB.SelectedItem)).country;
            Age_Rating_TB.Text = ((Film)(Name_CB.SelectedItem)).age_rating;
        }
    }
}
