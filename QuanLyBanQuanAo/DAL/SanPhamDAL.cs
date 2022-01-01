using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL
    {
        private QLBanQuanAoContext db = new QLBanQuanAoContext();
        private static SanPhamDAL instance;

        public static SanPhamDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SanPhamDAL();
                }
                return instance;
            }
        }

        public List<SanPham> LayToanBo()
        {
            return db.SanPhams.ToList();
        }

        public SanPham LayTheoMa(int maSP)
        {
            return db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == maSP);
        }

        public List<SanPham> LayTheoTuKhoa(string tenSP, int maLoaiSP)
        {
            if (tenSP == null)
            {
                return db.SanPhams.Where(sp => sp.LoaiSanPham.MaLoaiSanPham == maLoaiSP).ToList();
            }
            else if (maLoaiSP == 0)
            {
                return db.SanPhams.Where(sp => sp.TenSanPham.ToLower().Contains(tenSP.ToLower().Trim())).ToList();
            }
            else
            {
                return db.SanPhams.Where(sp => sp.TenSanPham.ToLower().Contains(tenSP.ToLower().Trim()) && sp.LoaiSanPham.MaLoaiSanPham == maLoaiSP).ToList();
            }
        }
    }
}
