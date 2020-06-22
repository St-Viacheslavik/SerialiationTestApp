using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace SerializationTest
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Serialization test app");
            Random rnd = new Random();
            var work = new List<WorkPlace>();
            var humans = new List<Human>();
            for (int i = 1; i < 10; i++)
            {
                work.Add(new WorkPlace(i, "Отдел " + i));
            }
            for (int i = 0; i < 50; i++)
            {
                var human = new Human("Человек " + i, rnd.Next(2000,40000))
                {
                    WorkPlace = work [i%9]
                };
                humans.Add(human);
            }

            Console.WriteLine("Binary serialization");

            #region BinarySerialization

            var bf = new BinaryFormatter();

            //serialization in file
            using (var file = new FileStream("humans.bin", FileMode.OpenOrCreate))
            {
                bf.Serialize(file, work);
            }

            //deserialization
            using (var file = new FileStream("humans.bin", FileMode.Open))
            {
                var nWork = (List<WorkPlace>)bf.Deserialize(file);
                foreach (var cnt in nWork)
                {
                    Console.WriteLine(cnt);
                }
            }

            #endregion

            Console.ReadLine();
            Console.WriteLine("Soap serialization");

            #region SoapSerialization

            var sf = new SoapFormatter();

            //serialization in file
            using (var file = new FileStream("humans.soap", FileMode.Create))
            {
                sf.Serialize(file, work.ToArray());
            }

            //deserialization
            using (var file = new FileStream("humans.soap", FileMode.Open))
            {
                var nWork = (WorkPlace[])sf.Deserialize(file);
                foreach (var cnt in nWork)
                {
                    Console.WriteLine(cnt);
                }
            }

            #endregion

            Console.ReadLine();
            Console.WriteLine("XML serialization");

            #region XML_Serialization

            var xmlForm = new XmlSerializer(typeof(List<WorkPlace>));

            //serialization in file
            using (var file = new FileStream("humans.xml", FileMode.Create))
            {
                xmlForm.Serialize(file, work);
            }

            //deserialization
            using (var file = new FileStream("humans.xml", FileMode.Open))
            {
                var nWork = (List<WorkPlace>)xmlForm.Deserialize(file);
                foreach (var cnt in nWork)
                {
                    Console.WriteLine(cnt);
                }
            }
            #endregion

            Console.ReadLine();
            Console.WriteLine("JSON serialization");

            #region JSON_Serialization

            var jsonForm = new DataContractJsonSerializer(typeof(List<Human>));

            //serialization in file
            using (var file = new FileStream("humans.json", FileMode.Create))
            {
                jsonForm.WriteObject(file, humans);
            }

            //deserialization
            using (var file = new FileStream("humans.json", FileMode.Open))
            {
                var nHuman = (List<Human>)jsonForm.ReadObject(file);
                foreach (var cnt in nHuman)
                {
                    Console.WriteLine(cnt);
                }
            }

            #endregion

            Console.ReadLine();
        }
    }
}
