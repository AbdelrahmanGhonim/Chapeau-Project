namespace ChapeauUI
{
    partial class Login
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            usernameTxt = new TextBox();
            passwordTxt = new TextBox();
            label2 = new Label();
            loginbtn = new Button();
            pictureBox1 = new PictureBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            invalidcredentiallbl = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 3;
            // 
            // usernameTxt
            // 
            usernameTxt.Location = new Point(142, 249);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.PlaceholderText = "username";
            usernameTxt.Size = new Size(228, 27);
            usernameTxt.TabIndex = 1;
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(142, 302);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.PlaceholderText = "Password";
            passwordTxt.Size = new Size(228, 27);
            passwordTxt.TabIndex = 2;
            passwordTxt.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(208, 170);
            label2.Name = "label2";
            label2.Size = new Size(97, 41);
            label2.TabIndex = 4;
            label2.Text = "Login";
            // 
            // loginbtn
            // 
            loginbtn.BackColor = Color.DodgerBlue;
            loginbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(161, 357);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(186, 38);
            loginbtn.TabIndex = 5;
            loginbtn.Text = "Login";
            loginbtn.UseVisualStyleBackColor = false;
            loginbtn.Click += loginbtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.WhatsApp_Image_2024_05_21_at_10_57_58;
            pictureBox1.Location = new Point(158, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 129);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // invalidcredentiallbl
            // 
            invalidcredentiallbl.AutoSize = true;
            invalidcredentiallbl.ForeColor = Color.Red;
            invalidcredentiallbl.Location = new Point(142, 226);
            invalidcredentiallbl.Name = "invalidcredentiallbl";
            invalidcredentiallbl.Size = new Size(0, 20);
            invalidcredentiallbl.TabIndex = 7;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(508, 576);
            Controls.Add(invalidcredentiallbl);
            Controls.Add(pictureBox1);
            Controls.Add(loginbtn);
            Controls.Add(label2);
            Controls.Add(passwordTxt);
            Controls.Add(usernameTxt);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox usernameTxt;
        private TextBox passwordTxt;
        private Label label2;
        private Button loginbtn;
        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenuStrip1;
        private Label invalidcredentiallbl;
    }
}