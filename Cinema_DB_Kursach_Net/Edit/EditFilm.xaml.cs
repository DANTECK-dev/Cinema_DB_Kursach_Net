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
    /// Логика взаимодействия для EditFilm.xaml
    /// </summary>
    public partial class EditFilm : Window
    {
        Cinema_DataBaseEntities _entities;
        public EditFilm(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            Name_CB.ItemsSource = _entities.Films.ToList();
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
                Film table = (Film)(Name_CB.SelectedItem);      // вытаскиваем клиента из списка ComboBox`a

                // изменяем данные выбраного маршрута
                _entities.Films.Find(table.id).name = Name_TB.Text;
                _entities.Films.Find(table.id).genre = Genre_TB.Text;
                _entities.Films.Find(table.id).country = Country_TB.Text;
                _entities.Films.Find(table.id).age_rating = Age_Rating_TB.Text;

                _entities.SaveChanges();         // сохраняем изменения в БД
                Status.Content = "Запись успешно измененна";        // выводим текст об успешном выполнении запроса
            }
            catch (Exception ex)
            {
                Status.Content = "";      // очищение текста статуса исполнения запроса
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Film_CB_DropDownClosed(object sender, EventArgs e)
        {
            Status.Content = "";
            if (Name_CB.SelectedItem == null) return;
            ID_TB.Text = ((Film)(Name_CB.SelectedItem)).id.ToString();
            Name_TB.Text = ((Film)(Name_CB.SelectedItem)).name;
            Genre_TB.Text = ((Film)(Name_CB.SelectedItem)).genre;
            Country_TB.Text = ((Film)(Name_CB.SelectedItem)).country;
            Age_Rating_TB.Text = ((Film)(Name_CB.SelectedItem)).age_rating;
        }
    }
}
