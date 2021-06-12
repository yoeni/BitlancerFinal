using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitlancer
{
    public class chartItemValue
    {

        public string itemName { get; set; }
        public double val { get; set; }
        public chartItemValue(string itemName,double val)
        {
            this.itemName = itemName ;
            this.val = val;
        }
    }
}
