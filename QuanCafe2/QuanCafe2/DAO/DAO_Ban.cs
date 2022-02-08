using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanCafe2.DAO
{
    class DAO_Ban
    {
        QuanLyCFEntities3 db;
        public DAO_Ban()
        {
            db = new QuanLyCFEntities3();
        }

        public dynamic LayDSBan()
        {
            var ds = db.Bans.Where(s => s.TinhTrang == 1).Select(s => new
            {
                s.Id,
                s.SucChua,
                s.TinhTrang
            }).ToList();
            return ds;
        }

        public dynamic LayDSBanChuaDat()
        {
            var ds = db.Bans.Where(s => s.TinhTrang == 0).ToList();
            return ds;
        }

        public bool KiemTraBan(Ban d)
        {
            Ban b = db.Bans.Find(d.Id);
            if(d != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SuaBan(Ban d)
        {
            Ban b = db.Bans.Find(d.Id);
            b.TinhTrang = d.TinhTrang;
            db.SaveChanges();
        }
    }
}
