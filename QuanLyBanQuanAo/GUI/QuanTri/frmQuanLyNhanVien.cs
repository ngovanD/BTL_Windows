﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.QuanTri
{
    public partial class frmQuanLyNhanVien : Form
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThiMacDinh(true);
        }
        
        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            btnThem.Text = "Thêm";
            var maNV = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();

            DTO.NhanVien nv = NhanVienBLL.Instance.LayNhanVienTheoMa(maNV);

            if (nv != null)
            {
                txtMaNV.Text = nv.MaNhanVien;
                txtHoTen.Text = nv.HoTen;
                dtpNgaySinh.Value = Convert.ToDateTime(nv.NgaySinh);
                txtDiaChi.Text = nv.DiaChi;
                txtTenDN.Text = nv.TaiKhoan.TenDangNhap;
                txtMatKhau.Text = nv.TaiKhoan.MatKhau;

                txtMaNV.ReadOnly = true;
                txtHoTen.ReadOnly = true;
                dtpNgaySinh.Enabled = false;
                txtSoDT.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtTenDN.ReadOnly = true;
            }
        }
        
        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.Text = txtTenDN.Text;
        }

        private void txtSoDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            NhanVienBLL.Instance.HienThiDanhSach(dgvNhanVien, txtTimKiem.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                HienThiMacDinh(false);
                txtMaNV.Text = NhanVienBLL.Instance.TaoMaNhanVien();
                txtMaNV.ReadOnly = true;
                btnThem.Text = "Lưu";
            }
            else
            {
                var tenDN = ChuyenKhongDau(txtTenDN.Text);
                if (txtHoTen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Họ và tên nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtTenDN.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (TaiKhoanBLL.Instance.KiemTraTenDangNhap(tenDN))
                {
                    MessageBox.Show("Tên đăng nhập này đã có, vui lòng nhập tên đăng nhập khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TaiKhoan tk = new TaiKhoan()
                    {
                        TenDangNhap = tenDN,
                        MatKhau = txtTenDN.Text,
                        LoaiTaiKhoan = true,
                    };

                    DTO.NhanVien nv = new DTO.NhanVien()
                    {
                        MaNhanVien = txtMaNV.Text,
                        HoTen = txtHoTen.Text,
                        NgaySinh = dtpNgaySinh.Value,
                        DiaChi = txtDiaChi.Text,
                        TaiKhoan = tk,
                    };

                    try
                    {
                        NhanVienBLL.Instance.CapNhatNhanVien(nv, 0);
                        MessageBox.Show("Thêm mới thành công nhân viên! Mật khẩu của nhân viên là tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        HienThiMacDinh(true);
                        btnThem.Text = "Thêm";
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLayMK_Click(object sender, EventArgs e)
        {
            DTO.NhanVien nv = NhanVienBLL.Instance.LayNhanVienTheoMa(txtMaNV.Text);

            if (nv != null)
            {
                var d = MessageBox.Show("Bạn có muốn lấy lại mật khẩu cho nhân viên này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (d == DialogResult.OK)
                {
                    try
                    {
                        nv.TaiKhoan.MatKhau = nv.TaiKhoan.TenDangNhap;
                        NhanVienBLL.Instance.CapNhatNhanVien(nv, 2);
                        MessageBox.Show("Lấy lại mật khẩu cho nhân viên thành công! Mật khẩu của nhân viên là tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        HienThiMacDinh(true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để lấy lại mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DTO.NhanVien nv = NhanVienBLL.Instance.LayNhanVienTheoMa(txtMaNV.Text);

            if (nv != null)
            {
                var d = MessageBox.Show("Bạn có muốn xóa nhân viên này", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (d == DialogResult.OK)
                {
                    try
                    {
                        nv.TaiKhoan.MatKhau = nv.TaiKhoan.TenDangNhap;
                        NhanVienBLL.Instance.CapNhatNhanVien(nv, 1);
                        MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        HienThiMacDinh(true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
       
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HienThiMacDinh(bool status)
        {
            if (status)
            {
                NhanVienBLL.Instance.HienThiDanhSach(dgvNhanVien, null);
            }
            txtMaNV.ReadOnly = false;
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtTenDN.Text = "";
            txtMatKhau.Text = "";
            dtpNgaySinh.Value = DateTime.Now;

            txtHoTen.ReadOnly = false;
            dtpNgaySinh.Enabled = true;
            txtSoDT.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtTenDN.ReadOnly = false;
        }

        public string ChuyenKhongDau(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            text = text.Replace(" ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
