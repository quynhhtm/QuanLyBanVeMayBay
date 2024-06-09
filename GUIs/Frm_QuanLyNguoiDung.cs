using QuanLyBanVeMayBay.BLLs;
using QuanLyBanVeMayBay.UCs;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_QuanLyNguoiDung : Form
    {
        public Frm_QuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void Btn_TraCuu_Click(object sender, EventArgs e)
        {
            BLL_HoaDon bll = new BLL_HoaDon();
            string error = "";
            string sodienthoai = Txt_SoDienThoaiTraCuu.Text;

            DataSet dataset = bll.timkiem_LichSuGiaoDich(sodienthoai, ref error);
            DataTable datatable = dataset.Tables[0];

            this.SuspendLayout();
            this.Pnl_ThongTinHoaDon.SuspendLayout();
            this.Pnl_DanhSachHoaDon.SuspendLayout();
            this.Pnl_DanhSachHoaDon.Controls.Clear();

            if(datatable.Rows.Count > 0)
            {
                this.Txt_MaNguoiDung.Text = datatable.Rows[0]["MaNguoiDung"].ToString();
                this.Txt_HoTen.Text = datatable.Rows[0]["HoTen"].ToString();
                this.Txt_Email.Text = datatable.Rows[0]["Email"].ToString();

            }

            for (int i = 0; i < datatable.Rows.Count; ++i)
            {
                UC_ThongTinGiaoDich hoadon = new UC_ThongTinGiaoDich();
                hoadon.Location = new System.Drawing.Point(1, 5 + 92 * i);
                hoadon.Lbl_MaHoaDon.Text = datatable.Rows[i]["MaHoaDon"].ToString();
                hoadon.Lbl_TongTien.Text = datatable.Rows[i]["TongTien"].ToString();
                hoadon.Lbl_ThoiGianThanhToan.Text = datatable.Rows[i]["ThoiGianThanhToan"].ToString();
                hoadon.Lbl_SoLuongVe.Text = datatable.Rows[i]["SoLuongVe"].ToString();
                this.Pnl_DanhSachHoaDon.Controls.Add(hoadon);
            }


            this.ResumeLayout(false);
            this.Pnl_ThongTinHoaDon.ResumeLayout(false);
            this.Pnl_DanhSachHoaDon.ResumeLayout(false);
        }
    }
}

