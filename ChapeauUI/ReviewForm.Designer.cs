namespace ChapeauUI
{
    partial class ReviewForm
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
        /// 

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReviewForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            paymentButton = new Button();
            pictureBox1 = new PictureBox();
            feedbackTextbox = new TextBox();
            sendFeedbackButton = new Button();
            tipTextbox = new TextBox();
            tip0Checkbox = new CheckBox();
            tip2Checkbox = new CheckBox();
            tip5Checkbox = new CheckBox();
            tip10Checkbox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(146, 133);
            label1.Name = "label1";
            label1.Size = new Size(91, 28);
            label1.TabIndex = 0;
            label1.Text = "Rate Us!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(49, 161);
            label2.Name = "label2";
            label2.Size = new Size(283, 25);
            label2.TabIndex = 1;
            label2.Text = "Your feedback is important to us";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(73, 264);
            label3.Name = "label3";
            label3.Size = new Size(239, 25);
            label3.TabIndex = 2;
            label3.Text = "Do you want to leave a tip?";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 298);
            label4.Name = "label4";
            label4.Size = new Size(214, 20);
            label4.TabIndex = 4;
            label4.Text = "100% of the tip goes to Charity";
            // 
            // paymentButton
            // 
            paymentButton.BackColor = SystemColors.ActiveCaption;
            paymentButton.Location = new Point(85, 445);
            paymentButton.Name = "paymentButton";
            paymentButton.Size = new Size(214, 41);
            paymentButton.TabIndex = 10;
            paymentButton.Text = "Proceed to Payment";
            paymentButton.UseVisualStyleBackColor = false;
            paymentButton.Click += paymentButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(73, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(239, 93);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // feedbackTextbox
            // 
            feedbackTextbox.Location = new Point(49, 205);
            feedbackTextbox.Name = "feedbackTextbox";
            feedbackTextbox.Size = new Size(188, 27);
            feedbackTextbox.TabIndex = 12;
            // 
            // sendFeedbackButton
            // 
            sendFeedbackButton.Location = new Point(262, 205);
            sendFeedbackButton.Name = "sendFeedbackButton";
            sendFeedbackButton.Size = new Size(70, 27);
            sendFeedbackButton.TabIndex = 13;
            sendFeedbackButton.Text = "Send ";
            sendFeedbackButton.UseVisualStyleBackColor = true;
            sendFeedbackButton.Click += sendFeedbackButton_Click;
            // 
            // tipTextbox
            // 
            tipTextbox.Location = new Point(101, 382);
            tipTextbox.Name = "tipTextbox";
            tipTextbox.Size = new Size(179, 27);
            tipTextbox.TabIndex = 14;
            tipTextbox.Text = "Enter another tip amount";
            tipTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // tip0Checkbox
            // 
            tip0Checkbox.AutoSize = true;
            tip0Checkbox.Location = new Point(22, 340);
            tip0Checkbox.Name = "tip0Checkbox";
            tip0Checkbox.Size = new Size(73, 24);
            tip0Checkbox.TabIndex = 15;
            tip0Checkbox.Text = "No tip";
            tip0Checkbox.UseVisualStyleBackColor = true;
            // 
            // tip2Checkbox
            // 
            tip2Checkbox.AutoSize = true;
            tip2Checkbox.Location = new Point(101, 340);
            tip2Checkbox.Name = "tip2Checkbox";
            tip2Checkbox.Size = new Size(70, 24);
            tip2Checkbox.TabIndex = 16;
            tip2Checkbox.Text = "€2.00 ";
            tip2Checkbox.UseVisualStyleBackColor = true;
            // 
            // tip5Checkbox
            // 
            tip5Checkbox.AutoSize = true;
            tip5Checkbox.Location = new Point(181, 340);
            tip5Checkbox.Name = "tip5Checkbox";
            tip5Checkbox.Size = new Size(66, 24);
            tip5Checkbox.TabIndex = 17;
            tip5Checkbox.Text = "€5.00";
            tip5Checkbox.UseVisualStyleBackColor = true;
            // 
            // tip10Checkbox
            // 
            tip10Checkbox.AutoSize = true;
            tip10Checkbox.Location = new Point(273, 340);
            tip10Checkbox.Name = "tip10Checkbox";
            tip10Checkbox.Size = new Size(74, 24);
            tip10Checkbox.TabIndex = 18;
            tip10Checkbox.Text = "€10.00";
            tip10Checkbox.UseVisualStyleBackColor = true;
            // 
            // ReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(414, 507);
            Controls.Add(tip10Checkbox);
            Controls.Add(tip5Checkbox);
            Controls.Add(tip2Checkbox);
            Controls.Add(tip0Checkbox);
            Controls.Add(tipTextbox);
            Controls.Add(sendFeedbackButton);
            Controls.Add(feedbackTextbox);
            Controls.Add(pictureBox1);
            Controls.Add(paymentButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ReviewForm";
            Text = "ReviewForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button paymentButton;
        private PictureBox pictureBox1;
        private TextBox feedbackTextbox;
        private Button sendFeedbackButton;
        private TextBox tipTextbox;
        private CheckBox tip0Checkbox;
        private CheckBox tip2Checkbox;
        private CheckBox tip5Checkbox;
        private CheckBox tip10Checkbox;
    }
}