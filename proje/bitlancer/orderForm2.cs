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
    public partial class orderForm2 : Form
    {
        DataTable lastOrdersData;
        int userID;
        public orderForm2(int userID)
        {
            this.userID = userID;
            InitializeComponent();
        }

        private void orderForm2_Load(object sender, EventArgs e)
        {
            comboPara.DataSource = SingletonDB.GetInstance.getItemBitlancer(0);
            comboPara.DisplayMember = "itemName";
            reset();
        }
        public void reset()
        {
            lastOrdersData = SingletonDB.GetInstance.getLastOrders(userID, ((item)comboPara.SelectedItem).id);
            transferlerDatgrid.DataSource = lastOrdersData;
        }

        private void comboPara_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
