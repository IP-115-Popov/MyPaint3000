using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using DynamicData;
using MyPaint3000.Models;
using MyPaint3000.Models.FigureWrappers;
using MyPaint3000.ViewModels.Page;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reactive;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyPaint3000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private MyFigure? myFigure;
        private ObservableCollection<MyFigure> myFiguresList;
        private ObservableCollection<Shape> canvasFigureList;
        private Shape listBoxShapesSelectItem;

        BrokenLineViewModel brokenLineViewModel;
        CompoundFigureViewModel compoundFigureViewModel;
        EllipseViewModel ellipseViewModel;
        PolygonViewModel polygonViewModel;
        RectangleViewModel rectangleViewModel;
        StraightLineViewModel straightLineViewModel;
        public MainWindowViewModel()
        {
            //список фигур для отображения на холсте и в списке фигур
            canvasFigureList = new ObservableCollection<Shape>();

            //первая отображаемая страниуа фигуры
            MyFigure = new StraightLineViewModel();
            //инициализируем фигуры
            brokenLineViewModel = new BrokenLineViewModel();
            compoundFigureViewModel = new CompoundFigureViewModel();
            ellipseViewModel = new EllipseViewModel();
            polygonViewModel = new PolygonViewModel();
            rectangleViewModel = new RectangleViewModel();
            straightLineViewModel = new StraightLineViewModel();
            //инициализируем массив
            myFiguresList = new ObservableCollection<MyFigure>();
            myFiguresList.Add(brokenLineViewModel);
            myFiguresList.Add(compoundFigureViewModel);
            myFiguresList.Add(ellipseViewModel);
            myFiguresList.Add(polygonViewModel);
            myFiguresList.Add(rectangleViewModel);
            myFiguresList.Add(straightLineViewModel);
            Export = ReactiveCommand.Create<string>((str) =>
            { 
                if (str == "png")
                {

                } else if (str == "xml")
                {

                }
                else if (str == "json")
                {

                }
                    
            });
            Import = ReactiveCommand.Create<string>(async (str) =>
            {
                if (str == "xml")
                {

                }
                else if (str == "json")
                {
                    
                }
            });
            MyClear = ReactiveCommand.Create(() => 
            {
                if (myFigure != null) myFigure.SetDefault();
            });
            AddMyFigure = ReactiveCommand.Create(() =>
            {
                //удаляем элемент с такимже именем
                string nameAddItem = myFigure.Name;
                foreach (Shape i in canvasFigureList)
                {
                    if (i.Name == nameAddItem)
                    {
                        CanvasFigureList.Remove(i);
                        break;
                    }
                }
                if (myFigure is BrokenLineViewModel) AddBrokenLine();
                else if (myFigure is CompoundFigureViewModel) AddCompoundFigure();
                else if (myFigure is EllipseViewModel) AddEllipse();
                else if (myFigure is PolygonViewModel) AddPolygon();
                else if (myFigure is RectangleViewModel) AddRectangle();
                else if (myFigure is StraightLineViewModel) AddStraightLine();
            });
            DelItem = ReactiveCommand.Create<Shape>((returnedMyFigure) => 
            {
                    CanvasFigureList.Remove(returnedMyFigure);                 
            });
        }

        public MyFigure? MyFigure
        {
            get => myFigure;
            set => this.RaiseAndSetIfChanged(ref myFigure, value);

        }
        private Shape ListBoxShapesSelectItem
        {
            get => listBoxShapesSelectItem;
            set => this.RaiseAndSetIfChanged(ref listBoxShapesSelectItem, value);
        }
        public ObservableCollection<MyFigure>  MyFiguresList
        {
            get => myFiguresList;
            set => this.RaiseAndSetIfChanged(ref myFiguresList, value);
        }
        public ObservableCollection<Shape> CanvasFigureList
        {
            get => canvasFigureList;
            set => this.RaiseAndSetIfChanged(ref canvasFigureList, value);
        }

        public ReactiveCommand<Unit, Unit> AddMyFigure { get; set; }
        public ReactiveCommand<Unit, Unit>? MyClear { get; set; }
        public ReactiveCommand<Shape, Unit>? DelItem { get; set; }
        public ReactiveCommand<string, Unit>? Export { get; set; }
        public ReactiveCommand<string, Unit>? Import { get; set; }
        public void Load(string path, string extension)
        {
            if (extension == "json")
            {
                CanvasFigureList.Clear();
                using (StreamReader file = new StreamReader(path))
                {
                    CanvasListSerialize lol = Newtonsoft.Json.JsonConvert.DeserializeObject<CanvasListSerialize>(file.ReadToEnd());
                    CanvasFigureList = lol.DeSerializeCanvas();
                }
            }
            else if (extension == "xml")
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CanvasListSerializeXml));
                CanvasListSerializeXml test4 = new CanvasListSerializeXml();
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    test4 = xmlSerializer.Deserialize(fs) as CanvasListSerializeXml;
                }

                CanvasFigureList = test4.DeSerializeCanvas();                    
            }
        }
        public void Save(string path, string extension) 
        {
            if (extension == "json")
            {
                CanvasListSerialize test3 = new CanvasListSerialize();
                test3.SerializeCanvas(canvasFigureList);
                string? jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(test3);
                if (jsonData != null)
                {
                    using (StreamWriter file = new StreamWriter(path, false))
                    {
                        file.Write(jsonData);
                    }
                }
            }
            else if (extension == "xml")
            {
                //CanvasListSerializeXml test4 = new CanvasListSerializeXml();
                //test4.SerializeCanvas(canvasFigureList);
                //var serializer = new ConfigurationContainer().UseOptimizedNamespaces().Create();
                /*XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
                XmlAttributes attrs = new XmlAttributes { XmlIgnore = true };
                attrOverrides.Add(typeof(Avalonia.Animation.Animatable), "Clock", attrs);
                attrOverrides.Add(typeof(Avalonia.Animation.Animatable), "Transitions", attrs);
                attrOverrides.Add(typeof(Avalonia.StyledElement), "Styles", attrs);
                attrOverrides.Add(typeof(Avalonia.StyledElement), "Resources", attrs);
                attrOverrides.Add(typeof(Avalonia.StyledElement), "TemplatedParent", attrs);
                attrOverrides.Add(typeof(Avalonia.StyledElement), "Parent", attrs);
                attrOverrides.Add(typeof(Avalonia.Visual), "OpacityMask", attrs);*/

                //XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
                //XmlAttributes attrs = new XmlAttributes { XmlIgnore = true };
                //List<Tuple<Type, string>> ignoreTypeList = null;
                //ignoreTypeList?.ForEach(t => attrOverrides.Add(t.Item1, t.Item2, attrs));    // ignore fields in ignoreTypeList


                //foreach (var t in typeof(Avalonia.Animation.Animatable).GetProperties())
                //{
                //    if (attrOverrides[typeof(Avalonia.Animation.Animatable), t.Name] is null)
                //            attrOverrides.Add(typeof(Avalonia.Animation.Animatable), t.Name, attrs); 
                //}
                //foreach (var t in typeof(Avalonia.StyledElement).GetProperties())
                //{
                //    if (attrOverrides[typeof(Avalonia.StyledElement), t.Name] is null)
                //        attrOverrides.Add(typeof(Avalonia.StyledElement), t.Name, attrs);
                //}
                //foreach (var t in typeof(Avalonia.Visual).GetProperties())
                //{
                //    if (attrOverrides[typeof(Avalonia.Visual), t.Name] is null)
                //        attrOverrides.Add(typeof(Avalonia.Visual), t.Name, attrs);
                //}


                //foreach (var t in typeof(Shape).GetProperties())
                //{
                //    if (attrOverrides[typeof(Avalonia.Animation.Animatable), t.Name] is null)
                //        attrOverrides.Add(typeof(Avalonia.Animation.Animatable), t.Name, attrs);    // ignore interface type fields
                //}
                ////attrOverrides.Add(typeof(Avalonia.Animation.Animatable), "Transitions", attrs);
                //foreach (var t in typeof(Avalonia.StyledElement).GetProperties())
                //{
                //    if (t.PropertyType.IsInterface)
                //        if (attrOverrides[t.DeclaringType, t.Name] is null)
                //            attrOverrides.Add(t.DeclaringType, t.Name, attrs);    // ignore interface type fields
                //}
                //foreach (var t in typeof(Avalonia.Visual).GetProperties())
                //{
                //    if (t.PropertyType.IsInterface)
                //        if (attrOverrides[t.DeclaringType, t.Name] is null)
                //            attrOverrides.Add(t.DeclaringType, t.Name, attrs);    // ignore interface type fields
                //}
                //attrOverrides.Add(typeof(Avalonia.StyledElement), "Parent", attrs);
                //attrOverrides.Add(typeof(Avalonia.StyledElement), "Parent", attrs);
                // "type" = type of the class that contains the member
                //XmlSerializer serializer = new XmlSerializer(obj.GetType(), attrOverrides);
                CanvasListSerializeXml test4 = new CanvasListSerializeXml();
                test4.SerializeCanvas(canvasFigureList);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(CanvasListSerializeXml), new Type[] {typeof(Color), typeof(Avalonia.Point) });
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, test4);
                }
                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Shape>));
                //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                //{
                //    xmlSerializer.Serialize(fs, canvasFigureList);
                //}
            }
            else if (extension == "png")
            {
            }
        }
        private void AddBrokenLine()
        {
            List<Avalonia.Point> listOfPoints = new List<Avalonia.Point>();
            string[] words = brokenLineViewModel.MyPoints.Split(' ');
            foreach (string word in words)
            {
                //0,0 65,0 78,26, 91,39
                listOfPoints.Add(Avalonia.Point.Parse(word));
            }
            PolylineWrappers BLine = new PolylineWrappers();
            BLine.StrokeThickness = brokenLineViewModel.LineSize;
            BLine.Stroke = brokenLineViewModel.SelectedColorLine.MyBrush;
            BLine.Points = listOfPoints;
            BLine.Name = brokenLineViewModel.Name;
            CanvasFigureList.Add(BLine);           
        }
        private void AddCompoundFigure()
        {
            //M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,50 Z
            PathWrappers path = new PathWrappers();
            path.DataText = compoundFigureViewModel.MyPoints;
            path.Data = Geometry.Parse(compoundFigureViewModel.MyPoints);
            path.Stroke = compoundFigureViewModel.SelectedColorLine.MyBrush;
            path.StrokeThickness = compoundFigureViewModel.LineSize;
            path.Fill = compoundFigureViewModel.SelectedColorFill.MyBrush;
            path.Name = compoundFigureViewModel.Name;
            CanvasFigureList.Add(path);           
        }
        private void AddEllipse()
        {
            EllipseWrappers elip = new EllipseWrappers();
            elip.Width = double.Parse(ellipseViewModel.MyWidth);
            elip.Height = double.Parse(ellipseViewModel.MyHeight);
            elip.Stroke = ellipseViewModel.SelectedColorLine.MyBrush;
            elip.StrokeThickness = ellipseViewModel.LineSize;
            elip.Margin = Avalonia.Thickness.Parse(ellipseViewModel.X1Y1);
            elip.MarginText = ellipseViewModel.X1Y1;
            elip.Fill = ellipseViewModel.SelectedColorFill.MyBrush;
            elip.Name = ellipseViewModel.Name;
            CanvasFigureList.Add(elip);
            
        }
        private void AddPolygon()
        {
            List<Avalonia.Point> listOfPoints = new List<Avalonia.Point>();
            string[] words = polygonViewModel.MyPoints.Split(' ');
            foreach (string word in words)
            {
                listOfPoints.Add(Avalonia.Point.Parse(word));
            }
            PolygonWrappers poly = new PolygonWrappers();
            poly.StrokeThickness = polygonViewModel.LineSize;
            poly.Stroke = polygonViewModel.SelectedColorLine.MyBrush;
            poly.Points = listOfPoints;
            poly.Fill = polygonViewModel.SelectedColorFill.MyBrush;
            poly.Name = polygonViewModel.Name;
            CanvasFigureList.Add(poly);          
        }
        private void AddRectangle()
        {
            RectangleWrappers rect = new RectangleWrappers();
            rect.Width = double.Parse(rectangleViewModel.MyWidth);
            rect.Height = double.Parse(rectangleViewModel.MyHeight);
            rect.Stroke = rectangleViewModel.SelectedColorLine.MyBrush;
            rect.StrokeThickness = rectangleViewModel.LineSize;
            rect.Margin = Avalonia.Thickness.Parse(rectangleViewModel.X1Y1);
            rect.MarginText = rectangleViewModel.X1Y1;
            rect.Fill = rectangleViewModel.SelectedColorFill.MyBrush;
            rect.Name = rectangleViewModel.Name;
            CanvasFigureList.Add(rect);   
        }
        private void AddStraightLine()
        {
            LineWrappers line = new LineWrappers();
            line.StrokeThickness = (double)straightLineViewModel.LineSize;
            if (straightLineViewModel.SelectedColorLine != null) line.Stroke = straightLineViewModel.SelectedColorLine.MyBrush;
            line.StartPoint = Avalonia.Point.Parse(straightLineViewModel.X1Y1);
            line.EndPoint = Avalonia.Point.Parse(straightLineViewModel.X2Y2);
            line.Name = straightLineViewModel.Name;
            CanvasFigureList.Add(line);
        }
    }
}
