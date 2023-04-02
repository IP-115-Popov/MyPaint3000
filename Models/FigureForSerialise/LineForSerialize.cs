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
    [Serializable]
    [DataContract]
    public class LineForSerialize
    {
        public LineForSerialize() { }
        [DataMember]
        public double StrokeThickness { get; set; }
        [DataMember]
        public string? Stroke { get; set; }
        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public string? StartPoint { get; set; }
        [DataMember]
        public string? EndPoint { get; set; }
    }
}
