using QuanCafe2.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanCafe2.BUS
{
    class BUS_NhanVien
    {
        DAO_NhanVien dNhanVien;
        public BUS_NhanVien()
        {
            dNhanVien = new DAO_NhanVien();
        }

        public void LayDSNhanVien(DataGridView dg)
        {
            dg.DataSource = dNhanVien.LayDSNhanVien();
        }

        public bool KiemTraDangNhap(string username, string password)
        {
            List<NhanVien> dsnv = new List<NhanVien>();
            dsnv = dNhanVien.KiemTraCredential(username, password);
            if (dsnv.Count > 0)
                return true;
            else
                return false;
        }

        public bool ThemNhanVien(NhanVien d)
        {
            try
            {
                dNhanVien.ThemNV(d);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool XoaNV(NhanVien s)
        {
            if (dNhanVien.KiemTraNV(s))
                try
                {
                    {
                        dNhanVien.XoaNV(s);
                        return true;
                    }
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;

                }
            else
            {
                return false;
            }

        }
        public bool SuaNV(NhanVien s)
        {
            if (dNhanVien.KiemTraNV(s))
                try
                {
                    {
                        dNhanVien.SuaNV(s);
                        return true;
                    }
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;

                }
            else
            {
                return false;
            }

        }
    }
}
