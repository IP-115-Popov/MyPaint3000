using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyPaint3000.Models
{
    public class MyShapesItem
    {
        public string? Name { get; set; }
        public int? Namber { get; set; }
        public MyShapesItem(string Name, int Namber)
        {
            this.Name = Name;
            this.Namber = Namber;
        }
    }
}
