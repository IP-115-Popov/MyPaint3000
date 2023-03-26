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
        private ViewModelBase myFigure;
        private ObservableCollection<ViewModelBase> myFiguresList;
        private ObservableCollection<Shape> canvasFigureList;
        public MainWindowViewModel()
        {
            //список фигур для отображения на холсте и в списке фигур
            canvasFigureList = new ObservableCollection<Shape>();

            Line line = new Line();
            line.Name = "Aboba";
            line.StrokeThickness = 2;
            line.Stroke = new SolidColorBrush(Colors.Red);
            line.StartPoint = Avalonia.Point.Parse("0,0");
            line.EndPoint = Avalonia.Point.Parse("100,100");
            CanvasFigureList.Add(line);
            //CollectionsOfNames.Add(new Figures(name));
            //Numbers.Add(0);
            //Clean();
            //CanvasFigureList.Add(new NameShape())
            //первая отображаемая страниуа фигуры
            MyFigure = new StraightLineViewModel();
            //инициализируем фигуры
            StraightLineViewModel straightLineViewModelnew = new StraightLineViewModel();
            //инициализируем массив
            myFiguresList = new ObservableCollection<ViewModelBase>();
            myFiguresList.Add(new BrokenLineViewModel());
            myFiguresList.Add(new CompoundFigureViewModel());
            myFiguresList.Add(new EllipseViewModel());
            myFiguresList.Add(new PolygonViewModel());
            myFiguresList.Add(new RectangleViewModel());
            myFiguresList.Add(straightLineViewModelnew);
            //инициализируем команды
            AddStraightLine = ReactiveCommand.Create(() =>
            {
                straightLineViewModelnew.AddItem.Subscribe(
                    (AddFig) =>
                    {
                        //AddFig.LineName;

                    }
                    );
            });
        }
        public ViewModelBase MyFigure
        {
            get => myFigure;
            set => this.RaiseAndSetIfChanged(ref myFigure, value); 
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
        public ReactiveCommand<Unit, Unit> AddBrokenLine;
        public ReactiveCommand<Unit, Unit> AddCompoundFigure;
        public ReactiveCommand<Unit, Unit> AddEllipse;
        public ReactiveCommand<Unit, Unit> AddPolygon;
        public ReactiveCommand<Unit, Unit> AddRectangle;
        public ReactiveCommand<Unit, Unit> AddStraightLine;
        public ReactiveCommand<Unit, Unit> Clear;
    }
}
