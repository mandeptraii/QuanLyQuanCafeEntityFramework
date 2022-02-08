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
    public partial class FDangNhap : Form
    {
        BUS_NhanVien busNV;
        public FDangNhap()
        {
            InitializeComponent();
            busNV = new BUS_NhanVien();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (busNV.KiemTraDangNhap(txtUsername.Text, txtPassword.Text))
            {
                Form1.checkLogin = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai username hoặc password");
            }
                
        }
    }
}
