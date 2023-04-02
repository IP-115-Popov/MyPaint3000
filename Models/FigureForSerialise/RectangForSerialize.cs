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
        public string? Stroke { get; set; }

        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public string? Width { get; set; }
        [DataMember]
        public string? Height { get; set; }
        [DataMember]
        public string? Margin { get; set; }

        [DataMember]
        public string? MarginText { get; set; }

        [DataMember]
        public string? Fill { get; set; }
    }
}
