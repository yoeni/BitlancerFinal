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
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (username_textbox.Text!="" && userpassword_textbox.Text!="")
            {
                int currentUser = SingletonDB.GetInstance.loginCheck(username_textbox.Text, userpassword_textbox.Text);
                if (currentUser!=0)
                {
                    main_form main = new main_form(currentUser);
                    this.Hide();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli giriş yapın!");
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli giriş yapın!");
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKullaniciKayit fr = new FrmKullaniciKayit();
            fr.ShowDialog();
        }
    }
}
