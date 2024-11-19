using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Iwanov_Egor_Pract_2
{
    /// <summary>
    /// Логика взаимодействия для FromToTill.xaml
    /// </summary>
    public partial class FromToTill : Window
    {
        public FromToTill()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window MainWindow = new MainWindow();
            MainWindow.Closed += (s, args) => this.Close();
            MainWindow.Show();
        }

        private void NumA_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != ',' && c != '-')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private bool ContainsLetters(string input)
        {
            return Regex.IsMatch(input, @"[A-Za-z]");
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (string.IsNullOrEmpty(Result.Text))
                {
                    NumA.Text += button.Content.ToString();
                }
            }
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            NumA.Text = "";
            Result.Text = "";
        }

        private void DashButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Result.Text))
            {
                if (!NumA.Text.Contains("-"))
                {
                    NumA.Text += "-";
                }
            }
        }

        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Result.Text))
            {
                if (!NumA.Text.Contains(","))
                {
                    NumA.Text += ",";
                }
            }
        }

        private void CountOP_Click(object sender, RoutedEventArgs e)
        {
            if (ContainsLetters(NumA.Text))
            {
                MessageBox.Show("Ошибка, некорректный Ввод! Пожалуйста, введите Число!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                NumA.Text = "";
                Result.Text = "";
                return;
            }

            double a = 0;

            if (!double.TryParse(NumA.Text, out a))
            {
                MessageBox.Show("Ошибка, пожалуйста, введите корректное число в поле A!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                Result.Text = "";
                return;
            }

            int FromToTill = Convert.ToInt32(a);

            if (a >= 0 && a <= 14)
            {
                Result.Text = "[0 - 14]";
            }
            else if (a >= 15 && a <= 35)
            {
                Result.Text = "[15 - 35]";
            }
            else if (a >= 36 && a <= 50)
            {
                Result.Text = "[36 - 50]";
            }
            else if (a >= 51 && a <= 100)
            {
                Result.Text = "[51 - 100]";
            }
            else 
            {
                MessageBox.Show("Ошибка, промежуток для данного числа отсутствует! Пожалуйста, введите число в промежутке от 0 до 100", "Ошибка операции", MessageBoxButton.OK, MessageBoxImage.Error);
                NumA.Text = "";
            }
        }
    }
}
