using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.Models.FigureForSerialise
{
    [DataContract]
    public class PolygonForSerialize
    {
        public PolygonForSerialize() { }
        [DataMember]
        public double StrokeThickness { get; set; }
        [DataMember]
        public IBrush? Stroke { get; set; }

        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public IList<Point> Points { get; set; }

        [DataMember]
        public IBrush? Fill { get; set; }

    }
}
