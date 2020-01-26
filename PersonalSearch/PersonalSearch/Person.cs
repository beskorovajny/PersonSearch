using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace PersonalSearch
{
    //[Serializable]
    [XmlRoot(ElementName = "person")]

    public class Person
    {
        [XmlAttribute(AttributeName = "FirstName")]
        public string FirstName { get; set; }
        [XmlAttribute(AttributeName = "LastName")]
        public string LastName { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlAttribute(AttributeName = "Age")]
        public string Age { get; set; }

        public override string ToString()
        {
            return $"{FirstName}, {LastName}, {ID}, {Age}";
        }

    }
}




