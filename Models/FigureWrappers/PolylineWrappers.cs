using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyPaint3000.Models.FigureWrappers
{
    [DataContract]
    public class PolylineWrappers : Avalonia.Controls.Shapes.Polyline
    {
        [DataMember]
        public IList<Point> Points
        {
            get { return GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }
        [DataMember]
        public double StrokeThickness
        {
            get { return GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }
        [DataMember]
        public IBrush? Stroke
        {
            get { return GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }
        [DataMember]
        public string? Name { get; set; }
    }
}
