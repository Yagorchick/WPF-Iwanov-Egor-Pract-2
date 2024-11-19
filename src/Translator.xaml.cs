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
    public partial class Translator : Window
    {
        public Translator()
        {
            InitializeComponent();
        }

        private readonly Dictionary<string, string> Words = new Dictionary<string, string>
        {
            { "жарко", "Hot" },
            { "hot", "Жарко" },
            { "тепло", "Warm" },
            { "warm", "Тепло" },
            { "ясно", "Clear" },
            { "clear", "Ясно" },
            { "солнечно", "Sunny" },
            { "sunny", "Солнечно" },
            { "ветрено", "Windy" },
            { "windy", "Ветрено" },
            { "дождь", "Rain" },
            { "rain", "Дождь" },
            { "туман", "Fog" },
            { "fog", "Туман" },
            { "туманно", "Foggy" },
            { "foggy", "Туманно" },
            { "дымка", "Mist" },
            { "mist", "Дымка" },
            { "лёгкая дымка", "Haze" },
            { "haze", "Лёгкая дымка" }
        };


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window MainWindow = new MainWindow();
            MainWindow.Closed += (s, args) => this.Close();
            MainWindow.Show();
        }

        private void Translate_Click(object sender, RoutedEventArgs e)
        {
            string input = WordA.Text.ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                WordB.Text = "";
                return;
            }

            if (Words.TryGetValue(input, out string translation))
            {
                WordB.Text = translation;
            }
            else
            {
                MessageBox.Show("Ошибка, такого слова нет!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                WordB.Text = "";
            }
        }

    }
}
