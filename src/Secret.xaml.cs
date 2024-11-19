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

namespace Iwanov_Egor_Pract_2
{
    /// <summary>
    /// Логика взаимодействия для Secret.xaml
    /// </summary>
    public partial class Secret : Window
    {
        public Secret()
        {
            InitializeComponent();
        }

        private string SecretPassword = "qwertyqwerty1234";
        private int AttemptsCount = 0;


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window MainWindow = new MainWindow();
            MainWindow.Closed += (s, args) => this.Close();
            MainWindow.Show();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string inputPassword = PasswordTextBox.Text;

            if (inputPassword == SecretPassword)
            {
                MessageBox.Show("Очень Секретное Сообщение (Закройте Глаза) - Привет, Мир!", "Операция прошла Успешно", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                AttemptsCount++;
                if (AttemptsCount < 3)
                {
                    MessageBox.Show("Ошибка, Пароль неверный!", "Ошибка операции", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Вы исчерпали все попытки!", "Ошибка операции", MessageBoxButton.OK, MessageBoxImage.Information);
                    PasswordTextBox.IsEnabled = false;
                }
            }

            PasswordTextBox.Clear();
            PasswordTextBox.Focus();
        }

    }
}
