using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanCafe2.DAO
{
    class DAO_BanSanPham
    {
        QuanLyCFEntities3 db;
        public DAO_BanSanPham()
        {
            db = new QuanLyCFEntities3();
        }
        public List<BanSanPham> LayDSBanChuaTinhTien(int banId)
        {
            var ds = db.BanSanPhams.Where(s => s.BanId == banId && s.DaTinhTien == 0).ToList();
            return ds;
        }

        public bool KiemTraBanSanPham(BanSanPham d)
        {
            BanSanPham o = db.BanSanPhams.Find(d.Id);
            if (d != null)
                return true;
            else
                return false;
        }

        public void CapNhatBanSanPham(BanSanPham d)
        {
            BanSanPham o = db.BanSanPhams.Find(d.Id);
            o.DaTinhTien = 1;
            db.SaveChanges();
        }
    }
}
