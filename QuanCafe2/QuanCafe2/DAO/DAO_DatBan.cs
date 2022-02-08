using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanCafe2.DAO
{
    class DAO_DatBan
    {
        QuanLyCFEntities3 db;
        public DAO_DatBan()
        {
            db = new QuanLyCFEntities3();
        }

        public dynamic LayDSDatBan()
        {
            var ds = db.BanSanPhams.Select(s => new
            {
                s.Id,
                s.BanId,
                s.SanPham.TenSanPham,
                s.SoLuong,
                s.TongTien
            }).ToList();
            return ds;
        }
        public dynamic LayDSSP()
        {
            var ds = db.SanPhams.Select(s => new
            {
                s.Id,
                s.TenSanPham
            }).ToList();
            return ds;
        }
        public dynamic LayDSBanTrong()
        {
            var ds = db.Bans.Where(s => s.TinhTrang == 0).Select(s => new
            {
                s.Id,
            }).ToList();
            return ds;
        }
        public dynamic LayDSBan()
        {
            var ds = db.Bans.Select(s => new
            {
                s.Id,
            }).ToList();
            return ds;
        }

        public void ThemBD(BanSanPham s)
        {

            db.BanSanPhams.Add(s);
            db.SaveChanges();
        }

        public bool KiemTraBD(BanSanPham d)
        {
            BanSanPham o = db.BanSanPhams.Find(d.Id);
            if (d != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SuaBD(BanSanPham d)
        {
            BanSanPham o = db.BanSanPhams.Find(d.Id);
            o.SoLuong = d.SoLuong;
            o.SanPhamId = d.SanPhamId;
            o.BanId = d.BanId;
            db.SaveChanges();
        }
        public void XoaBD(BanSanPham d)
        {
            BanSanPham o = db.BanSanPhams.Find(d.Id);
            db.BanSanPhams.Remove(o);
            db.SaveChanges();
        }
        public void SetTinhTrang(int d)
        {
            Ban o = db.Bans.Find(d);
            o.TinhTrang = 1;
            db.SaveChanges();
        }
    }
}
