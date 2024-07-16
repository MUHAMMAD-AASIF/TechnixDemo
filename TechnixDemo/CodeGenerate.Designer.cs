namespace TechnixDemo
{
    partial class CodeG
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
            Close = new Button();
            EntityCB = new ComboBox();
            Generate = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Close
            // 
            Close.BackgroundImage = Properties.Resources.close;
            Close.BackgroundImageLayout = ImageLayout.Stretch;
            Close.FlatAppearance.BorderSize = 0;
            Close.FlatStyle = FlatStyle.Flat;
            Close.Location = new Point(377, 0);
            Close.Margin = new Padding(4, 5, 4, 5);
            Close.Name = "Close";
            Close.Size = new Size(40, 38);
            Close.TabIndex = 0;
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // EntityCB
            // 
            EntityCB.FlatStyle = FlatStyle.Flat;
            EntityCB.FormattingEnabled = true;
            EntityCB.Location = new Point(51, 137);
            EntityCB.Margin = new Padding(4, 5, 4, 5);
            EntityCB.Name = "EntityCB";
            EntityCB.Size = new Size(325, 33);
            EntityCB.TabIndex = 1;
            // 
            // Generate
            // 
            Generate.BackColor = SystemColors.ActiveCaptionText;
            Generate.FlatAppearance.BorderSize = 0;
            Generate.FlatStyle = FlatStyle.Flat;
            Generate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Generate.ForeColor = Color.White;
            Generate.Location = new Point(150, 221);
            Generate.Margin = new Padding(4, 5, 4, 5);
            Generate.Name = "Generate";
            Generate.Size = new Size(107, 38);
            Generate.TabIndex = 2;
            Generate.Text = "Generate";
            Generate.UseVisualStyleBackColor = false;
            Generate.Click += Generate_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Khaki;
            panel1.Controls.Add(Close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(419, 85);
            panel1.TabIndex = 3;
            // 
            // CodeG
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 358);
            Controls.Add(panel1);
            Controls.Add(Generate);
            Controls.Add(EntityCB);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "CodeG";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button Close;
        private ComboBox EntityCB;
        private Button Generate;
        private Panel panel1;
    }
}