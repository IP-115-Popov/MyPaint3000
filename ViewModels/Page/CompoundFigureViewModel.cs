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
    public class CompoundFigureViewModel : ViewModelBase
    {
        private string? header = "Составная фигура";
        private string? name;

        private int lineSize = 1;
        private MyColor? selectedColor;
        private ObservableCollection<MyColor?>? colorList;
        public CompoundFigureViewModel()
        {
            SelectedColor = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) };
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
        public string? Header
        {
            get => header;
        }
    }
}
