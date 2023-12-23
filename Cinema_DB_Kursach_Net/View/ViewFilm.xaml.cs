﻿using System;
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
    /// Логика взаимодействия для ViewFilm.xaml
    /// </summary>
    public partial class ViewFilm : Window
    {
        Cinema_DataBaseEntities _entities;
        public ViewFilm(Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
            _DataGrid.ItemsSource = _entities.Films.ToList();
        }
    }
}
