using MyPaint3000.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyPaint3000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase myFigure;
        private ObservableCollection<ViewModelBase> myFiguresList;
        public MainWindowViewModel()
        {
            //первая отображаемая страниуа фигуры
            MyFigure = new StraightLineViewModel();
            //инициализируем массив
            myFiguresList = new ObservableCollection<ViewModelBase>();
            myFiguresList.Add(new BrokenLineViewModel());
            myFiguresList.Add(new CompoundFigureViewModel());
            myFiguresList.Add(new EllipseViewModel());
            myFiguresList.Add(new PolygonViewModel());
            myFiguresList.Add(new RectangleViewModel());
            myFiguresList.Add(new StraightLineViewModel());
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
    }
}
