using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp4.Model;

namespace WpfApp4.ViewModel
{
    public class PersonViewModel
    {
        public ObservableCollection<Person> ListPerson { get; set; } = new ObservableCollection<Person>();

        public PersonViewModel()
        {
            this.ListPerson.Add(
                new Person
                {
                    ID = 1,
                    Shifer = "dsf15sd1f51sd",
                    Inn = 84848121231,
                    Type = "Физическое лицо",
                    Data = new DateTime(2022, 04, 07)
                });
            this.ListPerson.Add(
                new Person
                {
                    ID = 2,
                    Shifer = "4s8dg48s46gs4",
                    Inn = 98426151651,
                    Type = "Физическое лицо",
                    Data = new DateTime(2022, 04, 07)
                });
            this.ListPerson.Add(
                new Person
                {
                    ID = 3,
                    Shifer = "f41gd85g419d8",
                    Inn = 48948161611,
                    Type = "Юридическое лицо",
                    Data = new DateTime(2022, 04, 07)
                });
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListPerson)
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
