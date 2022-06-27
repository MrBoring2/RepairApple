using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleRepair.Data
{
    public class BaseEntity
    {
        public object GetValue(string property)
        {
            return GetType().GetProperty(property).GetValue(this);
        }
    }
}
