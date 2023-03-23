using MyPaint3000.ViewModels.Page;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPaint3000.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase myFigure;
        public MainWindowViewModel()
        {
            MyFigure = new StraightLineViewModel();
        }
        private ViewModelBase MyFigure
        {
            get => myFigure;
            set => this.RaiseAndSetIfChanged(ref myFigure, value); 
        }
    }
}
