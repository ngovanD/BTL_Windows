using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class TaiKhoanDAL
    {
        private QLBanQuanAoContext db = new QLBanQuanAoContext();
        private static TaiKhoanDAL instance;

        public static TaiKhoanDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TaiKhoanDAL();
                }
                return instance;
            }
        }

        public TaiKhoan LayTaiKhoan(string tenDN)
        {
            return db.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == tenDN);
        }
    }
}
