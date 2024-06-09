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
    public partial class Frm_ThanhToan : Form
    {
        public static int thanhtoanthanhcong = 0;
        private int ThoiGianConLai = 600;
        private ThongTinChuyenBay thongTinChuyenBay = null;
        private List<KhachHangNguoiLon> khachHangNguoiLons = null;
        private List<KhachHangTreEm> khachHangTreEms = null;
        private Pair thongtinhoadon = null;

        private int X = 2;
        private int Y = 3;  

        public Frm_ThanhToan()
        {
            InitializeComponent();
        }

        public Frm_ThanhToan(
            List<KhachHangNguoiLon> khachHangNguoiLons, 
            List<KhachHangTreEm> khachHangTreEms,
            ThongTinChuyenBay thongTinChuyenBay)
        {
            InitializeComponent();
            this.khachHangNguoiLons = khachHangNguoiLons;
            this.khachHangTreEms = khachHangTreEms;
            this.thongTinChuyenBay = thongTinChuyenBay;
        }

        private void Frm_ThanhToan_Load(object sender, EventArgs e)
        {
            this.thongtinhoadon = khoitao_HoaDon();
            LayThongTinChuyenBay();
            LayThongTinHanhKhach();
        }

        private void Tmr_ThoiGianThanhToan_Tick(object sender, System.EventArgs e)
        {
            --ThoiGianConLai;
            Lbl_ThoiGianThanhToan.Text =
                (ThoiGianConLai / 60).ToString() + ":" + (ThoiGianConLai % 60);
            if (ThoiGianConLai == 0)
            {
                this.Tmr_ThoiGianConLai.Stop();
                thanhtoanthanhcong = 999;
                DialogResult rs = MessageBox.Show("Hết thời gian thanh toán", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (rs == DialogResult.OK) this.Close();
            }
        }

        private void Btn_Xong_Click(object sender, EventArgs e)
        {
            bool success1 = true;
            bool success2 = true;
            bool success = true;

            // Chieu di
            for (int i = 0; i < khachHangNguoiLons.Count; ++i)
            {
                int manguoilon = them_KhachHangNguoiLon(
                    khachHangNguoiLons[i].Hoten,
                    khachHangNguoiLons[i].Gioitinh,
                    khachHangNguoiLons[i].Ngaysinh,
                    khachHangNguoiLons[i].Sodienthoai,
                    khachHangNguoiLons[i].Email,
                    khachHangNguoiLons[i].Diachi,
                    khachHangNguoiLons[i].Mavechieudi,
                    khachHangNguoiLons[i].Magoihanhlychieudi,
                    (int)thongtinhoadon.first);

                khachHangNguoiLons[i].Makhachhangnguoilon = manguoilon;
                success1 = them_ThongTinNguoiDungMuaVe(khachHangNguoiLons[i].Mavechieudi, ConstantDATA.maNguoiDung) && success1;
            }

            // Chieu di
            for (int i = 0; i < khachHangTreEms.Count; ++i)
            {
                int matreem = them_KhachHangTreEm(
                    khachHangTreEms[i].Hoten,
                    khachHangTreEms[i].Gioitinh,
                    khachHangTreEms[i].Ngaysinh,
                    khachHangTreEms[i].Mavechieudi,
                    khachHangTreEms[i].Magoihanhlychieudi,
                    (int)thongtinhoadon.first);

                khachHangTreEms[i].Makhachhangtreem = matreem;
                success1 = them_ThongTinNguoiDungMuaVe(khachHangTreEms[i].Mavechieudi, ConstantDATA.maNguoiDung) && success1;
            }

            /*---------------------------------------------------------------------------------------*/

            if (thongTinChuyenBay.Machieuve > 0)
            {
                // Chieu ve
                for (int i = 0; i < khachHangNguoiLons.Count; ++i)
                {
                    int manguoilon = them_KhachHangNguoiLon(
                        khachHangNguoiLons[i].Hoten,
                        khachHangNguoiLons[i].Gioitinh,
                        khachHangNguoiLons[i].Ngaysinh,
                        khachHangNguoiLons[i].Sodienthoai,
                        khachHangNguoiLons[i].Email,
                        khachHangNguoiLons[i].Diachi,
                        khachHangNguoiLons[i].Mavechieuve,
                        khachHangNguoiLons[i].Magoihanhlychieuve,
                        (int)thongtinhoadon.first);

                    khachHangNguoiLons[i].Makhachhangnguoilon = manguoilon;
                    success2 = them_ThongTinNguoiDungMuaVe(khachHangNguoiLons[i].Mavechieuve, ConstantDATA.maNguoiDung) && success2;

                }

                // Chieu ve
                for (int i = 0; i < khachHangTreEms.Count; ++i)
                {
                    int matreem = them_KhachHangTreEm(
                        khachHangTreEms[i].Hoten,
                        khachHangTreEms[i].Gioitinh,
                        khachHangTreEms[i].Ngaysinh,
                        khachHangTreEms[i].Mavechieuve,
                        khachHangTreEms[i].Magoihanhlychieuve,
                        (int)thongtinhoadon.first);

                    khachHangTreEms[i].Makhachhangtreem = matreem;
                    success2 = them_ThongTinNguoiDungMuaVe(khachHangTreEms[i].Mavechieuve, ConstantDATA.maNguoiDung) && success2;
                }
            }

            for (int i = 0; i < khachHangNguoiLons.Count; ++i)
            {
                for (int j = 0; j < khachHangTreEms.Count; ++j)
                {
                    success = them_NguoiLonQuanLyTreEm(khachHangNguoiLons[i].Makhachhangnguoilon, khachHangTreEms[j].Makhachhangtreem) 
                        && success1 
                        && success2
                        && success;
                }
            }

            if (success) MessageBox.Show("Thành công! Hóa đơn của bạn có mã số là: " + thongtinhoadon.first.ToString());
            else MessageBox.Show("Thất bại!");

            thanhtoanthanhcong = 999;
            this.Close();
        }

        public Pair khoitao_HoaDon()
        {
            BLL_HoaDon bll = new BLL_HoaDon();
            string error = "";

            Pair mahoadon = bll.khoitao_HoaDon(ref error);
            return mahoadon;
        }

        public int them_KhachHangNguoiLon(
            string hoten,
            string gioitinh,
            DateTime ngaysinh,
            string sodienthoai,
            string email,
            string diachi,
            int mave,
            int magoi,
            int mahoadon)
        {
            BLL_KhachHang bll = new BLL_KhachHang();
            string error = "";

            int manguoilon = bll.them_KhachHangNguoiLon(
                hoten,
                gioitinh,
                ngaysinh,
                sodienthoai,
                email,
                diachi,
                mave,
                magoi,
                mahoadon,
                ref error);
            return manguoilon;
        }

        public int them_KhachHangTreEm(
            string hoten,
            string gioitinh,
            DateTime ngaysinh,
            int mave,
            int magoi,
            int mahoadon)
        {
            BLL_KhachHang bll = new BLL_KhachHang();
            string error = "";

            int matreem = bll.them_KhachHangTreEm(
                hoten,
                gioitinh,
                ngaysinh,
                mave,
                magoi,
                mahoadon,
                ref error);
            return matreem;
        }

        public bool them_NguoiLonQuanLyTreEm(int manguoilon, int matreem)
        {
            BLL_KhachHang bll = new BLL_KhachHang();
            string error = "";

            bool success = bll.them_NguoiLonQuanLyTreEm(
                manguoilon, 
                matreem,
                ref error);

            return success;
        }

        public bool them_ThongTinNguoiDungMuaVe(int mave, int manguoidung)
        {
            BLL_NguoiDung bll = new BLL_NguoiDung();
            string error = "";

            bool success = bll.them_ThongTinNguoiDungMuaVe(
                mave,
                manguoidung,
                ref error);
            return success;
        }

        private void LayThongTinChuyenBay()
        {
            // Thong tin chieu di
            UC_ThongTinChieuBay thongTinChieuBay = new UC_ThongTinChieuBay();
            thongTinChieuBay.Location = new Point(X, Y);
            thongTinChieuBay.Lbl_MaChuyenBay.Text = string.Concat("Mã chuyến bay: ", thongTinChuyenBay.Machieudi);
            thongTinChieuBay.Lbl_MaMayBay.Text = string.Concat("Mã máy bay: ", thongTinChuyenBay.Mamaybaydi);
            thongTinChieuBay.Lbl_DiemDi.Text = thongTinChuyenBay.Diemdi;
            thongTinChieuBay.Lbl_DiemDen.Text = thongTinChuyenBay.Diemden;
            thongTinChieuBay.Lbl_GioDi.Text = thongTinChuyenBay.Thoigiandi.ToString();
            Pnl_HanhTrinh.Controls.Add(thongTinChieuBay);
            Y = Y + 142;

            // Thong tin ve chieu ve
            if (thongTinChuyenBay.Machieuve > 0)
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
                Y = Y + 142;
            }
        }

        private void LayThongTinHanhKhach()
        {

            UC_ThongTinVeChieuBay thongtinvechieubaydi = new UC_ThongTinVeChieuBay();
            thongtinvechieubaydi.Location = new Point(X, Y);

            double tongtiennguoilonchieudi = 0;
            double tongtientreemchieudi = 0;
            double tongtienhanhlychieudi = 0;
            int soluonggoihanhlychieudi = 0;

            for (int i = 0; i < khachHangNguoiLons.Count; ++i)
                tongtiennguoilonchieudi += khachHangNguoiLons[i].Giatienvechieudi;

            for (int i = 0; i < khachHangTreEms.Count; ++i)
                tongtientreemchieudi += khachHangTreEms[i].Giatienvechieudi;

            for (int i = 0; i < khachHangNguoiLons.Count; ++i)
            {
                if (khachHangNguoiLons[i].Magoihanhlychieudi > 0)
                {
                    tongtienhanhlychieudi += khachHangNguoiLons[i].Giatiengoihanhlychieudi;
                    soluonggoihanhlychieudi++;
                }
            }

            for (int i = 0; i < khachHangTreEms.Count; ++i)
            {
                if (khachHangTreEms[i].Magoihanhlychieudi > 0)
                {
                    tongtienhanhlychieudi += khachHangTreEms[i].Giatiengoihanhlychieudi;
                    soluonggoihanhlychieudi++;
                }
            }
            thongtinvechieubaydi.Lbl_ChieuBay.Text = "Chiều đi";

            thongtinvechieubaydi.Lbl_SoLuongVeNguoiLon.Text = thongTinChuyenBay.Sokhachnguoilon.ToString();
            thongtinvechieubaydi.Lbl_SoLuongVeTreEm.Text = thongTinChuyenBay.Sokhachtreem.ToString();
            thongtinvechieubaydi.Lbl_SoLuongGoiHanhLy.Text = soluonggoihanhlychieudi.ToString();

            thongtinvechieubaydi.Lbl_TongTienNguoiLon.Text = tongtiennguoilonchieudi.ToString();
            thongtinvechieubaydi.Lbl_TongTienTreEm.Text = tongtientreemchieudi.ToString();
            thongtinvechieubaydi.Lbl_TongTienHanhLy.Text = tongtienhanhlychieudi.ToString();

            this.Pnl_HanhTrinh.Controls.Add(thongtinvechieubaydi);
            Y = Y + 156;

            double tongtiennguoilonchieuve = 0;
            double tongtientreemchieuve = 0;
            double tongtienhanhlychieuve = 0;
            int soluonggoihanhlychieuve = 0;

            if (thongTinChuyenBay.Machieuve > 0)
            {
                UC_ThongTinVeChieuBay thongtinvechieubayve = new UC_ThongTinVeChieuBay();
                thongtinvechieubayve.Location = new Point(X, Y);

                for (int i = 0; i < khachHangNguoiLons.Count; ++i)
                    tongtiennguoilonchieuve += khachHangNguoiLons[i].Giatienvechieuve;

                for (int i = 0; i < khachHangTreEms.Count; ++i)
                    tongtientreemchieuve += khachHangTreEms[i].Giatienvechieuve;

                for (int i = 0; i < khachHangNguoiLons.Count; ++i)
                {
                    if (khachHangNguoiLons[i].Magoihanhlychieuve > 0)
                    {
                        tongtienhanhlychieuve += khachHangNguoiLons[i].Giatiengoihanhlychieuve;
                        soluonggoihanhlychieuve++;
                    }
                }

                for (int i = 0; i < khachHangTreEms.Count; ++i)
                {
                    if (khachHangTreEms[i].Magoihanhlychieuve > 0)
                    {
                        tongtienhanhlychieuve += khachHangTreEms[i].Giatiengoihanhlychieuve;
                        soluonggoihanhlychieuve++;
                    }
                }
                thongtinvechieubayve.Lbl_ChieuBay.Text = "Chiều về";

                thongtinvechieubayve.Lbl_SoLuongVeNguoiLon.Text = thongTinChuyenBay.Sokhachnguoilon.ToString();
                thongtinvechieubayve.Lbl_SoLuongVeTreEm.Text = thongTinChuyenBay.Sokhachtreem.ToString();
                thongtinvechieubayve.Lbl_SoLuongGoiHanhLy.Text = soluonggoihanhlychieuve.ToString();

                thongtinvechieubayve.Lbl_TongTienNguoiLon.Text = tongtiennguoilonchieuve.ToString();
                thongtinvechieubayve.Lbl_TongTienTreEm.Text = tongtientreemchieuve.ToString();
                thongtinvechieubayve.Lbl_TongTienHanhLy.Text = tongtienhanhlychieuve.ToString();

                this.Pnl_HanhTrinh.Controls.Add(thongtinvechieubayve);
                Y = Y + 156;
            }

            double thue = (double)thongtinhoadon.second;
            double tongtienvehanhly =
                tongtiennguoilonchieudi + tongtientreemchieudi + tongtienhanhlychieudi
                + tongtiennguoilonchieuve + tongtientreemchieuve + tongtienhanhlychieuve;
            double tongtienthue = tongtienvehanhly * thue;

            UC_ThongTinThanhToan thongtinthanhtoan = new UC_ThongTinThanhToan();
            thongtinthanhtoan.Location = new Point(X, Y);
            thongtinthanhtoan.Lbl_PhanTramThue.Text = (100 * thue).ToString() + "%";
            thongtinthanhtoan.Lbl_TongTienThue.Text = tongtienthue.ToString();
            thongtinthanhtoan.Lbl_TongTienHoaDon.Text = (tongtienthue + tongtienvehanhly).ToString();
            this.Pnl_HanhTrinh.Controls.Add(thongtinthanhtoan);
        }
    }
}
