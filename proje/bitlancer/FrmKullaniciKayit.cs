using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace bitlancer
{
    public partial class FrmKullaniciKayit : Form
    {
        public FrmKullaniciKayit()
        {
            InitializeComponent();
        }
        private void logup_button_Click(object sender, EventArgs e)
        {
            bool sonuc = SingletonDB.GetInstance.userRegister(fullname_textbox.Text, username_textbox.Text, userpassword_textbox.Text, address_richtextbox.Text, email_textbox.Text, tc_textbox.Text, mskTel.Text);
            if (sonuc)
            {
                MessageBox.Show("Başarıyla Kaydedildi");
            }
            else
            {
                MessageBox.Show("Hatalı işlem");
            }
        }
    }
}
