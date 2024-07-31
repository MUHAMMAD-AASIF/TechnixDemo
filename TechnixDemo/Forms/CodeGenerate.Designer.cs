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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeG));
            mainframe = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            Close = new Button();
            pictureBox1 = new PictureBox();
            Config = new Button();
            NewProject = new Button();
            panel3 = new Panel();
            ExistingProject = new Button();
            panel1 = new Panel();
            panel6 = new Panel();
            NewPanel = new Panel();
            NextBtn = new Button();
            SolNmTxt = new TextBox();
            label2 = new Label();
            ProcNmTxt = new TextBox();
            label4 = new Label();
            GenProcBtn = new Button();
            folderpathbtn = new Button();
            label1 = new Label();
            folderpathTxt = new TextBox();
            ExistingPanel = new Panel();
            ProjectDir = new Label();
            runEntity = new Button();
            SelServiceFPBtn = new Button();
            label7 = new Label();
            ServicePathTxt = new TextBox();
            SelModelFPBtn = new Button();
            label6 = new Label();
            ModelPathTxt = new TextBox();
            SelcontrollerFPBtn = new Button();
            label5 = new Label();
            ControllerPathTxt = new TextBox();
            ConStrTxt = new Label();
            panel5 = new Panel();
            ProcessProgress = new ProgressBar();
            StatusGrid = new DataGridView();
            Process = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            mainframe.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            NewPanel.SuspendLayout();
            ExistingPanel.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)StatusGrid).BeginInit();
            SuspendLayout();
            // 
            // mainframe
            // 
            mainframe.BackColor = Color.Khaki;
            mainframe.Controls.Add(panel2);
            mainframe.Controls.Add(pictureBox1);
            mainframe.Dock = DockStyle.Top;
            mainframe.Location = new Point(0, 0);
            mainframe.Name = "mainframe";
            mainframe.Size = new Size(681, 91);
            mainframe.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(420, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(261, 91);
            panel2.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Khaki;
            panel4.Controls.Add(Close);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(261, 24);
            panel4.TabIndex = 0;
            // 
            // Close
            // 
            Close.BackgroundImage = (Image)resources.GetObject("Close.BackgroundImage");
            Close.BackgroundImageLayout = ImageLayout.Stretch;
            Close.Dock = DockStyle.Right;
            Close.FlatAppearance.BorderSize = 0;
            Close.FlatStyle = FlatStyle.Flat;
            Close.Location = new Point(238, 0);
            Close.Name = "Close";
            Close.Size = new Size(23, 24);
            Close.TabIndex = 3;
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.logo_removebg_preview;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Config
            // 
            Config.BackgroundImage = Properties.Resources.server;
            Config.BackgroundImageLayout = ImageLayout.Stretch;
            Config.FlatAppearance.BorderSize = 0;
            Config.FlatStyle = FlatStyle.Flat;
            Config.Location = new Point(634, 19);
            Config.Name = "Config";
            Config.Size = new Size(23, 24);
            Config.TabIndex = 4;
            Config.UseVisualStyleBackColor = true;
            Config.Click += Config_Click;
            // 
            // NewProject
            // 
            NewProject.BackColor = Color.Khaki;
            NewProject.Dock = DockStyle.Left;
            NewProject.FlatAppearance.BorderSize = 0;
            NewProject.FlatStyle = FlatStyle.Flat;
            NewProject.Font = new Font("Sans Serif Collection", 8.25F, FontStyle.Regular, GraphicsUnit.Pixel);
            NewProject.Location = new Point(0, 0);
            NewProject.Name = "NewProject";
            NewProject.Size = new Size(341, 29);
            NewProject.TabIndex = 6;
            NewProject.Text = "New";
            NewProject.UseVisualStyleBackColor = false;
            NewProject.Click += NewProject_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(ExistingProject);
            panel3.Controls.Add(NewProject);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 91);
            panel3.Name = "panel3";
            panel3.Size = new Size(681, 29);
            panel3.TabIndex = 8;
            // 
            // ExistingProject
            // 
            ExistingProject.BackColor = Color.White;
            ExistingProject.Dock = DockStyle.Right;
            ExistingProject.FlatAppearance.BorderSize = 0;
            ExistingProject.FlatAppearance.MouseDownBackColor = Color.White;
            ExistingProject.FlatAppearance.MouseOverBackColor = Color.Khaki;
            ExistingProject.FlatStyle = FlatStyle.Flat;
            ExistingProject.Font = new Font("Sans Serif Collection", 8.25F, FontStyle.Regular, GraphicsUnit.Pixel);
            ExistingProject.Location = new Point(340, 0);
            ExistingProject.Name = "ExistingProject";
            ExistingProject.Size = new Size(341, 29);
            ExistingProject.TabIndex = 7;
            ExistingProject.Text = "Existing";
            ExistingProject.UseVisualStyleBackColor = false;
            ExistingProject.Click += ExistingProject_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(-9, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(690, 540);
            panel1.TabIndex = 30;
            // 
            // panel6
            // 
            panel6.Controls.Add(NewPanel);
            panel6.Controls.Add(ExistingPanel);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(690, 254);
            panel6.TabIndex = 32;
            // 
            // NewPanel
            // 
            NewPanel.BackColor = Color.White;
            NewPanel.Controls.Add(NextBtn);
            NewPanel.Controls.Add(SolNmTxt);
            NewPanel.Controls.Add(label2);
            NewPanel.Controls.Add(ProcNmTxt);
            NewPanel.Controls.Add(label4);
            NewPanel.Controls.Add(GenProcBtn);
            NewPanel.Controls.Add(folderpathbtn);
            NewPanel.Controls.Add(label1);
            NewPanel.Controls.Add(folderpathTxt);
            NewPanel.Dock = DockStyle.Left;
            NewPanel.Location = new Point(0, 0);
            NewPanel.Name = "NewPanel";
            NewPanel.Size = new Size(687, 254);
            NewPanel.TabIndex = 33;
            // 
            // NextBtn
            // 
            NextBtn.BackColor = SystemColors.ActiveCaptionText;
            NextBtn.FlatAppearance.BorderSize = 0;
            NextBtn.FlatStyle = FlatStyle.Flat;
            NextBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NextBtn.ForeColor = Color.White;
            NextBtn.Location = new Point(512, 486);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new Size(80, 23);
            NextBtn.TabIndex = 26;
            NextBtn.Text = "Next >>";
            NextBtn.UseVisualStyleBackColor = false;
            NextBtn.Visible = false;
            // 
            // SolNmTxt
            // 
            SolNmTxt.BackColor = Color.White;
            SolNmTxt.BorderStyle = BorderStyle.FixedSingle;
            SolNmTxt.Location = new Point(65, 51);
            SolNmTxt.Name = "SolNmTxt";
            SolNmTxt.Size = new Size(447, 23);
            SolNmTxt.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(65, 33);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 24;
            label2.Text = "Solution Name";
            // 
            // ProcNmTxt
            // 
            ProcNmTxt.BackColor = Color.White;
            ProcNmTxt.BorderStyle = BorderStyle.FixedSingle;
            ProcNmTxt.Location = new Point(67, 95);
            ProcNmTxt.Name = "ProcNmTxt";
            ProcNmTxt.Size = new Size(447, 23);
            ProcNmTxt.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(67, 77);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 21;
            label4.Text = "Project Name";
            // 
            // GenProcBtn
            // 
            GenProcBtn.BackColor = SystemColors.ActiveCaptionText;
            GenProcBtn.FlatAppearance.BorderSize = 0;
            GenProcBtn.FlatStyle = FlatStyle.Flat;
            GenProcBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GenProcBtn.ForeColor = Color.White;
            GenProcBtn.Location = new Point(227, 184);
            GenProcBtn.Name = "GenProcBtn";
            GenProcBtn.Size = new Size(127, 23);
            GenProcBtn.TabIndex = 12;
            GenProcBtn.Text = "Generate Project";
            GenProcBtn.UseVisualStyleBackColor = false;
            GenProcBtn.Click += GenProcBtn_Click;
            // 
            // folderpathbtn
            // 
            folderpathbtn.BackColor = SystemColors.ActiveCaptionText;
            folderpathbtn.FlatAppearance.BorderSize = 0;
            folderpathbtn.FlatStyle = FlatStyle.Flat;
            folderpathbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            folderpathbtn.ForeColor = Color.White;
            folderpathbtn.Location = new Point(512, 139);
            folderpathbtn.Name = "folderpathbtn";
            folderpathbtn.Size = new Size(62, 23);
            folderpathbtn.TabIndex = 17;
            folderpathbtn.Text = "Browse";
            folderpathbtn.UseVisualStyleBackColor = false;
            folderpathbtn.Click += folderpathbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(67, 121);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 15;
            label1.Text = "Select Path";
            // 
            // folderpathTxt
            // 
            folderpathTxt.BackColor = Color.White;
            folderpathTxt.BorderStyle = BorderStyle.FixedSingle;
            folderpathTxt.Location = new Point(65, 139);
            folderpathTxt.Name = "folderpathTxt";
            folderpathTxt.ReadOnly = true;
            folderpathTxt.Size = new Size(447, 23);
            folderpathTxt.TabIndex = 16;
            // 
            // ExistingPanel
            // 
            ExistingPanel.BackColor = Color.White;
            ExistingPanel.Controls.Add(ProjectDir);
            ExistingPanel.Controls.Add(runEntity);
            ExistingPanel.Controls.Add(Config);
            ExistingPanel.Controls.Add(SelServiceFPBtn);
            ExistingPanel.Controls.Add(label7);
            ExistingPanel.Controls.Add(ServicePathTxt);
            ExistingPanel.Controls.Add(SelModelFPBtn);
            ExistingPanel.Controls.Add(label6);
            ExistingPanel.Controls.Add(ModelPathTxt);
            ExistingPanel.Controls.Add(SelcontrollerFPBtn);
            ExistingPanel.Controls.Add(label5);
            ExistingPanel.Controls.Add(ControllerPathTxt);
            ExistingPanel.Controls.Add(ConStrTxt);
            ExistingPanel.Dock = DockStyle.Right;
            ExistingPanel.Location = new Point(21, 0);
            ExistingPanel.Name = "ExistingPanel";
            ExistingPanel.Size = new Size(669, 254);
            ExistingPanel.TabIndex = 31;
            ExistingPanel.Visible = false;
            // 
            // ProjectDir
            // 
            ProjectDir.AutoSize = true;
            ProjectDir.FlatStyle = FlatStyle.Flat;
            ProjectDir.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            ProjectDir.Location = new Point(634, 57);
            ProjectDir.Name = "ProjectDir";
            ProjectDir.Size = new Size(0, 15);
            ProjectDir.TabIndex = 34;
            ProjectDir.Visible = false;
            // 
            // runEntity
            // 
            runEntity.BackColor = SystemColors.ActiveCaptionText;
            runEntity.FlatAppearance.BorderSize = 0;
            runEntity.FlatStyle = FlatStyle.Flat;
            runEntity.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            runEntity.ForeColor = Color.White;
            runEntity.Location = new Point(486, 204);
            runEntity.Name = "runEntity";
            runEntity.Size = new Size(107, 23);
            runEntity.TabIndex = 33;
            runEntity.Text = "Run Entity";
            runEntity.UseVisualStyleBackColor = false;
            runEntity.Click += runEntity_Click;
            // 
            // SelServiceFPBtn
            // 
            SelServiceFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelServiceFPBtn.FlatAppearance.BorderSize = 0;
            SelServiceFPBtn.FlatStyle = FlatStyle.Flat;
            SelServiceFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelServiceFPBtn.ForeColor = Color.White;
            SelServiceFPBtn.Location = new Point(531, 153);
            SelServiceFPBtn.Name = "SelServiceFPBtn";
            SelServiceFPBtn.Size = new Size(62, 23);
            SelServiceFPBtn.TabIndex = 32;
            SelServiceFPBtn.Text = "Browse";
            SelServiceFPBtn.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(84, 134);
            label7.Name = "label7";
            label7.Size = new Size(97, 15);
            label7.TabIndex = 30;
            label7.Text = "Select Service Path";
            // 
            // ServicePathTxt
            // 
            ServicePathTxt.BackColor = Color.White;
            ServicePathTxt.BorderStyle = BorderStyle.FixedSingle;
            ServicePathTxt.Location = new Point(84, 153);
            ServicePathTxt.Name = "ServicePathTxt";
            ServicePathTxt.ReadOnly = true;
            ServicePathTxt.Size = new Size(447, 23);
            ServicePathTxt.TabIndex = 31;
            // 
            // SelModelFPBtn
            // 
            SelModelFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelModelFPBtn.FlatAppearance.BorderSize = 0;
            SelModelFPBtn.FlatStyle = FlatStyle.Flat;
            SelModelFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelModelFPBtn.ForeColor = Color.White;
            SelModelFPBtn.Location = new Point(531, 96);
            SelModelFPBtn.Name = "SelModelFPBtn";
            SelModelFPBtn.Size = new Size(62, 23);
            SelModelFPBtn.TabIndex = 29;
            SelModelFPBtn.Text = "Browse";
            SelModelFPBtn.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(84, 78);
            label6.Name = "label6";
            label6.Size = new Size(91, 15);
            label6.TabIndex = 27;
            label6.Text = "Select Model Path";
            // 
            // ModelPathTxt
            // 
            ModelPathTxt.BackColor = Color.White;
            ModelPathTxt.BorderStyle = BorderStyle.FixedSingle;
            ModelPathTxt.Location = new Point(84, 96);
            ModelPathTxt.Name = "ModelPathTxt";
            ModelPathTxt.ReadOnly = true;
            ModelPathTxt.Size = new Size(447, 23);
            ModelPathTxt.TabIndex = 28;
            // 
            // SelcontrollerFPBtn
            // 
            SelcontrollerFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelcontrollerFPBtn.FlatAppearance.BorderSize = 0;
            SelcontrollerFPBtn.FlatStyle = FlatStyle.Flat;
            SelcontrollerFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelcontrollerFPBtn.ForeColor = Color.White;
            SelcontrollerFPBtn.Location = new Point(531, 40);
            SelcontrollerFPBtn.Name = "SelcontrollerFPBtn";
            SelcontrollerFPBtn.Size = new Size(62, 23);
            SelcontrollerFPBtn.TabIndex = 26;
            SelcontrollerFPBtn.Text = "Browse";
            SelcontrollerFPBtn.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(84, 22);
            label5.Name = "label5";
            label5.Size = new Size(106, 15);
            label5.TabIndex = 24;
            label5.Text = "Select Controller Path";
            // 
            // ControllerPathTxt
            // 
            ControllerPathTxt.BackColor = Color.White;
            ControllerPathTxt.BorderStyle = BorderStyle.FixedSingle;
            ControllerPathTxt.Location = new Point(84, 40);
            ControllerPathTxt.Name = "ControllerPathTxt";
            ControllerPathTxt.ReadOnly = true;
            ControllerPathTxt.Size = new Size(447, 23);
            ControllerPathTxt.TabIndex = 25;
            // 
            // ConStrTxt
            // 
            ConStrTxt.AutoSize = true;
            ConStrTxt.FlatStyle = FlatStyle.Flat;
            ConStrTxt.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            ConStrTxt.Location = new Point(646, 57);
            ConStrTxt.Name = "ConStrTxt";
            ConStrTxt.Size = new Size(0, 15);
            ConStrTxt.TabIndex = 23;
            ConStrTxt.Visible = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(ProcessProgress);
            panel5.Controls.Add(StatusGrid);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 252);
            panel5.Name = "panel5";
            panel5.Size = new Size(690, 288);
            panel5.TabIndex = 31;
            // 
            // ProcessProgress
            // 
            ProcessProgress.Location = new Point(93, 221);
            ProcessProgress.Name = "ProcessProgress";
            ProcessProgress.Size = new Size(509, 10);
            ProcessProgress.TabIndex = 36;
            // 
            // StatusGrid
            // 
            StatusGrid.AllowUserToAddRows = false;
            StatusGrid.AllowUserToDeleteRows = false;
            StatusGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            StatusGrid.BackgroundColor = Color.White;
            StatusGrid.BorderStyle = BorderStyle.None;
            StatusGrid.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            StatusGrid.ColumnHeadersHeight = 21;
            StatusGrid.Columns.AddRange(new DataGridViewColumn[] { Process, Status });
            StatusGrid.GridColor = Color.White;
            StatusGrid.Location = new Point(93, 23);
            StatusGrid.Name = "StatusGrid";
            StatusGrid.ReadOnly = true;
            StatusGrid.RowHeadersWidth = 62;
            StatusGrid.RowTemplate.Height = 25;
            StatusGrid.ShowEditingIcon = false;
            StatusGrid.Size = new Size(509, 194);
            StatusGrid.TabIndex = 35;
            // 
            // Process
            // 
            Process.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Process.HeaderText = "Process Name";
            Process.MinimumWidth = 8;
            Process.Name = "Process";
            Process.ReadOnly = true;
            Process.Width = 360;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 64;
            // 
            // CodeG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(681, 660);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(mainframe);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CodeG";
            mainframe.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            NewPanel.ResumeLayout(false);
            NewPanel.PerformLayout();
            ExistingPanel.ResumeLayout(false);
            ExistingPanel.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)StatusGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel mainframe;
        private PictureBox pictureBox1;
        private Button NewProject;
        private Panel panel3;
        private Button ExistingProject;
        private Panel panel2;
        private Panel panel4;
        private Button Close;
        private Panel panel1;
        private Panel panel6;
        private Panel ExistingPanel;
        private Button SelServiceFPBtn;
        private Label label7;
        private TextBox ServicePathTxt;
        private Button SelModelFPBtn;
        private Label label6;
        private TextBox ModelPathTxt;
        private Button SelcontrollerFPBtn;
        private Label label5;
        private TextBox ControllerPathTxt;
        private Label ConStrTxt;
        private Button Config;
        private Panel panel5;
        private ProgressBar ProcessProgress;
        private DataGridView StatusGrid;
        private DataGridViewTextBoxColumn Process;
        private DataGridViewTextBoxColumn Status;
        private Panel NewPanel;
        private Button NextBtn;
        private TextBox SolNmTxt;
        private Label label2;
        private TextBox ProcNmTxt;
        private Label label4;
        private Button GenProcBtn;
        private Button folderpathbtn;
        private Label label1;
        private TextBox folderpathTxt;
        private Button runEntity;
        private Label ProjectDir;
    }
}