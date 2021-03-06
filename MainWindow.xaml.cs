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

namespace GetPass
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string GetPass(int x, byte sw)
        {
            string pass = "";
            var rand = new Random();
            switch (sw)
            {
                case 0:
                    while (pass.Length < x)
                    {
                        Char c = (char)rand.Next(33, 125);
                        if (Char.IsLetterOrDigit(c))
                            pass += c;
                    }
                    return pass;
                case 1:
                    while (pass.Length < x)
                    {
                        Char c = (char)rand.Next(33, 125);
                        pass += c;
                    }
                    return pass;
                default:
                    return "пусто";
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;    //Начальное значение ComboBox
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = 8 + comboBox1.SelectedIndex;
            byte y;
            if ((bool)symb_1.IsChecked)
                y = 1;
            else
                y = 0;
            string pass = GetPass(x, y);
            labelPass.Content = pass;
            history.Items.Insert(0, pass);
            Clipboard.SetText(pass);
            buff.Content = pass;
        }

        private void history_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string pass_1 = (string)history.Items[history.SelectedIndex];
            Clipboard.SetText(pass_1);
            buff.Content = pass_1;
        }
    }
}
