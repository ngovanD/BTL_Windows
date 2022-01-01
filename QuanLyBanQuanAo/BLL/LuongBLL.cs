using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LuongBLL
    {
        private static LuongBLL instance;

        public static LuongBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LuongBLL();
                }
                return instance;
            }
        }

        public Luong LayThongTinLuong(int maNhanVien, string thangNam)
        {
            return LuongDAL.Instance.LayThongTinLuong(maNhanVien, thangNam);
        }
    }
}
