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
    /// Логика взаимодействия для AddSession.xaml
    /// </summary>
    public partial class AddSession : Window
    {
        Cinema_DataBaseEntities _entities;
        int selected_hall = -1;
        int selected_film = -1;

        public AddSession(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            Hall_CB.ItemsSource = (new Cinema_DataBaseEntities()).Halls.ToList();
            Film_CB.ItemsSource = (new Cinema_DataBaseEntities()).Films.ToList();

            Date_TB.Text = DateTime.Now.ToString();
        }
        private void Change(object sender = null, TextChangedEventArgs e = null)
        {
            if (Status != null)
                Status.Content = "";
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session table = new Session();

                table.date = DateTime.Parse(Date_TB.Text);
                table.duration = int.Parse(Duration_TB.Text);
                table.id_hall = selected_hall;
                table.id_film = selected_film;

                _entities.Sessions.Add(table);
                _entities.SaveChanges();
                Status.Content = "Запись успешно добавлена";

            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Hall_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected_hall = -1;
            if (Hall_CB.SelectedIndex == -1) return;
            selected_hall = ((Hall)Hall_CB.SelectedItem).id;
        }
        private void Film_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected_film = -1;
            if (Film_CB.SelectedIndex == -1) return;
            selected_film = ((Film)Film_CB.SelectedItem).id;
        }
    }
}
