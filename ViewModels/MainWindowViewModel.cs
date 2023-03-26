using Avalonia.Controls.Shapes;
using Avalonia.Media;
using MyPaint3000.Models;
using MyPaint3000.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            
            //CollectionsOfNames.Add(new Figures(name));
            //Numbers.Add(0);
            //Clean();
            //CanvasFigureList.Add(new NameShape())
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

            //инициализируем команды
            //AddStraightLine = ReactiveCommand.Create(() =>
            //{
            //    straightLineViewModel.AddItem.Subscribe(
            //        (AddFig) =>
            //        {
            //            if (AddFig != null)
            //            {
            //                Line line = new Line();
            //                line.StrokeThickness = (double)AddFig.LineSize;
            //                if (AddFig.SelectedColor != null) line.Stroke = AddFig.SelectedColor.MyBrush;
            //                line.StartPoint = Avalonia.Point.Parse(AddFig.X1Y1);
            //                line.EndPoint = Avalonia.Point.Parse(AddFig.X2Y2);
            //                CanvasFigureList.Add(line);
            //                ListBoxShapesList.Add(new MyShapesItem("Aboba", listBoxShapesList.Count));
            //            }                      
            //        }
            //        );
            //});
            MyClear = ReactiveCommand.Create(() => 
            {
                MyFigure = straightLineViewModel;
            });
            AddMyFigure = ReactiveCommand.Create(() =>
            {
                if (myFigure is StraightLineViewModel)
                {
                    AddStraightLine();
                }
            });
        }
        public ViewModelBase? MyFigure
        {
            get => myFigure;
            set
            {
                //if (value is StraightLineViewModel)
                //{
                //    AddMyFigure = AddStraightLine;
                //}
                this.RaiseAndSetIfChanged(ref myFigure, value);
            }
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
        //public ReactiveCommand<Unit, Unit>? AddBrokenLine { get; set; }
        //public ReactiveCommand<Unit, Unit>? AddCompoundFigure { get; set; }
        //Ellipse
        //public ReactiveCommand<Unit, Unit>? AddPolygon { get; set; }
        //public ReactiveCommand<Unit, Unit>? AddRectangle { get; set; }
        //public ReactiveCommand<Unit, Unit> AddStraightLine { get; set; }
        public ReactiveCommand<Unit, Unit> AddMyFigure { get; set; }
        public ReactiveCommand<Unit, Unit>? MyClear { get; set; }
        private void AddBrokenLine()
        {

        }
        private void AddCompoundFigure()
        {

        }
        private void Ellipse()
        {

        }
        private void AddPolygon()
        {

        }
        private void AddRectangle()
        {

        }
        private void AddStraightLine()
        {
            Line line = new Line();
            line.StrokeThickness = (double)straightLineViewModel.LineSize;
            if (straightLineViewModel.SelectedColor != null) line.Stroke = straightLineViewModel.SelectedColor.MyBrush;
            line.StartPoint = Avalonia.Point.Parse(straightLineViewModel.X1Y1);
            line.EndPoint = Avalonia.Point.Parse(straightLineViewModel.X2Y2);
            CanvasFigureList.Add(line);
            ListBoxShapesList.Add(new MyShapesItem("Aboba", listBoxShapesList.Count));
        }
    }
}
