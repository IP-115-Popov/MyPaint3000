using Avalonia.Controls.Shapes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.Models
{
    [DataContract]
    public class SerializeCanvas2
    {
        private List<Shape> ellipseWrappersList;
        private List<Shape> lineWrappersList;
        private List<Shape> pathWrappersList;
        private List<Shape> polygonWrappersList;
        private List<Shape> polylineWrappersList;
        private List<Shape> rectangleWrappersList;
        public SerializeCanvas2()
        {
            ellipseWrappersList = new List<Shape>();
            lineWrappersList = new List<Shape>();
            pathWrappersList = new List<Shape>();
            polygonWrappersList = new List<Shape>();
            polylineWrappersList = new List<Shape>();
            rectangleWrappersList = new List<Shape>();
        }
        //сериализуемые свойства
        [DataMember]
        public List<Shape> EllipseWrappersList 
        {
            get => ellipseWrappersList;
            set { ellipseWrappersList = value; }
        }
        [DataMember]
        public List<Shape> LineWrappersList
        {
            get => lineWrappersList;
            set { lineWrappersList = value; }
        }
        [DataMember]
        public List<Shape> PathWrappersList
        {
            get => pathWrappersList;
            set { pathWrappersList = value; }
        }
        [DataMember]
        public List<Shape> PolygonWrappersList
        {
            get => polygonWrappersList;
            set { polygonWrappersList = value; }
        }
        [DataMember]
        public List<Shape> PolylineWrappersList
        {
            get => polylineWrappersList;
            set { polylineWrappersList = value; }
        }
        [DataMember]
        public List<Shape> RectangleWrappersList
        {
            get => rectangleWrappersList;
            set { rectangleWrappersList = value; }
        }
        public void SerializeCanvas(ObservableCollection<Shape> canvasFigureList)
        {
            foreach (Shape i in canvasFigureList)
            {
                if (i is Ellipse)
                {
                    ellipseWrappersList.Add(i);
                }
                else if (i is Line)
                {
                    lineWrappersList.Add(i);
                }
                else if (i is Path)
                {
                    pathWrappersList.Add(i);
                }
                else if (i is Polygon)
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
