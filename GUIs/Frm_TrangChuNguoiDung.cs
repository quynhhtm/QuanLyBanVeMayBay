using System;
using System.Data;
using System.Windows.Forms;
using HeQuanTriDemo01.Models;
using QuanLyBanVeMayBay.BLLs;
using QuanLyBanVeMayBay.UCs;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_TrangChuNguoiDung : Form
    {
        public Frm_TrangChuNguoiDung()
        {
            InitializeComponent();
        }

        private void Frm_TrangChuNguoiDung_Load(object sender, EventArgs e)
        {
            BLL_ChuyenBay bll = new BLL_ChuyenBay();

            string error1 = "";
            string error2 = "";

            DataSet dataset1 = bll.lay_DiemDi(ref error1);
            DataTable datatable1 = new DataTable();
            datatable1.Clear();
            datatable1 = dataset1.Tables[0];
            foreach (DataRow row in datatable1.Rows)
                Cmb_DiemDi.Items.Add(row["DiemDi"]);

            DataSet dataset2 = bll.lay_DiemDen(ref error2);
            DataTable datatable2 = new DataTable();
            datatable2.Clear();
            datatable2 = dataset2.Tables[0];
            foreach (DataRow row in datatable2.Rows)
                Cmb_DiemDen.Items.Add(row["DiemDen"]);

            lay_DeXuatChuyenBay(8, "-1", "-1", -1);
        }

        private void lay_DeXuatChuyenBay(
            int soluongdexuat,
            string diemdi,
            string diemden,
            float ngansach)
        {
            BLL_ChuyenBay bll = new BLL_ChuyenBay();
            string error = "";

            this.SuspendLayout();
            this.Pnl_DeXuatChuyenBay.SuspendLayout();
            this.Pnl_DanhSachDeXuat.SuspendLayout();
            this.Pnl_DanhSachDeXuat.Controls.Clear();

            DataSet dataset = bll.lay_DeXuatChuyenBay(soluongdexuat, diemdi, diemden, ngansach, ref error);
            DataTable datatable = new DataTable();
            datatable.Clear();
            datatable = dataset.Tables[0];

            for (int i = 0; i < datatable.Rows.Count; ++i)
            {
                UC_ThongTinChuyenBayDeXuat chuyenbay = new UC_ThongTinChuyenBayDeXuat();
                chuyenbay.Lbl_DiemDi.Text = datatable.Rows[i]["DiemDi"].ToString();
                chuyenbay.Lbl_DiemDen.Text = datatable.Rows[i]["DiemDen"].ToString();
                chuyenbay.Lbl_NgayDi.Text = ((DateTime)datatable.Rows[i]["ThoiGianDi"]).ToString();
                chuyenbay.Lbl_GiaTien.Text = "Từ: " + datatable.Rows[i]["GiaVePhoThong"].ToString() + " VND";
                chuyenbay.Location = new System.Drawing.Point(5 + 300 * (i % 4), 5 + 438 * (i / 4));

                this.Pnl_DanhSachDeXuat.Controls.Add(chuyenbay);
            }

            this.Pnl_DanhSachDeXuat.ResumeLayout(false);
            this.Pnl_DeXuatChuyenBay.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void Txt_NganSach_Click(object sender, EventArgs e)
        {
            Txt_NganSach.Text = string.Empty;
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            Cmb_DiemDi.Text = "Điểm đi";
            Cmb_DiemDen.Text = "Điểm đến";
            Txt_NganSach.Text = "Ngân sách";
        }

        private void Btn_TimKiem_Click(object sender, EventArgs e)
        {
            int soluongdexuat = 8;
            string diemdi = Cmb_DiemDi.Text.Trim();
            string diemden = Cmb_DiemDen.Text.Trim();
            float ngansach = -1;

            diemdi = (diemdi.Equals("Điểm đi") ? "-1" : Cmb_DiemDi.Text);
            diemden = (diemden.Equals("Điểm đến") ? "-1" : Cmb_DiemDen.Text);
            if (!float.TryParse(Txt_NganSach.Text, out ngansach)) ngansach = -1;

            lay_DeXuatChuyenBay(soluongdexuat, diemdi, diemden, ngansach);
        }

        private void Btn_MuaVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Frm_TimKiemChuyenBay form1 = new Frm_TimKiemChuyenBay();
            form1.ShowDialog();

            this.Show();
        }

        private void Btn_TraCuuHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();

            Frm_TraCuuHoaDon form1 = new Frm_TraCuuHoaDon();
            form1.ShowDialog();

            this.Show();
        }

        private void Btn_TraCuuChuyenBay_Click(object sender, EventArgs e)
        {
            this.Hide();

            Frm_TraCuuChuyenBay form1 = new Frm_TraCuuChuyenBay();
            form1.ShowDialog();

            this.Show();
        }
    }
}
 