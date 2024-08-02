using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    internal class MySerializer
    {
        public void SerializeBIN(Magazine mag, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(mag.Name);
                    bw.Write(mag.PublHouse);
                    bw.Write(mag.Date.ToBinary());
                    bw.Write(mag.NumPages);
                }
            }
        }
        public Magazine DeSerializeBIN(string path)
        {
            Magazine mag = new Magazine();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (fs.Length > br.BaseStream.Position)
                    {
                        mag.setInfo(br.ReadString(), br.ReadString(), DateTime.FromBinary(br.ReadInt64()), br.ReadInt32());
                    }
                }
            }
            return mag;
        }
        public void SerializeXML(Magazine mag, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Magazine));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, mag);
            }
        }
        public Magazine DeSerializeXML(string path)
        {
            Magazine mag = new Magazine();
            XmlSerializer serializer = new XmlSerializer(typeof(Magazine));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                mag = (Magazine)serializer.Deserialize(fs);
            }
            return mag;
        }
        public void SerializeJSON(Magazine mag, string path)
        {
            string json = JsonConvert.SerializeObject(mag, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, json);
        }
        public Magazine DeSerializeJSON(string path)
        {
            Magazine mag = new Magazine();
            string json = File.ReadAllText(path);
            mag = JsonConvert.DeserializeObject<Magazine>(json);
            return mag;
        }
    }
}
