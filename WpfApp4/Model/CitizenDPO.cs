using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WpfApp4.ViewModel;

namespace WpfApp4.Model
{
    public class CitizenDPO
    {
        public int ID { get; set; }
        public string Person { get; set; }
        public string Document { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        public CitizenDPO() { }

        public CitizenDPO(int id, string person, string document, string firstNmae, string secondName, string lastName)
        {
            this.ID = id;
            this.Person = person;
            this.Document = document;
            this.FirstName = firstNmae;
            this.SecondName = secondName;
            this.LastName = lastName;
        }

        public CitizenDPO CopyFromCitizen(Citizen citizen)
        {
            CitizenDPO CitiDPO = new CitizenDPO();
            PersonViewModel vmPerson = new PersonViewModel();
            DocumentViewModel vmDocument = new DocumentViewModel();
            string person = string.Empty;
            string document = string.Empty;
            foreach (var r in vmPerson.ListPerson)
            {
                if (r.ID == citizen.PersonID)
                {
                    person = r.Shifer;
                    break;
                }
            }
            foreach (var r in vmDocument.ListDocument)
            {
                if (r.ID == citizen.DocumentID)
                {
                    document = r.Seriy;
                    break;
                }
            }
            if (person != string.Empty && document != string.Empty)
            {
                CitiDPO.ID = citizen.ID;
                CitiDPO.Person = person;
                CitiDPO.Document = document;
                CitiDPO.FirstName = citizen.FirstName;
                CitiDPO.SecondName = citizen.SecondName;
                CitiDPO.LastName = citizen.LastName;
            }
            return CitiDPO;
        }

        public CitizenDPO ShallowCopy()
        {
            return (CitizenDPO)this.MemberwiseClone();
        }
    }
}
