using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanCafe2.BUS;

namespace QuanCafe2
{
    public partial class FQuanLySanPham : Form
    {
        BUS_SanPham busSP;
        
        public FQuanLySanPham()
        {

            InitializeComponent();
            busSP = new BUS_SanPham(); 
            
        }
                
        private void HienThiDSSP()
        {
            gVSanPham.DataSource = null;
            busSP.LayDSSP(gVSanPham);
            gVSanPham.Columns[0].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[1].Width = (int)(gVSanPham.Width * 0.65);
            gVSanPham.Columns[2].Width = (int)(gVSanPham.Width * 0.25);            
        }
        private void FQuanLySanPham_Load(object sender, EventArgs e)
        {
            HienThiDSSP();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();

            sp.TenSanPham = txtTenSP.Text;
            sp.GiaTien = Decimal.Parse(txtDonGia.Text);
            if(busSP.ThemSanPham(sp))
            {
                MessageBox.Show("Them san pham thanh cong");
                busSP.LayDSSP(gVSanPham);

            }
            else
            {
                MessageBox.Show("Them san pham that bai");
            }

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            SanPham s = new SanPham();
            s.Id= int.Parse(txtId.Text);
            if (busSP.XoaSP(s))
            {
                MessageBox.Show("Xoa san pham thanh cong");
                busSP.LayDSSP(gVSanPham);

            }
            else
            {
                MessageBox.Show("Xoa san pham that bai");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SanPham d = new SanPham();
            d.Id = int.Parse(txtId.Text);
            d.TenSanPham = txtTenSP.Text;
            d.GiaTien = Decimal.Parse(txtDonGia.Text);
            if (busSP.SuaSP(d))
            {
                MessageBox.Show("Sua san pham thanh cong");
                busSP.LayDSSP(gVSanPham);
            }
            else
            {
                MessageBox.Show("Sua san pham that bai");
            }
        }

        private void gVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0 && e.RowIndex<gVSanPham.Rows.Count)
            {
                txtId.Text= gVSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDonGia.Text = gVSanPham.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTenSP.Text = gVSanPham.Rows[e.RowIndex].Cells[1].Value.ToString(); 
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
