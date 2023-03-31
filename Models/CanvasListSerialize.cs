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
        private List<EllipseWrappers> ellipseWrappersList;
        private List<LineWrappers> lineWrappersList;
        private List<PathWrappers> pathWrappersList;
        private List<PolygonWrappers> polygonWrappersList;
        private List<PolylineWrappers> polylineWrappersList;
        private List<RectangleWrappers> rectangleWrappersList;
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
            ellipseWrappersList = new List<EllipseWrappers>();
            lineWrappersList = new List<LineWrappers>();
            pathWrappersList = new List<PathWrappers>();
            polygonWrappersList = new List<PolygonWrappers>();
            polylineWrappersList = new List<PolylineWrappers>();
            rectangleWrappersList = new List<RectangleWrappers>();
        }
        public void SerializeCanvas(ObservableCollection<Shape> canvasFigureList) 
        { 
            foreach (Shape i in canvasFigureList) 
            {
                if (i is Ellipse)
                {
                    ellipseWrappersList.Add((EllipseWrappers)i);
                } else if(i is Line)
                {
                    lineWrappersList.Add((LineWrappers)i);
                } else if (i is Avalonia.Controls.Shapes.Path)
                {
                    pathWrappersList.Add((PathWrappers)i);
                } else if (i is Polygon)
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
            List<EllipseWrappers> ellipseWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EllipseWrappers>>(jsonEllipseWrappersList);
            foreach (EllipseWrappers i in ellipseWrappersListBuff)
            {
                ellipseWrappersList.Add(i);
            }
            List<LineWrappers> lineWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LineWrappers>>(jsonLineWrappersList);
            foreach (LineWrappers i in lineWrappersListBuff)
            {
                lineWrappersList.Add(i);
            }
            List<PathWrappers> pathWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PathWrappers>>(jsonPathWrappersList);
            foreach (PathWrappers i in pathWrappersListBuff)
            {
                pathWrappersList.Add(i);
            }
            List<PolygonWrappers> polygonWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PolygonWrappers>>(jsonPolygonWrappersList);
            foreach (PolygonWrappers i in polygonWrappersListBuff)
            {
                polygonWrappersList.Add(i);
            }
            List<PolylineWrappers> polylineWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PolylineWrappers>>(jsonPolylineWrappersList);
            foreach (PolylineWrappers i in polylineWrappersListBuff)
            {
                polylineWrappersList.Add(i);
            }
            List<RectangleWrappers> rectangleWrappersListBuff = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RectangleWrappers>>(jsonRectangleWrappersList);
            foreach (RectangleWrappers i in rectangleWrappersListBuff)
            {
                rectangleWrappersList.Add(i);
            }
            //заплнение результата из массивов
            foreach (EllipseWrappers i in ellipseWrappersList)
            {
                rez.Add(i);
            }
            foreach (LineWrappers i in lineWrappersList)
            {
                rez.Add(i);
            }
            foreach (PathWrappers i in pathWrappersList)
            {
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
            }
            return rez;
        }
    }
}
