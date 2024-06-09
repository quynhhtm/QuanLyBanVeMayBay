using QuanLyBanVeMayBay.BLLs;
using QuanLyBanVeMayBay.UCs;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_TraCuuChuyenBay : Form
    {

        BLL_ChuyenBay ChuyenBay = new BLL_ChuyenBay();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string error = "";
        public Frm_TraCuuChuyenBay()
        {
            InitializeComponent();
        }

        private void Frm_TraCuuChuyenBay_Load(object sender, System.EventArgs e)
        {
            DataSet dataset1 = ChuyenBay.lay_DiemDi(ref error);
            DataTable datatable1 = new DataTable();
            datatable1.Clear();
            datatable1 = dataset1.Tables[0];
            foreach (DataRow row in datatable1.Rows)
                Cmb_DiemDi.Items.Add(row["DiemDi"]);

            DataSet dataset2 = ChuyenBay.lay_DiemDen(ref error);
            DataTable datatable2 = new DataTable();
            datatable2.Clear();
            datatable2 = dataset2.Tables[0];
            foreach (DataRow row in datatable2.Rows)
                Cmb_DiemDen.Items.Add(row["DiemDen"]);

        }

        private void Btn_TraCuu_Click(object sender, System.EventArgs e)
        {
            string diemdi = Cmb_DiemDi.Text.Trim();
            string diemden = Cmb_DiemDen.Text.Trim();
            DateTime ngaydi = Dtp_NgayDi.Value;
            string tinhtrang = Cmb_TinhTrang.Text.Trim();

            diemdi = (diemdi.Equals("") ? "-1" : Cmb_DiemDi.Text);
            diemden = (diemden.Equals("") ? "-1" : Cmb_DiemDen.Text);
            tinhtrang = (tinhtrang.Equals("") ? "-1" : Cmb_TinhTrang.Text);

            this.Pnl_TraCuuChuyenBay.Controls.Clear();

            DataSet dataset = ChuyenBay.timkiem_ChuyenBay(diemdi, diemden, ngaydi, tinhtrang, ref error);
            DataTable datatable = new DataTable();
            datatable.Clear();
            datatable = dataset.Tables[0];

            for (int i = 0; i < datatable.Rows.Count; ++i)
            {
                UC_TraCuuChuyenBay chuyenbay = new UC_TraCuuChuyenBay();
                chuyenbay.Lbl_DiemDi.Text = datatable.Rows[i]["DiemDi"].ToString();
                chuyenbay.Lbl_DiemDen.Text = datatable.Rows[i]["DiemDen"].ToString();
                chuyenbay.Lbl_ThoiGianDi.Text = datatable.Rows[i]["ThoiGianDi"].ToString();
                chuyenbay.Lbl_ThoiGianDen.Text = datatable.Rows[i]["ThoiGianDuKienDen"].ToString();
                chuyenbay.Lbl_GiaVePhoThong.Text = datatable.Rows[i]["GiaVePhoThong"].ToString();
                chuyenbay.Lbl_GiaVeThuongGia.Text = datatable.Rows[i]["GiaVeThuongGia"].ToString();
                chuyenbay.Lbl_SoLuongConLaiPhoThong.Text = datatable.Rows[i]["SoVeConLaiPhoThong"].ToString();
                chuyenbay.Lbl_SoLuongConLaiThuongGia.Text = datatable.Rows[i]["SoVeConLaiThuongGia"].ToString();
                chuyenbay.Lbl_MaChuyenBay.Text = datatable.Rows[i]["MaChuyenBay"].ToString();
                chuyenbay.Lbl_TenMayBay.Text = datatable.Rows[i]["TenMayBay"].ToString();
                chuyenbay.Lbl_TinhTrangChuyenBay.Text = datatable.Rows[i]["TinhTrangChuyenBay"].ToString();

                chuyenbay.Location = new System.Drawing.Point(10, 100 * i + 3);

                this.Pnl_TraCuuChuyenBay.Controls.Add(chuyenbay);
            }
        }
    }
}
