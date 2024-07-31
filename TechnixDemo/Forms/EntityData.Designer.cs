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
            dataGridView1 = new DataGridView();
            Select = new DataGridViewCheckBoxColumn();
            TableName = new DataGridViewTextBoxColumn();
            GetAll = new DataGridViewCheckBoxColumn();
            GetById = new DataGridViewCheckBoxColumn();
            Save = new DataGridViewCheckBoxColumn();
            Update = new DataGridViewCheckBoxColumn();
            Delete = new DataGridViewCheckBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Khaki;
            panel1.Controls.Add(Close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(615, 26);
            panel1.TabIndex = 0;
            // 
            // Close
            // 
            Close.BackgroundImage = (Image)resources.GetObject("Close.BackgroundImage");
            Close.BackgroundImageLayout = ImageLayout.Stretch;
            Close.Dock = DockStyle.Right;
            Close.FlatAppearance.BorderSize = 0;
            Close.FlatStyle = FlatStyle.Flat;
            Close.Location = new Point(592, 0);
            Close.Name = "Close";
            Close.Size = new Size(23, 26);
            Close.TabIndex = 4;
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(31, 64);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
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
            Generate.Location = new Point(519, 265);
            Generate.Name = "Generate";
            Generate.Size = new Size(75, 23);
            Generate.TabIndex = 9;
            Generate.Text = "Generate";
            Generate.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Select, TableName, GetAll, GetById, Save, Update, Delete });
            dataGridView1.Location = new Point(31, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(563, 177);
            dataGridView1.TabIndex = 11;
            // 
            // Select
            // 
            Select.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Select.HeaderText = "Select";
            Select.Name = "Select";
            Select.Width = 50;
            // 
            // TableName
            // 
            TableName.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TableName.HeaderText = "Table Name";
            TableName.Name = "TableName";
            TableName.Width = 200;
            // 
            // GetAll
            // 
            GetAll.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            GetAll.HeaderText = "GetAll";
            GetAll.Name = "GetAll";
            GetAll.Width = 50;
            // 
            // GetById
            // 
            GetById.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            GetById.HeaderText = "GetById";
            GetById.Name = "GetById";
            GetById.Width = 70;
            // 
            // Save
            // 
            Save.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Save.HeaderText = "Save";
            Save.Name = "Save";
            Save.Width = 50;
            // 
            // Update
            // 
            Update.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Update.HeaderText = "Update";
            Update.Name = "Update";
            Update.Width = 50;
            // 
            // Delete
            // 
            Delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Delete.HeaderText = "Delete";
            Delete.Name = "Delete";
            Delete.Width = 50;
            // 
            // EntityData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(615, 311);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(Generate);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EntityData";
            Text = "EntityData";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button Close;
        private Label label2;
        private Button Generate;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn Select;
        private DataGridViewTextBoxColumn TableName;
        private DataGridViewCheckBoxColumn GetAll;
        private DataGridViewCheckBoxColumn GetById;
        private DataGridViewCheckBoxColumn Save;
        private DataGridViewCheckBoxColumn Update;
        private DataGridViewCheckBoxColumn Delete;
    }
}