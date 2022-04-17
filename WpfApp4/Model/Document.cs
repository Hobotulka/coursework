using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Model
{
    public class Document
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Seriy { get; set; }
        public string Organ { get; set; }
        public DateTime Data { get; set; }

        public Document() { }

        public Document(int id, string name, string seriy, string organ, DateTime data)
        {
            this.ID = id;
            this.Name = name;
            this.Seriy = seriy;
            this.Organ = organ;
            this.Data = data;
        }

        public Document ShallowCopy()
        {
            return (Document)this.MemberwiseClone();
        }
    }
}
