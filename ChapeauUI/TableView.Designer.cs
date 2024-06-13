namespace ChapeauUI
{
    partial class TableView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableView));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            avaliblelbl = new Label();
            reservedlbl = new Label();
            occupiedlbl = new Label();
            usernamelbl = new Label();
            logoutbtn = new Button();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Location = new Point(0, 76);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(510, 34);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Lime;
            pictureBox2.Location = new Point(106, 82);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(21, 24);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Red;
            pictureBox4.Location = new Point(227, 82);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(21, 24);
            pictureBox4.TabIndex = 13;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Yellow;
            pictureBox5.Location = new Point(350, 82);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(21, 24);
            pictureBox5.TabIndex = 14;
            pictureBox5.TabStop = false;
            // 
            // avaliblelbl
            // 
            avaliblelbl.AutoSize = true;
            avaliblelbl.BackColor = SystemColors.ControlLightLight;
            avaliblelbl.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            avaliblelbl.ForeColor = Color.Black;
            avaliblelbl.Location = new Point(12, 86);
            avaliblelbl.Name = "avaliblelbl";
            avaliblelbl.Size = new Size(90, 20);
            avaliblelbl.TabIndex = 16;
            avaliblelbl.Text = "Available";
            // 
            // reservedlbl
            // 
            reservedlbl.AutoSize = true;
            reservedlbl.BackColor = SystemColors.ControlLightLight;
            reservedlbl.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            reservedlbl.ForeColor = Color.Black;
            reservedlbl.Location = new Point(139, 86);
            reservedlbl.Name = "reservedlbl";
            reservedlbl.Size = new Size(81, 20);
            reservedlbl.TabIndex = 17;
            reservedlbl.Text = "Reserved";
            // 
            // occupiedlbl
            // 
            occupiedlbl.AutoSize = true;
            occupiedlbl.BackColor = SystemColors.ControlLightLight;
            occupiedlbl.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            occupiedlbl.ForeColor = Color.Black;
            occupiedlbl.Location = new Point(261, 86);
            occupiedlbl.Name = "occupiedlbl";
            occupiedlbl.Size = new Size(81, 20);
            occupiedlbl.TabIndex = 18;
            occupiedlbl.Text = "Occupied";
            // 
            // usernamelbl
            // 
            usernamelbl.AutoSize = true;
            usernamelbl.BackColor = SystemColors.HotTrack;
            usernamelbl.Font = new Font("Franklin Gothic Medium", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            usernamelbl.Location = new Point(367, 9);
            usernamelbl.Name = "usernamelbl";
            usernamelbl.Size = new Size(92, 21);
            usernamelbl.TabIndex = 21;
            usernamelbl.Text = "Username";
            // 
            // logoutbtn
            // 
            logoutbtn.FlatStyle = FlatStyle.Popup;
            logoutbtn.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point);
            logoutbtn.Location = new Point(420, 33);
            logoutbtn.Name = "logoutbtn";
            logoutbtn.Size = new Size(66, 29);
            logoutbtn.TabIndex = 22;
            logoutbtn.Text = "Logout";
            logoutbtn.UseVisualStyleBackColor = true;
            logoutbtn.Click += logoutbtn_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.HotTrack;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(510, 75);
            pictureBox3.TabIndex = 28;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(387, 86);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 30;
            label1.Text = "Ordered";
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = SystemColors.ActiveBorder;
            pictureBox6.Location = new Point(465, 82);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(21, 24);
            pictureBox6.TabIndex = 29;
            pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = SystemColors.HotTrack;
            pictureBox7.BorderStyle = BorderStyle.FixedSingle;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(0, 0);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(146, 75);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 31;
            pictureBox7.TabStop = false;
            // 
            // TableView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(508, 576);
            Controls.Add(pictureBox7);
            Controls.Add(label1);
            Controls.Add(pictureBox6);
            Controls.Add(logoutbtn);
            Controls.Add(usernamelbl);
            Controls.Add(occupiedlbl);
            Controls.Add(reservedlbl);
            Controls.Add(avaliblelbl);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox3);
            Name = "TableView";
            Text = "TableView";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private Label avaliblelbl;
        private Label reservedlbl;
        private Label occupiedlbl;
        private Label usernamelbl;
        private Button logoutbtn;
        private Button button1;
        private PictureBox pictureBox3;
        private Label label1;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
    }
}