using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HRMngt.View
{
    public partial class Template : Form
    {
        public Template()
        {
            InitializeComponent();

        }

        private void txtNavSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNavSearch.Text == "Nhập tìm kiếm của bạn ...")
            {
                txtNavSearch.Text = "";
                txtNavSearch.ForeColor = Color.Black;
            }    
            
        }

        private void txtNavSearch_Leave(object sender, EventArgs e)
        {
            if (txtNavSearch.Text == "")
            {
                txtNavSearch.Text = "Nhập tìm kiếm của bạn ...";
                txtNavSearch.ForeColor = Color.Black;
            }
        }
    }
}
