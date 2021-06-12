
namespace bitlancer
{
    partial class FrmKullaniciKayit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tc_textbox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.logup_button = new System.Windows.Forms.Button();
            this.mskTel = new System.Windows.Forms.MaskedTextBox();
            this.address_richtextbox = new System.Windows.Forms.RichTextBox();
            this.email_textbox = new System.Windows.Forms.TextBox();
            this.userpassword_textbox = new System.Windows.Forms.TextBox();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.fullname_textbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::bitlancer.Properties.Resources.sss1;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 457);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tc_textbox);
            this.panel2.Controls.Add(this.label);
            this.panel2.Controls.Add(this.logup_button);
            this.panel2.Controls.Add(this.mskTel);
            this.panel2.Controls.Add(this.address_richtextbox);
            this.panel2.Controls.Add(this.email_textbox);
            this.panel2.Controls.Add(this.userpassword_textbox);
            this.panel2.Controls.Add(this.username_textbox);
            this.panel2.Controls.Add(this.fullname_textbox);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(195, 25);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 422);
            this.panel2.TabIndex = 0;
            // 
            // tc_textbox
            // 
            this.tc_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.tc_textbox.Location = new System.Drawing.Point(110, 152);
            this.tc_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.tc_textbox.Name = "tc_textbox";
            this.tc_textbox.Size = new System.Drawing.Size(155, 27);
            this.tc_textbox.TabIndex = 17;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label.Location = new System.Drawing.Point(45, 154);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(68, 22);
            this.label.TabIndex = 16;
            this.label.Text = "TC No:";
            // 
            // logup_button
            // 
            this.logup_button.BackColor = System.Drawing.Color.MediumPurple;
            this.logup_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.logup_button.ForeColor = System.Drawing.Color.Black;
            this.logup_button.Location = new System.Drawing.Point(110, 360);
            this.logup_button.Margin = new System.Windows.Forms.Padding(2);
            this.logup_button.Name = "logup_button";
            this.logup_button.Size = new System.Drawing.Size(154, 40);
            this.logup_button.TabIndex = 15;
            this.logup_button.Text = "KAYDOL";
            this.logup_button.UseVisualStyleBackColor = false;
            this.logup_button.Click += new System.EventHandler(this.logup_button_Click);
            // 
            // mskTel
            // 
            this.mskTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.mskTel.Location = new System.Drawing.Point(110, 183);
            this.mskTel.Margin = new System.Windows.Forms.Padding(2);
            this.mskTel.Mask = "(999) 000-0000";
            this.mskTel.Name = "mskTel";
            this.mskTel.Size = new System.Drawing.Size(155, 27);
            this.mskTel.TabIndex = 14;
            // 
            // address_richtextbox
            // 
            this.address_richtextbox.Location = new System.Drawing.Point(110, 244);
            this.address_richtextbox.Margin = new System.Windows.Forms.Padding(2);
            this.address_richtextbox.Name = "address_richtextbox";
            this.address_richtextbox.Size = new System.Drawing.Size(155, 89);
            this.address_richtextbox.TabIndex = 13;
            this.address_richtextbox.Text = "";
            // 
            // email_textbox
            // 
            this.email_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.email_textbox.Location = new System.Drawing.Point(110, 213);
            this.email_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.email_textbox.Name = "email_textbox";
            this.email_textbox.Size = new System.Drawing.Size(155, 27);
            this.email_textbox.TabIndex = 12;
            // 
            // userpassword_textbox
            // 
            this.userpassword_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.userpassword_textbox.Location = new System.Drawing.Point(110, 122);
            this.userpassword_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.userpassword_textbox.Name = "userpassword_textbox";
            this.userpassword_textbox.PasswordChar = '*';
            this.userpassword_textbox.Size = new System.Drawing.Size(155, 27);
            this.userpassword_textbox.TabIndex = 11;
            // 
            // username_textbox
            // 
            this.username_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.username_textbox.Location = new System.Drawing.Point(110, 92);
            this.username_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(155, 27);
            this.username_textbox.TabIndex = 10;
            // 
            // fullname_textbox
            // 
            this.fullname_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.fullname_textbox.Location = new System.Drawing.Point(110, 62);
            this.fullname_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.fullname_textbox.Name = "fullname_textbox";
            this.fullname_textbox.Size = new System.Drawing.Size(155, 27);
            this.fullname_textbox.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label8.Location = new System.Drawing.Point(51, 245);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Adres:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label7.Location = new System.Drawing.Point(52, 215);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label6.Location = new System.Drawing.Point(40, 185);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Telefon:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(60, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Şifre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(4, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kullanıcı Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(22, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ad Soyad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(105, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kaydol";
            // 
            // FrmKullaniciKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 457);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmKullaniciKayit";
            this.Text = "Kullanıcı kaydı";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button logup_button;
        private System.Windows.Forms.MaskedTextBox mskTel;
        private System.Windows.Forms.RichTextBox address_richtextbox;
        private System.Windows.Forms.TextBox email_textbox;
        private System.Windows.Forms.TextBox userpassword_textbox;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.TextBox fullname_textbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tc_textbox;
        private System.Windows.Forms.Label label;
    }
}