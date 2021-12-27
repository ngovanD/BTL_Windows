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

namespace GUI.NhanVien
{
    public partial class frmTaoHoaDonBan : Form
    {
        public frmTaoHoaDonBan()
        {
            InitializeComponent();
        }

        private void frmTaoHoaDonBan_Load(object sender, EventArgs e)
        {
            lblMaHoaDon.Text = HoaDonBLL.Instance.TaoMaHoaDon(true);
        }

        private void tmrHienThiThoiGian_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void dgvDanhSachSanPham_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvChiTietSanPham_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void cbxLocLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTimTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void txtMaGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtTienKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnNhapTien_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
