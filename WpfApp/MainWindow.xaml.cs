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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var grid = this.Content as Grid;
            Button button = new Button();
            button.Height = 50;
            button.Width = 100;
            Margin = new Thickness(0, 0, 700, 385);
            //button.Margin = Margin;
            button.Content = "Button !!!";
            grid.Children.Add(button);
        }

        private void TextBox_TextChanged()
        {
        }
    }
}