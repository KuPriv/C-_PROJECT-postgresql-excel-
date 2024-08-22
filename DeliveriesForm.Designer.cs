
namespace Project
{
    partial class DeliveriesForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addProductButton = new System.Windows.Forms.Button();
            this.cmbSuppliers = new System.Windows.Forms.ComboBox();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.ExportToExcelButton = new System.Windows.Forms.Button();
            this.invoiceNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.cmbAmount = new System.Windows.Forms.TextBox();
            this.PaymentButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.full_price = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkIsPaidButton = new System.Windows.Forms.Button();
            this.payBut = new System.Windows.Forms.Button();
            this.delBut = new System.Windows.Forms.Button();
            this.payPart = new System.Windows.Forms.TextBox();
            this.dtpLast = new System.Windows.Forms.DateTimePicker();
            this.deliveryItemCheckButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(734, 203);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1538, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Список Поставок";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(13, 281);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(120, 31);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Добавить товар";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(151, 281);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(113, 31);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(280, 281);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(109, 31);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(15, 338);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(208, 31);
            this.addProductButton.TabIndex = 6;
            this.addProductButton.Text = "Добавить товар в поставку";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.addProductButton_Click);
            // 
            // cmbSuppliers
            // 
            this.cmbSuppliers.FormattingEnabled = true;
            this.cmbSuppliers.Location = new System.Drawing.Point(213, 24);
            this.cmbSuppliers.Name = "cmbSuppliers";
            this.cmbSuppliers.Size = new System.Drawing.Size(155, 24);
            this.cmbSuppliers.TabIndex = 7;
            this.cmbSuppliers.SelectedIndexChanged += new System.EventHandler(this.cmbSuppliers_SelectedIndexChanged);
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(374, 24);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDeliveryDate.TabIndex = 8;
            this.dtpDeliveryDate.ValueChanged += new System.EventHandler(this.dtpDeliveryDate_ValueChanged);
            // 
            // ExportToExcelButton
            // 
            this.ExportToExcelButton.Location = new System.Drawing.Point(238, 338);
            this.ExportToExcelButton.Name = "ExportToExcelButton";
            this.ExportToExcelButton.Size = new System.Drawing.Size(130, 31);
            this.ExportToExcelButton.TabIndex = 10;
            this.ExportToExcelButton.Text = "Экспорт в Excel";
            this.ExportToExcelButton.UseVisualStyleBackColor = true;
            this.ExportToExcelButton.Click += new System.EventHandler(this.ExportToExcelButton_Click);
            // 
            // invoiceNumber
            // 
            this.invoiceNumber.Location = new System.Drawing.Point(591, 24);
            this.invoiceNumber.Name = "invoiceNumber";
            this.invoiceNumber.Size = new System.Drawing.Size(155, 22);
            this.invoiceNumber.TabIndex = 9;
            this.invoiceNumber.TextChanged += new System.EventHandler(this.InvoiceNumber_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(752, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Номер накладной";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Location = new System.Drawing.Point(919, 56);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(185, 22);
            this.dtpPaymentDate.TabIndex = 12;
            // 
            // cmbAmount
            // 
            this.cmbAmount.Location = new System.Drawing.Point(1110, 56);
            this.cmbAmount.Name = "cmbAmount";
            this.cmbAmount.Size = new System.Drawing.Size(144, 22);
            this.cmbAmount.TabIndex = 13;
            this.cmbAmount.TextChanged += new System.EventHandler(this.cmbAmount_TextChanged);
            // 
            // PaymentButton
            // 
            this.PaymentButton.Location = new System.Drawing.Point(1260, 55);
            this.PaymentButton.Name = "PaymentButton";
            this.PaymentButton.Size = new System.Drawing.Size(163, 23);
            this.PaymentButton.TabIndex = 14;
            this.PaymentButton.Text = "Первичная оплата";
            this.PaymentButton.UseVisualStyleBackColor = true;
            this.PaymentButton.Click += new System.EventHandler(this.PaymentButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(919, 104);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(591, 229);
            this.dataGridView2.TabIndex = 15;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // full_price
            // 
            this.full_price.Location = new System.Drawing.Point(497, 311);
            this.full_price.Name = "full_price";
            this.full_price.Size = new System.Drawing.Size(164, 22);
            this.full_price.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Сумма для оплаты";
            // 
            // checkIsPaidButton
            // 
            this.checkIsPaidButton.Location = new System.Drawing.Point(497, 358);
            this.checkIsPaidButton.Name = "checkIsPaidButton";
            this.checkIsPaidButton.Size = new System.Drawing.Size(231, 28);
            this.checkIsPaidButton.TabIndex = 18;
            this.checkIsPaidButton.Text = "Проверить оплату";
            this.checkIsPaidButton.UseVisualStyleBackColor = true;
            this.checkIsPaidButton.Click += new System.EventHandler(this.checkIsPaidButton_Click);
            // 
            // payBut
            // 
            this.payBut.Location = new System.Drawing.Point(1340, 346);
            this.payBut.Name = "payBut";
            this.payBut.Size = new System.Drawing.Size(170, 23);
            this.payBut.TabIndex = 19;
            this.payBut.Text = "Оплатить еще часть";
            this.payBut.UseVisualStyleBackColor = true;
            this.payBut.Click += new System.EventHandler(this.payBut_Click);
            // 
            // delBut
            // 
            this.delBut.Location = new System.Drawing.Point(1366, 386);
            this.delBut.Name = "delBut";
            this.delBut.Size = new System.Drawing.Size(144, 23);
            this.delBut.TabIndex = 20;
            this.delBut.Text = "Удалить запись";
            this.delBut.UseVisualStyleBackColor = true;
            this.delBut.Click += new System.EventHandler(this.delBut_Click);
            // 
            // payPart
            // 
            this.payPart.Location = new System.Drawing.Point(1004, 347);
            this.payPart.Name = "payPart";
            this.payPart.Size = new System.Drawing.Size(100, 22);
            this.payPart.TabIndex = 21;
            // 
            // dtpLast
            // 
            this.dtpLast.Location = new System.Drawing.Point(1124, 347);
            this.dtpLast.Name = "dtpLast";
            this.dtpLast.Size = new System.Drawing.Size(200, 22);
            this.dtpLast.TabIndex = 22;
            // 
            // deliveryItemCheckButton
            // 
            this.deliveryItemCheckButton.Location = new System.Drawing.Point(15, 412);
            this.deliveryItemCheckButton.Name = "deliveryItemCheckButton";
            this.deliveryItemCheckButton.Size = new System.Drawing.Size(296, 39);
            this.deliveryItemCheckButton.TabIndex = 23;
            this.deliveryItemCheckButton.Text = "Посмотреть информацию по накладной";
            this.deliveryItemCheckButton.UseVisualStyleBackColor = true;
            this.deliveryItemCheckButton.Click += new System.EventHandler(this.deliveryItemCheckButton_Click);
            // 
            // DeliveriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 601);
            this.Controls.Add(this.deliveryItemCheckButton);
            this.Controls.Add(this.dtpLast);
            this.Controls.Add(this.payPart);
            this.Controls.Add(this.delBut);
            this.Controls.Add(this.payBut);
            this.Controls.Add(this.checkIsPaidButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.full_price);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.PaymentButton);
            this.Controls.Add(this.cmbAmount);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ExportToExcelButton);
            this.Controls.Add(this.invoiceNumber);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.cmbSuppliers);
            this.Controls.Add(this.addProductButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DeliveriesForm";
            this.Text = "DeliveriesForm";
            this.Load += new System.EventHandler(this.DeliveriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.ComboBox cmbSuppliers;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Button ExportToExcelButton;
        private System.Windows.Forms.TextBox invoiceNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.TextBox cmbAmount;
        private System.Windows.Forms.Button PaymentButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox full_price;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button checkIsPaidButton;
        private System.Windows.Forms.Button payBut;
        private System.Windows.Forms.Button delBut;
        private System.Windows.Forms.TextBox payPart;
        private System.Windows.Forms.DateTimePicker dtpLast;
        private System.Windows.Forms.Button deliveryItemCheckButton;
    }
}