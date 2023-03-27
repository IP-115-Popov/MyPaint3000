using Avalonia.Controls.Shapes;
using Avalonia.Media;
using DynamicData;
using MyPaint3000.Models;
using MyPaint3000.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Text;
using System.Xml.Linq;

namespace MyPaint3000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase? myFigure;
        private ObservableCollection<ViewModelBase> myFiguresList;
        private ObservableCollection<Shape> canvasFigureList;
        private ObservableCollection<MyShapesItem> listBoxShapesList;
        private MyShapesItem listBoxShapesSelectItem;

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
            listBoxShapesList = new ObservableCollection<MyShapesItem>();

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
            myFiguresList = new ObservableCollection<ViewModelBase>();
            myFiguresList.Add(brokenLineViewModel);
            myFiguresList.Add(compoundFigureViewModel);
            myFiguresList.Add(ellipseViewModel);
            myFiguresList.Add(polygonViewModel);
            myFiguresList.Add(rectangleViewModel);
            myFiguresList.Add(straightLineViewModel);

            MyClear = ReactiveCommand.Create(() => 
            {
                MyFigure = straightLineViewModel;
            });
            AddMyFigure = ReactiveCommand.Create(() =>
            {
                
                if (myFigure is BrokenLineViewModel) AddBrokenLine();
                else if (myFigure is CompoundFigureViewModel) AddCompoundFigure();
                else if (myFigure is EllipseViewModel) AddEllipse();
                else if (myFigure is PolygonViewModel) AddPolygon();
                else if (myFigure is RectangleViewModel) AddRectangle();
                else if (myFigure is StraightLineViewModel) AddStraightLine();
            });
            DelItem = ReactiveCommand.Create(() => 
            {
                if (ListBoxShapesSelectItem != null)
                {
                    CanvasFigureList.RemoveAt(ListBoxShapesSelectItem.Namber);
                    ListBoxShapesList.RemoveAt(ListBoxShapesSelectItem.Namber);          
                }            
            });
        }

        public ViewModelBase? MyFigure
        {
            get => myFigure;
            set => this.RaiseAndSetIfChanged(ref myFigure, value);

        }
        private MyShapesItem ListBoxShapesSelectItem
        {
            get => listBoxShapesSelectItem;
            set => this.RaiseAndSetIfChanged(ref listBoxShapesSelectItem, value);
        }
        public ObservableCollection<ViewModelBase>  MyFiguresList
        {
            get => myFiguresList;
            set => this.RaiseAndSetIfChanged(ref myFiguresList, value);
        }
        public ObservableCollection<Shape> CanvasFigureList
        {
            get => canvasFigureList;
            set => this.RaiseAndSetIfChanged(ref canvasFigureList, value);
        }
        public ObservableCollection<MyShapesItem> ListBoxShapesList
        {
            get => listBoxShapesList;
            set => this.RaiseAndSetIfChanged(ref listBoxShapesList, value);
        }
        public ReactiveCommand<Unit, Unit> AddMyFigure { get; set; }
        public ReactiveCommand<Unit, Unit>? MyClear { get; set; }
        public ReactiveCommand<Unit, Unit>? DelItem { get; set; }
        private void AddBrokenLine()
        {
            List<Avalonia.Point> listOfPoints = new List<Avalonia.Point>();
            string[] words = brokenLineViewModel.MyPoints.Split(' ');
            foreach (string word in words)
            {
                //0,0 65,0 78,26, 91,39
                listOfPoints.Add(Avalonia.Point.Parse(word));
            }
            Polyline BLine = new Polyline();
            BLine.StrokeThickness = brokenLineViewModel.LineSize;
            BLine.Stroke = brokenLineViewModel.SelectedColorLine.MyBrush;
            BLine.Points = listOfPoints;
            CanvasFigureList.Add(BLine);
            ListBoxShapesList.Add(new MyShapesItem(brokenLineViewModel.Name,listBoxShapesList.Count));
        }
        private void AddCompoundFigure()
        {
            //M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,50 Z
            Avalonia.Controls.Shapes.Path path = new Avalonia.Controls.Shapes.Path();
            path.Data = Geometry.Parse(compoundFigureViewModel.MyPoints);
            path.Stroke = compoundFigureViewModel.SelectedColorLine.MyBrush;
            path.StrokeThickness = compoundFigureViewModel.LineSize;
            path.Fill = compoundFigureViewModel.SelectedColorFill.MyBrush;
            CanvasFigureList.Add(path);
            ListBoxShapesList.Add(new MyShapesItem(compoundFigureViewModel.Name, listBoxShapesList.Count));
        }
        private void AddEllipse()
        {
            Ellipse elip = new Ellipse();
            elip.Width = double.Parse(ellipseViewModel.MyWidth);
            elip.Height = double.Parse(ellipseViewModel.MyHeight);
            elip.Stroke = ellipseViewModel.SelectedColorLine.MyBrush;
            elip.StrokeThickness = ellipseViewModel.LineSize;
            elip.Margin = Avalonia.Thickness.Parse(ellipseViewModel.X1Y1);
            elip.Fill = ellipseViewModel.SelectedColorFill.MyBrush;
            CanvasFigureList.Add(elip);
            ListBoxShapesList.Add(new MyShapesItem(ellipseViewModel.Name, listBoxShapesList.Count));
        }
        private void AddPolygon()
        {
            List<Avalonia.Point> listOfPoints = new List<Avalonia.Point>();
            string[] words = polygonViewModel.MyPoints.Split(' ');
            foreach (string word in words)
            {
                listOfPoints.Add(Avalonia.Point.Parse(word));
            }
            Polygon poly = new Polygon();
            poly.StrokeThickness = polygonViewModel.LineSize;
            poly.Stroke = polygonViewModel.SelectedColorLine.MyBrush;
            poly.Points = listOfPoints;
            poly.Fill = polygonViewModel.SelectedColorFill.MyBrush;
            CanvasFigureList.Add(poly);
            ListBoxShapesList.Add(new MyShapesItem(polygonViewModel.Name, listBoxShapesList.Count));
        }
        private void AddRectangle()
        {
            Rectangle rect = new Rectangle();
            rect.Width = double.Parse(rectangleViewModel.MyWidth);
            rect.Height = double.Parse(rectangleViewModel.MyHeight);
            rect.Stroke = rectangleViewModel.SelectedColorLine.MyBrush;
            rect.StrokeThickness = rectangleViewModel.LineSize;
            rect.Margin = Avalonia.Thickness.Parse(rectangleViewModel.X1Y1);
            rect.Fill = rectangleViewModel.SelectedColorFill.MyBrush;
            CanvasFigureList.Add(rect);
            ListBoxShapesList.Add(new MyShapesItem(rectangleViewModel.Name, listBoxShapesList.Count));
        }
        private void AddStraightLine()
        {
            Line line = new Line();
            line.StrokeThickness = (double)straightLineViewModel.LineSize;
            if (straightLineViewModel.SelectedColorLine != null) line.Stroke = straightLineViewModel.SelectedColorLine.MyBrush;
            line.StartPoint = Avalonia.Point.Parse(straightLineViewModel.X1Y1);
            line.EndPoint = Avalonia.Point.Parse(straightLineViewModel.X2Y2);
            CanvasFigureList.Add(line);
            ListBoxShapesList.Add(new MyShapesItem(straightLineViewModel.Name, listBoxShapesList.Count));
        }
    }
}
