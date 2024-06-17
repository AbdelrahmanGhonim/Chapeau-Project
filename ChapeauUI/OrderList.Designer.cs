namespace ChapeauUI
{
    partial class OrderList
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
            logOutBtn = new Button();
            roleLbl = new Label();
            tableViewBtn = new Button();
            lunchBtn = new Button();
            drinksBtn = new Button();
            listViewOrder = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            addBtn = new Button();
            dinnerBtn = new Button();
            label2 = new Label();
            btnRemoveAll = new Button();
            btnComment = new Button();
            btnRemove = new Button();
            numQuantity = new NumericUpDown();
            pnlComment = new Panel();
            btnAddComment = new Button();
            btnBack = new Button();
            txtBoxComment = new TextBox();
            label3 = new Label();
            flowLayoutPanelMenu = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            pnlComment.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(25, 123, 189);
            label1.ForeColor = Color.Cornsilk;
            label1.Location = new Point(-3, -3);
            label1.Name = "label1";
            label1.Size = new Size(909, 194);
            label1.TabIndex = 0;
            // 
            // logOutBtn
            // 
            logOutBtn.Location = new Point(754, 12);
            logOutBtn.Name = "logOutBtn";
            logOutBtn.Size = new Size(137, 45);
            logOutBtn.TabIndex = 1;
            logOutBtn.Text = "Logout";
            logOutBtn.UseVisualStyleBackColor = true;
            // 
            // roleLbl
            // 
            roleLbl.AutoSize = true;
            roleLbl.BackColor = Color.FromArgb(25, 123, 189);
            roleLbl.Location = new Point(458, 18);
            roleLbl.Name = "roleLbl";
            roleLbl.Size = new Size(125, 32);
            roleLbl.TabIndex = 2;
            roleLbl.Text = "Waitress: ";
            // 
            // tableViewBtn
            // 
            tableViewBtn.BackColor = Color.FromArgb(6, 167, 125);
            tableViewBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            tableViewBtn.ForeColor = Color.White;
            tableViewBtn.Location = new Point(12, 106);
            tableViewBtn.Name = "tableViewBtn";
            tableViewBtn.Size = new Size(207, 60);
            tableViewBtn.TabIndex = 3;
            tableViewBtn.Text = "Table View";
            tableViewBtn.UseVisualStyleBackColor = false;
            // 
            // lunchBtn
            // 
            lunchBtn.BackColor = Color.FromArgb(6, 167, 125);
            lunchBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            lunchBtn.ForeColor = Color.White;
            lunchBtn.Location = new Point(236, 106);
            lunchBtn.Name = "lunchBtn";
            lunchBtn.Size = new Size(207, 60);
            lunchBtn.TabIndex = 4;
            lunchBtn.Text = "Lunch";
            lunchBtn.UseVisualStyleBackColor = false;
            lunchBtn.Click += lunchBtn_Click;
            // 
            // drinksBtn
            // 
            drinksBtn.BackColor = Color.FromArgb(6, 167, 125);
            drinksBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            drinksBtn.ForeColor = Color.White;
            drinksBtn.Location = new Point(684, 106);
            drinksBtn.Name = "drinksBtn";
            drinksBtn.Size = new Size(207, 60);
            drinksBtn.TabIndex = 6;
            drinksBtn.Text = "Drinks";
            drinksBtn.UseVisualStyleBackColor = false;
            drinksBtn.Click += drinksBtn_Click;
            // 
            // listViewOrder
            // 
            listViewOrder.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listViewOrder.FullRowSelect = true;
            listViewOrder.Location = new Point(27, 983);
            listViewOrder.Name = "listViewOrder";
            listViewOrder.Size = new Size(851, 231);
            listViewOrder.TabIndex = 8;
            listViewOrder.UseCompatibleStateImageBehavior = false;
            listViewOrder.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Quant.";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Item";
            columnHeader2.Width = 550;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Comment";
            columnHeader3.Width = 197;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(6, 167, 125);
            addBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            addBtn.ForeColor = Color.White;
            addBtn.Location = new Point(700, 1212);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(178, 60);
            addBtn.TabIndex = 9;
            addBtn.Text = "ADD";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Visible = false;
            addBtn.Click += addBtn_Click;
            // 
            // dinnerBtn
            // 
            dinnerBtn.BackColor = Color.FromArgb(6, 167, 125);
            dinnerBtn.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            dinnerBtn.ForeColor = Color.White;
            dinnerBtn.Location = new Point(458, 106);
            dinnerBtn.Name = "dinnerBtn";
            dinnerBtn.Size = new Size(207, 60);
            dinnerBtn.TabIndex = 10;
            dinnerBtn.Text = "Dinner";
            dinnerBtn.UseVisualStyleBackColor = false;
            dinnerBtn.Click += dinnerBtn_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 951);
            label2.Name = "label2";
            label2.Size = new Size(95, 32);
            label2.TabIndex = 14;
            label2.Text = "ORDER";
            // 
            // btnRemoveAll
            // 
            btnRemoveAll.BackColor = Color.DarkRed;
            btnRemoveAll.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemoveAll.ForeColor = Color.White;
            btnRemoveAll.Location = new Point(504, 1212);
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.Size = new Size(178, 60);
            btnRemoveAll.TabIndex = 15;
            btnRemoveAll.Text = "REMOVE";
            btnRemoveAll.UseVisualStyleBackColor = false;
            btnRemoveAll.Visible = false;
            btnRemoveAll.Click += btnRemoveAll_Click;
            // 
            // btnComment
            // 
            btnComment.BackColor = Color.Goldenrod;
            btnComment.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnComment.ForeColor = Color.White;
            btnComment.Location = new Point(304, 1212);
            btnComment.Name = "btnComment";
            btnComment.Size = new Size(178, 60);
            btnComment.TabIndex = 16;
            btnComment.Text = "COMMENT";
            btnComment.UseVisualStyleBackColor = false;
            btnComment.Visible = false;
            btnComment.Click += btnComment_Click_1;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.DarkRed;
            btnRemove.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(504, 1212);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(178, 60);
            btnRemove.TabIndex = 17;
            btnRemove.Text = "REMOVE";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Visible = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(27, 1220);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(95, 39);
            numQuantity.TabIndex = 18;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Visible = false;
            // 
            // pnlComment
            // 
            pnlComment.BorderStyle = BorderStyle.FixedSingle;
            pnlComment.Controls.Add(btnAddComment);
            pnlComment.Controls.Add(btnBack);
            pnlComment.Controls.Add(txtBoxComment);
            pnlComment.Controls.Add(label3);
            pnlComment.Location = new Point(12, 194);
            pnlComment.Name = "pnlComment";
            pnlComment.Size = new Size(879, 754);
            pnlComment.TabIndex = 19;
            pnlComment.Visible = false;
            // 
            // btnAddComment
            // 
            btnAddComment.BackColor = Color.FromArgb(6, 167, 125);
            btnAddComment.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddComment.ForeColor = Color.White;
            btnAddComment.Location = new Point(614, 596);
            btnAddComment.Name = "btnAddComment";
            btnAddComment.Size = new Size(178, 60);
            btnAddComment.TabIndex = 21;
            btnAddComment.Text = "Add";
            btnAddComment.UseVisualStyleBackColor = false;
            btnAddComment.Click += btnAddComment_Click_1;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(6, 167, 125);
            btnBack.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(80, 596);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(178, 60);
            btnBack.TabIndex = 20;
            btnBack.Text = "Back";
            btnBack.UseCompatibleTextRendering = true;
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // txtBoxComment
            // 
            txtBoxComment.Location = new Point(80, 178);
            txtBoxComment.Multiline = true;
            txtBoxComment.Name = "txtBoxComment";
            txtBoxComment.Size = new Size(712, 312);
            txtBoxComment.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.875F, FontStyle.Underline, GraphicsUnit.Point);
            label3.Location = new Point(375, 64);
            label3.Name = "label3";
            label3.Size = new Size(143, 40);
            label3.TabIndex = 0;
            label3.Text = "Comment";
            // 
            // flowLayoutPanelMenu
            // 
            flowLayoutPanelMenu.AutoScroll = true;
            flowLayoutPanelMenu.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelMenu.Location = new Point(12, 194);
            flowLayoutPanelMenu.Name = "flowLayoutPanelMenu";
            flowLayoutPanelMenu.Size = new Size(879, 754);
            flowLayoutPanelMenu.TabIndex = 13;
            // 
            // OrderList
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(903, 1277);
            Controls.Add(pnlComment);
            Controls.Add(numQuantity);
            Controls.Add(btnComment);
            Controls.Add(btnRemoveAll);
            Controls.Add(label2);
            Controls.Add(flowLayoutPanelMenu);
            Controls.Add(dinnerBtn);
            Controls.Add(addBtn);
            Controls.Add(listViewOrder);
            Controls.Add(drinksBtn);
            Controls.Add(lunchBtn);
            Controls.Add(tableViewBtn);
            Controls.Add(roleLbl);
            Controls.Add(logOutBtn);
            Controls.Add(label1);
            Controls.Add(btnRemove);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Name = "OrderList";
            Text = "OrderList";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            pnlComment.ResumeLayout(false);
            pnlComment.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button logOutBtn;
        private Label roleLbl;
        private Button tableViewBtn;
        private Button lunchBtn;
        private Button button1;
        private Button drinksBtn;
        private ListView listViewOrder;
        private Button addBtn;
        private Button dinnerBtn;
        private Label label2;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnRemoveAll;
        private Button btnComment;
        private Button btnRemove;
        private NumericUpDown numQuantity;
        private ColumnHeader columnHeader3;
        private Panel pnlComment;
        private Button btnAddComment;
        private Button btnBack;
        private TextBox txtBoxComment;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanelMenu;
    }
}