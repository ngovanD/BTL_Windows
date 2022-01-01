using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
