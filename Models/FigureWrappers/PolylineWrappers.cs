﻿using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyPaint3000.Models.FigureWrappers
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PolylineWrappers : Avalonia.Controls.Shapes.Polyline
    {
        [JsonProperty]
        public IList<Point> Points
        {
            get { return GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }
        [JsonProperty]
        public double StrokeThickness
        {
            get { return GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }
        [JsonProperty]
        public IBrush? Stroke
        {
            get { return GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }
        [JsonProperty]
        public string? Name { get; set; }
    }
}
