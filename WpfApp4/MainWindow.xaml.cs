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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.View;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Citizen_OnClick(object sender, RoutedEventArgs e)
        {
            WindowCitizen citizen = new WindowCitizen();
            citizen.Show();
        }

        private void Person_OnClick(object sender, RoutedEventArgs e)
        {
            WindowPerson person = new WindowPerson();
            person.Show();
        }

        private void Document_OnClick(object sender, RoutedEventArgs e)
        {
            WindowDocument document = new WindowDocument();
            document.Show();
        }

        public static int IdCitizen { get; set; }
        public static int IdPerson { get; set; }
        public static int IdDocument { get; set; }
    }
}
