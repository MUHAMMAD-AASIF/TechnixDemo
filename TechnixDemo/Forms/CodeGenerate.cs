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
        public ProjectResponseModel projectResponseModel = new ProjectResponseModel();
        public CodeG()
        {
            InitializeComponent();
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

        private void NewProject_Click(object sender, EventArgs e)
        {
            this.NewPanel.Visible = true;
            this.NewProject.BackColor = Color.Khaki;
            this.FrontPanel.Visible = true;
            this.ExistingPanel.Visible = false;
            this.ExistingProject.BackColor = Color.White;
        }

        private void ExistingProject_Click(object sender, EventArgs e)
        {
            this.FrontPanel.Visible = false;
            this.NewPanel.Visible = true;
            this.NewProject.BackColor = Color.White;
            this.ExistingPanel.Visible = false;
            this.ExistingProject.BackColor = Color.Khaki;

        }

        private void folderpathbtn_Click(object sender, EventArgs e)
        {
            SelectFolder(folderpathTxt);
        }

        private async void GenProcBtn_Click(object sender, EventArgs e)
        {
            GenerateService generateService = new GenerateService(StatusGrid, ProcessProgress);
            this.NewPanel.Visible = false;
            this.ExistingPanel.Visible = true;
            string SolutionName = SolNmTxt.Text;
            string ProjectName = ProcNmTxt.Text;
            string ProjectPath = folderpathTxt.Text;
            var res = await generateService.GenerateAPIProjectAsync(SolutionName, ProjectName, ProjectPath);
            projectResponseModel = res;
            if (res.Status)
            {
                APIPathTxt.Text = res.APIPath;
                BusinessPathTxt.Text = res.BusinessPath;
                BusinessContractPathTxt.Text = res.BusinessContractPath;
                DataAccessPathTxt.Text = res.DataAccessPath;
                DataContractPathTxt.Text = res.DataAccessContractPath;
                CommonModelPathTxt.Text = res.CommonModelPath;
                APITestPathTxt.Text = res.APITestPath;
                BusinessTestPathTxt.Text = res.BusinessTestPath;
                SolutionPath.Text = res.SolutionPath;
                projectResponseModel = res;
                this.NewPanel.Visible = true;
                this.FrontPanel.Visible = false;
                this.ExistingPanel.Visible = false;

                ExistingProject_Click(sender, e);

                MessageBox.Show("Project Created Successfully");
            }
        }

        private void runEntity_Click(object sender, EventArgs e)
        {
            var validate = ValidatePaths(projectResponseModel);
            if (validate.IsValid)
            {
                EntityData entityData = new EntityData(projectResponseModel, this);
                entityData.Show();
            }
            else
            {
                MessageBox.Show(validate.Message);
            }

        }

        private static ValidatePathModel ValidatePaths(ProjectResponseModel projectResponseModel)
        {
            if (string.IsNullOrEmpty(projectResponseModel.SolutionPath))
            {
                return new ValidatePathModel { Message = "Enter the Solution Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.ProjectPath))
            {
                return new ValidatePathModel { Message = "Enter the Project Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.APIPath))
            {
                return new ValidatePathModel { Message = "Enter the API Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.BusinessPath))
            {
                return new ValidatePathModel { Message = "Enter the Business Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.BusinessContractPath))
            {
                return new ValidatePathModel { Message = "Enter the Business Contract Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.DataAccessPath))
            {
                return new ValidatePathModel { Message = "Enter the Data Access Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.DataAccessContractPath))
            {
                return new ValidatePathModel { Message = "Enter the Data Access Contract Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.CommonModelPath))
            {
                return new ValidatePathModel { Message = "Enter the Common Model Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.APITestPath))
            {
                return new ValidatePathModel { Message = "Enter the API Test Path.", IsValid = false };
            }
            else if (string.IsNullOrEmpty(projectResponseModel.BusinessTestPath))
            {
                return new ValidatePathModel { Message = "Enter the Business Test Path.", IsValid = false };
            }

            return new ValidatePathModel { Message = "All paths are valid.", IsValid = true };
        }

        private void SelectFolder(System.Windows.Forms.TextBox targetTextBox)
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
                    // Set the selected folder path in the target TextBox
                    targetTextBox.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void GetPathBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void SelApiFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(APIPathTxt);
        }

        private void SelBusinessFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(BusinessPathTxt);
        }

        private void SelBusinessCnFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(BusinessContractPathTxt);
        }

        private void SelCommonMdFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(CommonModelPathTxt);
        }

        private void SelDAFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(DataAccessPathTxt);
        }

        private void SelDaCFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(DataContractPathTxt);
        }

        private void SelApiTestFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(APITestPathTxt);
        }

        private void SelBusinessTstFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(BusinessTestPathTxt);
        }

        private void GetPathFPBtn_Click(object sender, EventArgs e)
        {
            SelectFolder(SolutionPath);
        }
    }
}