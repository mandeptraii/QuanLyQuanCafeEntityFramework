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
    public partial class FQuanLyNhanVien : Form
    {
        BUS_NhanVien busNV;
        public FQuanLyNhanVien()
        {

            InitializeComponent();
            busNV = new BUS_NhanVien();
        }

        public void HienThiDSNhanVien()
        {
            gVNV.DataSource = null;
            busNV.LayDSNhanVien(gVNV);
            gVNV.Columns[0].Width = (int)(gVNV.Width * 0.15);
            gVNV.Columns[1].Width = (int)(gVNV.Width * 0.35);
            gVNV.Columns[2].Width = (int)(gVNV.Width * 0.15);
            gVNV.Columns[3].Width = (int)(gVNV.Width * 0.35);
        }

        private void FQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDSNhanVien();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.HoTen = txtTenNV.Text;
            nv.NgaySinh = dtpNgaySinh.Value;
            nv.Password = txtMK.Text;
            nv.Username = txtTK.Text;
            if (rdNam.Checked)
            {
                nv.GioiTinh = "Nam";
            }
            else if (rdNu.Checked)
            {
                nv.GioiTinh = "Nu";
            }
            else
            {
                nv.GioiTinh = "Khac";
            }
            if (busNV.ThemNhanVien(nv))
            {
                MessageBox.Show("Them nhan vien thanh cong");
                busNV.LayDSNhanVien(gVNV);

            }
            else
            {
                MessageBox.Show("Them nhan vien that bai");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            NhanVien s = new NhanVien();
            s.Id = int.Parse(txtId.Text);
            if (busNV.XoaNV(s))
            {
                MessageBox.Show("Xoa nhan vien thanh cong");
                busNV.LayDSNhanVien(gVNV);

            }
            else
            {
                MessageBox.Show("Xoa nhan vien that bai");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            NhanVien d = new NhanVien();
            d.Id = int.Parse(txtId.Text);
            d.NgaySinh = dtpNgaySinh.Value;
            d.HoTen = txtTenNV.Text;
            d.Password = txtMK.Text;
            d.Username = txtTK.Text;
            if (rdNam.Checked)
            {
                d.GioiTinh = "Nam";
            }
            else
            {
                d.GioiTinh = "Nu";
            }

            if (busNV.SuaNV(d))
            {
                MessageBox.Show("Sua nhan vien thanh cong");
                busNV.LayDSNhanVien(gVNV);
            }
            else
            {
                MessageBox.Show("Sua nhan vien that bai");
            }
        }

        private void gVNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVNV.Rows.Count)
            {
                txtId.Text = gVNV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenNV.Text = gVNV.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpNgaySinh.Text = gVNV.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (gVNV.Rows[e.RowIndex].Cells[2].Value.ToString() == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                {
                    rdNu.Checked = true;
                }

            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
