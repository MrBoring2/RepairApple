using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleRepair.Models
{
    public class SortParam
    {
        public SortParam(string title, string property)
        {
            Title = title;
            Property = property;
        }

        public string Title { get; set; }
        public string Property { get; set; }    

    }
}
