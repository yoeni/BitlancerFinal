using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitlancer
{
    public class item
    {
        public int id { get;  set; }
        public string itemName { get; set; }
        public double unitPrice { get; set; }
        public int quantity { get; set; }
        public bool selling { get; set; }
        public item()
        {

        }
        public item(int id,string name)
        {
            this.id = id;
            this.itemName = name;
            this.unitPrice = 0;
            this.quantity = 0;
        }
        public item(int id, string name,double unitPrice,int quantity,bool selling=false)
        {
            this.id = id;
            this.itemName = name;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
            this.selling = selling;
        }
    }
}
