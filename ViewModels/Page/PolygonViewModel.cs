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
    public class PolygonViewModel : ViewModelBase
    {
        private string? header = "Многоугольник";
        private string? name;
        private string? myPoints;
        private int lineSize = 1;
        private MyColor? selectedColorLine;
        private MyColor? selectedColorFill;
        private ObservableCollection<MyColor?>? colorList;
        public PolygonViewModel()
        {
            SelectedColorLine = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) };
            SelectedColorFill = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) };
            ColorList = new ObservableCollection<MyColor?>();

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
        public string? Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public string? MyPoints
        {
            get => myPoints;
            set => this.RaiseAndSetIfChanged(ref myPoints, value);
        }
        public int LineSize
        {
            get => lineSize;
            set => this.RaiseAndSetIfChanged(ref lineSize, value);
        }
        public MyColor? SelectedColorLine
        {
            get => selectedColorLine;
            set => this.RaiseAndSetIfChanged(ref selectedColorLine, value);
        }
        public ObservableCollection<MyColor?>? ColorList
        {
            get => colorList;
            set => this.RaiseAndSetIfChanged(ref colorList, value);
        }
        public MyColor? SelectedColorFill
        {
            get => selectedColorFill;
            set => this.RaiseAndSetIfChanged(ref selectedColorFill, value);
        }
        public string? Header
        {
            get => header;
        }
    }
}
