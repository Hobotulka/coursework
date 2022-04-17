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
using WpfApp4.ViewModel;
using WpfApp4.Model;

namespace WpfApp4.View
{
    /// <summary>
    /// Логика взаимодействия для WindowPerson.xaml
    /// </summary>
    public partial class WindowPerson : Window
    {
        PersonViewModel vmPerson;
        public WindowPerson()
        {
            InitializeComponent();

            vmPerson = new PersonViewModel();
            lvPerson.ItemsSource = vmPerson.ListPerson;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPerson wnPerson = new WindowNewPerson
            {
                Title = "Новая личность",
                Owner = this
            };
            int maxIdType = vmPerson.MaxId() + 1;
            Person person = new Person
            {
                ID = maxIdType
            };
            wnPerson.DataContext = person;
            if (wnPerson.ShowDialog() == true)
            {
                vmPerson.ListPerson.Add(person);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPerson wnPerson = new WindowNewPerson
            {
                Title = "Редактирование личности",
                Owner = this
            };
            Person person = lvPerson.SelectedItem as Person;
            if (person != null)
            {
                Person tempType = person.ShallowCopy();
                wnPerson.DataContext = tempType;
                if (wnPerson.ShowDialog() == true)
                {
                    person.Shifer = tempType.Shifer;
                    person.Inn = tempType.Inn;
                    person.Type = tempType.Type;
                    person.Data = tempType.Data;
                    lvPerson.ItemsSource = null;
                    lvPerson.ItemsSource = vmPerson.ListPerson;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать личность для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Person person = (Person)lvPerson.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по личности: " +
                person.Inn, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmPerson.ListPerson.Remove(person);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать личность для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
