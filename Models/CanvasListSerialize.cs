using Avalonia.Controls.Shapes;
using DynamicData;
using DynamicData.Binding;
using MyPaint3000.Models.FigureWrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.Models
{
    public class CanvasListSerialize
    {    
        public List<EllipseWrappers> EllipseWrappersList { get; set; }
        public List<LineWrappers> LineWrappersList { get; set; }
        public List<PathWrappers> PathWrappersList { get; set; }
        public List<PolygonWrappers> PolygonWrappersList { get; set; }
        public List<PolylineWrappers> PolylineWrappersList { get; set; }
        public List<RectangleWrappers> RectangleWrappersList { get; set; }
        public void SerializeCanvas(ObservableCollection<Shape> canvasFigureList) 
        { 
            foreach (Shape i in canvasFigureList) 
            {
                if (i is Ellipse)
                {
                    EllipseWrappersList.Add((EllipseWrappers)i);
                } else if(i is Line)
                {
                    LineWrappersList.Add((LineWrappers)i);
                } else if (i is Path)
                {
                    PathWrappersList.Add((PathWrappers)i);
                } else if (i is Polygon)
                {
                    PolygonWrappersList.Add((PolygonWrappers)i);
                }
                else if (i is Polyline)
                {
                    PolylineWrappersList.Add((PolylineWrappers)i);

                }
                else if (i is Rectangle)
                {
                    RectangleWrappersList.Add((RectangleWrappers)i);
                }
            }
        }
        public ObservableCollection<Shape> DeSerializeCanvas()
        {
            ObservableCollection<Shape> rez = new ObservableCollection<Shape>();
            foreach (Shape i in EllipseWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in LineWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in PathWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in PolygonWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in PolylineWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in RectangleWrappersList)
            {
                rez.Add(i);
            }
            return rez;
        }
    }
}
