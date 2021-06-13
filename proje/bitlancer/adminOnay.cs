using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace bitlancer
{
    public partial class adminOnay : Form
    {
        public adminOnay()
        {
            InitializeComponent();
        }

        private void adminOnay_Load(object sender, EventArgs e)
        {
            veriReset();

        }

        public void veriReset()
        {
            adminOnayDataGrid.DataSource = SingletonDB.GetInstance.GetTable("SELECT i.id as 'İşlem No:',i.user_id as 'Kişi No:',(select user_full_name from users where id = i.user_id) as 'Kişi:',i.item_id as 'P.B. No:',(select item_name from items where id = i.item_id) as 'Para Birimi:',quantity as 'Miktar:',date as 'Tarih:',state as 'Durum:',description as 'Açıklama:'from item_adds i where state = 0");
            adminOnayDataGrid2.DataSource = SingletonDB.GetInstance.GetTable("SELECT i.id as 'İşlem No:',i.user_id as 'Kişi No:',(select user_full_name from users where id = i.user_id) as 'Kişi:',i.item_id as 'P.B. No:',(select item_name from items where id = i.item_id) as 'Para Birimi:',quantity as 'Miktar:',unit_price as 'Birim Fiyat:',date as 'Tarih:',state as 'Durum:',description as 'Açıklama:'from item_adds i where state = 1");
            orderGrid.DataSource = SingletonDB.GetInstance.getLastOrders();
        }

        private void btnAdminOnay_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(adminOnayDataGrid.CurrentRow.Cells[0].Value);
            int user_id = Convert.ToInt32(adminOnayDataGrid.CurrentRow.Cells[1].Value);
            int item_id = Convert.ToInt32(adminOnayDataGrid.CurrentRow.Cells[3].Value);
            int quantity = Convert.ToInt32(adminOnayDataGrid.CurrentRow.Cells[5].Value);
            double unit_price = 1;
            int state = cbAdminOnay.Checked ? 1 : 0;
            string description = txtAdminOnay.Text;
            if (item_id!=4)
            {
                switch (item_id)
                {
                    case 7:unit_price = getCurrency("US DOLLAR");break;
                    case 8: unit_price = getCurrency("EURO"); break;
                    case 9: unit_price = getCurrency("POUND STERLING"); break;
                    case 10: unit_price = getCurrency("SWISS FRANK"); break;
                    default:
                        break;
                }
            }
            int yatiralacakTutar = (int)(quantity * unit_price);

            int itemQuantity = SingletonDB.GetInstance.getId("select quantity from item_user_infos where  selling=0 and (item_id=4 and user_id=" + user_id + ")");
            SingletonDB.GetInstance.uptadeAdminOnayDataGrid(_id, state,description,unit_price);
            SingletonDB.GetInstance.updateAfterOrder(0, user_id, 4,(int)(itemQuantity + (yatiralacakTutar*0.99)));
            int itemQuantityAdmin = SingletonDB.GetInstance.getId("select quantity from item_user_infos where  selling=0 and (item_id=4 and user_id=3)");
            SingletonDB.GetInstance.updateAfterOrder(0, 3, 4, (int)(itemQuantityAdmin + (yatiralacakTutar * 0.01)));
            veriReset();
        }
        public double getCurrency(string name)
        {
            XmlDocument xDoc = new XmlDocument();
            string url = "http://www.tcmb.gov.tr/kurlar/today.xml";
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string xmlData = wc.DownloadString(url);
            xDoc.LoadXml(xmlData);
            XmlNodeList kur = xDoc.DocumentElement.ChildNodes;
            string s = xDoc.DocumentElement.SelectSingleNode(string.Format("Currency[CurrencyName='{0}']", name)).SelectSingleNode("BanknoteSelling").InnerText;
            return Convert.ToDouble(s.Replace(".",","));
        }
    }
}
