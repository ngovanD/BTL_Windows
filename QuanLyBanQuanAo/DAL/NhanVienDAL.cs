using DTO;
using System;
using System.Collections.Generic;
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

        public NhanVien LayThongTinNhanVien(int IDTK)
        {
            var taiKhoan = db.NhanViens.SingleOrDefault(tk => tk.IdTK == IDTK);
            return taiKhoan;
        }

        public bool SuaNhanVien(NhanVien nhanVien)
        {
            NhanVien nhanVienCanSua = db.NhanViens.Where(n => n.ID == nhanVien.ID).FirstOrDefault();
            try
            {
                nhanVienCanSua = nhanVien;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
