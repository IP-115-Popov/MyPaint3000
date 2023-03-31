using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace MyPaint3000.Models
{
    [Serializable]
    public class MyShapeSerialize
    { 
        public string? tupeFigure { get; set; }
        public string? name { get; set; }
        public double lineSize { get; set; }
        public MyColor? selectedColorLine { get; set; }
        public MyColor? selectedColorFill { get; set; }
        public string? x1Y1 { get; set; }
        public string? x2Y2 { get; set; }
        public string? myWidth { get; set; }
        public string? myHeight { get; set; }
        public List<Avalonia.Point>? myPoints { get; set; }
    }
}
