using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAL
{
    public class TaiKhoanDAO
    {
        private QLBanQuanAoContext db = new QLBanQuanAoContext();
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoanDAO();
                }
                return instance;
            }
        }

        public bool KiemTraTaiKhoan(string tenDangNhap, string matKhau)
        {
            bool check = db.TaiKhoans.Any(tk => tk.TenDangNhap == tenDangNhap && tk.MatKhau == matKhau);
            return check;
        }

        //true: nhan vien, false: admin
        public bool LaTaiKhoanNhanVien(string tenDangNhap)
        {
            var taiKhoan = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == tenDangNhap);
            if(taiKhoan.LoaiTaiKhoan == false)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
