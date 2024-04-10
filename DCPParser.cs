using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CompileAndRunTests
{
    public class DCPParser
    {
        public static uint GetAddress(string path, string name)
        {


            try
            {
                // Ścieżka do pliku XML
                string filePath = path;

                // Tworzenie obiektu XmlDocument
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                // Znalezienie elementu VAR o atrybucie LName równym "WYNIK2"
                XmlNode varNode = xmlDoc.SelectSingleNode($"//VAR[@LName='{name}']");

                if (varNode != null)
                {
                    // Pobranie wartości atrybutu Addr dla elementu VAR
                    string addrValue = varNode.Attributes["Addr"].Value;
                    //Console.WriteLine("Wartość atrybutu Addr dla WYNIK2: " + addrValue);
                    uint address = Convert.ToUInt32(addrValue,16);
                    return address;
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message);
            }

            return 1;




        }
    }
}


