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
    /// Логика взаимодействия для AddHall.xaml
    /// </summary>
    public partial class AddHall : Window
    {
        Cinema_DataBaseEntities entities;
        int selected = -1;

        public AddHall()
        {
            InitializeComponent();
            entities = new Cinema_DataBaseEntities();
            Cinema_CB.ItemsSource = (new Cinema_DataBaseEntities()).Cinemas.ToList();
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
                
                Hall table = new Hall();

                table.name = Name_TB.Text;
                table.type = Type_TB.Text;
                table.capacity = int.Parse(Capacity_TB.Text);
                table.id_cinema = selected;

                entities.Halls.Add(table);
                entities.SaveChanges();
                Status.Content = "Запись успешно добавлена";

            }
            catch (Exception ex)
            {
                Status.Content = "";
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cinema_CB_DropDownClosed(object sender, EventArgs e)
        {
            Change();
            selected = -1;
            if (Cinema_CB.SelectedIndex == -1) return;
            selected = ((Cinema)Cinema_CB.SelectedItem).id;
        }
    }
}
