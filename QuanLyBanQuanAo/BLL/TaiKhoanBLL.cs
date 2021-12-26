using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

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
            return TaiKhoanDAO.Instance.KiemTraTaiKhoan(tenDangNhap, matKhau);
        }
        public bool LaTaiKhoanNhanVien(string tenDangNhap)
        {
            return TaiKhoanDAO.Instance.LaTaiKhoanNhanVien(tenDangNhap);
        }
    }
}
