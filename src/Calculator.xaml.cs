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
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
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

        private void NumB_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
                if (string.IsNullOrEmpty(OP.Text))
                {
                    NumA.Text += button.Content.ToString();
                }
                else
                {
                    NumB.Text += button.Content.ToString();
                }
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                OP.Text = button.Content.ToString();
            }
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            NumA.Text = "";
            OP.Text = "";
            NumB.Text = "";
            Count.Text = "";
        }

        private void DashButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(OP.Text))
            {
                if (!NumA.Text.Contains("-"))
                {
                    NumA.Text += "-";
                }
            }
            else
            {
                if (!NumB.Text.Contains("-"))
                {
                    NumB.Text += "-";
                }
            }
        }

        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(OP.Text))
            {
                if (!NumA.Text.Contains(","))
                {
                    NumA.Text += ",";
                }
            }
            else
            {
                if (!NumB.Text.Contains(","))
                {
                    NumB.Text += ",";
                }
            }
        }

        private void CountOP_Click(object sender, RoutedEventArgs e)
        {
            if (ContainsLetters(NumA.Text) || ContainsLetters(NumB.Text))
            {
                MessageBox.Show("Ошибка, некорректный Ввод! Пожалуйста, введите Числа!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                Count.Text = "";
                return;
            }

            double a = 0;
            double b = 0;

            if (!double.TryParse(NumA.Text, out a))
            {
                MessageBox.Show("Ошибка, пожалуйста, введите корректное число в поле A!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                Count.Text = "";
                return;
            }

            if (NumB.Text != "" && !double.TryParse(NumB.Text, out b))
            {
                MessageBox.Show("Ошибка, пожалуйста, введите корректное число в поле B!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                Count.Text = "";
                return;
            }

            string op = OP.Text;

            switch (op)
            {
                case "+":
                    Count.Text = (a + b).ToString();
                    break;
                case "-":
                    Count.Text = (a - b).ToString();
                    break;
                case "*":
                    Count.Text = (a * b).ToString();
                    break;
                case "/":
                    if (b == 0)
                    {
                        MessageBox.Show("Ошибка, на 0 делить нельзя!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                        Count.Text = "";
                    }
                    else
                    {
                        Count.Text = (a / b).ToString();
                    }
                    break;
                default:
                    MessageBox.Show("Ошибка, несуществующая операция! Пожалуйста, введите корректную операцию!", "Ошибка операции", MessageBoxButton.OK, MessageBoxImage.Error);
                    OP.Text = "";
                    break;
            }
        }
    }
}
