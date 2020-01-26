using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PersonalSearch
{
    [XmlRoot(ElementName = "staff")]
    public class Staff
    {
        [XmlElement(ElementName = "person")]
        public List<Person> PersonList { get; set; }
        public Staff()
        {
            PersonList = new List<PersonalSearch.Person>();
        }
    }
}

