namespace ChapeauUI
{
    partial class MenuItemControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private Label lblPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            lblPrice = new Label();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.Location = new Point(19, 11);
            lblName.Margin = new Padding(6, 0, 6, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 29);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrice.Location = new Point(668, 8);
            lblPrice.Margin = new Padding(6, 0, 6, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(76, 31);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "Price";
            // 
            // MenuItemControl
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 217, 217);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Margin = new Padding(6, 7, 6, 7);
            Name = "MenuItemControl";
            Size = new Size(794, 55);
            ResumeLayout(false);
            PerformLayout();
        }
    }

}
