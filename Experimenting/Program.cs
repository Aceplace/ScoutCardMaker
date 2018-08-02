using OffensiveFormation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace Experimenting
{
    class Program
    {    
        static void Main(string[] args)
        {
            var formationsToTest = new List<PlacedFormation>();

            formationsToTest.Add(new PlacedFormation());
            formationsToTest.Add(new PlacedFormation());
            formationsToTest.Add(new PlacedFormation());
            formationsToTest.Add(new PlacedFormation());

           /* using (FileStream stream = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<PlacedFormation>));
                xml.Serialize(stream, formationsToTest);
            }*/


            List<PlacedFormation> readFormations;
            using (FileStream stream = new FileStream("test.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<PlacedFormation>));
                readFormations = (List<PlacedFormation>)xml.Deserialize(stream);
            }
            foreach (PlacedFormation placedFormation in readFormations)
            {
                Console.WriteLine(placedFormation.RightTackle.PlacedLocation.XPosition);
            }
            Console.ReadKey();

        }
    }
}
