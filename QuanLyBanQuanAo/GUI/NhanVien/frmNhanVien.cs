using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmNhanVien : Form
    {
        private string tenDangNhap;

        public frmNhanVien(string tenDangNhap)
        {
            this.tenDangNhap = tenDangNhap;
            InitializeComponent();
        }

        private void xemThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmThongTinTaiKhoan(tenDangNhap).ShowDialog();
            Close();
        }
    }
}
