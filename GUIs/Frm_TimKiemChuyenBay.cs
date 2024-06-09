using HeQuanTriDemo01.Models;
using QuanLyBanVeMayBay.BLLs;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_TimKiemChuyenBay : Form
    {
        private bool chuyenbayduocdexuat = false;
        private string diemdi = "-1";
        private string diemden = "-1";

        private DateTime ngaydi = new DateTime(2010, 1, 1);
        private DateTime ngayve = new DateTime(2010, 1, 1);

        private int sokhachnguoilon = -1;
        private int sokhachtreem = -1;
        private int soluonghanhkhach = -1;

        private int mavechieudi = -1;
        private int mavechieuve = -1;

        private int mamaybaychieudi = -1;
        private int mamaybaychieuve = -1;

        private bool khuhoi = false;

        public Frm_TimKiemChuyenBay()
        {
            InitializeComponent();
            Rdb_MotChieu.Checked = true;
        }

        public Frm_TimKiemChuyenBay(string diemdi, string diemden, DateTime ngaydi)
        {
            InitializeComponent();
            this.diemdi = diemdi;
            this.diemden = diemden;
            this.ngaydi = ngaydi;
            this.chuyenbayduocdexuat = true;
            this.khuhoi = false;
        }

        private void Frm_MuaVe1_Load(object sender, EventArgs e)
        {
            BLL_ChuyenBay bll = new BLL_ChuyenBay();
            string error1 = "";
            string error2 = "";

            DataSet dataset1 = bll.lay_DiemDi(ref error1);
            DataTable datatable1 = new DataTable();
            datatable1.Clear();
            datatable1 = dataset1.Tables[0];
            foreach (DataRow row in datatable1.Rows)
                Cbb_DiemDi.Items.Add(row["DiemDi"]);

            DataSet dataset2 = bll.lay_DiemDen(ref error2);
            DataTable datatable2 = new DataTable();
            datatable2.Clear();
            datatable2 = dataset2.Tables[0];
            foreach (DataRow row in datatable2.Rows)
                Cbb_DiemDen.Items.Add(row["DiemDen"]);

            if (chuyenbayduocdexuat)
                nhan_ThongTinChuyenBayDeXuat();
        }


        private void nhan_ThongTinChuyenBayDeXuat()
        {
            Rdb_MotChieu.Checked = true;
            Cbb_DiemDi.Text = diemdi;
            Cbb_DiemDen.Text = diemden;
            Dtp_NgayDi.Value = ngaydi;
        }

        public void nhap_HanhKhach()
        {
            Frm_HanhKhach form = new Frm_HanhKhach();
            form.ShowDialog();

            sokhachnguoilon = (int)form.Nud_NguoiLon.Value;
            sokhachtreem = (int)form.Nud_TreEm.Value;
            soluonghanhkhach = sokhachnguoilon + sokhachtreem;

            string skn = "- " + sokhachtreem.ToString() + " trẻ em";
            if (sokhachtreem == 0) skn = "";

            this.Txt_HanhKhach.Text = " " + sokhachnguoilon.ToString() + " người lớn " + skn;
        }

        private void Rdb_MotChieu_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_MotChieu.Checked)
            {
                Rdb_KhuHoi.Checked = false;
                Pnl_NgayVe.Hide();
            }
        }

        private void Rdb_KhuHoi_CheckedChanged(object sender, EventArgs e)
        {
            if (Rdb_KhuHoi.Checked)
            {
                Rdb_MotChieu.Checked = false;
                Pnl_NgayVe.Show();
            }
        }

        private void Btn_HanhKhach_Click(object sender, EventArgs e)
        {
            nhap_HanhKhach();
        }

        private void Btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (sokhachnguoilon == -1 || sokhachtreem == -1)
            {
                DialogResult temp = MessageBox.Show("Bạn chưa nhập số lượng hành khách!", "Warning", MessageBoxButtons.OK);
                if (temp == DialogResult.OK) nhap_HanhKhach();
            }
            else
            {
                this.Hide();

                diemdi = Cbb_DiemDi.Text;
                diemden = Cbb_DiemDen.Text;
                ngaydi = Dtp_NgayDi.Value;

                Frm_MuaVe muavechieudi = new Frm_MuaVe(diemdi, diemden, ngaydi, soluonghanhkhach);
                muavechieudi.ShowDialog();
                mavechieudi = muavechieudi.lay_MaChuyenBay();
                mamaybaychieudi = muavechieudi.lay_MaMayBay();
                ngaydi = muavechieudi.lay_NgayDi();

                if (mavechieudi == -1 || mamaybaychieudi == -1)
                {
                    this.Show();
                    return;
                }

                if (Rdb_KhuHoi.Checked)
                {
                    ngayve = Dtp_NgayVe.Value;

                    Frm_MuaVe muavechieuve = new Frm_MuaVe(diemden, diemdi, ngayve, soluonghanhkhach);
                    muavechieuve.ShowDialog();
                    mavechieuve = muavechieuve.lay_MaChuyenBay();
                    mamaybaychieuve = muavechieuve.lay_MaMayBay();
                    ngayve = muavechieuve.lay_NgayDi();
                    khuhoi = true;

                    if (mavechieuve == -1 || mamaybaychieuve == -1)
                    {
                        this.Show();
                        return;
                    }
                }

                ThongTinChuyenBay thongtinchuyenbay = new ThongTinChuyenBay(
                    diemdi, diemden, 
                    ngaydi, ngayve, 
                    sokhachnguoilon, sokhachtreem, 
                    mavechieudi, mavechieuve,
                    mamaybaychieudi, mamaybaychieuve,
                    khuhoi);

                Frm_ThongTinKhachHang khachhang = new Frm_ThongTinKhachHang(thongtinchuyenbay);
                khachhang.ShowDialog();

                if (Frm_ThanhToan.thanhtoanthanhcong == 999)
                {
                    this.Close();
                    Frm_ThanhToan.thanhtoanthanhcong = 0;
                }
                this.Show();
            }
        }

    }
}

