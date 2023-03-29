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
    public class CompoundFigureViewModel : MyFigure
    {
        private string? myPoints;
        private MyColor? selectedColorFill;
        public CompoundFigureViewModel() : base()
        {
            header = "Составная фигура";
            SelectedColorFill = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) };
        }
        public string? MyPoints
        {
            get => myPoints;
            set => this.RaiseAndSetIfChanged(ref myPoints, value);
        } 
        public MyColor? SelectedColorFill
        {
            get => selectedColorFill;
            set => this.RaiseAndSetIfChanged(ref selectedColorFill, value);
        }
        public override void SetDefault()
        {
            base.SetDefault();
            MyPoints = null;
            SelectedColorFill = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) };
        }
    }
}
