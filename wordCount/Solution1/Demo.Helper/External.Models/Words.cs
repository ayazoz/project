using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo.Helper.External.Models
{
    [Serializable]
    [XmlRoot("Words"), XmlType("Words")]
    public class Words
    {
        public string word { get; set; }
        public string count { get; set; }
    
    }
}
