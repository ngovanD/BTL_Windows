using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace BLL
{
    public class HoaDonBLL
    {
        private static HoaDonBLL instance;
        private List<DongHoaDon> chiTietHoaDon;
        private decimal tienHang = 0;
        private decimal giamGia = 0;
        private decimal khachTra = 0;

        public static HoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonBLL();
                }
                return instance;
            }
        }
        public decimal TienHang { get { return tienHang; }}
        public decimal GiamGia { get { return giamGia; }}
        public decimal KhachTra { get { return khachTra; } set { this.khachTra = value; } }

        public String TaoMaHoaDon(bool kiemTra)
        {
            String ma = (kiemTra) ? "HDB-" : "HDN-";
            DateTime date = DateTime.Now;
            ma += date.ToString("ddMMyy-");
            ma += HoaDonDAL.Instance.LaySoHoaDon(ma).ToString("000");
            return ma;
        }

        public void HienThiSanPham(DataGridView dgv, string tenSP, int maLoaiSP)
        {
            List<SanPham> dsNV = new List<SanPham>();
            if (isEmpty(tenSP) && maLoaiSP == 0)
            {
                dsNV = SanPhamDAL.Instance.LayToanBo();
            }
            else
            {
                if (isEmpty(tenSP)) tenSP = null;
                dsNV = SanPhamDAL.Instance.LayTheoTuKhoa(tenSP, maLoaiSP);
            }
            dgv.DataSource = dsNV.Select(sp => new {
                                        sp.MaSanPham,
                                        sp.TenSanPham,
                                        SoLuongCo = sp.ChiTietSanPhams.Sum(ctsp => ctsp.SoLuongCon),
                                        LoaiSanPham = sp.LoaiSanPham.TenLoaiSanPham, 
                                        sp.DonGiaBan}).ToList();
            dgv.ClearSelection();
        }

        public void TaoDSLoaiSP(ComboBox cbxLocLoaiSP)
        {
            List<LoaiSanPham> data = new List<LoaiSanPham>();
            data.Add(new LoaiSanPham() { MaLoaiSanPham = 0, TenLoaiSanPham = "Tất cả" });
            data.AddRange(LoaiSanPhamDAL.Instance.LayToanBo());

            cbxLocLoaiSP.DataSource = data;
            cbxLocLoaiSP.ValueMember = "MaLoaiSanPham";
            cbxLocLoaiSP.DisplayMember = "TenLoaiSanPham";
        }

        public void HienThiKichThuc(List<ChiTietSanPham> chiTietSanPhams, ComboBox cbxSize)
        {
            List<KichThuoc> data = new List<KichThuoc>();

            foreach(var ctsp in chiTietSanPhams)
            {
                if (ctsp.SoLuongCon > 0)
                {
                    data.Add(ctsp.KichThuoc);
                }
            }

            cbxSize.DataSource = data;
            cbxSize.ValueMember = "ID_KichThuoc";
            cbxSize.DisplayMember = "Ten";
        }

        public DongHoaDon LayChiTietHDTheoMaSPVaKichThuoc(int maSP, int idKichThuoc)
        {
            return chiTietHoaDon.FirstOrDefault(cthd => cthd.MaSanPham == maSP && cthd.ID_KichThuoc == idKichThuoc);
        }

        public void CapNhatChiTietHoaDon(DataGridView dgv, int maSP, int idKichThuoc, int soLuong, int status)
        {
            if (chiTietHoaDon == null)
            {
                chiTietHoaDon = new List<DongHoaDon>();
            }

            switch (status)
            {
                case 0:
                    bool kt = true;
                    foreach (var cthd in chiTietHoaDon)
                    {
                        if (cthd.MaSanPham == maSP && cthd.ID_KichThuoc == idKichThuoc)
                        {
                            kt = false;
                            cthd.SoLuong += soLuong;
                        }
                    }

                    if (kt)
                    {
                        chiTietHoaDon.Add(new DongHoaDon()
                        {
                            MaSanPham = maSP,
                            ID_KichThuoc = idKichThuoc,
                            SoLuong = soLuong,
                            KichThuoc = KichThuocDAL.Instance.LayTheoMa(idKichThuoc),
                            SanPham = SanPhamDAL.Instance.LayTheoMa(maSP),
                        });
                    }
                    break;
                case 1:
                    foreach (var cthd in chiTietHoaDon)
                    {
                        if (cthd.MaSanPham == maSP && cthd.ID_KichThuoc == idKichThuoc)
                        {
                            cthd.SoLuong = soLuong;
                        }
                    }
                    break;
                case 2:
                    DongHoaDon itemRemove = new DongHoaDon();
                    foreach (var cthd in chiTietHoaDon)
                    {
                        if (cthd.MaSanPham == maSP && cthd.ID_KichThuoc == idKichThuoc)
                        {
                            itemRemove = cthd;
                        }
                    }
                    chiTietHoaDon.Remove(itemRemove);
                    break;
            }

            var data = chiTietHoaDon.Select(cthd => new
            {
                MaSP = cthd.MaSanPham,
                MaKichThuoc = cthd.ID_KichThuoc,
                TenSP = cthd.SanPham.TenSanPham,
                Size = cthd.KichThuoc.Ten,
                SoLuongMua = cthd.SoLuong,
                DonGia = cthd.SanPham.DonGiaBan,
                ThanhTien = cthd.SoLuong * cthd.SanPham.DonGiaBan
            });
            dgv.DataSource = data.ToList();
            dgv.ClearSelection();

            tienHang = Convert.ToDecimal(chiTietHoaDon.Sum(cthd => cthd.SoLuong * cthd.SanPham.DonGiaBan));
        }

        public bool ThanhToanHoaDonBan(string maHD)
        {
            TaiKhoan tk = TaiKhoanDAL.Instance.LayTaiKhoan("The");
            HoaDon hoaDon = new HoaDon()
            {
                MaHoaDon = maHD,
                ThoiGian = DateTime.Now,
                LoaiHoaDon = true,
                TongTien = Convert.ToInt32(tienHang - giamGia),
            };
            
            foreach(var cthd in chiTietHoaDon)
            {
                cthd.MaHoaDon = maHD;
                cthd.KichThuoc = null;
                cthd.SanPham = null;
            }

            try
            {
                HoaDonDAL.Instance.LuuHoaDon(hoaDon,chiTietHoaDon);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public bool isEmpty(string str)
        {
            if(str == null || str.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
