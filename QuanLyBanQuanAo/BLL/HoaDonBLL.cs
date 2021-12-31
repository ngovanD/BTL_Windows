using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        private static HoaDonBLL instance;

        public static HoaDonBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HoaDonBLL();
                }
                return instance;
            }
        }

        public String TaoMaHoaDon(bool kiemTra)
        {
            String ma = (kiemTra) ? "HDB-" : "HDN-";
            DateTime date = DateTime.Now;
            ma += date.ToString("ddMMyy-");
            ma += HoaDonDAL.Instance.LaySoHoaDon(ma).ToString("000");
            return ma;
        }

    }
}
