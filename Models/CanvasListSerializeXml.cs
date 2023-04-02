﻿using Avalonia.Controls.Shapes;
using Avalonia.Media;
using MyPaint3000.Models.FigureForSerialise;
using MyPaint3000.Models.FigureWrappers;
using MyPaint3000.ViewModels.Page;
using MyPaint3000.Views.Page;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;

namespace MyPaint3000.Models
{
    [Serializable]
    public class CanvasListSerializeXml
    {
        //сериализуемые свойства
        public List<EllipseForSerialize> ellipseForSerializeList { get; set; }
        public List<LineForSerialize> lineForSerializeList { get; set; }
        public List<PathForSerialize> pathForSerializeList { get; set; }
        public List<PolygonForSerialize> polygonForSerializeList { get; set; }
        //public List<PolylineForSerialize> polylineForSerializeList { get; set; }
       // public List<RectangForSerialize> rectangleForSerializeList { get; set; }
        public CanvasListSerializeXml()
        {
            ellipseForSerializeList = new List<EllipseForSerialize>();
            lineForSerializeList = new List<LineForSerialize>();
            pathForSerializeList = new List<PathForSerialize>();
            polygonForSerializeList = new List<PolygonForSerialize>();
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
                else if (i is Avalonia.Controls.Shapes.Path)
                {
                    pathForSerializeList.Add(new PathForSerialize()
                    {
                        Data = ((PathWrappers)i).DataText,
                        Fill = ((Avalonia.Controls.Shapes.Path)i).Fill.ToString(),
                        StrokeThickness = ((Avalonia.Controls.Shapes.Path)i).StrokeThickness,
                        Stroke = ((Avalonia.Controls.Shapes.Path)i).Stroke.ToString(),
                        Name = ((Avalonia.Controls.Shapes.Path)i).Name
                    });
                }
                else if (i is Polygon)
                {
                    polygonForSerializeList.Add(new PolygonForSerialize()
                    {
                        StrokeThickness = ((Polygon)i).StrokeThickness,
                        Stroke = ((Polygon)i).Stroke.ToString(),
                        Points = ((PolygonWrappers)i).PointsText,
                        Fill = ((Polygon)i).Fill.ToString(),
                        Name = ((Polygon)i).Name
                });
                }
                /*else if (i is Polyline)
                {
                    polylineForSerializeList.Add((PolylineForSerialize)i);
                }
                else if (i is Avalonia.Controls.Shapes.Rectangle)
                {
                    rectangleForSerializeList.Add((RectangleForSerialize)i);
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
            foreach (PathForSerialize i in pathForSerializeList)
            {
                //i.Data = Geometry.Parse(i.DataText);
                rez.Add(new Avalonia.Controls.Shapes.Path()
                {
                    Data = Geometry.Parse(i.Data),
                    Stroke = new SolidColorBrush(FromName(i.Stroke)),
                    StrokeThickness = i.StrokeThickness,
                    Fill = new SolidColorBrush(FromName(i.Fill)),
                    Name = i.Name,
            });
            }
            foreach (PolygonForSerialize i in polygonForSerializeList)
            {
                Polygon poly = new Polygon()
                {
                    Name = i.Name,
                    Stroke = new SolidColorBrush(FromName(i.Stroke)),
                    StrokeThickness = i.StrokeThickness,
                    Fill = new SolidColorBrush(FromName(i.Fill)),
                };
                List<Avalonia.Point> listOfPoints = new List<Avalonia.Point>();
                string[] words = i.Points.Split(' ');            
                foreach (string word in words)
                {
                    listOfPoints.Add(Avalonia.Point.Parse(word));
                }
                poly.Points = listOfPoints;
                rez.Add(poly);
            }
            /*foreach (PolylineForSerialize i in polylineWrappersList)
            {
                rez.Add(new Polyline()
            {
                Name = i.Name,
                Stroke = new SolidColorBrush(FromName(i.Stroke)),
                StrokeThickness = i.StrokeThickness,
            });
            }
            foreach (RectangleForSerialize i in rectangleWrappersList)
            {
                rez.Add(new Rectangle()
            {
                Name = i.Name,
                Stroke = new SolidColorBrush(FromName(i.Stroke)),
                StrokeThickness = i.StrokeThickness,
            });
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