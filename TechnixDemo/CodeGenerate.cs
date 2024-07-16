using TechnixDemo.Helper;
using TechnixModel;

namespace TechnixDemo
{
    public partial class CodeG : Form
    {
        public CodeG()
        {
            InitializeComponent();
            GetEntityDt();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public async void GetEntityDt()
        {
            Helper.ApiHelper db = new Helper.ApiHelper();
            var tst = await db.GetClientDt();
            BindingSource bs = new BindingSource();
            bs.DataSource = tst;
            EntityCB.DataSource = bs;
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            Helper.ApiHelper db = new Helper.ApiHelper();
            GenerateModel generateModel = new GenerateModel()
            {
                EntityName = EntityCB.Text,
            };
            var rs = db.PostClientDt(generateModel);
            if (rs.Result == true)
            {
                MessageBox.Show("Entity Successfully Created");
            }
        }
    }
}