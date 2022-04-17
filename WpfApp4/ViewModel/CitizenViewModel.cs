using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp4.Model;

namespace WpfApp4.ViewModel
{
    public class CitizenViewModel
    {
        public ObservableCollection<Citizen> ListCitizen { get; set; } = new ObservableCollection<Citizen>();

        public CitizenViewModel()
        {
            this.ListCitizen.Add(
                new Citizen
                {
                    ID = 1,
                    PersonID = 1,
                    DocumentID = 1,
                    FirstName = "Елена",
                    SecondName = "Ильинична",
                    LastName = "Кутузова"
                });
            this.ListCitizen.Add(
                new Citizen
                {
                    ID = 2,
                    PersonID = 2,
                    DocumentID = 2,
                    FirstName = "Алина",
                    SecondName = "Ярославовна",
                    LastName = "Холодкова"
                });
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListCitizen)
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
