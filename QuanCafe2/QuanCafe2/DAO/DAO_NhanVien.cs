using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanCafe2.DAO
{
    class DAO_NhanVien
    {
        QuanLyCFEntities3 db;
        public DAO_NhanVien()
        {
            db = new QuanLyCFEntities3();
        }

        public dynamic LayDSNhanVien()
        {
            var ds = db.NhanViens.Select(s => new
            {
                s.Id,
                s.HoTen,
                s.GioiTinh,
                s.NgaySinh
            }).ToList();
            return ds;
        }

        public List<NhanVien> KiemTraCredential(string username, string password)
        {
            var ds = db.NhanViens.Where(s => s.Username == username && s.Password == password ).ToList();
            return ds;
        }

        public void ThemNV(NhanVien s)
        {
            db.NhanViens.Add(s);
            db.SaveChanges();
        }
        public bool KiemTraNV(NhanVien d)
        {
            NhanVien o = db.NhanViens.Find(d.Id);
            if (d != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SuaNV(NhanVien d)
        {
            NhanVien o = db.NhanViens.Find(d.Id);
            o.HoTen = d.HoTen;
            o.GioiTinh = d.GioiTinh;
            o.NgaySinh = d.NgaySinh;
            db.SaveChanges();
        }
        public void XoaNV(NhanVien d)
        {
            NhanVien o = db.NhanViens.Find(d.Id);
            db.NhanViens.Remove(o);
            db.SaveChanges();
        }
    }
}
