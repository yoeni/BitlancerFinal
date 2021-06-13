using ClosedXML.Excel;
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
    public partial class main_form : Form
    {
        DataTable itemData,lastOrdersData,userTransfers;
        User MyUser;
        int userID;
        public main_form(int userID)
        {
            this.userID = userID;
            InitializeComponent();
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            timer1.Start();
        }
        public void setLastOrder()
        {
            lastOrdersDatagrid.DataSource = lastOrdersData;
            foreach (DataGridViewRow row in lastOrdersDatagrid.Rows)
            {
                if (row.Cells[1].Value.ToString() == "ALIM")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        public void setUserToUI()
        {
            try
            {
                mainItemsDataGrid.DataSource = itemData;
                mainItemsDataGrid.Columns[5].Visible = false;
                urunlerDatagrid.DataSource = MyUser.items;
                urunlerDatagrid.Columns[1].Visible = false;
                urunlerDatagrid.Columns[2].HeaderText = "Para Birimi:";
                urunlerDatagrid.Columns[3].Visible=false;
                urunlerDatagrid.Columns[4].HeaderText = "Miktar:";
                urunlerDatagrid.Columns[5].HeaderText = "Satışta:";
                transferlerDatgrid.DataSource = userTransfers;
                transferlerDatgrid.Columns[2].Visible = false;
                setLastOrder();
                kullancıAdLabel.Text = MyUser.fullName;
                switch (MyUser.userType)
                {
                    case bitlancer.userTypes.basic:
                        kullaniciTipiLabel.Text = "Temel Kullanıcı";
                        adminButton.Visible = false;
                        break;
                    case bitlancer.userTypes.admin:
                        kullaniciTipiLabel.Text = "Üst Düzey Kullanıcı";
                        adminButton.Visible = true;
                        break;
                    default:
                        kullaniciTipiLabel.Text = "Temel Kullanıcı";
                        adminButton.Visible = false;
                        break;
                }
                bakiyeLabel.Text = MyUser.money + " ₺";
                List<chartItemValue> chartItemList = new List<chartItemValue>();
                if (MyUser.items!=null)
                {
                    foreach (item item in MyUser.items)
                    {
                        chartItemList.Add(new chartItemValue((item.selling ? "Sş. " : "") + " " + item.itemName , item.quantity));
                    }
                   graphic.DataSource = chartItemList;
                }
                graphic.Series["Para"].XValueMember = "itemName";
                graphic.Series["Para"].YValueMembers = "val";
                graphic.Series["Para"].IsValueShownAsLabel = true;
                graphic.Titles["miktar"].Text = "CÜZDAN "+bakiyeLabel.Text;
                graphic.DataBind();
                chartItemList.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
            itemData = SingletonDB.GetInstance.getItems();
            MyUser = SingletonDB.GetInstance.getUser(userID);
            userTransfers = SingletonDB.GetInstance.getItemTransfers(MyUser.id);
            lastOrdersData = SingletonDB.GetInstance.getLastOrders(userID);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setUserToUI();
        }

        private void mainItemsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                orderForm order;
                if (e.ColumnIndex==0)
                {
                    order = new orderForm(bitlancer.orderTypes.buy,userID,Convert.ToInt32(mainItemsDataGrid[5, e.RowIndex].Value));
                }
                else
                {
                    order = new orderForm(bitlancer.orderTypes.sell,userID, Convert.ToInt32(mainItemsDataGrid[5, e.RowIndex].Value));
                }
                order.ShowDialog();
            }
        }

        private void urunlerDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && Convert.ToInt32(urunlerDatagrid[1, e.RowIndex].Value)!=4)
            {
                orderForm order = new orderForm(bitlancer.orderTypes.sell, userID, Convert.ToInt32(urunlerDatagrid[1, e.RowIndex].Value));
                order.ShowDialog();
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer(userID);
            transfer.ShowDialog();
        }


        private void raporButton_Click(object sender, EventArgs e)
        {
            DataTable raporData = SingletonDB.GetInstance.getLastOrderBetwenDate(userID,date1.Value,date2.Value);
            CreateRapor(raporData);
        }
        public void CreateRapor(DataTable data)
        {
            using (SaveFileDialog sfd=new SaveFileDialog() { Filter="Excel Dosyası|*.xlsx"})
            {
                if (sfd.ShowDialog()==DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook=new XLWorkbook())
                        {
                            workbook.Worksheets.Add(data,"Rapor "+DateTime.Now.ToShortDateString());
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Rapor Başarıyla Oluşturuldu!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Hata Oluştu! :\n"+e.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void userInfoButton_Click(object sender, EventArgs e)
        {
            userForm userInfoForm = new userForm(MyUser);
            userInfoForm.ShowDialog();
        }

        private void adminButton_Click(object sender, EventArgs e)
        {
            adminOnay admin = new adminOnay();
            admin.ShowDialog();
        }
    }
}
