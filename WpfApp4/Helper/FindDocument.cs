using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.Model;

namespace WpfApp4.Helper
{
    class FindDocument
    {
        int id;
        public FindDocument(int id)
        {
            this.id = id;
        }
        public bool DocumentPredicate(Document document)
        {
            return document.ID == id;
        }
    }
}
