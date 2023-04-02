using Avalonia.Animation;
using Avalonia.Media;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class PathWrappers : Avalonia.Controls.Shapes.Path
    {
        [DataMember]
        public string DataText
        {
            get;
            set;
        }
        [DataMember]
        public Geometry Data
        {
            get { return GetValue(DataProperty); }
            set { SetValue(DataProperty, value);  }
        }
        [DataMember]
        public IBrush? Fill
        {
            get { return GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
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
