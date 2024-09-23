using TechnixDemo.Service;
using TechnixDemo.Model;
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
            // Hide and show necessary panels
            TogglePanels(isProcessing: true);

            // Retrieve input values
            string solutionName = SolNmTxt.Text.Trim();
            string projectName = ProcNmTxt.Text.Trim();
            string projectPath = folderpathTxt.Text.Trim();

            // Initialize the service and generate the project
            GenerateService generateService = new GenerateService(StatusGrid, ProcessProgress);
            var result = await generateService.GenerateAPIProjectAsync(solutionName, projectName, projectPath);

            // Update project response model
            UpdateProjectResponseModel(result, projectName, solutionName);

            // If generation was successful, update UI and notify the user
            if (result.Status)
            {
                UpdatePaths(result);
                TogglePanels(isProcessing: false);

                ExistingProject_Click(sender, e);
                MessageBox.Show("Project Created Successfully");
            }
        }

        private void TogglePanels(bool isProcessing)
        {
            NewPanel.Visible = !isProcessing;
            FrontPanel.Visible = !isProcessing;
            ExistingPanel.Visible = isProcessing;
        }

        private void UpdateProjectResponseModel(ProjectResponseModel result, string projectName, string solutionName)
        {
            projectResponseModel = result;
            projectResponseModel.ProjectName = projectName;
            projectResponseModel.SolutionName = solutionName;
        }

        private void UpdatePaths(ProjectResponseModel result)
        {
            APIPathTxt.Text = result.APIPath;
            BusinessPathTxt.Text = result.BusinessPath;
            BusinessContractPathTxt.Text = result.BusinessContractPath;
            DataAccessPathTxt.Text = result.DataAccessPath;
            DataContractPathTxt.Text = result.DataAccessContractPath;
            CommonModelPathTxt.Text = result.CommonModelPath;
            APITestPathTxt.Text = result.APITestPath;
            BusinessTestPathTxt.Text = result.BusinessTestPath;
            SolutionPath.Text = result.SolutionPath;
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
            // Combine paths and check if they exist before assigning them to text boxes.
            string projectname = Path.GetFileName(Directory.GetFiles(SolutionPath.Text, "*.sln").FirstOrDefault().Replace("Msc.", "").Replace(".Service.sln", ""));
            var apiPath = Path.Combine(SolutionPath.Text, $"Msc.{projectname}.Service.Api");
            
            projectResponseModel.ProjectName =string.IsNullOrEmpty(SolNmTxt.Text)? projectname:SolNmTxt.Text;
            ProcNmTxt.Text = string.IsNullOrEmpty(ProcNmTxt.Text) ? projectname : ProcNmTxt.Text;

            projectResponseModel.SolutionPath = apiPath;
            if (Directory.Exists(apiPath))
            {
                APIPathTxt.Text = apiPath;
                projectResponseModel.APIPath = apiPath;
            }

            var businessPath = Path.Combine(SolutionPath.Text, $"Msc.{projectname}.Service.Business");
            if (Directory.Exists(businessPath))
            {
                BusinessPathTxt.Text = businessPath;
                projectResponseModel.BusinessPath = businessPath;
            }

            var businessContractPath = Path.Combine(SolutionPath.Text, $"Msc.{projectname}.Service.Business.Contracts");
            if (Directory.Exists(businessContractPath))
            {
                BusinessContractPathTxt.Text = businessContractPath;
                projectResponseModel.BusinessContractPath = businessContractPath;
            }

            var dataAccessPath = Path.Combine(SolutionPath.Text, $"Msc.{projectname}.Service.DataAccess");
            if (Directory.Exists(dataAccessPath))
            {
                DataAccessPathTxt.Text = dataAccessPath;
                projectResponseModel.DataAccessPath = dataAccessPath;
            }

            var dataContractPath = Path.Combine(SolutionPath.Text, $"Msc.{projectname}.Service.DataAccess.Contracts");
            if (Directory.Exists(dataContractPath))
            {
                DataContractPathTxt.Text = dataContractPath;
                projectResponseModel.DataAccessContractPath = dataContractPath;
            }

            var commonModelPath = Path.Combine(SolutionPath.Text, $"Msc.{projectname}.Service.CommonModel");
            if (Directory.Exists(commonModelPath))
            {
                CommonModelPathTxt.Text = commonModelPath;
                projectResponseModel.CommonModelPath = commonModelPath;
            }

            var apiTestPath = Path.Combine(SolutionPath.Text, $"Msc.{projectname}.Service.Api.Test");
            if (Directory.Exists(apiTestPath))
            {
                APITestPathTxt.Text = apiTestPath;
                projectResponseModel.APITestPath = apiTestPath;
            }

            var businessTestPath = Path.Combine(SolutionPath.Text, $"Msc.{projectname}.Service.Business.Test");
            if (Directory.Exists(businessTestPath))
            {
                BusinessTestPathTxt.Text = businessTestPath;
                projectResponseModel.BusinessTestPath = businessTestPath;
            }
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