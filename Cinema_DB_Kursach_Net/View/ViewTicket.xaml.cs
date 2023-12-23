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
    /// Логика взаимодействия для ViewTicket.xaml
    /// </summary>
    public partial class ViewTicket : Window
    {
        Cinema_DataBaseEntities _entities;
        public ViewTicket(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            _DataGrid.ItemsSource = _entities.Tickets.ToList();
        }
    }
}
