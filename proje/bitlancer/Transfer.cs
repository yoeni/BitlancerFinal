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
    public partial class Transfer : Form
    {
        int userID = 0;
        public Transfer(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }
        private void Transfer_Load(object sender, EventArgs e)
        {
            comboPara.DataSource = SingletonDB.GetInstance.getItemBitlancer();
            comboPara.DisplayMember="itemName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (quantity.Value!=0)
            {
                if (SingletonDB.GetInstance.setItemTransfer(userID, ((item)comboPara.SelectedItem).id, Convert.ToInt32(quantity.Value)))
                {
                    MessageBox.Show(quantity.Value.ToString() + " Adet " + comboPara.Text + " Yükleme Başarılı");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Giriş Yapın");
            }
        }
    }
}
