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

        public EntityData(ProjectResponseModel filepathRes, CodeG parentForm)
        {
           
            InitializeComponent();
            DatabaseHelper dbHelper = new DatabaseHelper();
            var res = dbHelper.GetTableNames("Server=HQAPEW1C002-AUZ;Database=technix;User Id=sa;Password=msc123;TrustServerCertificate=True;");
            _parentForm = parentForm;
            _entities = new List<EntitySelectModel>();

            foreach (var name in res)
            {
                _entities.Add(new EntitySelectModel { Entity = name });
            }

            // Bind data to DataGridView
            EntityGrid.DataSource = new BindingList<EntitySelectModel>(_entities);
            EntityGrid.Columns["Entity"].ReadOnly = true;

            // Subscribe to events
            EntityGrid.CellValueChanged += dataGridView_CellValueChanged;
            EntityGrid.CurrentCellDirtyStateChanged += dataGridView_CurrentCellDirtyStateChanged;

        }

        private void dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (EntityGrid.IsCurrentCellDirty)
            {
                EntityGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell value changes if needed
        }


        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
