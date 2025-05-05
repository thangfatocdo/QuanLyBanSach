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
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
            //tránh stack overflow
            this.Load += (s, e) =>
            {
                if (formMain.Instance != null)
                    guna2MessageDialog1.Parent = formMain.Instance;
            };
        }


    }
}
