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
    public class EllipseViewModel : MyFigure
    {
        private string? x1Y1;
        private string? myWidth;
        private string? myHeight;
        private MyColor? selectedColorFill;
        public EllipseViewModel()
        {
            header = "Элипс";
            SelectedColorFill = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) };
        }

        public string? X1Y1
        {
            get => x1Y1;
            set => this.RaiseAndSetIfChanged(ref x1Y1, value);
        }
        public string? MyWidth
        {
            get => myWidth;
            set => this.RaiseAndSetIfChanged(ref myWidth, value);
        }
        public string? MyHeight
        {
            get => myHeight;
            set => this.RaiseAndSetIfChanged(ref myHeight, value);
        }

        public MyColor? SelectedColorFill
        {
            get => selectedColorFill;
            set => this.RaiseAndSetIfChanged(ref selectedColorFill, value);
        }
    }
}
