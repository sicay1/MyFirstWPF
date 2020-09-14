﻿using App6.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App6.Views
{
    
    /// <summary>
    /// Interaction logic for UC_Click.xaml
    /// </summary>
    public partial class ClickUserControl : UserControl
    {
        public string Title { get; set; }

        public int MaxLength { get; set; }

        public ClickUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
