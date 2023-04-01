using Avalonia.Controls.Shapes;
using Avalonia.Media;
using MyPaint3000.Models.FigureWrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyPaint3000.Models
{
    [Serializable]
    public class CanvasListSerializeXml
    {
       //сериализуемые свойства
        private List<LineWrappers> lineWrappersList { get; set; }
        public CanvasListSerializeXml()
        {
            lineWrappersList = new List<LineWrappers>();
        }
        public void SerializeCanvas(ObservableCollection<Shape> canvasFigureList)
        {
            foreach (Shape i in canvasFigureList)
            {
                if (i is Line)
                {
                    lineWrappersList.Add((LineWrappers)i);
                }
            }
        }
        public ObservableCollection<Shape> DeSerializeCanvas()
        {
            ObservableCollection<Shape> rez = new ObservableCollection<Shape>();

            //заплнение результата из массивов   
            foreach (LineWrappers i in lineWrappersList)
            {
                rez.Add(i);
            }          
            return rez;
        }
    }
}
