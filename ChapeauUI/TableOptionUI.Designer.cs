namespace ChapeauUI
{
    partial class TableOptionUI
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
            tableNumberlbl = new Label();
            placeOrderbtn = new Button();
            reserveTablebtn = new Button();
            FreeTablebtn = new Button();
            paybtn = new Button();
            backbtn = new Button();
            SuspendLayout();
            // 
            // tableNumberlbl
            // 
            tableNumberlbl.AutoSize = true;
            tableNumberlbl.Location = new Point(189, 33);
            tableNumberlbl.Name = "tableNumberlbl";
            tableNumberlbl.Size = new Size(102, 20);
            tableNumberlbl.TabIndex = 0;
            tableNumberlbl.Text = "Table Number";
            // 
            // placeOrderbtn
            // 
            placeOrderbtn.Location = new Point(1, 90);
            placeOrderbtn.Name = "placeOrderbtn";
            placeOrderbtn.Size = new Size(506, 46);
            placeOrderbtn.TabIndex = 1;
            placeOrderbtn.Text = "Place Order";
            placeOrderbtn.UseVisualStyleBackColor = true;
            placeOrderbtn.Click += placeOrderbtn_Click;
            // 
            // reserveTablebtn
            // 
            reserveTablebtn.Location = new Point(1, 169);
            reserveTablebtn.Name = "reserveTablebtn";
            reserveTablebtn.Size = new Size(506, 46);
            reserveTablebtn.TabIndex = 2;
            reserveTablebtn.Text = "Reserve Table";
            reserveTablebtn.UseVisualStyleBackColor = true;
            reserveTablebtn.Click += reserveTablebtn_Click;
            // 
            // FreeTablebtn
            // 
            FreeTablebtn.Location = new Point(1, 242);
            FreeTablebtn.Name = "FreeTablebtn";
            FreeTablebtn.Size = new Size(506, 46);
            FreeTablebtn.TabIndex = 3;
            FreeTablebtn.Text = "Free Table";
            FreeTablebtn.UseVisualStyleBackColor = true;
            FreeTablebtn.Click += FreeTablebtn_Click;
            // 
            // paybtn
            // 
            paybtn.Location = new Point(1, 311);
            paybtn.Name = "paybtn";
            paybtn.Size = new Size(506, 46);
            paybtn.TabIndex = 4;
            paybtn.Text = "Pay Bill";
            paybtn.UseVisualStyleBackColor = true;
            paybtn.Click += paybtn_Click;
            // 
            // backbtn
            // 
            backbtn.Location = new Point(172, 407);
            backbtn.Name = "backbtn";
            backbtn.Size = new Size(141, 39);
            backbtn.TabIndex = 5;
            backbtn.Text = "Back";
            backbtn.UseVisualStyleBackColor = true;
            backbtn.Click += backbtn_Click;
            // 
            // TableOptionUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(508, 498);
            Controls.Add(backbtn);
            Controls.Add(paybtn);
            Controls.Add(FreeTablebtn);
            Controls.Add(reserveTablebtn);
            Controls.Add(placeOrderbtn);
            Controls.Add(tableNumberlbl);
            Name = "TableOptionUI";
            Text = "TableOptionUI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tableNumberlbl;
        private Button placeOrderbtn;
        private Button reserveTablebtn;
        private Button FreeTablebtn;
        private Button paybtn;
        private Button backbtn;
    }
}