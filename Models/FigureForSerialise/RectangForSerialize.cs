using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.Models.FigureForSerialise
{
    [DataContract]
    public class RectangForSerialize
    {
        public RectangForSerialize() {}
        [DataMember]
        public double StrokeThickness { get; set; }
        [DataMember]
        public IBrush? Stroke { get; set; }
        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public double Width { get; set; }
        [DataMember]
        public double Height { get; set; }
        [DataMember]
        public Thickness Margin { get; set; }
        [DataMember]
        public string MarginText { get; set; }
        [DataMember]
        public IBrush? Fill { get; set; }
    }
}
