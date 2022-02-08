using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanCafe2.DAO;

namespace QuanCafe2.BUS
{
    class BUS_SanPham
    {
        DAO_SanPham dSanPham;
        public BUS_SanPham()
        {
            dSanPham = new DAO_SanPham();
        }
        public void LayDSSP(DataGridView dg)
        {
            dg.DataSource = dSanPham.LayDSSanPham();
        }
        public bool ThemSanPham(SanPham d)
        {
            try
            {
                dSanPham.ThemSP(d);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public int LayIdSanPham(String ten)
        {
            List<SanPham> SanPhamTemp = dSanPham.TimSanPham(ten);
            return SanPhamTemp[0].Id;
        }
        public Decimal LayTienSanPham(String ten)
        {
            List<SanPham> SanPhamTemp = dSanPham.TimSanPham(ten);
            return Decimal.Parse(SanPhamTemp[0].GiaTien.ToString());
        }

        public bool SuaSP(SanPham d)
        {
            if (dSanPham.KiemTraSP(d))
            {
                try
                {
                    dSanPham.SuaSP(d);
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public bool XoaSP(SanPham s)
        {
            if (dSanPham.KiemTraSP(s))
                try
                {
                    {
                        dSanPham.XoaSP(s);
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
