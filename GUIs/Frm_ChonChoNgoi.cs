using HeQuanTriDemo01.Models;
using QuanLyBanVeMayBay.BLLs;
using QuanLyBanVeMayBay.Models;
using QuanLyBanVeMayBay.UCs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_ChonChoNgoi : Form
    {
        private ThongTinChuyenBay thongTinChuyenBay = null;
        private List<KhachHangNguoiLon> khachHangNguoiLons = null;
        private List<KhachHangTreEm> khachHangTreEms = null;

        private int i1 = 0;
        private int j1 = 0;

        private int i2 = 0;
        private int j2 = 0;

        private int X = 10;
        private int Y = 10;

        private int mave = -1;
        private double giave = -1;
        private int idx = -1;

        private int currentSelect = 5;

        private List<UC_HanhKhachChonChoNgoi> uckhs = new List<UC_HanhKhachChonChoNgoi>();
        private List<Button> buttons = new List<Button>();

        private List<int> mavedachons = new List<int>();
        private List<int> maves = new List<int>();
        private List<double> giaves = new List<double>();

        public Frm_ChonChoNgoi()
        {
            InitializeComponent();
        }

        public Frm_ChonChoNgoi(
            List<KhachHangNguoiLon> khachHangNguoiLons,
            List<KhachHangTreEm> khachHangTreEms,
            ThongTinChuyenBay thongTinChuyenBay)
        {
            InitializeComponent();
            this.khachHangNguoiLons = khachHangNguoiLons;
            this.khachHangTreEms = khachHangTreEms;
            this.thongTinChuyenBay = thongTinChuyenBay;
        }

        private void Frm_ChonChoNgoi_Load(object sender, System.EventArgs e)
        {
            LayThongTinChuyenBay();
            LayDanhSachKhachHang();
            LayThongTinChoNgoi(thongTinChuyenBay.Machieudi);
        }

        public void LayDanhSachKhachHang()
        {
            UC_HanhKhachChonChoNgoi hanhKhachChonChoNgoi = new UC_HanhKhachChonChoNgoi();

            if (i1 < thongTinChuyenBay.Sokhachnguoilon)
            {
                hanhKhachChonChoNgoi.Lbl_TenKhach.Text = khachHangNguoiLons[i1].Hoten;
                hanhKhachChonChoNgoi.Lbl_ChieuDi.Text = "Chiều đi";
            }
            else if (j1 < thongTinChuyenBay.Sokhachtreem)
            {
                hanhKhachChonChoNgoi.Lbl_TenKhach.Text = khachHangTreEms[j1].Hoten;
                hanhKhachChonChoNgoi.Lbl_ChieuDi.Text = "Chiều đi";
            }
            else if(i2 < thongTinChuyenBay.Sokhachnguoilon)
            {
                hanhKhachChonChoNgoi.Lbl_TenKhach.Text = khachHangNguoiLons[i2].Hoten;
                hanhKhachChonChoNgoi.Lbl_ChieuDi.Text = "Chiều về";
            }
            else if(j2 < thongTinChuyenBay.Sokhachtreem)
            {
                hanhKhachChonChoNgoi.Lbl_TenKhach.Text = khachHangTreEms[j2].Hoten;
                hanhKhachChonChoNgoi.Lbl_ChieuDi.Text = "Chiều về";
            }
            else
            {
                return;
            }

            hanhKhachChonChoNgoi.Location = new Point(X, Y);
            Pnl_DanhSachHanhKhach.Controls.Add(hanhKhachChonChoNgoi);
            uckhs.Add(hanhKhachChonChoNgoi);
            Y = Y + 90;
        }

        public void LayThongTinChoNgoi(int machuyenbay)
        {
            BLL_ChuyenBay bll = new BLL_ChuyenBay();
            string error = "";

            DataSet dataset = bll.lay_DanhSachChoNgoi(machuyenbay, ref error);
            DataTable datatable = new DataTable();
            datatable.Clear();
            datatable = dataset.Tables[0];

            this.SuspendLayout();
            this.Pnl_ChonViTri.SuspendLayout();
            this.Pnl_ChonViTri.Controls.Clear();

            int khoangCach = 5;
            int khoangCachGiua = 20;
            int numCols = 4;
            int numRows = 40;
            this.Controls.Add(Pnl_ChonViTri);

            int totalButtonWidth = numCols * (80 + khoangCach) - khoangCach + khoangCachGiua;
            int x = (Pnl_ChonViTri.Width - totalButtonWidth) / 2;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    if (datatable.Rows[numCols * row + col]["TinhTrangVe"].Equals("chưa bán"))
                    {
                        Button btn_ChuaMua = new Button();
                        btn_ChuaMua.Width = 80;
                        btn_ChuaMua.Height = 40;
                        btn_ChuaMua.BackColor = Color.SkyBlue;
                        btn_ChuaMua.Left = x - 5 + (col * (btn_ChuaMua.Width + khoangCach)) + (col / 2) * khoangCachGiua;
                        btn_ChuaMua.Top = 10 + (row * (btn_ChuaMua.Height + khoangCach));
                        btn_ChuaMua.Text = datatable.Rows[numCols * row + col]["ChoNgoi"].ToString();
                        btn_ChuaMua.Click += chonGhe;
                        buttons.Add(btn_ChuaMua);
                        maves.Add(Convert.ToInt32(datatable.Rows[numCols * row + col]["MaVe"].ToString()));
                        giaves.Add(Convert.ToDouble(datatable.Rows[numCols * row + col]["GiaVe"].ToString()));
                        Pnl_ChonViTri.Controls.Add(btn_ChuaMua);

                    }
                    else
                    {
                        Button btn_DaMua = new Button();
                        btn_DaMua.Width = 80;
                        btn_DaMua.Height = 40;
                        btn_DaMua.BackColor = Color.Silver;
                        btn_DaMua.Left = x - 5 + (col * (btn_DaMua.Width + khoangCach)) + (col / 2) * khoangCachGiua;
                        btn_DaMua.Top = 10 + (row * (btn_DaMua.Height + khoangCach));
                        btn_DaMua.Enabled = false;
                        Pnl_ChonViTri.Controls.Add(btn_DaMua);
                    }
                }
            }
            this.Pnl_ChonViTri.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void LayThongTinChuyenBay()
        {
            // Thong tin chieu di
            UC_ThongTinChieuBay thongTinChieuBay = new UC_ThongTinChieuBay();
            thongTinChieuBay.Location = new Point(2, 3);
            thongTinChieuBay.Lbl_MaChuyenBay.Text = string.Concat("Mã chuyến bay: ", thongTinChuyenBay.Machieudi);
            thongTinChieuBay.Lbl_MaMayBay.Text = string.Concat("Mã máy bay: ", thongTinChuyenBay.Mamaybaydi);
            thongTinChieuBay.Lbl_DiemDi.Text = thongTinChuyenBay.Diemdi;
            thongTinChieuBay.Lbl_DiemDen.Text = thongTinChuyenBay.Diemden;
            thongTinChieuBay.Lbl_GioDi.Text = thongTinChuyenBay.Thoigiandi.ToString();
            Pnl_HanhTrinh.Controls.Add(thongTinChieuBay);

            // Thong tin ve chieu ve
            if (thongTinChuyenBay.Machieuve != -1)
            {
                thongTinChieuBay = new UC_ThongTinChieuBay();
                thongTinChieuBay.Location = new Point(2, 145);
                thongTinChieuBay.Lbl_MaChuyenBay.Text = string.Concat("Mã chuyến bay: ", thongTinChuyenBay.Machieuve);
                thongTinChieuBay.Lbl_MaMayBay.Text = string.Concat("Mã máy bay: ", thongTinChuyenBay.Mamaybayve);
                thongTinChieuBay.Lbl_DiemDi.Text = thongTinChuyenBay.Diemden;
                thongTinChieuBay.Lbl_DiemDen.Text = thongTinChuyenBay.Diemdi;
                thongTinChieuBay.Lbl_ChieuBay.Text = "Chiều về";
                thongTinChieuBay.Lbl_GioDi.Text = thongTinChuyenBay.Thoigianve.ToString();
                Pnl_HanhTrinh.Controls.Add(thongTinChieuBay);
            }
        }

        private void chonGhe(object sender, EventArgs e)
        {
            Button temp = sender as Button;
            idx = buttons.IndexOf(temp);
            mave = maves[idx];
            giave = giaves[idx];
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            if (mavedachons.IndexOf(mave) != -1 || idx == -1)
                return;
            if (i1 >= thongTinChuyenBay.Sokhachnguoilon 
                && j1 >= thongTinChuyenBay.Sokhachtreem 
                && thongTinChuyenBay.Machieuve <= 0)
                return;
            if (i2 >= thongTinChuyenBay.Sokhachnguoilon
               && j2 >= thongTinChuyenBay.Sokhachtreem)
                return;

            mavedachons.Add(mave);
            uckhs[i1 + i2 + j1 + j2].Lbl_MaVe.Text = mave.ToString();
            uckhs[i1 + i2 + j1 + j2].Lbl_MaGhe.Text = buttons[idx].Text;

            if (i1 < thongTinChuyenBay.Sokhachnguoilon && currentSelect == 5)
            {
                khachHangNguoiLons[i1].Mavechieudi = mave;
                khachHangNguoiLons[i1].Giatienvechieudi = giave;
                i1 = i1 + 1;
            }
            else if (j1 < thongTinChuyenBay.Sokhachtreem && currentSelect == 5)
            {
                khachHangTreEms[j1].Mavechieudi = mave;
                khachHangTreEms[j1].Giatienvechieudi = giave;
                j1 = j1 + 1;

            }
            else if (i2 < thongTinChuyenBay.Sokhachnguoilon && currentSelect == 10)
            {
                khachHangNguoiLons[i2].Mavechieuve = mave;
                khachHangNguoiLons[i2].Giatienvechieuve = giave;
                i2 = i2 + 1;
            }
            else if (currentSelect == 10 && j2 < thongTinChuyenBay.Sokhachtreem)
            {
                khachHangTreEms[j2].Mavechieuve = mave;
                khachHangTreEms[j2].Giatienvechieuve = giave;
                j2 = j2 + 1;
            }
            buttons[idx].BackColor = Color.Silver;
            buttons[idx].Text = "";
            buttons[idx].Click -= chonGhe;
            buttons[idx].Enabled = false;

            if (i1 >= thongTinChuyenBay.Sokhachnguoilon
                && j1 >= thongTinChuyenBay.Sokhachtreem
                && thongTinChuyenBay.Machieuve <= 0)
                return;
            if (i2 >= thongTinChuyenBay.Sokhachnguoilon
               && j2 >= thongTinChuyenBay.Sokhachtreem)
                return;
            
            LayDanhSachKhachHang();
            
            if (i1 >= thongTinChuyenBay.Sokhachnguoilon 
                && j1 >= thongTinChuyenBay.Sokhachtreem
                && thongTinChuyenBay.Machieuve > 0
                && currentSelect != 10)
            {
                currentSelect = 10;
                LayThongTinChoNgoi(thongTinChuyenBay.Machieuve);
            }
            
        }

        private void Btn_TiepTuc_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < thongTinChuyenBay.Sokhachnguoilon; i++)
                if (khachHangNguoiLons[i].Mavechieudi <= 0)
                {
                    MessageBox.Show("Quý khách vui lòng chọn ghế ");
                    return;
                }

            for (int i = 0; i < thongTinChuyenBay.Sokhachtreem; i++)
                if (khachHangTreEms[i].Mavechieudi <= 0)
                {
                    MessageBox.Show("Quý khách vui lòng chọn ghế ");
                    return;
                }

            if(thongTinChuyenBay.Machieuve > 0)
            {
                for (int i = 0; i < thongTinChuyenBay.Sokhachnguoilon; i++)
                    if (khachHangNguoiLons[i].Mavechieuve <= 0)
                    {
                        MessageBox.Show("Quý khách vui lòng chọn ghế ");
                        return;
                    }

                for (int i = 0; i < thongTinChuyenBay.Sokhachnguoilon; i++)
                    if (khachHangTreEms[i].Mavechieuve <= 0)
                    {
                        MessageBox.Show("Quý khách vui lòng chọn ghế ");
                        return;
                    }
            }

            this.Hide();

            Frm_ThanhToan thanhToan = new Frm_ThanhToan(khachHangNguoiLons, khachHangTreEms, thongTinChuyenBay);
            thanhToan.ShowDialog();

            if (Frm_ThanhToan.thanhtoanthanhcong == 999) this.Close();
            this.Show();

        }
    }
}
