using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnixDemo.Model;
using TechnixDemo.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TechnixDemo.Forms
{
    public partial class EntityData : Form
    {
        private List<EntitySelectModel> _entities;
        private CodeG _parentForm;
        private BindingList<EntitySelectModel> _bindingList;
        private readonly ProjectResponseModel _filepathRes;

        public EntityData(ProjectResponseModel filepathRes, CodeG parentForm)
        {

            InitializeComponent();
            _filepathRes=filepathRes;
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
                        updatedModel.Select = !updatedModel.Select;
                        updatedModel.GetAll = !updatedModel.GetAll;
                        updatedModel.GetById = !updatedModel.GetById;
                        updatedModel.Save = !updatedModel.Save;
                        updatedModel.Update = !updatedModel.Update;
                        updatedModel.Delete = !updatedModel.Delete;
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

                // Refresh the DataGridView to reflect changes
                EntityGrid.Refresh();
            }
        }

        //private void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    var selectedModels = _bindingList.ToList();
        //    _parentForm.HandleSelectedEntities(selectedModels);
        //    this.Close();
        //}
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            var selectedModels = _bindingList.ToList();
            var Filepath = _filepathRes;
            //_parentForm.HandleSelectedEntities(selectedModels);
            this.Close();
        }
    }
}
