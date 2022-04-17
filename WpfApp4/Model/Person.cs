using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4.Model
{
    public class Person
    {
        public int ID { get; set; }
        public string Shifer { get; set; }
        public long Inn { get; set; }
        public string Type { get; set; }
        public DateTime Data { get; set; }

        public Person() { }

        public Person(int id, string shifer, long inn, string type, DateTime data)
        {
            this.ID = id;
            this.Shifer = shifer;
            this.Inn = inn;
            this.Type = type;
            this.Data = data;
        }

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }
    }
}
