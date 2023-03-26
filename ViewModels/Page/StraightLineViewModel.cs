using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using MyPaint3000.Models;
using System.Collections.ObjectModel;
using Avalonia.Media;
using SkiaSharp;
using System.Reflection;

namespace MyPaint3000.ViewModels.Page
{
   public class StraightLineViewModel : ViewModelBase
    {
        private string? header = "Прямая линия";

        private string? name;
        private string? x1Y1;
        private string? x2Y2;
        private int lineSize = 1;
        private MyColor? selectedColor;
        private ObservableCollection<MyColor?>? colorList;
        public StraightLineViewModel()
        {
            SelectedColor = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) };
            ColorList= new ObservableCollection<MyColor?>();

            PropertyInfo[] colorProps = typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static);
            foreach (PropertyInfo colorProp in colorProps)
            {
                if (colorProp.PropertyType == typeof(Color))
                {
                    Color color = (Color)colorProp.GetValue(null, null);
                    string colorName = colorProp.Name;
                    SolidColorBrush brush = new SolidColorBrush(color);
                    ColorList.Add(new MyColor() { MyBrush = brush });
                }
            }
        }
        public string? Header
        {
            get => header;
        }
        public string? Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public string? X1Y1
        {
            get => x1Y1;
            set => this.RaiseAndSetIfChanged(ref x1Y1, value);
        }
        public string? X2Y2
        {
            get => x2Y2;
            set => this.RaiseAndSetIfChanged(ref x2Y2, value);
        }
        public int LineSize
        {
            get => lineSize;
            set => this.RaiseAndSetIfChanged(ref lineSize, value);
        }
        public MyColor? SelectedColor
        {
            get => selectedColor;
            set => this.RaiseAndSetIfChanged(ref selectedColor, value);
        }
        public ObservableCollection<MyColor?>? ColorList
        {
            get => colorList;
            set => this.RaiseAndSetIfChanged(ref colorList, value);
        }

}
}
