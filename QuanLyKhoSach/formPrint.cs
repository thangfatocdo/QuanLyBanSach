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
    public partial class formPrint : Sample
    {
        public formPrint()
        {
            InitializeComponent();
        }

        private void formPrint_Load(object sender, EventArgs e)
        {
            btnMax.PerformClick();  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
