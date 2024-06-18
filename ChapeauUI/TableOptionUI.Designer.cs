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
            infolbl = new Label();
            occupybtn = new Button();
            SuspendLayout();
            // 
            // tableNumberlbl
            // 
            tableNumberlbl.AutoSize = true;
            tableNumberlbl.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            tableNumberlbl.Location = new Point(210, 37);
            tableNumberlbl.Name = "tableNumberlbl";
            tableNumberlbl.Size = new Size(131, 25);
            tableNumberlbl.TabIndex = 0;
            tableNumberlbl.Text = "Table Number";
            // 
            // placeOrderbtn
            // 
            placeOrderbtn.Location = new Point(1, 90);
            placeOrderbtn.Name = "placeOrderbtn";
            placeOrderbtn.Size = new Size(507, 46);
            placeOrderbtn.TabIndex = 1;
            placeOrderbtn.Text = "Place Order";
            placeOrderbtn.UseVisualStyleBackColor = true;
            placeOrderbtn.Click += placeOrderbtn_Click;
            // 
            // reserveTablebtn
            // 
            reserveTablebtn.Location = new Point(1, 152);
            reserveTablebtn.Name = "reserveTablebtn";
            reserveTablebtn.Size = new Size(507, 46);
            reserveTablebtn.TabIndex = 2;
            reserveTablebtn.Text = "Reserve Table";
            reserveTablebtn.UseVisualStyleBackColor = true;
            reserveTablebtn.Click += reserveTablebtn_Click;
            // 
            // FreeTablebtn
            // 
            FreeTablebtn.Location = new Point(1, 278);
            FreeTablebtn.Name = "FreeTablebtn";
            FreeTablebtn.Size = new Size(507, 46);
            FreeTablebtn.TabIndex = 3;
            FreeTablebtn.Text = "Free Table";
            FreeTablebtn.UseVisualStyleBackColor = true;
            FreeTablebtn.Click += FreeTablebtn_Click;
            // 
            // paybtn
            // 
            paybtn.Location = new Point(1, 341);
            paybtn.Name = "paybtn";
            paybtn.Size = new Size(507, 46);
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
            // infolbl
            // 
            infolbl.AutoSize = true;
            infolbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            infolbl.ForeColor = Color.Yellow;
            infolbl.Location = new Point(138, 64);
            infolbl.Name = "infolbl";
            infolbl.Size = new Size(0, 23);
            infolbl.TabIndex = 6;
            // 
            // occupybtn
            // 
            occupybtn.Location = new Point(1, 216);
            occupybtn.Name = "occupybtn";
            occupybtn.Size = new Size(507, 46);
            occupybtn.TabIndex = 7;
            occupybtn.Text = "Occupy Table";
            occupybtn.UseVisualStyleBackColor = true;
            occupybtn.Click += occupybtn_Click;
            // 
            // TableOptionUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(508, 498);
            Controls.Add(occupybtn);
            Controls.Add(infolbl);
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
        private Label infolbl;
        private Button occupybtn;
    }
}