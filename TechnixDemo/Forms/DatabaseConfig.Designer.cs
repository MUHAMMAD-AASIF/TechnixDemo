namespace TechnixDemo
{
    partial class DatabaseConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseConfig));
            panel1 = new Panel();
            Close = new Button();
            ServerNameTxt = new TextBox();
            label4 = new Label();
            UserNameTxt = new TextBox();
            label1 = new Label();
            PasswordTxt = new TextBox();
            label2 = new Label();
            DbNameTxt = new TextBox();
            label3 = new Label();
            SubmitBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Khaki;
            panel1.Controls.Add(Close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(362, 26);
            panel1.TabIndex = 1;
            // 
            // Close
            // 
            Close.BackgroundImage = (Image)resources.GetObject("Close.BackgroundImage");
            Close.BackgroundImageLayout = ImageLayout.Stretch;
            Close.Dock = DockStyle.Right;
            Close.FlatAppearance.BorderSize = 0;
            Close.FlatStyle = FlatStyle.Flat;
            Close.Location = new Point(339, 0);
            Close.Name = "Close";
            Close.Size = new Size(23, 26);
            Close.TabIndex = 4;
            Close.UseVisualStyleBackColor = true;
            // 
            // ServerNameTxt
            // 
            ServerNameTxt.BackColor = Color.White;
            ServerNameTxt.BorderStyle = BorderStyle.FixedSingle;
            ServerNameTxt.Location = new Point(12, 71);
            ServerNameTxt.Name = "ServerNameTxt";
            ServerNameTxt.Size = new Size(338, 23);
            ServerNameTxt.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 53);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 15;
            label4.Text = "Server Name";
            // 
            // UserNameTxt
            // 
            UserNameTxt.BackColor = Color.White;
            UserNameTxt.BorderStyle = BorderStyle.FixedSingle;
            UserNameTxt.Location = new Point(12, 129);
            UserNameTxt.Name = "UserNameTxt";
            UserNameTxt.Size = new Size(338, 23);
            UserNameTxt.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 111);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 17;
            label1.Text = "User Name";
            // 
            // PasswordTxt
            // 
            PasswordTxt.BackColor = Color.White;
            PasswordTxt.BorderStyle = BorderStyle.FixedSingle;
            PasswordTxt.Location = new Point(12, 184);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PasswordChar = '*';
            PasswordTxt.Size = new Size(338, 23);
            PasswordTxt.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 166);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 19;
            label2.Text = "Password";
            // 
            // DbNameTxt
            // 
            DbNameTxt.BackColor = Color.White;
            DbNameTxt.BorderStyle = BorderStyle.FixedSingle;
            DbNameTxt.Location = new Point(12, 241);
            DbNameTxt.Name = "DbNameTxt";
            DbNameTxt.Size = new Size(338, 23);
            DbNameTxt.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 223);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 21;
            label3.Text = "Database Name";
            // 
            // SubmitBtn
            // 
            SubmitBtn.BackColor = SystemColors.ActiveCaptionText;
            SubmitBtn.FlatAppearance.BorderSize = 0;
            SubmitBtn.FlatStyle = FlatStyle.Flat;
            SubmitBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SubmitBtn.ForeColor = Color.White;
            SubmitBtn.Location = new Point(257, 287);
            SubmitBtn.Name = "SubmitBtn";
            SubmitBtn.Size = new Size(93, 23);
            SubmitBtn.TabIndex = 23;
            SubmitBtn.Text = "Submit";
            SubmitBtn.UseVisualStyleBackColor = false;
            SubmitBtn.Click += SubmitBtn_Click;
            // 
            // DatabaseConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(362, 363);
            Controls.Add(SubmitBtn);
            Controls.Add(DbNameTxt);
            Controls.Add(label3);
            Controls.Add(PasswordTxt);
            Controls.Add(label2);
            Controls.Add(UserNameTxt);
            Controls.Add(label1);
            Controls.Add(ServerNameTxt);
            Controls.Add(label4);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DatabaseConfig";
            Text = "DatabaseConfig";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button Close;
        private TextBox ServerNameTxt;
        private Label label4;
        private TextBox UserNameTxt;
        private Label label1;
        private TextBox PasswordTxt;
        private Label label2;
        private TextBox DbNameTxt;
        private Label label3;
        private Button SubmitBtn;
    }
}