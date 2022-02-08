using QuanCafe2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanCafe2.BUS
{
    class BUS_DoanhThu
    {
        DAO_DoanhThu dDoanhThu;
        public BUS_DoanhThu()
        {
            dDoanhThu = new DAO_DoanhThu();
        }

        public bool TaoDoanhThu(DoanhThu d)
        {
            try
            {
                dDoanhThu.ThemDoanhThu(d);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void LayDSDoanhThu(DataGridView dg)
        {
            dg.DataSource = dDoanhThu.LayDSDoanhThu();
        }

        public void LayDSDoanhThuThang(DataGridView dg, String Thang, String Nam)
        {
            dg.DataSource = null;
            dg.DataSource = dDoanhThu.LayDSDoanhThuThang(Thang, Nam);
            dg.Columns[0].Width = (int)(dg.Width * 0.35);
            dg.Columns[1].Width = (int)(dg.Width * 0.15);
            dg.Columns[2].Width = (int)(dg.Width * 0.15);
            dg.Columns[3].Width = (int)(dg.Width * 0.35);
        }

        public void LayDSDoanhThuThangMB(String Thang, String Nam)
        {
            int tempTongSL = 0;
            double tempTongTien = 0;
            String m = "01";
            String y = "01";
            List<DoanhThu> temp = new List<DoanhThu>();
            temp = dDoanhThu.LayDSDoanhThuThangMB(Thang, Nam);
            foreach (DoanhThu a in temp)
            {
                String ThoiDiem = a.ThoiDiem.ToString();
                String[] Check = ThoiDiem.Split('/');
                m = Check[0];
                y = Check[2].Substring(0, 4);
                //if (int.Parse(Check[0])>=10)
                //{
                //    m = a.ThoiDiem.ToString().Substring(0, 2);
                //    if(int.Parse(Check[0]) >= 10)
                //        y = a.ThoiDiem.ToString().Substring(6, 4);
                //    else
                //        y = a.ThoiDiem.ToString().Substring(5, 4);
                //}
                //else
                //{
                //    m = a.ThoiDiem.ToString().Substring(0, 1);
                //    if (int.Parse(Check[0]) >= 10)
                //        y = a.ThoiDiem.ToString().Substring(5, 4);
                //    else
                //        y = a.ThoiDiem.ToString().Substring(4, 4);
                //}

                tempTongSL += int.Parse(a.TongSoLuong.ToString());
                tempTongTien += Double.Parse(a.TongTienSP.ToString());
            }
            if (tempTongSL != 0 && tempTongTien != 0)
            {
                MessageBox.Show
                  (
                      "Tổng sản phẩm bán: " + tempTongSL.ToString() +
                      "\n\nTổng tiền bán: " + tempTongTien.ToString() +
                      "\n\nTháng: " + m +
                      "\n\nNăm: " + y, "Tổng kết", MessageBoxButtons.OK
                  );
            }
            else
            {
                MessageBox.Show
                  (
                      "Không có dữ liệu", "Tổng kết", MessageBoxButtons.OK, MessageBoxIcon.Error
                  );
            }
        }
    }
}
