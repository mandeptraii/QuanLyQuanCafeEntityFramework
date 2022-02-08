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
    public partial class FDoanhThu : Form
    {
        BUS_DoanhThu busDT;
        public FDoanhThu()
        {
            InitializeComponent();
            busDT = new BUS_DoanhThu();
            for (int i = 2000; i <= 2100; i++)
            {
                cbNam.Items.Add(i.ToString());
            }
        }

        public void HienThiDSDoanhThu()
        {
            gVDT.DataSource = null;
            busDT.LayDSDoanhThu(gVDT);
            gVDT.Columns[0].Width = (int)(gVDT.Width * 0.35);
            gVDT.Columns[1].Width = (int)(gVDT.Width * 0.15);
            gVDT.Columns[2].Width = (int)(gVDT.Width * 0.15);
            gVDT.Columns[3].Width = (int)(gVDT.Width * 0.35);
        }

        private void FDoanhThu_Load(object sender, EventArgs e)
        {
            HienThiDSDoanhThu();
        }
        private void btChon_Click(object sender, EventArgs e)
        {
            if (cbThang.GetItemText(cbThang.SelectedItem).Length != 0 && cbNam.GetItemText(cbNam.SelectedItem).Length != 0)
            {
                busDT.LayDSDoanhThuThang(gVDT, cbThang.GetItemText(cbThang.SelectedItem),
              cbNam.GetItemText(cbNam.SelectedItem));
                if (gVDT.Rows.Count == 0)
                {
                    MessageBox.Show
                 (
                     "Không có doanh thu tháng trong năm nay", "Tổng kết", MessageBoxButtons.OK, MessageBoxIcon.Question
                 );
                }
            }
            else
            {
                MessageBox.Show
                  (
                      "Vui lòng nhập tháng, năm", "Tổng kết", MessageBoxButtons.OK, MessageBoxIcon.Error
                  );
            }
        }

        private void btTongKet_Click(object sender, EventArgs e)
        {
            busDT.LayDSDoanhThuThangMB(cbThang.GetItemText(cbThang.SelectedItem),
                cbNam.GetItemText(cbNam.SelectedItem));
        }
    }
}
