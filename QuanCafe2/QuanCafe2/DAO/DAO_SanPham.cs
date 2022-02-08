using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanCafe2.DAO
{
    class DAO_SanPham
    {
        QuanLyCFEntities3 db;

        public DAO_SanPham()
        {
            db = new QuanLyCFEntities3();
        }
        public dynamic LayDSSanPham()
        {
            var ds = db.SanPhams.Select(s => new
            {
                s.Id,
                s.TenSanPham,
                s.GiaTien
            }).ToList();
            return ds;
        }
        public void ThemSP(SanPham s)
        {
            db.SanPhams.Add(s);
            db.SaveChanges();
        }
        public bool KiemTraSP(SanPham d)
        {
            SanPham o = db.SanPhams.Find(d.Id);
            if (d != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SuaSP(SanPham d)
        {
            SanPham o = db.SanPhams.Find(d.Id);
            o.GiaTien = d.GiaTien;
            o.TenSanPham = d.TenSanPham;            
            db.SaveChanges();
        }



        public List<SanPham> TimSanPham(string ten)
        {
            var ds = db.SanPhams.Where(s => s.TenSanPham == ten).ToList();
            return ds;
        }
        

        public void XoaSP(SanPham d)
        {
            SanPham o = db.SanPhams.Find(d.Id);
            db.SanPhams.Remove(o);
            db.SaveChanges();
        }
    }
}
