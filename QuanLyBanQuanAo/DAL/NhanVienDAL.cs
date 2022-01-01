using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        private QLBanQuanAoContext db = new QLBanQuanAoContext();
        private static NhanVienDAL instance;

        public static NhanVienDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienDAL();
                }
                return instance;
            }
        }

        public List<NhanVien> LayToanBo()
        {
            return db.NhanViens.ToList();
        }

        public List<NhanVien> LayTheoTuKhoa(string tuKhoa)
        {
            return db.NhanViens.Where(nv=>nv.MaNhanVien.ToLower().Contains(tuKhoa.ToLower().Trim()) ||
                                          nv.HoTen.ToLower().Contains(tuKhoa.ToLower().Trim()) ||
                                          nv.TaiKhoan.TenDangNhap.ToLower().Contains(tuKhoa.ToLower().Trim())
                                          ).ToList();
        }

        public string LayMaNhanVien()
        {
            return db.NhanViens.OrderByDescending(nv => nv.MaNhanVien).Select(nv => nv.MaNhanVien).FirstOrDefault();
        }

        public void CapNhatNhanVien(NhanVien nv, int status)
        {
            if (status == 0)
            {
                db.NhanViens.Add(nv);
            }
            if(status == 1)
            {
                TaiKhoan tk = nv.TaiKhoan;
                db.NhanViens.Remove(nv);
                db.TaiKhoans.Remove(tk);
            }
            db.SaveChanges();
        }

        public NhanVien LayNhanVienTheoMa(string maNV)
        {
            return db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNV);
        }
    }
}
