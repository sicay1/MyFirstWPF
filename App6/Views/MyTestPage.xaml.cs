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

        private string _lastValue = "";
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var cbx = (ComboBox)sender;
            if (cbx != null && cbx.Text != _lastValue)
            {
                emptyStack.Children.Clear();
                _lastValue = cbx.Text;
                //MessageBox.Show("aaaaaaaaaabbb");
                Button btn1 = new Button();
                switch (cbx.Text)
                {
                    case "Left Click":
                        btn1.Content = "SET1";
                        btn1.Click += Btn1_Click;
                        emptyStack.Children.Add(btn1);
                        break;
                    case "Right Click":
                        btn1.Content = "SET2";
                        emptyStack.Children.Add(btn1);
                        break;
                    case "Double Left Click":
                        btn1.Content = "SET3";
                        emptyStack.Children.Add(btn1);
                        break;
                }
            }





        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            Window1 w1 = new Window1();
            w1.Show();
        }
    }
}
