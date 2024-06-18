namespace ChapeauUI
{
    partial class OrderSummaryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderSummaryForm));
            LogoutButton = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ReviewButton = new Button();
            totalLabel = new Label();
            vatLabel = new Label();
            dataGridViewOrderSummary = new DataGridView();
            ItemName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderSummary).BeginInit();
            SuspendLayout();
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(320, 12);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(108, 38);
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(80, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(264, 100);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(130, 183);
            label1.Name = "label1";
            label1.Size = new Size(162, 28);
            label1.TabIndex = 2;
            label1.Text = "Order Summary";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReviewButton
            // 
            ReviewButton.BackColor = SystemColors.ActiveCaption;
            ReviewButton.Location = new Point(120, 505);
            ReviewButton.Name = "ReviewButton";
            ReviewButton.Size = new Size(182, 47);
            ReviewButton.TabIndex = 4;
            ReviewButton.Text = "Review and Appreciate";
            ReviewButton.UseVisualStyleBackColor = false;
            ReviewButton.Click += ReviewButton_Click;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(120, 456);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(100, 20);
            totalLabel.TabIndex = 5;
            totalLabel.Text = "Total amount:";
            // 
            // vatLabel
            // 
            vatLabel.AutoSize = true;
            vatLabel.Location = new Point(120, 414);
            vatLabel.Name = "vatLabel";
            vatLabel.Size = new Size(37, 20);
            vatLabel.TabIndex = 6;
            vatLabel.Text = "VAT:";
            // 
            // dataGridViewOrderSummary
            // 
            dataGridViewOrderSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrderSummary.Columns.AddRange(new DataGridViewColumn[] { ItemName, Quantity, Price });
            dataGridViewOrderSummary.Location = new Point(12, 214);
            dataGridViewOrderSummary.Name = "dataGridViewOrderSummary";
            dataGridViewOrderSummary.RowHeadersWidth = 51;
            dataGridViewOrderSummary.RowTemplate.Height = 29;
            dataGridViewOrderSummary.Size = new Size(405, 188);
            dataGridViewOrderSummary.TabIndex = 7;
            // 
            // ItemName
            // 
            ItemName.HeaderText = "Name";
            ItemName.MinimumWidth = 6;
            ItemName.Name = "ItemName";
            ItemName.Width = 125;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.Width = 125;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.Width = 125;
            // 
            // OrderSummaryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(440, 564);
            Controls.Add(dataGridViewOrderSummary);
            Controls.Add(vatLabel);
            Controls.Add(totalLabel);
            Controls.Add(ReviewButton);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(LogoutButton);
            Name = "OrderSummaryForm";
            Text = "OrderSummaryForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderSummary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LogoutButton;
        private PictureBox pictureBox1;
        private Label label1;
        private Button ReviewButton;
        private Label totalLabel;
        private Label vatLabel;
        private DataGridView dataGridViewOrderSummary;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Price;
    }
}