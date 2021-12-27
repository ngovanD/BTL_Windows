using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVienBLL
    {
        private static NhanVienBLL instance;

        public static NhanVienBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienBLL();
                }
                return instance;
            }
        }

        public void HienThiDanhSach(DataGridView dgv, string tuKhoa)
        {
            List<NhanVien> dsNV = new List<NhanVien>();
            if(tuKhoa == null || tuKhoa.Trim().Length == 0)
            {
                dsNV = NhanVienDAL.Instance.LayToanBo();
            }
            else
            {
                dsNV = NhanVienDAL.Instance.LayTheoTuKhoa(tuKhoa);
            }
            dgv.DataSource = dsNV.Select(nv => new { nv.MaNhanVien, nv.HoTen, nv.NgaySinh, TenDangNhap = nv.TaiKhoan.TenDangNhap, nv.DiaChi }).ToList();
        }

        public NhanVien LayNhanVienTheoMa(string maNV)
        {
            return NhanVienDAL.Instance.LayNhanVienTheoMa(maNV);
        }

        public string TaoMaNhanVien()
        {
            return "NV" + NhanVienDAL.Instance.LayMaNhanVien().ToString("000");
        }

        public void CapNhatNhanVien(NhanVien nv, int status)
        {
            NhanVienDAL.Instance.CapNhatNhanVien(nv,status);
        }
    }
}
