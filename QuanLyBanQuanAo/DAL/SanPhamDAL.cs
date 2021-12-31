using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class SanPhamDAL
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


    }
}
