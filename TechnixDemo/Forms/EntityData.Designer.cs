namespace TechnixDemo.Forms
{
    partial class EntityData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityData));
            panel1 = new Panel();
            Close = new Button();
            label2 = new Label();
            Generate = new Button();
            EntityGrid = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)EntityGrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(238, 212, 132);
            panel1.Controls.Add(Close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(879, 43);
            panel1.TabIndex = 0;
            // 
            // Close
            // 
            Close.BackgroundImage = (Image)resources.GetObject("Close.BackgroundImage");
            Close.BackgroundImageLayout = ImageLayout.Stretch;
            Close.Dock = DockStyle.Right;
            Close.FlatAppearance.BorderSize = 0;
            Close.FlatStyle = FlatStyle.Flat;
            Close.Location = new Point(846, 0);
            Close.Margin = new Padding(4, 5, 4, 5);
            Close.Name = "Close";
            Close.Size = new Size(33, 43);
            Close.TabIndex = 4;
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(44, 107);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(96, 20);
            label2.TabIndex = 10;
            label2.Text = "Select Entity";
            // 
            // Generate
            // 
            Generate.BackColor = SystemColors.ActiveCaptionText;
            Generate.FlatAppearance.BorderSize = 0;
            Generate.FlatStyle = FlatStyle.Flat;
            Generate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Generate.ForeColor = Color.White;
            Generate.Location = new Point(741, 442);
            Generate.Margin = new Padding(4, 5, 4, 5);
            Generate.Name = "Generate";
            Generate.Size = new Size(107, 38);
            Generate.TabIndex = 9;
            Generate.Text = "Generate";
            Generate.UseVisualStyleBackColor = false;
            Generate.Click += Generate_Click;
            // 
            // EntityGrid
            // 
            EntityGrid.AllowUserToAddRows = false;
            EntityGrid.AllowUserToDeleteRows = false;
            EntityGrid.BackgroundColor = Color.White;
            EntityGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            EntityGrid.Location = new Point(44, 137);
            EntityGrid.Margin = new Padding(4, 5, 4, 5);
            EntityGrid.Name = "EntityGrid";
            EntityGrid.ReadOnly = true;
            EntityGrid.RowHeadersWidth = 62;
            EntityGrid.RowTemplate.Height = 25;
            EntityGrid.Size = new Size(804, 295);
            EntityGrid.TabIndex = 11;
            // 
            // EntityData
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(879, 518);
            Controls.Add(EntityGrid);
            Controls.Add(label2);
            Controls.Add(Generate);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "EntityData";
            Text = "EntityData";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)EntityGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button Close;
        private Label label2;
        private Button Generate;
        private DataGridView dataGridView1;
        private DataGridView EntityGrid;
    }
}