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
    /// Логика взаимодействия для WindowDocument.xaml
    /// </summary>
    public partial class WindowDocument : Window
    {
        DocumentViewModel vmDocument;
        public WindowDocument()
        {
            InitializeComponent();

            vmDocument = new DocumentViewModel();
            lvDocument.ItemsSource = vmDocument.ListDocument;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewDocument wnDocument = new WindowNewDocument
            {
                Title = "Новый документ",
                Owner = this
            };
            int maxIdType = vmDocument.MaxId() + 1;
            Document document = new Document
            {
                ID = maxIdType
            };
            wnDocument.DataContext = document;
            if (wnDocument.ShowDialog() == true)
            {
                vmDocument.ListDocument.Add(document);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewDocument wnDocument = new WindowNewDocument
            {
                Title = "Редактирование документа",
                Owner = this
            };
            Document document = lvDocument.SelectedItem as Document;
            if (document != null)
            {
                Document tempType = document.ShallowCopy();
                wnDocument.DataContext = tempType;
                if (wnDocument.ShowDialog() == true)
                {
                    document.Name = tempType.Name;
                    document.Seriy = tempType.Seriy;
                    document.Organ = tempType.Organ;
                    document.Data = tempType.Data;
                    lvDocument.ItemsSource = null;
                    lvDocument.ItemsSource = vmDocument.ListDocument;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать документ для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Document document = (Document)lvDocument.SelectedItem;
            if (document != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные по документу: " +
                document.Name, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmDocument.ListDocument.Remove(document);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать документ для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
