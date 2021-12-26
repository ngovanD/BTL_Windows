using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            bool check = TaiKhoanBLL.Instance.KiemTraTaiKhoan(tenDangNhap, matKhau);
            if(check)
            {
                if(TaiKhoanBLL.Instance.LaTaiKhoanNhanVien(tenDangNhap))
                {
                    new frmNhanVien().ShowDialog();
                }
                else
                {
                    new frmQuanTri().ShowDialog();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Kiểm tra lại tài khoản và mật khẩu");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
