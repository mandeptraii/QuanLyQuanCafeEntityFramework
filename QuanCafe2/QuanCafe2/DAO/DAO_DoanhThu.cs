using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanCafe2.DAO
{
    class DAO_DoanhThu
    {
        QuanLyCFEntities3 db;
        public DAO_DoanhThu()
        {
            db = new QuanLyCFEntities3();
        }

        public void ThemDoanhThu(DoanhThu d)
        {
            db.DoanhThus.Add(d);
            db.SaveChanges();
        }

        public dynamic LayDSDoanhThu()
        {
            var ds = db.DoanhThus.Select(s => new
            {
                s.SanPham.TenSanPham,
                s.TongSoLuong,
                s.TongTienSP,
                s.ThoiDiem
            }).ToList();
            return ds;
        }

        public dynamic LayDSDoanhThuThang(String Thang, String Nam)
        {
            var ds = db.DoanhThus.Where
                (
                   s => s.ThoiDiem.ToString().Substring(5, 2) == Thang &&
                   s.ThoiDiem.ToString().Substring(0, 4) == Nam
                ).Select
                (s => new
                {
                    s.SanPham.TenSanPham,
                    s.TongSoLuong,
                    s.TongTienSP,
                    s.ThoiDiem
                })
                .ToList();
            return ds;
        }

        public List<DoanhThu> LayDSDoanhThuThangMB(String Thang, String Nam)
        {
            var ds = db.DoanhThus.Where
                (
                   s => s.ThoiDiem.ToString().Substring(5, 2) == Thang &&
                   s.ThoiDiem.ToString().Substring(0, 4) == Nam
                ).ToList();
            return ds;
        }
    }
}
