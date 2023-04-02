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
        //public List<EllipseWrappers> ellipseWrappersList { get; set; }
        public List<LineForSerialize> lineForSerializeList { get; set; }
        /*public List<PathWrappers> pathWrappersList { get; set; }
        public List<PolygonWrappers> polygonWrappersList { get; set; }
        public List<PolylineWrappers> polylineWrappersList { get; set; }
        public List<RectangleWrappers> rectangleWrappersList { get; set; }*/
        public CanvasListSerializeXml()
        {
            //ellipseWrappersList = new List<EllipseWrappers>();
            lineForSerializeList = new List<LineForSerialize>();
            /*pathWrappersList = new List<PathWrappers>();
            polygonWrappersList = new List<PolygonWrappers>();
            polylineWrappersList = new List<PolylineWrappers>();
            rectangleWrappersList = new List<RectangleWrappers>();*/
        }
        public void SerializeCanvas(ObservableCollection<Shape> canvasFigureList)
        {
            foreach (Shape i in canvasFigureList)
            {
                /*if (i is Ellipse)
                {
                    ellipseWrappersList.Add((EllipseWrappers)i);
                }
                else*/ if (i is Line)
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


           /* foreach (EllipseWrappers i in ellipseWrappersList)
            {
                //i.Margin = Avalonia.Thickness.Parse(i.MarginText);
                rez.Add(i);
            }*/
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
            /*foreach (PathWrappers i in pathWrappersList)
            {
                //i.Data = Geometry.Parse(i.DataText);
                rez.Add(i);
            }
            foreach (PolygonWrappers i in polygonWrappersList)
            {
                rez.Add(i);
            }
            foreach (PolylineWrappers i in polylineWrappersList)
            {
                rez.Add(i);
            }
            foreach (RectangleWrappers i in rectangleWrappersList)
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
