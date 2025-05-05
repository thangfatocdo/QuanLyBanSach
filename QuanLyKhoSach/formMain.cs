using QuanLyKhoSach.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhoSach
{
    public partial class formMain : Sample
    {
        static formMain _obj;
        public static int CurrentUserId { get; set; }
        public static formMain Instance
        {
            get { if (_obj == null) { _obj = new formMain(); } return _obj; }
        }
        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            _obj = this;
            btnMax.PerformClick();
        }

        public void AddControls(Form F)
        {
            this.CenterPanel.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            CenterPanel.Controls.Add(F);
            F.Show();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            AddControls(new formCustomerView());
        }
        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = formMain.Instance.Size;
                Background.Location = formMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new formCategoryView());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AddControls(new formUserView());

        }

        private void btnOder_Click(object sender, EventArgs e)
        {
            AddControls(new formOderView());
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            AddControls(new formBookView());
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            AddControls(new formImportView());

        }
    }
}