using LiveCharts.Wpf;
using LiveCharts;
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
    /// Логика взаимодействия для Revenue.xaml
    /// </summary>
    public partial class Revenue : Window
    {
        Cinema_DataBaseEntities _entities;
        DateTime? _start_date = null;
        DateTime? _end_date = null;

        public Revenue(ref Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            _start_date = _entities.Sessions.Min(x => x.date).Date;
            _end_date = _entities.Sessions.Max(x => x.date).Date;
            FillComboBox(Start_Date_CB, _entities.Sessions.ToList(), x => x.date.Date);
            FillComboBox(End_Date_CB,   _entities.Sessions.ToList(), x => x.date.Date);
            Update();
        }
        private void FillComboBox<T>(ComboBox comboBox, List<Session> film_Session_Halls, Func<Session, T> selector)
        {
            var uniqueItems = new List<T> { }; // Добавляем "Пусто" (или default для типа T)
            uniqueItems.AddRange(film_Session_Halls.Select(selector).Distinct());

            comboBox.ItemsSource = uniqueItems;
        }
        private void Update()
        {
            var list = _entities.Revenue(_start_date, _end_date).ToList();

            int summ = 0;
            int count = _DataGrid.Items.Count;
            for (int i = 0; i < count; i++)
                _DataGrid.Items.RemoveAt(0);
            for (int i = 0; i < list.Count; i++)
            {
                _DataGrid.Items.Add(list[i]);
                summ += int.Parse(list[i].sum.ToString());
            }
            Revenue_L.Content = "Сумма продаж:\n" + summ;
        }
        private void Start_Date_CB_DropDownClosed(object sender, EventArgs e)
        {
            if (Start_Date_CB.SelectedIndex == -1) _start_date = null;
            else _start_date = DateTime.Parse(Start_Date_CB.Text);
            Update();
        }

        private void End_Date_CB_DropDownClosed(object sender, EventArgs e)
        {
            if (End_Date_CB.SelectedIndex == -1) _end_date = null;
            else _end_date = DateTime.Parse(End_Date_CB.Text);
            Update();
        }
    }
}
