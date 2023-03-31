using Avalonia.Controls.Shapes;
using DynamicData;
using DynamicData.Binding;
using MyPaint3000.Models.FigureWrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CanvasListSerialize
    {
        private List<Shape> ellipseWrappersList;
        private List<Shape> lineWrappersList;
        private List<Shape> pathWrappersList;
        private List<Shape> polygonWrappersList;
        private List<Shape> polylineWrappersList;
        private List<Shape> rectangleWrappersList;
        //сериализуемые свойства
        [JsonProperty]
        public string? jsonEllipseWrappersList;
        [JsonProperty]
        public string? jsonLineWrappersList;
        [JsonProperty]
        public string? jsonPathWrappersList;
        [JsonProperty]
        public string? jsonPolygonWrappersList;
        [JsonProperty]
        public string? jsonPolylineWrappersList;
        [JsonProperty]
        public string? jsonRectangleWrappersList;
        public CanvasListSerialize()
        {
            ellipseWrappersList = new List<Shape>();
            lineWrappersList = new List<Shape>();
            pathWrappersList = new List<Shape>();
            polygonWrappersList = new List<Shape>();
            polylineWrappersList = new List<Shape>();
            rectangleWrappersList = new List<Shape>();
        }
        //public List<Shape> EllipseWrappersList 
        //{
        //    get => ellipseWrappersList;
        //    set { ellipseWrappersList = value; }
        //}
        //public List<Shape> LineWrappersList
        //{
        //    get => lineWrappersList;
        //    set { lineWrappersList = value; }
        //}     
        //public List<Shape> PathWrappersList
        //{
        //    get => pathWrappersList;
        //    set { pathWrappersList = value; }
        //}    
        //public List<Shape> PolygonWrappersList
        //{
        //    get => polygonWrappersList;
        //    set { polygonWrappersList = value; }
        //}    
        //public List<Shape> PolylineWrappersList
        //{
        //    get => polylineWrappersList;
        //    set { polylineWrappersList = value; }
        //} 
        //public List<Shape> RectangleWrappersList
        //{
        //    get => rectangleWrappersList;
        //    set { rectangleWrappersList = value; }
        //}
       // [JsonIgnore]
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
                } else if (i is Path)
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
                else if (i is Rectangle)
                {
                    rectangleWrappersList.Add(i);
                }
            }
            jsonEllipseWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(ellipseWrappersList, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
            jsonLineWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(lineWrappersList, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
            jsonPathWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(pathWrappersList, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
            jsonPolygonWrappersList = Newtonsoft.Json.JsonConvert.SerializeObject(polygonWrappersList, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
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
