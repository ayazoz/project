using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Web;
using System.Web;


namespace deneme1
{
    class Program
    {

        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("dosya.txt");

            List<string> lineWords = new List<string>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();//kelimelerin ve sayılarının aynı dizide tutulması

            char[] delimiters = { '.', ',', '?', ' ','{','}',';','!','-','(',')' }; //kelimeleri biribirinden ayıran karakterler

            string line = null; //textten okunan satırı tutar

            do
            {

                line = sr.ReadLine();//textten satır okunur
                line = line.ToLower();
                lineWords = line.Split(delimiters).ToList();//satır kelimelere ayrılır
                

                foreach (string word in lineWords)
                {


                    if (word.Length >= 2)// 2 ve daha fazla harfli kelimeler sayılır.
                    {

                        if (dictionary.ContainsKey(word))//eğer kelime daha önce kullanılmışsa
                        {

                            dictionary[word]++;//kelimenin sayısı arttılır

                        }
                        else// keliem ilk defa kullanılmışsa
                        {
                            dictionary.Add(word, 1);//ekleme yapılır 

                        }

                    }

                } // foreach döngü sonu

            } while (!sr.EndOfStream); //text sonu


            //azalan sıraya göre kelimelerin geçme sıklıkların sıralanması
            var sortedDict = (from entry in dictionary orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
          
            Console.WriteLine("WORDS  -    FREQUENCY");



           //*****************************************************************
           //xml dosyası oluşturma

            XmlTextWriter xmlFile = new XmlTextWriter("wordXMLfile.xml", Encoding.UTF8);

            xmlFile.Formatting = Formatting.Indented;
            xmlFile.WriteStartDocument();
            xmlFile.WriteStartElement("words");//xml ilk başlık

            foreach (KeyValuePair<string, int> pair in sortedDict)
            {
                Console.WriteLine(pair.Key + "\t\t" + pair.Value);

                xmlFile.WriteStartElement("word text= "+ '"'+ pair.Key + '"'+ "    Count= " + '"' + pair.Value + '"' );//her kelime bilgisinin xml dosyasına eklenmesi
                xmlFile.WriteEndElement();

            }

            xmlFile.WriteEndElement();//acilan tagları kapatma
            xmlFile.Close();

            Console.ReadKey();
        }

       

    }

}
