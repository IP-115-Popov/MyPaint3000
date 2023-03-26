using Avalonia.Controls.Shapes;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint3000.Models
{
    public abstract class NameShape : Shape
    {
        public string? Name { get; set;}   
    }
}
