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
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
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
            button1 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
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
            mainframe.Margin = new Padding(4, 5, 4, 5);
            mainframe.Name = "mainframe";
            mainframe.Size = new Size(973, 142);
            mainframe.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Khaki;
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(600, 0);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(373, 142);
            panel2.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Khaki;
            panel4.Controls.Add(Close);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 5, 4, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(373, 40);
            panel4.TabIndex = 0;
            // 
            // Close
            // 
            Close.BackgroundImage = (Image)resources.GetObject("Close.BackgroundImage");
            Close.BackgroundImageLayout = ImageLayout.Stretch;
            Close.Dock = DockStyle.Right;
            Close.FlatAppearance.BorderSize = 0;
            Close.FlatStyle = FlatStyle.Flat;
            Close.Location = new Point(338, 0);
            Close.Margin = new Padding(4, 5, 4, 5);
            Close.Name = "Close";
            Close.Size = new Size(35, 40);
            Close.TabIndex = 3;
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_removebg_preview;
            pictureBox1.Location = new Point(26, 5);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(156, 138);
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
            Config.Location = new Point(923, 10);
            Config.Margin = new Padding(4, 5, 4, 5);
            Config.Name = "Config";
            Config.Size = new Size(33, 40);
            Config.TabIndex = 4;
            Config.UseVisualStyleBackColor = true;
            Config.Click += Config_Click;
            // 
            // NewProject
            // 
            NewProject.BackColor = Color.Khaki;
            NewProject.Dock = DockStyle.Left;
            NewProject.FlatAppearance.BorderSize = 0;
            NewProject.FlatAppearance.MouseDownBackColor = Color.White;
            NewProject.FlatAppearance.MouseOverBackColor = Color.Khaki;
            NewProject.FlatStyle = FlatStyle.Flat;
            NewProject.Font = new Font("Sans Serif Collection", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            NewProject.Location = new Point(0, 0);
            NewProject.Margin = new Padding(4, 5, 4, 5);
            NewProject.Name = "NewProject";
            NewProject.Size = new Size(487, 48);
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
            panel3.Location = new Point(0, 142);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(973, 48);
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
            ExistingProject.Font = new Font("Sans Serif Collection", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            ExistingProject.Location = new Point(486, 0);
            ExistingProject.Margin = new Padding(4, 5, 4, 5);
            ExistingProject.Name = "ExistingProject";
            ExistingProject.Size = new Size(487, 48);
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
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 190);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(973, 565);
            panel1.TabIndex = 30;
            // 
            // panel6
            // 
            panel6.Controls.Add(NewPanel);
            panel6.Controls.Add(ExistingPanel);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(4, 5, 4, 5);
            panel6.Name = "panel6";
            panel6.Size = new Size(973, 271);
            panel6.TabIndex = 32;
            // 
            // NewPanel
            // 
            NewPanel.BackColor = Color.White;
            NewPanel.Controls.Add(checkBox3);
            NewPanel.Controls.Add(checkBox2);
            NewPanel.Controls.Add(checkBox1);
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
            NewPanel.Margin = new Padding(4, 5, 4, 5);
            NewPanel.Name = "NewPanel";
            NewPanel.Size = new Size(969, 271);
            NewPanel.TabIndex = 33;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(357, 167);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(83, 29);
            checkBox3.TabIndex = 29;
            checkBox3.Text = "NUnit";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(237, 167);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(65, 29);
            checkBox2.TabIndex = 28;
            checkBox2.Text = "API";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(96, 167);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(86, 29);
            checkBox1.TabIndex = 27;
            checkBox1.Text = "Blazor";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // NextBtn
            // 
            NextBtn.BackColor = SystemColors.ActiveCaptionText;
            NextBtn.FlatAppearance.BorderSize = 0;
            NextBtn.FlatStyle = FlatStyle.Flat;
            NextBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NextBtn.ForeColor = Color.White;
            NextBtn.Location = new Point(731, 810);
            NextBtn.Margin = new Padding(4, 5, 4, 5);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new Size(114, 38);
            NextBtn.TabIndex = 26;
            NextBtn.Text = "Next >>";
            NextBtn.UseVisualStyleBackColor = false;
            NextBtn.Visible = false;
            // 
            // SolNmTxt
            // 
            SolNmTxt.BackColor = Color.White;
            SolNmTxt.BorderStyle = BorderStyle.FixedSingle;
            SolNmTxt.Location = new Point(93, 85);
            SolNmTxt.Margin = new Padding(4, 5, 4, 5);
            SolNmTxt.Name = "SolNmTxt";
            SolNmTxt.Size = new Size(350, 31);
            SolNmTxt.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(93, 55);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 24;
            label2.Text = "Solution Name";
            // 
            // ProcNmTxt
            // 
            ProcNmTxt.BackColor = Color.White;
            ProcNmTxt.BorderStyle = BorderStyle.FixedSingle;
            ProcNmTxt.Location = new Point(514, 85);
            ProcNmTxt.Margin = new Padding(4, 5, 4, 5);
            ProcNmTxt.Name = "ProcNmTxt";
            ProcNmTxt.Size = new Size(408, 31);
            ProcNmTxt.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(514, 55);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
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
            GenProcBtn.Location = new Point(802, 223);
            GenProcBtn.Margin = new Padding(4, 5, 4, 5);
            GenProcBtn.Name = "GenProcBtn";
            GenProcBtn.Size = new Size(116, 38);
            GenProcBtn.TabIndex = 12;
            GenProcBtn.Text = "Generate";
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
            folderpathbtn.Location = new Point(870, 166);
            folderpathbtn.Margin = new Padding(4, 5, 4, 5);
            folderpathbtn.Name = "folderpathbtn";
            folderpathbtn.Size = new Size(50, 33);
            folderpathbtn.TabIndex = 17;
            folderpathbtn.Text = "....";
            folderpathbtn.UseVisualStyleBackColor = false;
            folderpathbtn.Click += folderpathbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(521, 142);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 15;
            label1.Text = "Select Path";
            // 
            // folderpathTxt
            // 
            folderpathTxt.BackColor = Color.White;
            folderpathTxt.BorderStyle = BorderStyle.FixedSingle;
            folderpathTxt.Location = new Point(519, 167);
            folderpathTxt.Margin = new Padding(4, 5, 4, 5);
            folderpathTxt.Name = "folderpathTxt";
            folderpathTxt.ReadOnly = true;
            folderpathTxt.Size = new Size(351, 31);
            folderpathTxt.TabIndex = 16;
            // 
            // ExistingPanel
            // 
            ExistingPanel.BackColor = Color.White;
            ExistingPanel.Controls.Add(button1);
            ExistingPanel.Controls.Add(Config);
            ExistingPanel.Controls.Add(label3);
            ExistingPanel.Controls.Add(textBox1);
            ExistingPanel.Controls.Add(ProjectDir);
            ExistingPanel.Controls.Add(runEntity);
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
            ExistingPanel.Location = new Point(4, 0);
            ExistingPanel.Margin = new Padding(4, 5, 4, 5);
            ExistingPanel.Name = "ExistingPanel";
            ExistingPanel.Size = new Size(969, 271);
            ExistingPanel.TabIndex = 31;
            ExistingPanel.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(853, 147);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(50, 33);
            button1.TabIndex = 37;
            button1.Text = "....";
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(503, 123);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 20);
            label3.TabIndex = 35;
            label3.Text = "Select Interface Path";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(503, 148);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(350, 31);
            textBox1.TabIndex = 36;
            // 
            // ProjectDir
            // 
            ProjectDir.AutoSize = true;
            ProjectDir.FlatStyle = FlatStyle.Flat;
            ProjectDir.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            ProjectDir.Location = new Point(906, 95);
            ProjectDir.Margin = new Padding(4, 0, 4, 0);
            ProjectDir.Name = "ProjectDir";
            ProjectDir.Size = new Size(0, 20);
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
            runEntity.Location = new Point(793, 209);
            runEntity.Margin = new Padding(4, 5, 4, 5);
            runEntity.Name = "runEntity";
            runEntity.Size = new Size(109, 38);
            runEntity.TabIndex = 33;
            runEntity.Text = "Entity";
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
            SelServiceFPBtn.Location = new Point(417, 148);
            SelServiceFPBtn.Margin = new Padding(4, 5, 4, 5);
            SelServiceFPBtn.Name = "SelServiceFPBtn";
            SelServiceFPBtn.Size = new Size(50, 32);
            SelServiceFPBtn.TabIndex = 32;
            SelServiceFPBtn.Text = "....";
            SelServiceFPBtn.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(67, 123);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(143, 20);
            label7.TabIndex = 30;
            label7.Text = "Select Service Path";
            // 
            // ServicePathTxt
            // 
            ServicePathTxt.BackColor = Color.White;
            ServicePathTxt.BorderStyle = BorderStyle.FixedSingle;
            ServicePathTxt.Location = new Point(67, 148);
            ServicePathTxt.Margin = new Padding(4, 5, 4, 5);
            ServicePathTxt.Name = "ServicePathTxt";
            ServicePathTxt.ReadOnly = true;
            ServicePathTxt.Size = new Size(350, 31);
            ServicePathTxt.TabIndex = 31;
            // 
            // SelModelFPBtn
            // 
            SelModelFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelModelFPBtn.FlatAppearance.BorderSize = 0;
            SelModelFPBtn.FlatStyle = FlatStyle.Flat;
            SelModelFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelModelFPBtn.ForeColor = Color.White;
            SelModelFPBtn.Location = new Point(852, 72);
            SelModelFPBtn.Margin = new Padding(4, 5, 4, 5);
            SelModelFPBtn.Name = "SelModelFPBtn";
            SelModelFPBtn.Size = new Size(50, 33);
            SelModelFPBtn.TabIndex = 29;
            SelModelFPBtn.Text = "....";
            SelModelFPBtn.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(503, 48);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(134, 20);
            label6.TabIndex = 27;
            label6.Text = "Select Model Path";
            // 
            // ModelPathTxt
            // 
            ModelPathTxt.BackColor = Color.White;
            ModelPathTxt.BorderStyle = BorderStyle.FixedSingle;
            ModelPathTxt.Location = new Point(503, 73);
            ModelPathTxt.Margin = new Padding(4, 5, 4, 5);
            ModelPathTxt.Name = "ModelPathTxt";
            ModelPathTxt.ReadOnly = true;
            ModelPathTxt.Size = new Size(350, 31);
            ModelPathTxt.TabIndex = 28;
            // 
            // SelcontrollerFPBtn
            // 
            SelcontrollerFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelcontrollerFPBtn.FlatAppearance.BorderSize = 0;
            SelcontrollerFPBtn.FlatStyle = FlatStyle.Flat;
            SelcontrollerFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelcontrollerFPBtn.ForeColor = Color.White;
            SelcontrollerFPBtn.Location = new Point(417, 71);
            SelcontrollerFPBtn.Margin = new Padding(4, 5, 4, 5);
            SelcontrollerFPBtn.Name = "SelcontrollerFPBtn";
            SelcontrollerFPBtn.Size = new Size(50, 33);
            SelcontrollerFPBtn.TabIndex = 26;
            SelcontrollerFPBtn.Text = "....";
            SelcontrollerFPBtn.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(67, 47);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(159, 20);
            label5.TabIndex = 24;
            label5.Text = "Select Controller Path";
            // 
            // ControllerPathTxt
            // 
            ControllerPathTxt.BackColor = Color.White;
            ControllerPathTxt.BorderStyle = BorderStyle.FixedSingle;
            ControllerPathTxt.Location = new Point(67, 72);
            ControllerPathTxt.Margin = new Padding(4, 5, 4, 5);
            ControllerPathTxt.Name = "ControllerPathTxt";
            ControllerPathTxt.ReadOnly = true;
            ControllerPathTxt.Size = new Size(350, 31);
            ControllerPathTxt.TabIndex = 25;
            // 
            // ConStrTxt
            // 
            ConStrTxt.AutoSize = true;
            ConStrTxt.FlatStyle = FlatStyle.Flat;
            ConStrTxt.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            ConStrTxt.Location = new Point(923, 95);
            ConStrTxt.Margin = new Padding(4, 0, 4, 0);
            ConStrTxt.Name = "ConStrTxt";
            ConStrTxt.Size = new Size(0, 20);
            ConStrTxt.TabIndex = 23;
            ConStrTxt.Visible = false;
            // 
            // panel5
            // 
            panel5.Controls.Add(ProcessProgress);
            panel5.Controls.Add(StatusGrid);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 271);
            panel5.Margin = new Padding(4, 5, 4, 5);
            panel5.Name = "panel5";
            panel5.Size = new Size(973, 294);
            panel5.TabIndex = 31;
            // 
            // ProcessProgress
            // 
            ProcessProgress.Location = new Point(118, 272);
            ProcessProgress.Margin = new Padding(4, 5, 4, 5);
            ProcessProgress.MarqueeAnimationSpeed = 80;
            ProcessProgress.Name = "ProcessProgress";
            ProcessProgress.Size = new Size(727, 16);
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
            StatusGrid.ColumnHeadersHeight = 31;
            StatusGrid.Columns.AddRange(new DataGridViewColumn[] { Process, Status });
            StatusGrid.GridColor = Color.White;
            StatusGrid.Location = new Point(118, 10);
            StatusGrid.Margin = new Padding(4, 5, 4, 5);
            StatusGrid.Name = "StatusGrid";
            StatusGrid.ReadOnly = true;
            StatusGrid.RowHeadersWidth = 62;
            StatusGrid.RowTemplate.Height = 25;
            StatusGrid.ShowEditingIcon = false;
            StatusGrid.Size = new Size(727, 255);
            StatusGrid.TabIndex = 35;
            // 
            // Process
            // 
            Process.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Process.HeaderText = "Process Name";
            Process.MinimumWidth = 8;
            Process.Name = "Process";
            Process.ReadOnly = true;
            Process.Width = 510;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Status.HeaderText = "Status";
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 150;
            // 
            // CodeG
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(973, 783);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(mainframe);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
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
        private DataGridViewTextBoxColumn Process;
        private DataGridViewTextBoxColumn Status;
        private Button button1;
        private Label label3;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
    }
}