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
    class BUS_DatBan
    {
        DAO_DatBan dDatBan;
        public BUS_DatBan()
        {
            dDatBan = new DAO_DatBan();
        }

        public void LayDSDatBan(DataGridView dg)
        {
            dg.DataSource = dDatBan.LayDSDatBan();
        }
        public void LayDSSP(ComboBox cbb)
        {
            cbb.DataSource = dDatBan.LayDSSP();
            cbb.DisplayMember = "TenSanPham";
            cbb.ValueMember = "Id";
        }
        public void LayDSBanTrong(ComboBox cbb)
        {
            cbb.DataSource = dDatBan.LayDSBanTrong();
            cbb.DisplayMember = "Id";
            cbb.ValueMember = "Id";
        }
        public void LayDSBan(ComboBox cbb)
        {
            cbb.DataSource = dDatBan.LayDSBan();
            cbb.DisplayMember = "Id";
            cbb.ValueMember = "Id";
        }
        public bool ThemBanDat(BanSanPham d)
        {
            try
            {
                dDatBan.ThemBD(d);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SetTinhTrang(int d)
        {
            try
            {
                dDatBan.SetTinhTrang(d);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool SuaBD(BanSanPham d)
        {
            if (dDatBan.KiemTraBD(d))
            {
                try
                {
                    dDatBan.SuaBD(d);
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
        public bool XoaBD(BanSanPham d)
        {
            if (dDatBan.KiemTraBD(d))
            {
                try
                {
                    dDatBan.XoaBD(d);
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
