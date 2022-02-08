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
    class BUS_Ban
    {
        DAO_Ban dBan;
        public BUS_Ban()
        {
            dBan = new DAO_Ban();
        }

        public void HienThiDSBan(DataGridView dg)
        {
            dg.DataSource = dBan.LayDSBan();
        }

        public void LayDSBan(DataGridView dg)
        {
            dg.DataSource = dBan.LayDSBan();
        }

        public void LayDSBanChuaDat(DataGridView dg)
        {
            dg.DataSource = dBan.LayDSBanChuaDat();
        }

        public bool CapNhatBan(Ban d)
        {
            if(dBan.KiemTraBan(d))
            {
                try
                {
                    dBan.SuaBan(d);
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
