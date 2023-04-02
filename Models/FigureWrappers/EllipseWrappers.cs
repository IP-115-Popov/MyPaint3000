using Avalonia;
using Avalonia.Animation;
using Avalonia.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyPaint3000.Models.FigureWrappers
{
    [DataContract]
    public class EllipseWrappers : Avalonia.Controls.Shapes.Ellipse
    {
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
        [DataMember]
        public double Width
        {
            get { return GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }
        [DataMember]
        public double Height
        {
            get { return GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }
        [DataMember]
        public Thickness Margin
        {
            get { return GetValue(MarginProperty); }
            set { SetValue(MarginProperty, value); }
        }
        [DataMember]
        public string MarginText
        {
            get;
            set;
        }
        [DataMember]
        public IBrush? Fill
        {
            get { return GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }
    }
}
