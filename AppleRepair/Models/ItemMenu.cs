using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleRepair.Models
{
    public class ItemMenu
    { 
        public ItemMenu(string title, PackIconKind icon, Uri destination)
        {
            Title = title;
            Icon = icon;
            Destination = destination;
        }
        public string Title { get; set; } 
        public PackIconKind Icon { get; set; }    
        public Uri Destination { get; set; }
    }
}
