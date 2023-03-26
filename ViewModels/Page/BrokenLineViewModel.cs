using MyPaint3000.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.ViewModels.Page
{
    public class BrokenLineViewModel : ViewModelBase
    {
        private string? header = "Ломаная линия";
        private string? name;
        private string? myPoints;
        private MyColor? selectedColor;
        private ObservableCollection<MyColor?>? colorList;

        public string? Header
        {
            get => header;
        }
    }
}
