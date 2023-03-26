using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using MyPaint3000.Models;
using System.Drawing;
using System.Collections.ObjectModel;
using Avalonia.Media;
using MyPaint3000.Models;

namespace MyPaint3000.ViewModels.Page
{
   public class StraightLineViewModel : ViewModelBase
    {
        private string? header = "Прямая линия";

        private string? lineName;
        private string? x1Y1;
        private string? x2Y2;
        private int? numericText;
        private MyColor? selectedColor;
        private ObservableCollection<MyColor?> colorList;
        public StraightLineViewModel()
        {
            SelectedColor = new MyColor() { MyBrush = new SolidColorBrush(Colors.Red)};
            ColorList= new ObservableCollection<MyColor?>();
            ColorList.Add(new MyColor() { MyBrush = new SolidColorBrush(Colors.Red) });
            ColorList.Add(new MyColor() { MyBrush = new SolidColorBrush(Colors.Purple) });

        }
        public string? Header
        {
            get => header;
        }
        public string? LineName
        {
            get => lineName;
            set => this.RaiseAndSetIfChanged(ref lineName, value);
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
        private int? NumericText
        {
            get => numericText;
            set => this.RaiseAndSetIfChanged(ref numericText, value);
        }
        public MyColor? SelectedColor
        {
            get => selectedColor;
            set => this.RaiseAndSetIfChanged(ref selectedColor, value);
        }
        public ObservableCollection<MyColor?> ColorList
        {
            get => colorList;
            set => this.RaiseAndSetIfChanged(ref colorList, value);
        }
        public ReactiveCommand<Unit, StraightLine> AddItem;

}
}
