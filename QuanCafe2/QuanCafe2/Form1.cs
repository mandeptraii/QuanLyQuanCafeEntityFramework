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
    public partial class Form1 : Form
    {
        BUS_NhanVien busNV;
        public static bool checkLogin = false;
        public Form1()
        {
            InitializeComponent();
            busNV = new BUS_NhanVien();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQuanLyNhanVien f = new FQuanLyNhanVien();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void đặtBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQuanLyDatBan f = new FQuanLyDatBan();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void thanhToanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQuanLyBan f = new FQuanLyBan();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDoanhThu f = new FDoanhThu();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void dangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDangNhap f = new FDangNhap();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void quanLySanPhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FQuanLySanPham f = new FQuanLySanPham();
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        public void DisposeAll(Form form)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }
        }

        private void KiemTraDangNhap()
        {
            if (checkLogin)
            {
                quanLyNhanVienToolStripMenuItem.Enabled = true;
                quanLySanPhamToolStripMenuItem.Enabled = true;
                datBanToolStripMenuItem.Enabled = true;
                thanhToanToolStripMenuItem.Enabled = true;
                doanhThuToolStripMenuItem.Enabled = true;
                txtPassword.Visible = txtUsername.Visible = label1.Visible = label2.Visible = btLogin.Visible = false;
            }
            else
            {
                quanLyNhanVienToolStripMenuItem.Enabled = false;
                quanLySanPhamToolStripMenuItem.Enabled = false;
                datBanToolStripMenuItem.Enabled = false;
                thanhToanToolStripMenuItem.Enabled = false;
                doanhThuToolStripMenuItem.Enabled = false;
                txtPassword.Visible = txtUsername.Visible = label1.Visible = label2.Visible = btLogin.Visible = true;
                
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (busNV.KiemTraDangNhap(txtUsername.Text, txtPassword.Text))
            {
                checkLogin = true;
                KiemTraDangNhap();
            }
            else
            {
                MessageBox.Show("Sai username hoặc password");
            }
        }
    }
}
