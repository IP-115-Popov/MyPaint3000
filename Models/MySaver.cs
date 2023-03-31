using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using DynamicData.Binding;
using Avalonia.Media;

namespace MyPaint3000.Models
{
    public class MySaver
    {
        public MyShapeSerialize convertShapeToMyShapeSerialize(Shape serializedFigure)
        {
            MyShapeSerialize myShapeSerialize = new MyShapeSerialize();
            //общие своитва
            myShapeSerialize.name = serializedFigure.Name;
            myShapeSerialize.lineSize = serializedFigure.StrokeThickness;

            myShapeSerialize.selectedColorLine = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) };
            myShapeSerialize.selectedColorLine.MyBrush = (Avalonia.Media.SolidColorBrush)serializedFigure.Stroke;

            //локальные своиства
            if (serializedFigure is Polyline)
            {
                myShapeSerialize.tupeFigure = "Polyline";
            }
            else if (serializedFigure is Avalonia.Controls.Shapes.Path)
            {
                myShapeSerialize.tupeFigure = "Path";
            }
            else if (serializedFigure is Ellipse)
            {
                myShapeSerialize.tupeFigure = "Ellipse";
            }
            else if (serializedFigure is Polygon)
            {
                myShapeSerialize.tupeFigure = "Polygon";
            }
            else if (serializedFigure is Rectangle)
            {
                myShapeSerialize.tupeFigure = "Rectangle";

            }
            else if (serializedFigure is Line)
            {
                myShapeSerialize.tupeFigure = "Line";
            }

            return myShapeSerialize;
        }
        public List<MyShapeSerialize> convertShapeToMyShapeSerialize(ObservableCollection<Shape> serializedFigureList)
        {
            List<MyShapeSerialize> myShapeSerializeList = new List<MyShapeSerialize>();
            foreach (Shape shape in serializedFigureList) 
            {
                myShapeSerializeList.Add(convertShapeToMyShapeSerialize(shape));
            }
            return myShapeSerializeList;
        }
        public string? mySerialize(ObservableCollection<Shape> serializedFigureList, string Exception)
        {
            string? rez = "";
            if (Exception == "json")
            {
                rez = JsonSerializer.Serialize<List<MyShapeSerialize>>(convertShapeToMyShapeSerialize(serializedFigureList));
            }
            return rez;
        }
        public ObservableCollection<Shape> myDeSerialize(string? path, string Exception)
        {
            ObservableCollection<Shape> rez = new ObservableCollection<Shape>();
            List<MyShapeSerialize> MyShapeDeserializeList = new List<MyShapeSerialize>();
            if (Exception == "json")
            {
                MyShapeDeserializeList = JsonSerializer.Deserialize<List<MyShapeSerialize>>(path);
            }
            foreach (MyShapeSerialize i in MyShapeDeserializeList)
            {
            }
            return rez;
        }
        public void Save(ObservableCollection<Shape> serializedFigureList, string path, string Exception)
        {         
            using (StreamWriter file = new StreamWriter(path, false))
            {
                file.Write(mySerialize(serializedFigureList, Exception));
            }
        }
        public void load()
        {

        }
    }
}
