using System.ComponentModel;
using System.Data;
using TechnixDemo.Model;
using TechnixDemo.Service;

namespace TechnixDemo.Forms
{
    public partial class EntityData : Form
    {
        private List<EntitySelectModel> _entities;
        private CodeG _parentForm;
        private BindingList<EntitySelectModel> _bindingList;
        private readonly ProjectResponseModel _filePathRes;

        public EntityData(ProjectResponseModel filePathRes, CodeG parentForm)
        {

            InitializeComponent();
            _filePathRes = filePathRes;
            _parentForm = parentForm;
            _entities = new List<EntitySelectModel>();

            DatabaseHelper db = new DatabaseHelper();
            var entityNames = db.GetTableNames();
            _bindingList = new BindingList<EntitySelectModel>();
            foreach (var name in entityNames)
            {
                _bindingList.Add(new EntitySelectModel { Entity = name });
            }
            // Bind data to DataGridView
            EntityGrid.DataSource = _bindingList;
            EntityGrid.Columns["Entity"].ReadOnly = true;
            // Set the boolean columns to be checkbox columns
            foreach (DataGridViewColumn column in EntityGrid.Columns)
            {
                if (column.ValueType == typeof(bool))
                {
                    column.ReadOnly = false;
                    column.CellTemplate = new DataGridViewCheckBoxCell();
                    column.Width = 60;
                }
                else if (column.HeaderText == "Entity")
                {
                    column.ReadOnly = true;
                    column.Width = 150; // Optionally set the width for the Entity column
                }
            }
            EntityGrid.CellContentClick += dataGridView_CellContentClick;

        }


        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && EntityGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                EntityGrid.EndEdit(); // Commit the change to the data source
                var updatedModel = _bindingList[e.RowIndex];

                switch (e.ColumnIndex)
                {
                    case 0: // Select
                        bool newSelectValue = !updatedModel.Select;
                        updatedModel.Select = newSelectValue;
                        updatedModel.GetAll = newSelectValue;
                        updatedModel.GetById = newSelectValue;
                        updatedModel.Save = newSelectValue;
                        updatedModel.Update = newSelectValue;
                        updatedModel.Delete = newSelectValue;
                        break;
                    case 2: // GetAll
                        updatedModel.GetAll = !updatedModel.GetAll;
                        break;
                    case 3: // GetById
                        updatedModel.GetById = !updatedModel.GetById;
                        break;
                    case 4: // Save
                        updatedModel.Save = !updatedModel.Save;
                        break;
                    case 5: // Update
                        updatedModel.Update = !updatedModel.Update;
                        break;
                    case 6: // Delete
                        updatedModel.Delete = !updatedModel.Delete;
                        break;
                }

                // Ensure Select is checked if any of the other options are checked
                updatedModel.Select = updatedModel.GetAll || updatedModel.GetById || updatedModel.Save || updatedModel.Update || updatedModel.Delete;

                // Refresh the DataGridView to reflect changes
                EntityGrid.Refresh();
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            var selectedModels = _bindingList.Where(x => x.Select && (x.GetAll || x.GetById || x.Save || x.Update || x.Delete)).ToList();
            FileGenerateService fileGenerateService = new FileGenerateService(selectedModels, _filePathRes);
            fileGenerateService.ProcessFileGeneration();
            MessageBox.Show("Files Created Sucessfully");
        }
    }
}
