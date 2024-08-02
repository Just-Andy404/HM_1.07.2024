using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable]
    public class Magazine
    {
        public string Name { get; set; }
        public string PublHouse { get; set; }
        public DateTime Date { get; set; }
        public int NumPages { get; set; }
        public Magazine() { }
        public Magazine(string name, string publHouse, DateTime date, int numPages)
        {
            Name = name;
            PublHouse = publHouse;
            Date = date;
            NumPages = numPages;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nPublishing house: {PublHouse}\nPublishing date: {Date}\nNumber of pages: {NumPages}";
        }
        public void setInfo(string name, string publHouse, DateTime date, int numPages)
        {
            Name = name;
            PublHouse = publHouse;
            Date = date;
            NumPages = numPages;
        }
    }
}
