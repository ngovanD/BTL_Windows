using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LuongDAL
    {
        private QLBanQuanAoContext db = new QLBanQuanAoContext();
        private static LuongDAL instance;

        public static LuongDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LuongDAL();
                }
                return instance;
            }
        }
        public Luong LayThongTinLuong(int ID, string thangNam)
        {
            var luong = db.Luongs.AsEnumerable()
                                .Where(l => l.MaNhanVien == ID && String.Format("MM/yyyy", l.ThangNam) == String.Format("MM/yyyy", thangNam))
                                .FirstOrDefault();
            return luong;
        }
    }
}
