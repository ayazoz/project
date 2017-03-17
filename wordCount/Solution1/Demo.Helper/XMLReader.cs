using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web;//Add References -> Choose assemblies  
using System.Data;//Add  
using Demo.Helper.External.Models; // Add  


namespace Demo.Helper
{
    public class XMLReader
    {
        public List<Words> ReturnListOfProducts()
        {
            string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/wordXMLfile.xml");//Path of the xml script  
            DataSet ds = new DataSet();//Using dataset to read xml file  
            ds.ReadXml(xmlData);
            var words = new List<Words>();
            words = (from rows in ds.Tables[0].AsEnumerable()
                        select new Words
                        {
                            word = rows[0].ToString(),
                            count = rows[1].ToString(),
                        }).ToList();

            return words;


        }
    }
}
