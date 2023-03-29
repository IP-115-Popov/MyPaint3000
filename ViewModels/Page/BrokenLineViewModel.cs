using Avalonia.Media;
using MyPaint3000.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.ViewModels.Page
{
    public class BrokenLineViewModel : MyFigure
    {
        private string? myPoints;
        public BrokenLineViewModel() : base()
        {
            header = "Ломаная линия";
        }
        public string? MyPoints
        {
            get => myPoints;
            set => this.RaiseAndSetIfChanged(ref myPoints, value);
        }
        public override void SetDefault() 
        { 
            base.SetDefault();
            MyPoints = null;
        }
    }
}
