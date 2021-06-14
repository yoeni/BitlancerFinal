namespace bitlancer
{
    partial class orderForm2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.transferlerDatgrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPara = new System.Windows.Forms.ComboBox();
            this.secondLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.unitPriceTextBox = new System.Windows.Forms.TextBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.buyButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.waitingOrdersDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.transferlerDatgrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingOrdersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "Gerçekleşen Emirler:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // transferlerDatgrid
            // 
            this.transferlerDatgrid.AllowDrop = true;
            this.transferlerDatgrid.AllowUserToAddRows = false;
            this.transferlerDatgrid.AllowUserToDeleteRows = false;
            this.transferlerDatgrid.AllowUserToOrderColumns = true;
            this.transferlerDatgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.transferlerDatgrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.transferlerDatgrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.transferlerDatgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.transferlerDatgrid.GridColor = System.Drawing.Color.Plum;
            this.transferlerDatgrid.Location = new System.Drawing.Point(5, 437);
            this.transferlerDatgrid.MultiSelect = false;
            this.transferlerDatgrid.Name = "transferlerDatgrid";
            this.transferlerDatgrid.ReadOnly = true;
            this.transferlerDatgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transferlerDatgrid.ShowEditingIcon = false;
            this.transferlerDatgrid.Size = new System.Drawing.Size(781, 172);
            this.transferlerDatgrid.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Para Birimi:";
            // 
            // comboPara
            // 
            this.comboPara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPara.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.comboPara.FormattingEnabled = true;
            this.comboPara.Location = new System.Drawing.Point(7, 28);
            this.comboPara.Name = "comboPara";
            this.comboPara.Size = new System.Drawing.Size(781, 37);
            this.comboPara.TabIndex = 14;
            this.comboPara.SelectedIndexChanged += new System.EventHandler(this.comboPara_SelectedIndexChanged);
            // 
            // secondLabel
            // 
            this.secondLabel.AutoSize = true;
            this.secondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.secondLabel.Location = new System.Drawing.Point(376, 68);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(85, 16);
            this.secondLabel.TabIndex = 19;
            this.secondLabel.Text = "Birim Fiyat:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(4, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Miktar:";
            // 
            // unitPriceTextBox
            // 
            this.unitPriceTextBox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.unitPriceTextBox.Location = new System.Drawing.Point(379, 90);
            this.unitPriceTextBox.Name = "unitPriceTextBox";
            this.unitPriceTextBox.Size = new System.Drawing.Size(407, 35);
            this.unitPriceTextBox.TabIndex = 17;
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.quantityTextBox.Location = new System.Drawing.Point(7, 90);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(366, 35);
            this.quantityTextBox.TabIndex = 16;
            this.quantityTextBox.Text = "0";
            // 
            // buyButton
            // 
            this.buyButton.BackColor = System.Drawing.Color.LightSeaGreen;
            this.buyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buyButton.Font = new System.Drawing.Font("Bahnschrift", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buyButton.Location = new System.Drawing.Point(112, 144);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(536, 61);
            this.buyButton.TabIndex = 20;
            this.buyButton.Text = "EMRİ VER";
            this.buyButton.UseVisualStyleBackColor = false;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(5, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 31);
            this.label3.TabIndex = 22;
            this.label3.Text = "Beklemede Olan Emirler:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waitingOrdersDataGrid
            // 
            this.waitingOrdersDataGrid.AllowDrop = true;
            this.waitingOrdersDataGrid.AllowUserToAddRows = false;
            this.waitingOrdersDataGrid.AllowUserToDeleteRows = false;
            this.waitingOrdersDataGrid.AllowUserToOrderColumns = true;
            this.waitingOrdersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.waitingOrdersDataGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.waitingOrdersDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.waitingOrdersDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.waitingOrdersDataGrid.GridColor = System.Drawing.Color.Plum;
            this.waitingOrdersDataGrid.Location = new System.Drawing.Point(5, 241);
            this.waitingOrdersDataGrid.MultiSelect = false;
            this.waitingOrdersDataGrid.Name = "waitingOrdersDataGrid";
            this.waitingOrdersDataGrid.ReadOnly = true;
            this.waitingOrdersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.waitingOrdersDataGrid.ShowEditingIcon = false;
            this.waitingOrdersDataGrid.Size = new System.Drawing.Size(781, 172);
            this.waitingOrdersDataGrid.TabIndex = 21;
            // 
            // orderForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 621);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.waitingOrdersDataGrid);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.secondLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unitPriceTextBox);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboPara);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transferlerDatgrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "orderForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMİR VER";
            this.Load += new System.EventHandler(this.orderForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transferlerDatgrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingOrdersDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView transferlerDatgrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboPara;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox unitPriceTextBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView waitingOrdersDataGrid;
    }
}