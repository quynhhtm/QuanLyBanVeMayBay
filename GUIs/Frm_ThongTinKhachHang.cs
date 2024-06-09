using HeQuanTriDemo01.Models;
using QuanLyBanVeMayBay.BLLs;
using QuanLyBanVeMayBay.Models;
using QuanLyBanVeMayBay.UCs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_ThongTinKhachHang : Form
    {
        private ThongTinChuyenBay thongtinchuyenbay;
        private string ho = "-1";
        private string ten = "-1";
        private string gioitinh = "-1";
        private DateTime ngaysinh = new DateTime(2010, 1, 1);
        private string sodienthoai = "-1";
        private string email = "-1";
        private string diachi = "-1";

        public Frm_ThongTinKhachHang()
        {
            InitializeComponent();
        }

        public Frm_ThongTinKhachHang(ThongTinChuyenBay thongtinchuyenbay)
        {
            InitializeComponent();
            this.thongtinchuyenbay = thongtinchuyenbay;
        }

        private void Frm_ThongTinKhachHang_Load(object sender, EventArgs e)
        {
            BLL_KhachHang bll = new BLL_KhachHang();

            // Load form dien thong tin khach hang 
            int X = 3;
            int Y = 0;
            for (int i = 0; i < thongtinchuyenbay.Sokhachnguoilon; i++)
            {
                UC_ThongTinNguoiLon nl = new UC_ThongTinNguoiLon();
                Y = 540 * i;
                nl.Lbl_NguoiLon.Text = string.Concat("NGƯỜI LỚN ", i + 1);
                nl.Location = new Point(X, Y);
                Pnl_ThongTinKhachHang.Controls.Add(nl);
            }

            for (int i = thongtinchuyenbay.Sokhachnguoilon; i < (thongtinchuyenbay.Sokhachnguoilon + thongtinchuyenbay.Sokhachtreem); i++)
            {
                UC_ThongTinTreEm te = new UC_ThongTinTreEm();
                Y = i == thongtinchuyenbay.Sokhachnguoilon ? 540 * i : Y + 350;
                te.Lbl_TreEm.Text = string.Concat("TRẺ EM ", i - thongtinchuyenbay.Sokhachnguoilon + 1);
                te.Location = new Point(X, Y); ;
                Pnl_ThongTinKhachHang.Controls.Add(te);
            }

            // Lay thong tin chuyen bay
            LayThongTinChuyenBay();
        }

        private bool KiemTraThongTinNguoiLon(UC_ThongTinNguoiLon thongTinNguoiLon)
        {
            ho = thongTinNguoiLon.Txt_Ho.Text.Trim();
            ten = thongTinNguoiLon.Txt_TenDemVaTen.Text.Trim();
            gioitinh = thongTinNguoiLon.Cmb_GioiTinh.Text.Trim();
            ngaysinh = thongTinNguoiLon.Dtp_NgaySinh.Value;
            sodienthoai = thongTinNguoiLon.Txt_SoDienThoai.Text.Trim();
            email = thongTinNguoiLon.Txt_Email.Text.Trim();
            diachi = thongTinNguoiLon.Txt_DiaChi.Text.Trim();

            return string.IsNullOrEmpty(ho)
                || string.IsNullOrEmpty(ten)
                || string.IsNullOrEmpty(gioitinh)
                || string.IsNullOrEmpty(sodienthoai)
                || string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(diachi) ? false : true;
        }                               
        private bool KiemTraThongTinTreEm(UC_ThongTinTreEm thongTinTreEm)
        {
            ho = thongTinTreEm.Txt_Ho.Text.Trim();
            ten = thongTinTreEm.Txt_TenDemVaTen.Text.Trim();
            gioitinh = thongTinTreEm.Cmb_GioiTinh.Text.Trim();
            ngaysinh = thongTinTreEm.Dtp_NgaySinh.Value;

            return string.IsNullOrEmpty(ho)
                || string.IsNullOrEmpty(ten)
                || string.IsNullOrEmpty(gioitinh) ? false : true;
        }

        private bool DanhSachNguoiLon(ref List<KhachHangNguoiLon> khachHangNguoiLons)
        {
            foreach (Control control in Pnl_ThongTinKhachHang.Controls)
            {
                if (control is UC_ThongTinNguoiLon)
                {
                    UC_ThongTinNguoiLon thongTinNguoiLon = (UC_ThongTinNguoiLon)control;

                    string HoTen = string.Concat(thongTinNguoiLon.Txt_Ho.Text.Trim(), " ",
                                                 thongTinNguoiLon.Txt_TenDemVaTen.Text.Trim());
                    gioitinh = thongTinNguoiLon.Cmb_GioiTinh.Text.Trim();
                    ngaysinh = thongTinNguoiLon.Dtp_NgaySinh.Value;
                    sodienthoai = thongTinNguoiLon.Txt_SoDienThoai.Text.Trim();
                    email = thongTinNguoiLon.Txt_Email.Text.Trim();
                    diachi = thongTinNguoiLon.Txt_DiaChi.Text.Trim();

                    if (DateTime.Now.Subtract(thongTinNguoiLon.Dtp_NgaySinh.Value).TotalDays < 5110) return false;

                    KhachHangNguoiLon khachHangNguoiLon =
                        new KhachHangNguoiLon(HoTen, gioitinh, ngaysinh, sodienthoai, email, diachi);

                    if (!KiemTraThongTinNguoiLon(thongTinNguoiLon)) return false;

                    khachHangNguoiLons.Add(khachHangNguoiLon);
                }
            }
            return true;
        }

        private bool DanhSachTreEm(ref List<KhachHangTreEm> khachHangTreEms)
        {
            foreach (Control control in Pnl_ThongTinKhachHang.Controls)
            {
                if (control is UC_ThongTinTreEm)
                {
                    UC_ThongTinTreEm thongTinTreEm = (UC_ThongTinTreEm)control;

                    string HoTen = string.Concat(thongTinTreEm.Txt_Ho.Text.Trim(), " ",
                                                 thongTinTreEm.Txt_TenDemVaTen.Text.Trim());
                    gioitinh = thongTinTreEm.Cmb_GioiTinh.Text.Trim();
                    ngaysinh = thongTinTreEm.Dtp_NgaySinh.Value;

                    if (DateTime.Now.Subtract(thongTinTreEm.Dtp_NgaySinh.Value).TotalDays > 5110) return false;

                    KhachHangTreEm khachHangTreEm = new KhachHangTreEm(HoTen, gioitinh, ngaysinh);

                    if (!KiemTraThongTinTreEm(thongTinTreEm)) return false;

                    khachHangTreEms.Add(khachHangTreEm);
                }
            }
            return true;
        }

        private void LayThongTinChuyenBay()
        {
            // Thong tin chieu di
            UC_ThongTinChieuBay thongTinChieuBay = new UC_ThongTinChieuBay();
            thongTinChieuBay.Location = new Point(2, 3);
            thongTinChieuBay.Lbl_MaChuyenBay.Text = string.Concat("Mã chuyến bay: ", thongtinchuyenbay.Machieudi);
            thongTinChieuBay.Lbl_MaMayBay.Text = string.Concat("Mã máy bay: ", thongtinchuyenbay.Mamaybaydi);
            thongTinChieuBay.Lbl_DiemDi.Text = thongtinchuyenbay.Diemdi;
            thongTinChieuBay.Lbl_DiemDen.Text = thongtinchuyenbay.Diemden;
            thongTinChieuBay.Lbl_GioDi.Text = thongtinchuyenbay.Thoigiandi.ToString();
            Pnl_HanhTrinh.Controls.Add(thongTinChieuBay);

            // Thong tin ve chieu ve
            if (thongtinchuyenbay.Machieuve != -1)
            {
                thongTinChieuBay = new UC_ThongTinChieuBay();
                thongTinChieuBay.Location = new Point(2, 145);
                thongTinChieuBay.Lbl_MaChuyenBay.Text = string.Concat("Mã chuyến bay: ", thongtinchuyenbay.Machieuve);
                thongTinChieuBay.Lbl_MaMayBay.Text = string.Concat("Mã máy bay: ", thongtinchuyenbay.Mamaybayve);
                thongTinChieuBay.Lbl_DiemDi.Text = thongtinchuyenbay.Diemden;
                thongTinChieuBay.Lbl_DiemDen.Text = thongtinchuyenbay.Diemdi;
                thongTinChieuBay.Lbl_ChieuBay.Text = "Chiều về";
                thongTinChieuBay.Lbl_GioDi.Text = thongtinchuyenbay.Thoigianve.ToString();
                Pnl_HanhTrinh.Controls.Add(thongTinChieuBay);
            }
        }

        private void Btn_TiepTuc_Click(object sender, EventArgs e)
        {
            List<KhachHangNguoiLon> khachHangNguoiLons = new List<KhachHangNguoiLon>();
            List<KhachHangTreEm> khachHangTreEms = new List<KhachHangTreEm>();

            if (DanhSachNguoiLon(ref khachHangNguoiLons) && DanhSachTreEm(ref khachHangTreEms))
            {
                this.Hide();
                
                Frm_GoiHanhLy frm_GoiHanhLy = new Frm_GoiHanhLy(khachHangNguoiLons, khachHangTreEms, thongtinchuyenbay);
                frm_GoiHanhLy.ShowDialog();

                if (Frm_ThanhToan.thanhtoanthanhcong == 999) this.Close();
                this.Show();
            }
            else
            {
                MessageBox.Show("Thông tin khách hàng không hợp lệ!");
            }
        }
    }
}
