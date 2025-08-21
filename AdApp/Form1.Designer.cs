namespace AdApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTestConnection = new Button();
            txtTitle = new TextBox();
            txtPrice = new TextBox();
            txtDescription = new TextBox();
            cmbCategory = new ComboBox();
            btnSaveAd = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dgvAds = new DataGridView();
            txtSearchTitle = new TextBox();
            cmbSearchCategory = new ComboBox();
            btnSearch = new Button();
            btnLogin = new Button();
            btnDeleteAd = new Button();
            btnRegister = new Button();
            lblLoggedInUser = new Label();
            btnLogout = new Button();
            cmbSort = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvAds).BeginInit();
            SuspendLayout();
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(25, 707);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(153, 34);
            btnTestConnection.TabIndex = 0;
            btnTestConnection.Text = "TestConnection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click_1;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(1102, 483);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(150, 31);
            txtTitle.TabIndex = 1;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(1102, 586);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(150, 31);
            txtPrice.TabIndex = 2;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(1102, 534);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(150, 31);
            txtDescription.TabIndex = 3;
            txtDescription.TextChanged += txtDescription_TextChanged;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(1102, 643);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 33);
            cmbCategory.TabIndex = 4;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // btnSaveAd
            // 
            btnSaveAd.Location = new Point(1219, 707);
            btnSaveAd.Name = "btnSaveAd";
            btnSaveAd.Size = new Size(153, 34);
            btnSaveAd.TabIndex = 5;
            btnSaveAd.Text = "Save Ad";
            btnSaveAd.UseVisualStyleBackColor = true;
            btnSaveAd.Click += btnSaveAd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1045, 589);
            label1.Name = "label1";
            label1.Size = new Size(49, 25);
            label1.TabIndex = 6;
            label1.Text = "Price";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(594, 190);
            label2.Name = "label2";
            label2.Size = new Size(0, 25);
            label2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(602, 198);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1035, 489);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 9;
            label4.Text = "Name";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1012, 643);
            label5.Name = "label5";
            label5.Size = new Size(84, 25);
            label5.TabIndex = 10;
            label5.Text = "Category";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(994, 540);
            label6.Name = "label6";
            label6.Size = new Size(102, 25);
            label6.TabIndex = 11;
            label6.Text = "Description";
            // 
            // dgvAds
            // 
            dgvAds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAds.Location = new Point(54, 198);
            dgvAds.Name = "dgvAds";
            dgvAds.RowHeadersWidth = 62;
            dgvAds.Size = new Size(852, 404);
            dgvAds.TabIndex = 12;
            dgvAds.CellContentClick += dgvAds_CellContentClick;
            // 
            // txtSearchTitle
            // 
            txtSearchTitle.Location = new Point(444, 46);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.Size = new Size(150, 31);
            txtSearchTitle.TabIndex = 13;
            txtSearchTitle.TextChanged += txtSearchTitle_TextChanged;
            // 
            // cmbSearchCategory
            // 
            cmbSearchCategory.FormattingEnabled = true;
            cmbSearchCategory.Location = new Point(444, 94);
            cmbSearchCategory.Name = "cmbSearchCategory";
            cmbSearchCategory.Size = new Size(150, 33);
            cmbSearchCategory.TabIndex = 14;
            cmbSearchCategory.Text = "Category";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(613, 138);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(1202, 72);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(153, 34);
            btnLogin.TabIndex = 16;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnDeleteAd
            // 
            btnDeleteAd.Location = new Point(1035, 707);
            btnDeleteAd.Name = "btnDeleteAd";
            btnDeleteAd.Size = new Size(153, 34);
            btnDeleteAd.TabIndex = 18;
            btnDeleteAd.Text = "Delete";
            btnDeleteAd.UseVisualStyleBackColor = true;
            btnDeleteAd.Click += btnDeleteAd_Click;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(1202, 112);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(153, 34);
            btnRegister.TabIndex = 19;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblLoggedInUser
            // 
            lblLoggedInUser.AutoSize = true;
            lblLoggedInUser.Location = new Point(1169, 35);
            lblLoggedInUser.Name = "lblLoggedInUser";
            lblLoggedInUser.Size = new Size(123, 25);
            lblLoggedInUser.TabIndex = 20;
            lblLoggedInUser.Text = "Not logged in";
            lblLoggedInUser.Click += lblLoggedInUser_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1202, 152);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(153, 34);
            btnLogout.TabIndex = 21;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // cmbSort
            // 
            cmbSort.FormattingEnabled = true;
            cmbSort.Location = new Point(392, 140);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(202, 33);
            cmbSort.TabIndex = 22;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1396, 781);
            Controls.Add(cmbSort);
            Controls.Add(btnLogout);
            Controls.Add(lblLoggedInUser);
            Controls.Add(btnRegister);
            Controls.Add(btnDeleteAd);
            Controls.Add(btnLogin);
            Controls.Add(btnSearch);
            Controls.Add(cmbSearchCategory);
            Controls.Add(txtSearchTitle);
            Controls.Add(dgvAds);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSaveAd);
            Controls.Add(cmbCategory);
            Controls.Add(txtDescription);
            Controls.Add(txtPrice);
            Controls.Add(txtTitle);
            Controls.Add(btnTestConnection);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAds).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestConnection;
        private TextBox txtTitle;
        private TextBox txtPrice;
        private TextBox txtDescription;
        private ComboBox cmbCategory;
        private Button btnSaveAd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DataGridView dgvAds;
        private TextBox txtSearchTitle;
        private ComboBox cmbSearchCategory;
        private Button btnSearch;
        private Button btnLogin;
        private Button btnDeleteAd;
        private Button btnRegister;
        private Label lblLoggedInUser;
        private Button btnLogout;
        private ComboBox cmbSort;
    }
}
