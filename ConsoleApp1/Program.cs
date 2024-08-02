using System.Xml.Serialization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathBIN = @".\data.bin";
            string pathXML = @".\data.xml";
            string pathJSON = @".\data.json";
            Magazine magazine = new Magazine("Science and Technology", "Knowledge Publishing", new DateTime(2024, 07, 01), 128);
            MySerializer mySerializer = new MySerializer();
            Console.WriteLine("=====BIN=====");
            mySerializer.SerializeBIN(magazine, pathBIN);
            Magazine magazine1 = mySerializer.DeSerializeBIN(pathBIN);
            Console.WriteLine(magazine1);
            Console.WriteLine("=====JSON=====");
            mySerializer.SerializeJSON(magazine, pathJSON);
            Magazine magazine2 = mySerializer.DeSerializeJSON(pathJSON);
            Console.WriteLine(magazine2);
            Console.WriteLine("=====XML=====");
            mySerializer.SerializeXML(magazine, pathXML);
            Magazine magazine3 = mySerializer.DeSerializeXML(pathXML);
            Console.WriteLine(magazine3);
        }
    }
}
