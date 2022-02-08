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
    class BUS_BanSanPham
    {
        DAO_BanSanPham dBanSanPham;
        public BUS_BanSanPham()
        {
            dBanSanPham = new DAO_BanSanPham();
        }

        public List<BanSanPham> GetDSBanSanPham(int banId)
        {
            List<BanSanPham> listBanSanPham = new List<BanSanPham>();
            listBanSanPham = dBanSanPham.LayDSBanChuaTinhTien(banId);
            return listBanSanPham;
        }

        public bool CapNhatBanSanPham(BanSanPham d)
        {
            if (dBanSanPham.KiemTraBanSanPham(d))
            {
                try
                {
                    dBanSanPham.CapNhatBanSanPham(d);
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
    }
}
