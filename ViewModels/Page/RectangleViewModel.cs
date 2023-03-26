﻿using Avalonia.Media;
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
    public class RectangleViewModel : ViewModelBase
    {
        private string? header = "Прямоугольник";
        private string? name;
        private string? x1Y1;
        private string? myWidth;
        private string? myHeight;
        private int lineSize = 1;
        private MyColor? selectedColor;
        private MyColor? selectedColorFill;
        private ObservableCollection<MyColor?>? colorList;
        public RectangleViewModel()
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
        public int LineSize
        {
            get => lineSize;
            set => this.RaiseAndSetIfChanged(ref lineSize, value);
        }
        public MyColor? SelectedColorLine
        {
            get => selectedColor;
            set => this.RaiseAndSetIfChanged(ref selectedColor, value);
        }
        public MyColor? SelectedColorFill
        {
            get => selectedColorFill;
            set => this.RaiseAndSetIfChanged(ref selectedColorFill, value);
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
