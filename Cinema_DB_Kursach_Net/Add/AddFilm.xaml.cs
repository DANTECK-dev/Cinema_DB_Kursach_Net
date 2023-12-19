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
    /// Логика взаимодействия для AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Window
    {
        public AddFilm()
        {
            InitializeComponent();
        }
        private void Change(object sender, TextChangedEventArgs e)
        {
            if (Status != null)
                Status.Content = "";
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cinema_DataBaseEntities entities = new Cinema_DataBaseEntities();
                Film table = new Film();

                table.name = Name_TB.Text;
                table.genre = Genre_TB.Text;
                table.country = Country_TB.Text;
                table.age_rating = Age_Rating_TB.Text;

                entities.Films.Add(table);
                entities.SaveChanges();
                Status.Content = "Запись успешно добавлена";

            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
