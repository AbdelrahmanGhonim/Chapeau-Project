namespace ChapeauUI
{
    partial class PaymentMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMethod));
            pictureBox1 = new PictureBox();
            cashCheckBox = new CheckBox();
            debitCheckBox = new CheckBox();
            visaCheckBox = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            payButton = new Button();
            priceLabel = new Label();
            label3 = new Label();
            amountTextbox = new TextBox();
            label4 = new Label();
            numericUpDown = new NumericUpDown();
            yesCheckbox = new CheckBox();
            noCheckbox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(59, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(239, 93);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // cashCheckBox
            // 
            cashCheckBox.AutoSize = true;
            cashCheckBox.Location = new Point(73, 366);
            cashCheckBox.Name = "cashCheckBox";
            cashCheckBox.Size = new Size(62, 24);
            cashCheckBox.TabIndex = 13;
            cashCheckBox.Text = "Cash";
            cashCheckBox.UseVisualStyleBackColor = true;
            // 
            // debitCheckBox
            // 
            debitCheckBox.AutoSize = true;
            debitCheckBox.Location = new Point(154, 366);
            debitCheckBox.Name = "debitCheckBox";
            debitCheckBox.Size = new Size(68, 24);
            debitCheckBox.TabIndex = 14;
            debitCheckBox.Text = "Debit";
            debitCheckBox.UseVisualStyleBackColor = true;
            // 
            // visaCheckBox
            // 
            visaCheckBox.AutoSize = true;
            visaCheckBox.Location = new Point(240, 366);
            visaCheckBox.Name = "visaCheckBox";
            visaCheckBox.Size = new Size(58, 24);
            visaCheckBox.TabIndex = 15;
            visaCheckBox.Text = "Visa";
            visaCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(73, 119);
            label1.Name = "label1";
            label1.Size = new Size(130, 25);
            label1.TabIndex = 16;
            label1.Text = "Total amount:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(73, 319);
            label2.Name = "label2";
            label2.Size = new Size(225, 25);
            label2.TabIndex = 17;
            label2.Text = "How do you wish to pay?";
            // 
            // payButton
            // 
            payButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            payButton.Location = new Point(118, 488);
            payButton.Name = "payButton";
            payButton.Size = new Size(129, 39);
            payButton.TabIndex = 18;
            payButton.Text = "Pay now";
            payButton.UseVisualStyleBackColor = true;
            payButton.Click += payButton_Click;
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(210, 123);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(50, 20);
            priceLabel.TabIndex = 19;
            priceLabel.Text = "label3";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(23, 428);
            label3.Name = "label3";
            label3.Size = new Size(171, 25);
            label3.TabIndex = 20;
            label3.Text = "Introduce amount:";
            // 
            // amountTextbox
            // 
            amountTextbox.Location = new Point(200, 429);
            amountTextbox.Name = "amountTextbox";
            amountTextbox.Size = new Size(129, 27);
            amountTextbox.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(73, 175);
            label4.Name = "label4";
            label4.Size = new Size(256, 25);
            label4.TabIndex = 22;
            label4.Text = "Do you want to split the bill?";
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(110, 260);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(150, 27);
            numericUpDown.TabIndex = 23;
            // 
            // yesCheckbox
            // 
            yesCheckbox.AutoSize = true;
            yesCheckbox.Location = new Point(110, 215);
            yesCheckbox.Name = "yesCheckbox";
            yesCheckbox.Size = new Size(52, 24);
            yesCheckbox.TabIndex = 24;
            yesCheckbox.Text = "Yes";
            yesCheckbox.UseVisualStyleBackColor = true;
            // 
            // noCheckbox
            // 
            noCheckbox.AutoSize = true;
            noCheckbox.Location = new Point(208, 215);
            noCheckbox.Name = "noCheckbox";
            noCheckbox.Size = new Size(51, 24);
            noCheckbox.TabIndex = 25;
            noCheckbox.Text = "No";
            noCheckbox.UseVisualStyleBackColor = true;
            // 
            // PaymentMethod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(388, 539);
            Controls.Add(noCheckbox);
            Controls.Add(yesCheckbox);
            Controls.Add(numericUpDown);
            Controls.Add(label4);
            Controls.Add(amountTextbox);
            Controls.Add(label3);
            Controls.Add(priceLabel);
            Controls.Add(payButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(visaCheckBox);
            Controls.Add(debitCheckBox);
            Controls.Add(cashCheckBox);
            Controls.Add(pictureBox1);
            Name = "PaymentMethod";
            Text = "PaymentMethod";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private CheckBox cashCheckBox;
        private CheckBox debitCheckBox;
        private CheckBox visaCheckBox;
        private Label label1;
        private Label label2;
        private Button payButton;
        private Label priceLabel;
        private Label label3;
        private TextBox amountTextbox;
        private Label label4;
        private NumericUpDown numericUpDown;
        private CheckBox yesCheckbox;
        private CheckBox noCheckbox;
    }
}