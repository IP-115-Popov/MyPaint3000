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
    public class PathForSerialize
    {
        public PathForSerialize() { }
        [DataMember]
        public string DataText { get; set; }
        [DataMember]
        public string Data { get; set; }
        [DataMember]
        public string Fill { get; set; }
        [DataMember]
        public double StrokeThickness { get; set; }
        [DataMember]
        public string Stroke { get; set; }
        [DataMember]
        public string? Name { get; set; }
    }
}
