using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        private QLBanQuanAoContext db = new QLBanQuanAoContext();
        private static LoaiSanPhamDAL instance;

        public static LoaiSanPhamDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoaiSanPhamDAL();
                }
                return instance;
            }
        }

        public List<LoaiSanPham> LayToanBo()
        {
            return db.LoaiSanPhams.ToList();
        }
    }
}
