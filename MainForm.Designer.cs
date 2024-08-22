namespace Project
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.suppliersButton = new System.Windows.Forms.Button();
            this.productsButton = new System.Windows.Forms.Button();
            this.deliveriesButton = new System.Windows.Forms.Button();
            this.reportsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // suppliersButton
            // 
            this.suppliersButton.Location = new System.Drawing.Point(220, 28);
            this.suppliersButton.Name = "suppliersButton";
            this.suppliersButton.Size = new System.Drawing.Size(154, 33);
            this.suppliersButton.TabIndex = 0;
            this.suppliersButton.Text = "Поставщики";
            this.suppliersButton.UseVisualStyleBackColor = true;
            this.suppliersButton.Click += new System.EventHandler(this.suppliersButton_Click_1);
            // 
            // productsButton
            // 
            this.productsButton.Location = new System.Drawing.Point(220, 68);
            this.productsButton.Name = "productsButton";
            this.productsButton.Size = new System.Drawing.Size(154, 33);
            this.productsButton.TabIndex = 1;
            this.productsButton.Text = "Товары";
            this.productsButton.UseVisualStyleBackColor = true;
            this.productsButton.Click += new System.EventHandler(this.productsButton_Click_1);
            // 
            // deliveriesButton
            // 
            this.deliveriesButton.Location = new System.Drawing.Point(220, 108);
            this.deliveriesButton.Name = "deliveriesButton";
            this.deliveriesButton.Size = new System.Drawing.Size(154, 26);
            this.deliveriesButton.TabIndex = 2;
            this.deliveriesButton.Text = "Накладная";
            this.deliveriesButton.UseVisualStyleBackColor = true;
            this.deliveriesButton.Click += new System.EventHandler(this.deliveriesButton_Click_1);
            // 
            // reportsButton
            // 
            this.reportsButton.Location = new System.Drawing.Point(220, 140);
            this.reportsButton.Name = "reportsButton";
            this.reportsButton.Size = new System.Drawing.Size(154, 29);
            this.reportsButton.TabIndex = 4;
            this.reportsButton.Text = "Отчёт";
            this.reportsButton.UseVisualStyleBackColor = true;
            this.reportsButton.Click += new System.EventHandler(this.reportsButton_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 367);
            this.Controls.Add(this.reportsButton);
            this.Controls.Add(this.deliveriesButton);
            this.Controls.Add(this.productsButton);
            this.Controls.Add(this.suppliersButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button suppliersButton;
        private System.Windows.Forms.Button productsButton;
        private System.Windows.Forms.Button deliveriesButton;
        private System.Windows.Forms.Button reportsButton;
    }
}

