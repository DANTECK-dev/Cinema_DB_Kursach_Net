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
    /// Логика взаимодействия для Revenue.xaml
    /// </summary>
    public partial class Revenue : Window
    {
        Cinema_DataBaseEntities _entities;
        public Revenue(Cinema_DataBaseEntities entities)
        {
            InitializeComponent();
            _entities = entities;
        }
    }
}
