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
            NewProject = new Button();
            panel3 = new Panel();
            ExistingProject = new Button();
            panel1 = new Panel();
            panel6 = new Panel();
            NewPanel = new Panel();
            FrontPanel = new Panel();
            SolNmTxt = new TextBox();
            label2 = new Label();
            ProcNmTxt = new TextBox();
            label4 = new Label();
            GenProcBtn = new Button();
            folderpathbtn = new Button();
            label1 = new Label();
            folderpathTxt = new TextBox();
            GetPathBtn = new Button();
            GetPathFPBtn = new Button();
            label12 = new Label();
            SolutionPath = new TextBox();
            SelBusinessTstFPBtn = new Button();
            label10 = new Label();
            BusinessTestPathTxt = new TextBox();
            SelApiTestFPBtn = new Button();
            label11 = new Label();
            APITestPathTxt = new TextBox();
            SelDaCFPBtn = new Button();
            label8 = new Label();
            DataContractPathTxt = new TextBox();
            SelDAFPBtn = new Button();
            label9 = new Label();
            DataAccessPathTxt = new TextBox();
            SelCommonMdFPBtn = new Button();
            label3 = new Label();
            CommonModelPathTxt = new TextBox();
            runEntity = new Button();
            SelBusinessCnFPBtn = new Button();
            label7 = new Label();
            BusinessContractPathTxt = new TextBox();
            SelBusinessFPBtn = new Button();
            label6 = new Label();
            BusinessPathTxt = new TextBox();
            SelApiFPBtn = new Button();
            label5 = new Label();
            APIPathTxt = new TextBox();
            NextBtn = new Button();
            ExistingPanel = new Panel();
            ProcessProgress = new ProgressBar();
            StatusGrid = new DataGridView();
            Process = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ProjectDir = new Label();
            ConStrTxt = new Label();
            mainframe.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            NewPanel.SuspendLayout();
            FrontPanel.SuspendLayout();
            ExistingPanel.SuspendLayout();
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
            mainframe.Size = new Size(681, 79);
            mainframe.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Khaki;
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(420, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(261, 79);
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
            Close.Location = new Point(237, 0);
            Close.Name = "Close";
            Close.Size = new Size(24, 24);
            Close.TabIndex = 3;
            Close.UseVisualStyleBackColor = true;
            Close.Click += Close_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_removebg_preview;
            pictureBox1.Location = new Point(18, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 83);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // NewProject
            // 
            NewProject.BackColor = Color.Khaki;
            NewProject.Dock = DockStyle.Left;
            NewProject.FlatAppearance.BorderSize = 0;
            NewProject.FlatAppearance.MouseDownBackColor = Color.White;
            NewProject.FlatAppearance.MouseOverBackColor = Color.Khaki;
            NewProject.FlatStyle = FlatStyle.Flat;
            NewProject.Font = new Font("Sans Serif Collection", 10F, FontStyle.Regular, GraphicsUnit.Pixel);
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
            panel3.Location = new Point(0, 79);
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
            ExistingProject.Font = new Font("Sans Serif Collection", 10F, FontStyle.Regular, GraphicsUnit.Pixel);
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
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(681, 434);
            panel1.TabIndex = 30;
            // 
            // panel6
            // 
            panel6.Controls.Add(NewPanel);
            panel6.Controls.Add(ExistingPanel);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(681, 418);
            panel6.TabIndex = 32;
            // 
            // NewPanel
            // 
            NewPanel.BackColor = Color.White;
            NewPanel.Controls.Add(FrontPanel);
            NewPanel.Controls.Add(GetPathBtn);
            NewPanel.Controls.Add(GetPathFPBtn);
            NewPanel.Controls.Add(label12);
            NewPanel.Controls.Add(SolutionPath);
            NewPanel.Controls.Add(SelBusinessTstFPBtn);
            NewPanel.Controls.Add(label10);
            NewPanel.Controls.Add(BusinessTestPathTxt);
            NewPanel.Controls.Add(SelApiTestFPBtn);
            NewPanel.Controls.Add(label11);
            NewPanel.Controls.Add(APITestPathTxt);
            NewPanel.Controls.Add(SelDaCFPBtn);
            NewPanel.Controls.Add(label8);
            NewPanel.Controls.Add(DataContractPathTxt);
            NewPanel.Controls.Add(SelDAFPBtn);
            NewPanel.Controls.Add(label9);
            NewPanel.Controls.Add(DataAccessPathTxt);
            NewPanel.Controls.Add(SelCommonMdFPBtn);
            NewPanel.Controls.Add(label3);
            NewPanel.Controls.Add(CommonModelPathTxt);
            NewPanel.Controls.Add(runEntity);
            NewPanel.Controls.Add(SelBusinessCnFPBtn);
            NewPanel.Controls.Add(label7);
            NewPanel.Controls.Add(BusinessContractPathTxt);
            NewPanel.Controls.Add(SelBusinessFPBtn);
            NewPanel.Controls.Add(label6);
            NewPanel.Controls.Add(BusinessPathTxt);
            NewPanel.Controls.Add(SelApiFPBtn);
            NewPanel.Controls.Add(label5);
            NewPanel.Controls.Add(APIPathTxt);
            NewPanel.Controls.Add(NextBtn);
            NewPanel.Dock = DockStyle.Left;
            NewPanel.Location = new Point(0, 0);
            NewPanel.Name = "NewPanel";
            NewPanel.Size = new Size(663, 418);
            NewPanel.TabIndex = 33;
            // 
            // FrontPanel
            // 
            FrontPanel.Controls.Add(SolNmTxt);
            FrontPanel.Controls.Add(label2);
            FrontPanel.Controls.Add(ProcNmTxt);
            FrontPanel.Controls.Add(label4);
            FrontPanel.Controls.Add(GenProcBtn);
            FrontPanel.Controls.Add(folderpathbtn);
            FrontPanel.Controls.Add(label1);
            FrontPanel.Controls.Add(folderpathTxt);
            FrontPanel.Dock = DockStyle.Left;
            FrontPanel.Location = new Point(0, 0);
            FrontPanel.Name = "FrontPanel";
            FrontPanel.Size = new Size(660, 418);
            FrontPanel.TabIndex = 74;
            // 
            // SolNmTxt
            // 
            SolNmTxt.BackColor = Color.White;
            SolNmTxt.BorderStyle = BorderStyle.FixedSingle;
            SolNmTxt.Location = new Point(35, 40);
            SolNmTxt.Name = "SolNmTxt";
            SolNmTxt.Size = new Size(579, 23);
            SolNmTxt.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(37, 22);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 32;
            label2.Text = "Solution Name";
            // 
            // ProcNmTxt
            // 
            ProcNmTxt.BackColor = Color.White;
            ProcNmTxt.BorderStyle = BorderStyle.FixedSingle;
            ProcNmTxt.Location = new Point(35, 104);
            ProcNmTxt.Name = "ProcNmTxt";
            ProcNmTxt.Size = new Size(579, 23);
            ProcNmTxt.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(37, 86);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 30;
            label4.Text = "Project Name";
            // 
            // GenProcBtn
            // 
            GenProcBtn.BackColor = SystemColors.ActiveCaptionText;
            GenProcBtn.FlatAppearance.BorderSize = 0;
            GenProcBtn.FlatStyle = FlatStyle.Flat;
            GenProcBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GenProcBtn.ForeColor = Color.White;
            GenProcBtn.Location = new Point(531, 223);
            GenProcBtn.Name = "GenProcBtn";
            GenProcBtn.Size = new Size(81, 23);
            GenProcBtn.TabIndex = 26;
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
            folderpathbtn.Location = new Point(579, 168);
            folderpathbtn.Name = "folderpathbtn";
            folderpathbtn.Size = new Size(35, 23);
            folderpathbtn.TabIndex = 29;
            folderpathbtn.Text = "....";
            folderpathbtn.UseVisualStyleBackColor = false;
            folderpathbtn.Click += folderpathbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(37, 150);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 27;
            label1.Text = "Select Path";
            // 
            // folderpathTxt
            // 
            folderpathTxt.BackColor = Color.White;
            folderpathTxt.BorderStyle = BorderStyle.FixedSingle;
            folderpathTxt.Location = new Point(35, 168);
            folderpathTxt.Name = "folderpathTxt";
            folderpathTxt.ReadOnly = true;
            folderpathTxt.Size = new Size(544, 23);
            folderpathTxt.TabIndex = 28;
            // 
            // GetPathBtn
            // 
            GetPathBtn.BackColor = SystemColors.ActiveCaptionText;
            GetPathBtn.FlatAppearance.BorderSize = 0;
            GetPathBtn.FlatStyle = FlatStyle.Flat;
            GetPathBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GetPathBtn.ForeColor = Color.White;
            GetPathBtn.Location = new Point(566, 83);
            GetPathBtn.Name = "GetPathBtn";
            GetPathBtn.Size = new Size(76, 23);
            GetPathBtn.TabIndex = 73;
            GetPathBtn.Text = "Get Path";
            GetPathBtn.UseVisualStyleBackColor = false;
            GetPathBtn.Click += GetPathBtn_Click;
            // 
            // GetPathFPBtn
            // 
            GetPathFPBtn.BackColor = SystemColors.ActiveCaptionText;
            GetPathFPBtn.FlatAppearance.BorderSize = 0;
            GetPathFPBtn.FlatStyle = FlatStyle.Flat;
            GetPathFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            GetPathFPBtn.ForeColor = Color.White;
            GetPathFPBtn.Location = new Point(604, 49);
            GetPathFPBtn.Name = "GetPathFPBtn";
            GetPathFPBtn.Size = new Size(35, 23);
            GetPathFPBtn.TabIndex = 72;
            GetPathFPBtn.Text = "....";
            GetPathFPBtn.UseVisualStyleBackColor = false;
            GetPathFPBtn.Click += GetPathFPBtn_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.FlatStyle = FlatStyle.Flat;
            label12.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(54, 34);
            label12.Name = "label12";
            label12.Size = new Size(100, 15);
            label12.TabIndex = 70;
            label12.Text = "Select Solution Path";
            // 
            // SolutionPath
            // 
            SolutionPath.BackColor = Color.White;
            SolutionPath.BorderStyle = BorderStyle.FixedSingle;
            SolutionPath.Location = new Point(54, 49);
            SolutionPath.Name = "SolutionPath";
            SolutionPath.Size = new Size(551, 23);
            SolutionPath.TabIndex = 71;
            // 
            // SelBusinessTstFPBtn
            // 
            SelBusinessTstFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelBusinessTstFPBtn.FlatAppearance.BorderSize = 0;
            SelBusinessTstFPBtn.FlatStyle = FlatStyle.Flat;
            SelBusinessTstFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelBusinessTstFPBtn.ForeColor = Color.White;
            SelBusinessTstFPBtn.Location = new Point(605, 290);
            SelBusinessTstFPBtn.Name = "SelBusinessTstFPBtn";
            SelBusinessTstFPBtn.Size = new Size(35, 23);
            SelBusinessTstFPBtn.TabIndex = 69;
            SelBusinessTstFPBtn.Text = "....";
            SelBusinessTstFPBtn.UseVisualStyleBackColor = false;
            SelBusinessTstFPBtn.Click += SelBusinessTstFPBtn_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.FlatStyle = FlatStyle.Flat;
            label10.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(359, 275);
            label10.Name = "label10";
            label10.Size = new Size(125, 15);
            label10.TabIndex = 67;
            label10.Text = "Select Business Test Path";
            // 
            // BusinessTestPathTxt
            // 
            BusinessTestPathTxt.BackColor = Color.White;
            BusinessTestPathTxt.BorderStyle = BorderStyle.FixedSingle;
            BusinessTestPathTxt.Location = new Point(359, 290);
            BusinessTestPathTxt.Name = "BusinessTestPathTxt";
            BusinessTestPathTxt.Size = new Size(246, 23);
            BusinessTestPathTxt.TabIndex = 68;
            // 
            // SelApiTestFPBtn
            // 
            SelApiTestFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelApiTestFPBtn.FlatAppearance.BorderSize = 0;
            SelApiTestFPBtn.FlatStyle = FlatStyle.Flat;
            SelApiTestFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelApiTestFPBtn.ForeColor = Color.White;
            SelApiTestFPBtn.Location = new Point(299, 290);
            SelApiTestFPBtn.Name = "SelApiTestFPBtn";
            SelApiTestFPBtn.Size = new Size(35, 23);
            SelApiTestFPBtn.TabIndex = 66;
            SelApiTestFPBtn.Text = "....";
            SelApiTestFPBtn.UseVisualStyleBackColor = false;
            SelApiTestFPBtn.Click += SelApiTestFPBtn_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.FlatStyle = FlatStyle.Flat;
            label11.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(54, 275);
            label11.Name = "label11";
            label11.Size = new Size(100, 15);
            label11.TabIndex = 64;
            label11.Text = "Select API Test Path";
            // 
            // APITestPathTxt
            // 
            APITestPathTxt.BackColor = Color.White;
            APITestPathTxt.BorderStyle = BorderStyle.FixedSingle;
            APITestPathTxt.Location = new Point(54, 290);
            APITestPathTxt.Name = "APITestPathTxt";
            APITestPathTxt.Size = new Size(246, 23);
            APITestPathTxt.TabIndex = 65;
            // 
            // SelDaCFPBtn
            // 
            SelDaCFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelDaCFPBtn.FlatAppearance.BorderSize = 0;
            SelDaCFPBtn.FlatStyle = FlatStyle.Flat;
            SelDaCFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelDaCFPBtn.ForeColor = Color.White;
            SelDaCFPBtn.Location = new Point(605, 238);
            SelDaCFPBtn.Name = "SelDaCFPBtn";
            SelDaCFPBtn.Size = new Size(35, 23);
            SelDaCFPBtn.TabIndex = 62;
            SelDaCFPBtn.Text = "....";
            SelDaCFPBtn.UseVisualStyleBackColor = false;
            SelDaCFPBtn.Click += SelDaCFPBtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(359, 223);
            label8.Name = "label8";
            label8.Size = new Size(166, 15);
            label8.TabIndex = 60;
            label8.Text = "Select Data Access Contracts Path";
            // 
            // DataContractPathTxt
            // 
            DataContractPathTxt.BackColor = Color.White;
            DataContractPathTxt.BorderStyle = BorderStyle.FixedSingle;
            DataContractPathTxt.Location = new Point(359, 238);
            DataContractPathTxt.Name = "DataContractPathTxt";
            DataContractPathTxt.Size = new Size(246, 23);
            DataContractPathTxt.TabIndex = 61;
            // 
            // SelDAFPBtn
            // 
            SelDAFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelDAFPBtn.FlatAppearance.BorderSize = 0;
            SelDAFPBtn.FlatStyle = FlatStyle.Flat;
            SelDAFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelDAFPBtn.ForeColor = Color.White;
            SelDAFPBtn.Location = new Point(299, 238);
            SelDAFPBtn.Name = "SelDAFPBtn";
            SelDAFPBtn.Size = new Size(35, 23);
            SelDAFPBtn.TabIndex = 59;
            SelDAFPBtn.Text = "....";
            SelDAFPBtn.UseVisualStyleBackColor = false;
            SelDAFPBtn.Click += SelDAFPBtn_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.FlatStyle = FlatStyle.Flat;
            label9.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(54, 223);
            label9.Name = "label9";
            label9.Size = new Size(120, 15);
            label9.TabIndex = 57;
            label9.Text = "Select Data Access Path";
            // 
            // DataAccessPathTxt
            // 
            DataAccessPathTxt.BackColor = Color.White;
            DataAccessPathTxt.BorderStyle = BorderStyle.FixedSingle;
            DataAccessPathTxt.Location = new Point(54, 238);
            DataAccessPathTxt.Name = "DataAccessPathTxt";
            DataAccessPathTxt.Size = new Size(246, 23);
            DataAccessPathTxt.TabIndex = 58;
            // 
            // SelCommonMdFPBtn
            // 
            SelCommonMdFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelCommonMdFPBtn.FlatAppearance.BorderSize = 0;
            SelCommonMdFPBtn.FlatStyle = FlatStyle.Flat;
            SelCommonMdFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelCommonMdFPBtn.ForeColor = Color.White;
            SelCommonMdFPBtn.Location = new Point(604, 192);
            SelCommonMdFPBtn.Name = "SelCommonMdFPBtn";
            SelCommonMdFPBtn.Size = new Size(35, 23);
            SelCommonMdFPBtn.TabIndex = 56;
            SelCommonMdFPBtn.Text = "....";
            SelCommonMdFPBtn.UseVisualStyleBackColor = false;
            SelCommonMdFPBtn.Click += SelCommonMdFPBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(359, 177);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 54;
            label3.Text = "Select Common Model Path";
            // 
            // CommonModelPathTxt
            // 
            CommonModelPathTxt.BackColor = Color.White;
            CommonModelPathTxt.BorderStyle = BorderStyle.FixedSingle;
            CommonModelPathTxt.Location = new Point(359, 192);
            CommonModelPathTxt.Name = "CommonModelPathTxt";
            CommonModelPathTxt.Size = new Size(246, 23);
            CommonModelPathTxt.TabIndex = 55;
            // 
            // runEntity
            // 
            runEntity.BackColor = SystemColors.ActiveCaptionText;
            runEntity.FlatAppearance.BorderSize = 0;
            runEntity.FlatStyle = FlatStyle.Flat;
            runEntity.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            runEntity.ForeColor = Color.White;
            runEntity.Location = new Point(562, 337);
            runEntity.Name = "runEntity";
            runEntity.Size = new Size(76, 23);
            runEntity.TabIndex = 53;
            runEntity.Text = "Entity";
            runEntity.UseVisualStyleBackColor = false;
            runEntity.Click += runEntity_Click;
            // 
            // SelBusinessCnFPBtn
            // 
            SelBusinessCnFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelBusinessCnFPBtn.FlatAppearance.BorderSize = 0;
            SelBusinessCnFPBtn.FlatStyle = FlatStyle.Flat;
            SelBusinessCnFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelBusinessCnFPBtn.ForeColor = Color.White;
            SelBusinessCnFPBtn.Location = new Point(299, 192);
            SelBusinessCnFPBtn.Name = "SelBusinessCnFPBtn";
            SelBusinessCnFPBtn.Size = new Size(35, 23);
            SelBusinessCnFPBtn.TabIndex = 52;
            SelBusinessCnFPBtn.Text = "....";
            SelBusinessCnFPBtn.UseVisualStyleBackColor = false;
            SelBusinessCnFPBtn.Click += SelBusinessCnFPBtn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(54, 177);
            label7.Name = "label7";
            label7.Size = new Size(150, 15);
            label7.TabIndex = 50;
            label7.Text = "Select Business Contracts Path";
            // 
            // BusinessContractPathTxt
            // 
            BusinessContractPathTxt.BackColor = Color.White;
            BusinessContractPathTxt.BorderStyle = BorderStyle.FixedSingle;
            BusinessContractPathTxt.Location = new Point(54, 192);
            BusinessContractPathTxt.Name = "BusinessContractPathTxt";
            BusinessContractPathTxt.Size = new Size(246, 23);
            BusinessContractPathTxt.TabIndex = 51;
            // 
            // SelBusinessFPBtn
            // 
            SelBusinessFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelBusinessFPBtn.FlatAppearance.BorderSize = 0;
            SelBusinessFPBtn.FlatStyle = FlatStyle.Flat;
            SelBusinessFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelBusinessFPBtn.ForeColor = Color.White;
            SelBusinessFPBtn.Location = new Point(603, 147);
            SelBusinessFPBtn.Name = "SelBusinessFPBtn";
            SelBusinessFPBtn.Size = new Size(35, 23);
            SelBusinessFPBtn.TabIndex = 49;
            SelBusinessFPBtn.Text = "....";
            SelBusinessFPBtn.UseVisualStyleBackColor = false;
            SelBusinessFPBtn.Click += SelBusinessFPBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(359, 132);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 47;
            label6.Text = "Select Business Path";
            // 
            // BusinessPathTxt
            // 
            BusinessPathTxt.BackColor = Color.White;
            BusinessPathTxt.BorderStyle = BorderStyle.FixedSingle;
            BusinessPathTxt.Location = new Point(359, 147);
            BusinessPathTxt.Name = "BusinessPathTxt";
            BusinessPathTxt.Size = new Size(246, 23);
            BusinessPathTxt.TabIndex = 48;
            // 
            // SelApiFPBtn
            // 
            SelApiFPBtn.BackColor = SystemColors.ActiveCaptionText;
            SelApiFPBtn.FlatAppearance.BorderSize = 0;
            SelApiFPBtn.FlatStyle = FlatStyle.Flat;
            SelApiFPBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SelApiFPBtn.ForeColor = Color.White;
            SelApiFPBtn.Location = new Point(299, 146);
            SelApiFPBtn.Name = "SelApiFPBtn";
            SelApiFPBtn.Size = new Size(35, 23);
            SelApiFPBtn.TabIndex = 46;
            SelApiFPBtn.Text = "....";
            SelApiFPBtn.UseVisualStyleBackColor = false;
            SelApiFPBtn.Click += SelApiFPBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Sans Serif Collection", 4F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(54, 131);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 44;
            label5.Text = "Select API Path";
            // 
            // APIPathTxt
            // 
            APIPathTxt.BackColor = Color.White;
            APIPathTxt.BorderStyle = BorderStyle.FixedSingle;
            APIPathTxt.Location = new Point(54, 146);
            APIPathTxt.Name = "APIPathTxt";
            APIPathTxt.Size = new Size(246, 23);
            APIPathTxt.TabIndex = 45;
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
            // ExistingPanel
            // 
            ExistingPanel.BackColor = Color.White;
            ExistingPanel.Controls.Add(ProcessProgress);
            ExistingPanel.Controls.Add(StatusGrid);
            ExistingPanel.Controls.Add(ProjectDir);
            ExistingPanel.Controls.Add(ConStrTxt);
            ExistingPanel.Dock = DockStyle.Right;
            ExistingPanel.Location = new Point(35, 0);
            ExistingPanel.Name = "ExistingPanel";
            ExistingPanel.Size = new Size(646, 418);
            ExistingPanel.TabIndex = 31;
            ExistingPanel.Visible = false;
            // 
            // ProcessProgress
            // 
            ProcessProgress.Location = new Point(53, 350);
            ProcessProgress.MarqueeAnimationSpeed = 80;
            ProcessProgress.Name = "ProcessProgress";
            ProcessProgress.Size = new Size(509, 10);
            ProcessProgress.TabIndex = 45;
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
            StatusGrid.Location = new Point(53, 26);
            StatusGrid.Name = "StatusGrid";
            StatusGrid.ReadOnly = true;
            StatusGrid.RowHeadersWidth = 62;
            StatusGrid.RowTemplate.Height = 25;
            StatusGrid.ShowEditingIcon = false;
            StatusGrid.Size = new Size(509, 318);
            StatusGrid.TabIndex = 44;
            // 
            // Process
            // 
            Process.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Process.HeaderText = "Process Name";
            Process.MinimumWidth = 8;
            Process.Name = "Process";
            Process.ReadOnly = true;
            Process.Width = 320;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Status.HeaderText = "Status";
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.ReadOnly = true;
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
            // CodeG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(681, 526);
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
            FrontPanel.ResumeLayout(false);
            FrontPanel.PerformLayout();
            ExistingPanel.ResumeLayout(false);
            ExistingPanel.PerformLayout();
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
        private Label ConStrTxt;
        private Panel NewPanel;
        private Button NextBtn;
        private Label ProjectDir;
        private Button SelDaCFPBtn;
        private Label label8;
        private TextBox DataContractPathTxt;
        private Button SelDAFPBtn;
        private Label label9;
        private TextBox DataAccessPathTxt;
        private Button SelCommonMdFPBtn;
        private Label label3;
        private TextBox CommonModelPathTxt;
        private Button runEntity;
        private Button SelBusinessCnFPBtn;
        private Label label7;
        private TextBox BusinessContractPathTxt;
        private Button SelBusinessFPBtn;
        private Label label6;
        private TextBox BusinessPathTxt;
        private Button SelApiFPBtn;
        private Label label5;
        private TextBox APIPathTxt;
        private ProgressBar ProcessProgress;
        private DataGridView StatusGrid;
        private DataGridViewTextBoxColumn Process;
        private DataGridViewTextBoxColumn Status;
        private Button SelBusinessTstFPBtn;
        private Label label10;
        private TextBox BusinessTestPathTxt;
        private Button SelApiTestFPBtn;
        private Label label11;
        private TextBox APITestPathTxt;
        private Button GetPathFPBtn;
        private Label label12;
        private TextBox SolutionPath;
        private Button GetPathBtn;
        private Panel FrontPanel;
        private TextBox SolNmTxt;
        private Label label2;
        private TextBox ProcNmTxt;
        private Label label4;
        private Button GenProcBtn;
        private Button folderpathbtn;
        private Label label1;
        private TextBox folderpathTxt;
    }
}