namespace TechnixDemo.Forms
{
    partial class DBConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBConfig));
            panel1 = new Panel();
            Close = new Button();
            ServerTxt = new TextBox();
            DatabaseTxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ConfigBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 22);
            panel1.TabIndex = 0;
            // 
            // Close
            // 
            Close.BackgroundImage = (Image)resources.GetObject("Close.BackgroundImage");
            Close.BackgroundImageLayout = ImageLayout.Stretch;
            Close.FlatAppearance.BorderSize = 0;
            Close.FlatStyle = FlatStyle.Flat;
            Close.Location = new Point(228, 0);
            Close.Name = "Close";
            Close.Size = new Size(22, 18);
            Close.TabIndex = 4;
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // ServerTxt
            // 
            ServerTxt.Location = new Point(18, 56);
            ServerTxt.Margin = new Padding(2, 2, 2, 2);
            ServerTxt.Name = "ServerTxt";
            ServerTxt.Size = new Size(213, 23);
            ServerTxt.TabIndex = 1;
            ServerTxt.Text = "HQAPEW1C002-AUZ";
            // 
            // DatabaseTxt
            // 
            DatabaseTxt.Location = new Point(18, 100);
            DatabaseTxt.Margin = new Padding(2, 2, 2, 2);
            DatabaseTxt.Name = "DatabaseTxt";
            DatabaseTxt.Size = new Size(213, 23);
            DatabaseTxt.TabIndex = 2;
            DatabaseTxt.Text = "technix";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 39);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 4;
            label1.Text = "Server Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 83);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 5;
            label2.Text = "Database";
            // 
            // ConfigBtn
            // 
            ConfigBtn.Location = new Point(151, 143);
            ConfigBtn.Margin = new Padding(2, 2, 2, 2);
            ConfigBtn.Name = "ConfigBtn";
            ConfigBtn.Size = new Size(78, 31);
            ConfigBtn.TabIndex = 6;
            ConfigBtn.Text = "Config";
            ConfigBtn.UseVisualStyleBackColor = true;
            ConfigBtn.Click += Config_Click;
            // 
            // DBConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 185);
            Controls.Add(ConfigBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DatabaseTxt);
            Controls.Add(ServerTxt);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DBConfig";
            Text = "DBConfig";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button Close;
        private TextBox ServerTxt;
        private TextBox DatabaseTxt;
        private Label label1;
        private Label label2;
        private Button ConfigBtn;
    }
}