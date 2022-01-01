using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        private QLBanQuanAoContext db = new QLBanQuanAoContext();
        private static HoaDonDAL instance;

        public static HoaDonDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonDAL();
                }
                return instance;
            }
        }

        public int LaySoHoaDon(String maHD)
        {
            return db.HoaDons.Count(hd=>hd.MaHoaDon.Contains(maHD)) + 1;

        }

        public void LuuHoaDon(HoaDon hoaDon, List<DongHoaDon> dongHoaDons)
        {
            db.HoaDons.Add(hoaDon);
            db.SaveChanges();

            db.DongHoaDons.AddRange(dongHoaDons);
            db.SaveChanges();
        }

        public HoaDon LayTheoMa(string maHoaDon)
        {
            return db.HoaDons.FirstOrDefault(nv => nv.MaHoaDon == maHoaDon);
        }
    }
}
