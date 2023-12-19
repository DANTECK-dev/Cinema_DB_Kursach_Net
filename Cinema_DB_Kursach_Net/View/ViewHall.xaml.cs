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
    /// Логика взаимодействия для ViewHall.xaml
    /// </summary>
    public partial class ViewHall : Window
    {
        public ViewHall()
        {
            InitializeComponent();
            _DataGrid.ItemsSource = (new Cinema_DataBaseEntities()).Halls.ToList();
        }
    }
}
