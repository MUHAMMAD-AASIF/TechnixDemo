using TechnixDemo.Helper;
using TechnixDemo.Service;
using TechnixDemo.Model;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TechnixDemo.Forms;

namespace TechnixDemo
{
    public partial class CodeG : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);
        public string ServerName = string.Empty;
        public CodeG()
        {
            InitializeComponent();
            // Add event handlers for mouse events
            this.MouseDown += new MouseEventHandler(MainForm_MouseDown);
            this.MouseMove += new MouseEventHandler(MainForm_MouseMove);
            this.MouseUp += new MouseEventHandler(MainForm_MouseUp);
            // Set up the ProgressBar
            ProcessProgress.Minimum = 0;
            ProcessProgress.Maximum = 100;
            ProcessProgress.Step = 1;
            //GetEntityDt();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateConfig(DbConfigModel dbConfig)
        {
            string DbCon = $"Data Source={dbConfig.ServerName};Initial Catalog={dbConfig.DbName};User ID={dbConfig.UserName};Password={dbConfig.Password};Trust Server Certificate=True";
            ConStrTxt.Text = DbCon;

        }
        //public async void GetEntityDt()
        //{
        //    Helper.ApiHelper db = new Helper.ApiHelper();
        //    var tst = await db.GetClientDt();
        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = tst;
        //    EntityCB.DataSource = bs;
        //}

        //private void Generate_Click(object sender, EventArgs e)
        //{
        //    Helper.ApiHelper db = new Helper.ApiHelper();
        //    GenerateModel generateModel = new GenerateModel()
        //    {
        //        EntityName = EntityCB.Text,
        //    };
        //    var rs = db.PostClientDt(generateModel);
        //    if (rs.Result == true)
        //    {
        //        MessageBox.Show("Entity Successfully Created");
        //    }
        //}

        private void NewProject_Click(object sender, EventArgs e)
        {
            this.NewPanel.Visible = true;
            this.NewProject.BackColor = Color.Khaki;
            this.ExistingPanel.Visible = false;
            this.ExistingProject.BackColor = Color.White;
        }

        private void ExistingProject_Click(object sender, EventArgs e)
        {
            this.NewPanel.Visible = false;
            this.NewProject.BackColor = Color.White;
            this.ExistingPanel.Visible = true;
            this.ExistingProject.BackColor = Color.Khaki;

        }

        private void folderpathbtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Optional: Set the dialog's description and initial directory
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.SelectedPath = "C:\\";

                // Show the dialog and get the result
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Set the selected folder path in the TextBox
                    folderpathTxt.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private async void GenProcBtn_Click(object sender, EventArgs e)
        {
            GenerateService generateService = new GenerateService(StatusGrid, ProcessProgress);
            string SolutionName = SolNmTxt.Text;
            string ProjectName = ProcNmTxt.Text;
            string ProjectPath = folderpathTxt.Text;
            var res = await generateService.GenerateAPIProject(SolutionName, ProjectName, ProjectPath);

            if (res.Status)
            {
                ControllerPathTxt.Text = res.ControllerPath;
                ServicePathTxt.Text = res.ServicePath;
                ModelPathTxt.Text = res.ModelPath;
                ProjectDir.Text=res.ProjectPath;
                ExistingProject_Click(sender, e);

                MessageBox.Show("Project Created Successfully");
            }
        }

        private void Config_Click(object sender, EventArgs e)
        {
            DatabaseConfig dbconfig = new DatabaseConfig(this);

            // To open the form as a non-modal form (the user can interact with both forms):
            dbconfig.Show();
        }



        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void SelcontrollerFPBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Optional: Set the dialog's description and initial directory
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.SelectedPath = "C:\\";

                // Show the dialog and get the result
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Set the selected folder path in the TextBox
                    ControllerPathTxt.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void SelModelFPBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Optional: Set the dialog's description and initial directory
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.SelectedPath = "C:\\";

                // Show the dialog and get the result
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Set the selected folder path in the TextBox
                    ModelPathTxt.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void SelServiceFPBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Optional: Set the dialog's description and initial directory
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.SelectedPath = "C:\\";

                // Show the dialog and get the result
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Set the selected folder path in the TextBox
                    ServicePathTxt.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void runEntity_Click(object sender, EventArgs e)
        {
            EntityData entityData = new EntityData();
            entityData.Show();
            //GenerateService generateService = new GenerateService(StatusGrid, ProcessProgress);
            //string SolutionName = SolNmTxt.Text;
            //string ProjectName = ProcNmTxt.Text;
            //string ProjectPath = folderpathTxt.Text;
            //var res = generateService.GetTableNames("Server=HQAPEW1C002-AUZ;Database=technix;User Id=sa;Password=msc123;TrustServerCertificate=True;");


        }
    }
}