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

        public bool KiemTraTenDangNhap(string tenDN)
        {
            return (TaiKhoanDAL.Instance.LayTaiKhoan(tenDN) != null) ? true : false;
        }
    }
}
