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
using WpfApp4.Helper;
using WpfApp4.Model;
using System.Collections.ObjectModel;

namespace WpfApp4.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCitizen.xaml
    /// </summary>
    public partial class WindowCitizen : Window
    {
        CitizenViewModel vmCitizen;
        PersonViewModel vmPerson;
        DocumentViewModel vmDocument;
        List<Person> persons;
        List<Document> documents;
        ObservableCollection<CitizenDPO> citizensDPO;

        public WindowCitizen()
        {
            InitializeComponent();

            vmCitizen = new CitizenViewModel();
            vmPerson = new PersonViewModel();
            vmDocument = new DocumentViewModel();
            persons = vmPerson.ListPerson.ToList();
            documents = vmDocument.ListDocument.ToList();

            citizensDPO = new ObservableCollection<CitizenDPO>();
            foreach (var citizen in vmCitizen.ListCitizen)
            {
                CitizenDPO p = new CitizenDPO();
                p = p.CopyFromCitizen(citizen);
                citizensDPO.Add(p);
            }
            lvCitizen.ItemsSource = citizensDPO;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCitizen wnCitizen = new WindowNewCitizen
            {
                Title = "Новый гражданин",
                Owner = this
            };
            int maxIdCitizen = vmCitizen.MaxId() + 1;
            CitizenDPO per = new CitizenDPO
            {
                ID = maxIdCitizen
            };
            wnCitizen.DataContext = per;
            wnCitizen.CbPerson.ItemsSource = persons;
            wnCitizen.CbDocument.ItemsSource = documents;
            if (wnCitizen.ShowDialog() == true)
            {
                Person r = (Person)wnCitizen.CbPerson.SelectedValue;
                per.Person = r.Shifer;
                Document p = (Document)wnCitizen.CbDocument.SelectedValue;
                per.Document = p.Seriy;
                citizensDPO.Add(per);
                Citizen f = new Citizen();
                f = f.CopyFromCitizenDPO(per);
                vmCitizen.ListCitizen.Add(f);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCitizen wnCitizen = new WindowNewCitizen
            {
                Title = "Редактирование данных",
                Owner = this
            };
            CitizenDPO perDPO = (CitizenDPO)lvCitizen.SelectedValue;
            CitizenDPO tempPerDPO;
            if (perDPO != null)
            {
                tempPerDPO = perDPO.ShallowCopy();
                wnCitizen.DataContext = tempPerDPO;
                wnCitizen.CbPerson.ItemsSource = persons;
                wnCitizen.CbDocument.ItemsSource = documents;
                wnCitizen.CbPerson.Text = tempPerDPO.Person;
                wnCitizen.CbDocument.Text = tempPerDPO.Document;
                if (wnCitizen.ShowDialog() == true)
                {
                    Person r = (Person)wnCitizen.CbPerson.SelectedValue;
                    perDPO.Person = r.Shifer;
                    Document p = (Document)wnCitizen.CbDocument.SelectedValue;
                    perDPO.Document = p.Seriy;
                    perDPO.FirstName = tempPerDPO.FirstName;
                    perDPO.SecondName = tempPerDPO.SecondName;
                    perDPO.LastName = tempPerDPO.LastName;
                    lvCitizen.ItemsSource = null;
                    lvCitizen.ItemsSource = citizensDPO;
                    FindCitizen finder = new FindCitizen(perDPO.ID);
                    List<Citizen> listCitizen = vmCitizen.ListCitizen.ToList();
                    Citizen f = listCitizen.Find(new Predicate<Citizen>(finder.CitizenPredicate));
                    f = f.CopyFromCitizenDPO(perDPO);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать гражданина для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CitizenDPO citizen = (CitizenDPO)lvCitizen.SelectedItem;
            if (citizen != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по гражданину:\n" + citizen.FirstName + " " + citizen.LastName, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    citizensDPO.Remove(citizen);
                    Citizen per = new Citizen();
                    per = per.CopyFromCitizenDPO(citizen);
                    vmCitizen.ListCitizen.Remove(per);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные по гражданину для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
