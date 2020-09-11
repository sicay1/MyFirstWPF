using App6.ViewModels;
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
    /// Interaction logic for MyTestPage.xaml
    /// </summary>
    public partial class MyTestPage : Page
    {
        public MyTestPage(MyTestViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }


    }
}
