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
    public partial class FQuanLyBan : Form
    {
        string banIdTemp;
        BUS_Ban busBan;
        BUS_BanSanPham busBanSanPham;
        BUS_DoanhThu busDoanhThu;
        public FQuanLyBan()
        {
            InitializeComponent();
            busBan = new BUS_Ban();
            busBanSanPham = new BUS_BanSanPham();
            busDoanhThu = new BUS_DoanhThu();
        }

        private void HienThiDSBan()
        {
            gVBan.DataSource = null;
            busBan.LayDSBan(gVBan);
            gVBan.Columns[0].Width = (int)(gVBan.Width * 0.33);
            gVBan.Columns[1].Width = (int)(gVBan.Width * 0.33);
            gVBan.Columns[2].Width = (int)(gVBan.Width * 0.33);
        }

        private void FQuanLyBan_Load(object sender, EventArgs e)
        {
            HienThiDSBan();
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            Ban b = new Ban();
            try
            {
                b.Id = int.Parse(banIdTemp);
                b.TinhTrang = 0;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException || ex is ArgumentNullException)
                {
                    MessageBox.Show("Vui lòng chọn bàn");
                }
                throw;
            }

            if (busBan.CapNhatBan(b))
            {
                MessageBox.Show("Thanh toán thành công");
                busBan.HienThiDSBan(gVBan);
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại");
            }
            DoanhThu d = new DoanhThu();
            int SanPhamIdTemp=0;
            int TongSoLuongTemp=0;
            decimal TongTienSPTemp=0;
            DateTime ThoiDiemTemp = DateTime.Now;
            List<BanSanPham> listBanSanPhamTemp = busBanSanPham.GetDSBanSanPham(int.Parse(banIdTemp));
            List<DoanhThu> ListDoanhThuTemp = new List<DoanhThu>();

            listBanSanPhamTemp = busBanSanPham.GetDSBanSanPham(int.Parse(banIdTemp));
            foreach(BanSanPham k in listBanSanPhamTemp)
            {
                busBanSanPham.CapNhatBanSanPham(k);
                busBan.HienThiDSBan(gVBan);
                SanPhamIdTemp = int.Parse(k.SanPhamId.ToString());
                TongSoLuongTemp = int.Parse(k.SoLuong.ToString());
                TongTienSPTemp = int.Parse(k.TongTien.ToString());

                d.SanPhamId = SanPhamIdTemp;
                d.TongSoLuong = TongSoLuongTemp;
                d.TongTienSP = TongTienSPTemp;
                d.ThoiDiem = ThoiDiemTemp;
                busDoanhThu.TaoDoanhThu(d);
            }
        }

        private void gVBan_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVBan.Rows.Count)
            {
                banIdTemp = gVBan.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            }
        }
    }
}
