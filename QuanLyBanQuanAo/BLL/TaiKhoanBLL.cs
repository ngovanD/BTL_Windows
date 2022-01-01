using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TaiKhoanBLL
    {
        private static TaiKhoanBLL instance;

        public static TaiKhoanBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoanBLL();
                }
                return instance;
            }
        }

        public bool KiemTraTaiKhoan(string tenDangNhap, string matKhau)
        {
            return TaiKhoanDAL.Instance.KiemTraTaiKhoan(tenDangNhap, matKhau);
        }
        public bool LaTaiKhoanNhanVien(string tenDangNhap)
        {
            return TaiKhoanDAL.Instance.LaTaiKhoanNhanVien(tenDangNhap);
        }

        public TaiKhoan LayThongTinTaiKhoan(string tenDangNhap)
        {
            return TaiKhoanDAL.Instance.LayThongTinTaiKhoan(tenDangNhap);
        }

        public bool SuaTaiKhoan(TaiKhoan taiKhoan)
        {
            return TaiKhoanDAL.Instance.SuaTaiKhoan(taiKhoan);
        }
    }
}
