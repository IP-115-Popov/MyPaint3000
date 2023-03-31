using Avalonia.Controls.Shapes;
using DynamicData;
using DynamicData.Binding;
using MyPaint3000.Models.FigureWrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.Models
{
    [DataContract]
    public class CanvasListSerialize
    {
        private List<Shape> ellipseWrappersList;
        private List<Shape> lineWrappersList;
        private List<Shape> pathWrappersList;
        private List<Shape> polygonWrappersList;
        private List<Shape> polylineWrappersList;
        private List<Shape> rectangleWrappersList;
        //сериализуемые свойства
        [DataMember]
        public string? jsonEllipseWrappersList { get; set; }
        [DataMember]
        public string? jsonLineWrappersList { get; set; }
        [DataMember]
        public string? jsonPathWrappersList { get; set; }
        [DataMember]
        public string? jsonPolygonWrappersList { get; set; }
        [DataMember]
        public string? jsonPolylineWrappersList { get; set; }
        [DataMember]
        public string? jsonRectangleWrappersList { get; set; }
        public CanvasListSerialize()
        {
            ellipseWrappersList = new List<Shape>();
            lineWrappersList = new List<Shape>();
            pathWrappersList = new List<Shape>();
            polygonWrappersList = new List<Shape>();
            polylineWrappersList = new List<Shape>();
            rectangleWrappersList = new List<Shape>();
        }
        public void SerializeCanvas(ObservableCollection<Shape> canvasFigureList) 
        { 
            foreach (Shape i in canvasFigureList) 
            {
                if (i is Ellipse)
                {
                    ellipseWrappersList.Add(i);
                } else if(i is Line)
                {
                    lineWrappersList.Add(i);
                } else if (i is Avalonia.Controls.Shapes.Path)
                {
                    pathWrappersList.Add(i);
                } else if (i is Polygon)
                {
                    polygonWrappersList.Add(i);
                }
                else if (i is Polyline)
                {
                    polylineWrappersList.Add(i);
                }
                else if (i is Avalonia.Controls.Shapes.Rectangle)
                {
                    rectangleWrappersList.Add(i);
                }
            }
            jsonEllipseWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(ellipseWrappersList);
            jsonLineWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(lineWrappersList);
            jsonPathWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(pathWrappersList);
            jsonPolygonWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(polygonWrappersList);
            jsonPolylineWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(polylineWrappersList, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
            jsonRectangleWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(rectangleWrappersList, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
        }
        public ObservableCollection<Shape> DeSerializeCanvas()
        {
            ObservableCollection<Shape> rez = new ObservableCollection<Shape>();
            //распоковка json строк
            List<Ellipse> ellipseWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ellipse>>(jsonEllipseWrappersList);
            foreach (Ellipse i in ellipseWrappersListBuff)
            {
                lineWrappersList.Add(i);
            }
            List<Line> lineWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Line>>(jsonLineWrappersList);
            foreach (Line i in lineWrappersListBuff)
            {
                lineWrappersList.Add(i);
            }
            List<Avalonia.Controls.Shapes.Path> pathWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Avalonia.Controls.Shapes.Path>>(jsonPathWrappersList);
            foreach (Avalonia.Controls.Shapes.Path i in pathWrappersListBuff)
            {
                lineWrappersList.Add(i);
            }
            List<Polygon> polygonWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Polygon>>(jsonPolygonWrappersList);
            foreach (Polygon i in polygonWrappersListBuff)
            {
                lineWrappersList.Add(i);
            }
            List<Polyline> polylineWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Polyline>>(jsonPolylineWrappersList);
            foreach (Polyline i in polylineWrappersListBuff)
            {
                lineWrappersList.Add(i);
            }
            List<Avalonia.Controls.Shapes.Rectangle> rectangleWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Avalonia.Controls.Shapes.Rectangle>>(jsonRectangleWrappersList);
            foreach (Avalonia.Controls.Shapes.Rectangle i in rectangleWrappersListBuff)
            {
                lineWrappersList.Add(i);
            }
            //заплнение результата из массивов
            foreach (Shape i in ellipseWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in lineWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in pathWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in polygonWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in polylineWrappersList)
            {
                rez.Add(i);
            }
            foreach (Shape i in rectangleWrappersList)
            {
                rez.Add(i);
            }
            return rez;
        }
    }
}
