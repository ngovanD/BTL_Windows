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

        public NhanVien LayThongTinNhanVien(int IDTK)
        {
            return NhanVienDAL.Instance.LayThongTinNhanVien(IDTK);
        }

        public bool SuaNhanVien(NhanVien nhanVien)
        {
            return NhanVienDAL.Instance.SuaNhanVien(nhanVien);
        }

        public void HienThiDanhSach(DataGridView dgv, string tuKhoa)
        {
            List<NhanVien> dsNV = new List<NhanVien>();
            if (tuKhoa == null || tuKhoa.Trim().Length == 0)
            {
                dsNV = NhanVienDAL.Instance.LayToanBo();
            }
            else
            {
                dsNV = NhanVienDAL.Instance.LayTheoTuKhoa(tuKhoa);
            }
            dgv.DataSource = dsNV.Select(nv => new { nv.MaNhanVien, nv.HoTen, nv.NgaySinh, TenDangNhap = nv.TaiKhoan.TenDangNhap }).ToList();
            dgv.ClearSelection();
        }

        public NhanVien LayNhanVienTheoMa(string maNV)
        {
            return NhanVienDAL.Instance.LayNhanVienTheoMa(maNV);
        }

        public string TaoMaNhanVien()
        {
            string maNV = NhanVienDAL.Instance.LayMaNhanVien().Split('V')[1];
            int ma = Convert.ToInt32(maNV) + 1;
            return "NV" + ma.ToString("000");
        }

        public void CapNhatNhanVien(NhanVien nv, int status)
        {
            NhanVienDAL.Instance.CapNhatNhanVien(nv, status);
        }
    }
}
