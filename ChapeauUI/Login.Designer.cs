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
            label1 = new Label();
            usernameTxt = new TextBox();
            passwordTxt = new TextBox();
            label2 = new Label();
            loginbtn = new Button();
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
            usernameTxt.Location = new Point(274, 179);
            usernameTxt.Name = "usernameTxt";
            usernameTxt.PlaceholderText = "username";
            usernameTxt.Size = new Size(228, 27);
            usernameTxt.TabIndex = 1;
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(274, 232);
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
            label2.Location = new Point(349, 82);
            label2.Name = "label2";
            label2.Size = new Size(97, 41);
            label2.TabIndex = 4;
            label2.Text = "Login";
            // 
            // loginbtn
            // 
            loginbtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            loginbtn.Location = new Point(316, 283);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(150, 38);
            loginbtn.TabIndex = 5;
            loginbtn.Text = "button1";
            loginbtn.UseVisualStyleBackColor = true;
            loginbtn.Click += loginbtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginbtn);
            Controls.Add(label2);
            Controls.Add(passwordTxt);
            Controls.Add(usernameTxt);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox usernameTxt;
        private TextBox passwordTxt;
        private Label label2;
        private Button loginbtn;
    }
}