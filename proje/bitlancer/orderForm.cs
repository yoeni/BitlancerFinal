using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bitlancer
{
    public partial class orderForm : Form
    {
        DataTable lastOrdersData;
        item myItem;
        int itemID=0,userID=0;
        bitlancer.orderTypes islem;
        bool own = false;
        int x = 0;
        public orderForm(bitlancer.orderTypes islem,int userID,int itemID,bool own=false)
        {
            this.islem = islem;
            this.itemID = itemID;
            this.userID = userID;
            this.own = own;
            InitializeComponent();
        }

        private void orderForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            
            if (islem==bitlancer.orderTypes.buy)
            {
                int check = SingletonDB.GetInstance.getId("select user_id from item_user_infos where selling=1 and (user_id!="+userID+" and item_id=" + itemID+")");
                if (check == 0)
                {
                    MessageBox.Show("Sadece Siz Sattığınız için veya Satış Olmadığı için Alım Yapamazsınız!");
                    this.Close();
                }
            }
            else
            {
                myItem = SingletonDB.GetInstance.getItemOrder(itemID, userID); myItem.quantity = SingletonDB.GetInstance.getId("select quantity from item_user_infos where selling=0 and (item_id=" + itemID + " and user_id=" + userID + ")");
                if (myItem.quantity == 0)
                {
                    MessageBox.Show("Bakiyeniz Olmadığı için Satım Yapamazsınız!");
                    this.Close();
                }
            }
            timer1.Start();
            setIslem();
        }
        public void setIslem()
        {
            switch (islem)
            {
                case bitlancer.orderTypes.buy:
                    secondLabel.Text = "Toplam Tutar:";
                    buyButton.BackColor = Color.Green;
                    buyButton.ForeColor = Color.White;
                    valTextBox.Enabled = false;
                    buyButton.Text = "ALIM YAP";
                    break;
                case bitlancer.orderTypes.sell:
                    secondLabel.Text = "Birim Fiyat:";
                    buyButton.BackColor = Color.Red;
                    buyButton.ForeColor = Color.Black;
                    valTextBox.Enabled = true;
                    buyButton.Text = "SATIM YAP";
                    break;
                default:
                    break;
            }
        }
        public void setUI()
        {
            label1.Text = myItem.itemName;
            quantity.Text = "Maksimum Miktar: " + myItem.quantity;
            itemPriceLabel.Text = myItem.unitPrice + " ₺ : ";
            transferlerDatgrid.DataSource = lastOrdersData;
            if (quantityTextBox.Text != ""&&islem==bitlancer.orderTypes.buy)
            {
                try
                {
                    valTextBox.Text = (Convert.ToDouble(quantityTextBox.Text) * myItem.unitPrice).ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            if (x >= 250)
            {
                chart.Series["line"].Points.RemoveAt(0);
            }
            else
            {
                x++;
            }
            chart.Series["line"].Points.AddXY(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second, myItem.unitPrice);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (islem == bitlancer.orderTypes.sell)
            {
                myItem = SingletonDB.GetInstance.getItem(itemID);
                myItem.quantity = SingletonDB.GetInstance.getId("select quantity from item_user_infos where selling=0 and (item_id=" + itemID + " and user_id=" + userID + ")");
                myItem.unitPrice = SingletonDB.GetInstance.getDouble("select min(unit_price) from item_user_infos where selling=1 and item_id="+itemID);
            }
            else
            {
                myItem = SingletonDB.GetInstance.getItemOrder(itemID,userID);
            }
            lastOrdersData = SingletonDB.GetInstance.getLastOrders(userID,itemID);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (islem == bitlancer.orderTypes.sell)
            {
                int check = SingletonDB.GetInstance.getId("select user_id from item_user_infos where selling=1 and item_id=" + itemID);
                if (check == 0 || check == userID)
                {
                    MessageBox.Show("Sadece Siz Sattığınız için veya Satış Olmadığı için Alım Yapamazsınız!");
                }
                else
                {
                    islem = bitlancer.orderTypes.buy;
                    setIslem();
                }
            }
            else
            {
                myItem.quantity = SingletonDB.GetInstance.getId("select quantity from item_user_infos where selling=0 and (item_id=" + itemID + " and user_id=" + userID + ")");
                if (myItem.quantity == 0)
                {
                    MessageBox.Show("Bakiyeniz Olmadığı için Satım Yapamazsınız!");
                }
                else
                {
                    islem = bitlancer.orderTypes.sell;
                    setIslem();
                }
            }
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            if (int.Parse(quantityTextBox.Text) <= myItem.quantity)
            {
                orderProcces.RunWorkerAsync();
                quantityTextBox.Enabled = false;
                buyButton.Enabled = false;
                pictureBox1.Enabled = false;
                pictureBox2.Visible = true;
                pictureBox2.Enabled = true;
                label3.Visible = true;
            }
            else
            {
                MessageBox.Show("Maksimum Miktardan Fazla Alamazsınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void orderProcces_DoWork(object sender, DoWorkEventArgs e)
        {
            double unitPriceIn = Convert.ToDouble(valTextBox.Text.Replace(".",","));
            SingletonDB.GetInstance.manageOrder(userID, myItem.id, int.Parse(quantityTextBox.Text), islem,unitPriceIn);
        }

        private void orderProcces_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            quantityTextBox.Enabled = true;
            buyButton.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox2.Visible = false;
            pictureBox2.Enabled = false;
            label3.Visible = false;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setUI();
        }
    }
}
