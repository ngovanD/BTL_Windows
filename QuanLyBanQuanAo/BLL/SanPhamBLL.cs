using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class SanPhamBLL
    {
        private static SanPhamBLL instance;

        public static SanPhamBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamBLL();
                }
                return instance;
            }
        }

        public SanPham LayTheoMa(int maSP)
        {
            return SanPhamDAL.Instance.LayTheoMa(maSP);
        }
    }
}
