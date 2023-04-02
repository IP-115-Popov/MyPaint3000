using Avalonia.Controls.Shapes;
using Avalonia.Media;
using MyPaint3000.Models.FigureForSerialise;
using MyPaint3000.Models.FigureWrappers;
using MyPaint3000.ViewModels.Page;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyPaint3000.Models
{
    [Serializable]
    public class CanvasListSerializeXml
    {
        //сериализуемые свойства
        public List<EllipseForSerialize> ellipseForSerializeList { get; set; }
        public List<LineForSerialize> lineForSerializeList { get; set; }
        //public List<PathForSerialize> pathForSerializeList { get; set; }
        //public List<PolygonForSerialize> polygonForSerializeList { get; set; }
        //public List<PolylineForSerialize> polylineForSerializeList { get; set; }
       // public List<RectangForSerialize> rectangleForSerializeList { get; set; }
        public CanvasListSerializeXml()
        {
            ellipseForSerializeList = new List<EllipseForSerialize>();
            lineForSerializeList = new List<LineForSerialize>();
            //pathForSerializeList = new List<PathForSerialize>();
            //polygonForSerializeList = new List<PolygonForSerialize>();
            //polylineForSerializeList = new List<PolylineForSerialize>();
           // rectangleForSerializeList = new List<RectangForSerialize>();
        }
        public void SerializeCanvas(ObservableCollection<Shape> canvasFigureList)
        {
            foreach (Shape i in canvasFigureList)
            {
                if (i is Ellipse)
                {
                    ellipseForSerializeList.Add(new EllipseForSerialize()
                    {
                        Width = ((Ellipse)i).Width.ToString(),
                        Height = ((Ellipse) i).Height.ToString(),
                        Stroke = ((Ellipse) i).Stroke.ToString(),
                        StrokeThickness = ((Ellipse)i).StrokeThickness ,
                        Margin = ((Ellipse) i).Margin.ToString(),
                        Fill = ((Ellipse)i).Fill.ToString(),
                        Name = ((Ellipse)i).Name,
                });
                }
                else if (i is Line)
                {

                    lineForSerializeList.Add(new LineForSerialize()
                    {
                        EndPoint = ((Line)i).EndPoint.ToString(),
                        Name= ((Line)i).Name,
                        StartPoint = ((Line)i).StartPoint.ToString(),
                        StrokeThickness = ((Line)i).StrokeThickness,
                        Stroke = ((SolidColorBrush?)i.Stroke).Color.ToString()
                    });
                }
                /*else if (i is Avalonia.Controls.Shapes.Path)
                {
                    pathWrappersList.Add((PathWrappers)i);
                }
                else if (i is Polygon)
                {
                    polygonWrappersList.Add((PolygonWrappers)i);
                }
                else if (i is Polyline)
                {
                    polylineWrappersList.Add((PolylineWrappers)i);
                }
                else if (i is Avalonia.Controls.Shapes.Rectangle)
                {
                    rectangleWrappersList.Add((RectangleWrappers)i);
                }*/
            }
        }
        public ObservableCollection<Shape> DeSerializeCanvas()
        {
            ObservableCollection<Shape> rez = new ObservableCollection<Shape>();

            //заплнение результата из массивов   


            foreach (EllipseForSerialize i in ellipseForSerializeList)
            {
                //i.Margin = Avalonia.Thickness.Parse(i.MarginText);
                rez.Add(new Ellipse()
                {
                    Width = double.Parse(i.Width),
                    Height = double.Parse(i.Height),
                    Stroke = new SolidColorBrush(FromName(i.Stroke)),
                    StrokeThickness = i.StrokeThickness,
                    Margin = Avalonia.Thickness.Parse(i.Margin),
                    Fill = new SolidColorBrush(FromName(i.Fill)),
                    Name = i.Name,
                });
            }
            foreach (LineForSerialize i in lineForSerializeList)
            {
                rez.Add(new Line()
                {
                    EndPoint = Avalonia.Point.Parse(i.EndPoint),
                    Name = i.Name,
                    StartPoint = Avalonia.Point.Parse(i.StartPoint),
                    StrokeThickness = i.StrokeThickness,
                    Stroke = new SolidColorBrush(FromName(i.Stroke)),//new Colors(i.Stroke)
                });
            }
            /*foreach (PathForSerialize i in pathWrappersList)
            {
                //i.Data = Geometry.Parse(i.DataText);
                rez.Add(i);
            }
            foreach (PolygonForSerialize i in polygonWrappersList)
            {
                rez.Add(i);
            }
            foreach (PolylineForSerialize i in polylineWrappersList)
            {
                rez.Add(i);
            }
            foreach (RectangleForSerialize i in rectangleWrappersList)
            {
                rez.Add(i);
            }*/
            return rez;
        }
        public static Color FromName(String name)
        {
            var color_props = typeof(Colors).GetProperties();
            foreach (var c in color_props)
                if (name.Equals(c.Name, StringComparison.OrdinalIgnoreCase))
                    return (Color)c.GetValue(new Color(), null);
            return Colors.Transparent;
        }
    }
}
