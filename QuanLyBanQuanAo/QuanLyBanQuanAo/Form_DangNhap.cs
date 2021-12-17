using QuanLyBanQuanAo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanQuanAo
{
    public partial class Form_DangNhap : Form
    {
        QLBanQuanAoContext db = new QLBanQuanAoContext();
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = textBox_TenDangNhap.Text;
            string matKhau = textBox_MatKhau.Text;

            if(tenDangNhap == string.Empty || matKhau == string.Empty)
            {
                MessageBox.Show("Hãy điền đầy đủ tài khoản và mật khẩu !!!");
                return;
            }    

            var taiKhoan = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau);

            if(taiKhoan == null)
            {
                MessageBox.Show("Kiểm tra lại tên đăng nhập và mật khẩu !!!");
                return;
            }
            else if(taiKhoan.LoaiTaiKhoan == false) // false: admin, true: nhan vien
            {
                new Home_Admin().ShowDialog();
                Close();
            }   
            else if(taiKhoan.LoaiTaiKhoan == true)
            {
                new Home().ShowDialog();
                Close();
            }
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
