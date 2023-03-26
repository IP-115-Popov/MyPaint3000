using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.Models
{
    public class StraightLine
    {
        public StraightLine() { }
        public string? LineName { get; set; }
        public string? X1Y1 { get; set; }
        public string? X2Y2 { get; set; }
        public Color? Color { get; set; }
        public int? Size { get; set; }
    }
}
