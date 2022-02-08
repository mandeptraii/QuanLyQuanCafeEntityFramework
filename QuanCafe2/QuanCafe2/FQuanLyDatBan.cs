using QuanCafe2.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanCafe2
{
    public partial class FQuanLyDatBan : Form
    {
        BUS_DatBan busDB;
        BUS_SanPham busSP;
        public FQuanLyDatBan()
        {
            InitializeComponent();
            busDB = new BUS_DatBan();
            busSP = new BUS_SanPham();
        }

        public void HienThiDSBanDat()
        {
            gVBanDat.DataSource = null;
            busDB.LayDSDatBan(gVBanDat);
            gVBanDat.Columns[0].Width = (int)(gVBanDat.Width * 0.15);
            gVBanDat.Columns[1].Width = (int)(gVBanDat.Width * 0.15);
            gVBanDat.Columns[2].Width = (int)(gVBanDat.Width * 0.25);
            gVBanDat.Columns[3].Width = (int)(gVBanDat.Width * 0.15);
            gVBanDat.Columns[4].Width = (int)(gVBanDat.Width * 0.21);
        }

        private void FQuanLyDatBan_Load(object sender, EventArgs e)
        {
            HienThiDSBanDat();
            busDB.LayDSSP(cbTenSP);
            busDB.LayDSBan(cbBan);
        }

        private void btThem_Click(object sender, EventArgs e)
        {

            BanSanPham db = new BanSanPham();
            db.SanPhamId = busSP.LayIdSanPham(cbTenSP.Text);
            db.SoLuong = int.Parse(txtSoLuong.Text);
            db.BanId = int.Parse(cbBan.Text);
            db.TongTien = int.Parse(txtSoLuong.Text) * busSP.LayTienSanPham(cbTenSP.Text);
            if (busDB.ThemBanDat(db))
            {
                MessageBox.Show("Them ban dat thanh cong");
                busDB.LayDSDatBan(gVBanDat);
                busDB.SetTinhTrang(int.Parse(cbBan.Text));
            }
            else
            {
                MessageBox.Show("Them ban dat that bai");
            }


        }

        private void gVBanDat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVBanDat.Rows.Count)
            {
                txtSoLuong.Text = gVBanDat.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbBan.Text = gVBanDat.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbTenSP.Text = gVBanDat.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTongTien.Text = gVBanDat.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMaBD.Text = gVBanDat.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            BanSanPham d = new BanSanPham();
            d.Id = int.Parse(txtMaBD.Text);
            if (busDB.XoaBD(d))
            {
                MessageBox.Show("Xoa ban dat thanh cong");
                busDB.LayDSDatBan(gVBanDat);
            }
            else
            {
                MessageBox.Show("Xoa ban dat that bai");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            BanSanPham d = new BanSanPham();
            d.Id = int.Parse(txtMaBD.Text);
            d.BanId = int.Parse(cbBan.Text);
            d.SoLuong = int.Parse(txtSoLuong.Text);
            d.SanPhamId = busSP.LayIdSanPham(cbTenSP.Text);
            if (busDB.SuaBD(d))
            {
                MessageBox.Show("Sua ban dat thanh cong");
                busDB.LayDSDatBan(gVBanDat);
            }
            else
            {
                MessageBox.Show("Sua ban dat that bai");
            }
        }
    }
}
