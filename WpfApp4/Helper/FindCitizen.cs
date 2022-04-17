using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Model;

namespace WpfApp4.Helper
{
    class FindCitizen
    {
        int id;
        public FindCitizen(int id)
        {
            this.id = id;
        }
        public bool CitizenPredicate(Citizen citizen)
        {
            return citizen.ID == id;
        }
    }
}
