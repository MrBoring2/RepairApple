using AppleRepair.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppleRepair.Models
{
    public class SpendedMaterial : INotifyPropertyChanged
    {
        private int amount;
        public SpendedMaterial(Material material, int amount)
        {
            Material = material;
            Amount = amount;
        }

        public Material Material { get; set; }
        public string Name { get => Material.Name; }
        public int Amount { get => amount; set { amount = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        }
    }
}
