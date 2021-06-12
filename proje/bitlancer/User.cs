using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitlancer
{
    public class User
    {
        public int id { get; private set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string address { get; set; }
        public string userMail { get; set; }
        public string userTc { get; set; }
        public string userTel { get; set; }
        public bitlancer.userTypes userType { get; set; }
        public List<item> items { get; set; }
        public double money { get; private set; }
        public User()
        {
            this.id = 0;
        }
        public User(int id, string fullName, string userName,string userPassword, string address, string userMail, string userTc,string userTel, bitlancer.userTypes userType,List<item> items)
        {
            this.id = id;
            this.fullName = fullName;
            this.userName = userName;
            this.userPassword = userPassword;
            this.address = address;
            this.userMail = userMail;
            this.userType = userType;
            this.userTc = userTc;
            this.userTel = userTel;
            this.items = items;
            this.money = 0;
            foreach (item item in items)
            {
                this.money += (double)item.quantity * item.unitPrice;
            }
        }
        public void addItems(item MyItem)
        {
            items.Add(MyItem);
        }

        
    }
}
