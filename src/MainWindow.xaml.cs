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

namespace Iwanov_Egor_Pract_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Translator_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window Translator = new Translator();
            Translator.Closed += (s, args) => this.Close();
            Translator.Show();
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window Calculator = new Calculator();
            Calculator.Closed += (s, args) => this.Close();
            Calculator.Show();
        }

        private void FromToTill_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window FromToTill = new FromToTill();
            FromToTill.Closed += (s, args) => this.Close();
            FromToTill.Show();
        }

        private void Secret_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window Secret = new Secret();
            Secret.Closed += (s, args) => this.Close();
            Secret.Show();
        }
    }
}