using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitlancer
{
    public class orderUpdateItem
    {

        public int id { get; set; }
        public int sourceId { get; set; }
        public int quantity { get; set; }
        public double unitPrice { get; set; }
    }
}
