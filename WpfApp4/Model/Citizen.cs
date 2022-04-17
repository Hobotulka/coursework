using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.ViewModel;

namespace WpfApp4.Model
{
    public class Citizen
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int DocumentID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        public Citizen() { }

        public Citizen(int id, int personID, int documentID, string firstNmae, string secondName, string lastName)
        {
            this.ID = id;
            this.PersonID = personID;
            this.DocumentID = documentID;
            this.FirstName = firstNmae;
            this.SecondName = secondName;
            this.LastName = lastName;
        }

        public Citizen CopyFromCitizenDPO(CitizenDPO p)
        {
            PersonViewModel vmPerson = new PersonViewModel();
            DocumentViewModel vmDocument = new DocumentViewModel();
            int personId = 0;
            int documentId = 0;
            foreach (var r in vmPerson.ListPerson)
            {
                if (r.Shifer == p.Person)
                {
                    personId = r.ID;
                    break;
                }
            }
            foreach (var r in vmDocument.ListDocument)
            {
                if (r.Seriy == p.Document)
                {
                    documentId = r.ID;
                    break;
                }
            }
            if (personId != 0 && documentId != 0)
            {
                this.ID = p.ID;
                this.PersonID = personId;
                this.DocumentID = documentId;
                this.FirstName = p.FirstName;
                this.SecondName = p.SecondName;
                this.LastName = p.LastName;
            }
            return this;
        }

        public Citizen ShallowCopy()
        {
            return (Citizen)this.MemberwiseClone();
        }
    }
}
