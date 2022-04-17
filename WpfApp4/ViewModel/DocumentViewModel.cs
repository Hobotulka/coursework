using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp4.Model;

namespace WpfApp4.ViewModel
{
    public class DocumentViewModel
    {
        public ObservableCollection<Document> ListDocument { get; set; } = new ObservableCollection<Document>();

        public DocumentViewModel()
        {
            this.ListDocument.Add(
                new Document
                {
                    ID = 1,
                    Name = "Паспорт",
                    Seriy = "8481 484156",
                    Organ = "",
                    Data = new DateTime (2022, 04, 07)
                });
            this.ListDocument.Add(
                new Document
                {
                    ID = 2,
                    Name = "Паспорт",
                    Seriy = "8941 481046",
                    Organ = "",
                    Data = new DateTime(2022, 04, 07)
                });
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListDocument)
            {
                if (max < r.ID)
                {
                    max = r.ID;
                };
            }
            return max;
        }
    }
}
