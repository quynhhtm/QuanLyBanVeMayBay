using HeQuanTriDemo01.Models;
using QuanLyBanVeMayBay.BLLs;
using QuanLyBanVeMayBay.Models;
using QuanLyBanVeMayBay.UCs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_GoiHanhLy : Form
    {
        BLL_GoiHanhLy GoiHanhLy = new BLL_GoiHanhLy();
        ThongTinChuyenBay thongtinchuyenbay;
        List<KhachHangNguoiLon> khachHangNguoiLons = new List<KhachHangNguoiLon>();
        List<KhachHangTreEm> khachHangTreEms = new List<KhachHangTreEm>();
        
        int thutunguoilon = 0;
        int thututreem = -1;
        bool khuhoi = false;

        public Frm_GoiHanhLy()
        {
            InitializeComponent();
        }

        public Frm_GoiHanhLy(
            List<KhachHangNguoiLon> khachHangNguoiLons, 
            List<KhachHangTreEm> khachHangTreEms, 
            ThongTinChuyenBay thongTinChuyenBay)
        {
            InitializeComponent();
            this.khachHangNguoiLons = khachHangNguoiLons;
            this.khachHangTreEms = khachHangTreEms;
            this.thongtinchuyenbay = thongTinChuyenBay;
            khuhoi = thongTinChuyenBay.Khuhoi;
            foreach (KhachHangNguoiLon khachHangNguoiLon in khachHangNguoiLons)
            {
                khachHangNguoiLon.Magoihanhlychieudi = -1;
                khachHangNguoiLon.Magoihanhlychieuve = -1;
            }
            foreach (KhachHangTreEm KhachHangTreEm in khachHangTreEms)
            {
                KhachHangTreEm.Magoihanhlychieudi = -1;
                KhachHangTreEm.Magoihanhlychieuve = -1;
            }
        }

        private void Frm_GoiHanhLy_Load(object sender, System.EventArgs e)
        {
            LayGoiHanhLy(thutunguoilon);
            LayThongTinChuyenBay();
        }
        private void LayGoiHanhLy(int thutu)
        {
            if (thututreem == -1)
            {
                Lbl_TenKhachHang.Text = string.Concat("Khách hàng: ",khachHangNguoiLons[thutu].Hoten);
            }
            else
            {
                Lbl_TenKhachHang.Text = string.Concat("Khách hàng: ", khachHangTreEms[thutu].Hoten);
            }
            if (khuhoi)
            {
                Cmb_Chieu.Items.Clear();
                Cmb_Chieu.Items.Add("Chiều đi");
                Cmb_Chieu.Items.Add("Chiều về");
                Cmb_Chieu.Text = "Chiều đi";
            }
            else
            {
                Cmb_Chieu.Items.Clear();
                Cmb_Chieu.Items.Add("Chiều đi");
                Cmb_Chieu.Text = "Chiều đi";
            }
            Pnl_GoiHanhLy.Controls.Clear();
            DataSet ds = GoiHanhLy.LayGoiHanhLy();
            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                UC_GoiHanhLy goihanhly = new UC_GoiHanhLy();
                goihanhly.Lbl_MaGoiHanhLy.Text = dt.Rows[i]["MaGoi"].ToString();
                goihanhly.Lbl_KhoiLuongMuaThem.Text = dt.Rows[i]["KhoiLuongMuaThem"].ToString();
                goihanhly.Lbl_Gia.Text = dt.Rows[i]["GiaTien"].ToString();
                goihanhly.Location = new Point(10, 40 * i + 3);
                goihanhly.Btn_Chon.Click += Btn_Chon_Click;
                this.Pnl_GoiHanhLy.Controls.Add(goihanhly);
            }
        }
        private void Btn_Chon_Click(object sender, EventArgs e)
        {
            if (sender is Button Btn_Chon)
            {
                if (Btn_Chon.Parent is UC_GoiHanhLy goihanhly)
                {
                    BLL_GoiHanhLy GoiHanhLy = new BLL_GoiHanhLy();
                    DialogResult xacnhanmua = MessageBox.Show("Mỗi vé chỉ được mua 01 gói hành lý \n\nXác nhận mua/ thay đổi ?", "Mua gói hành lý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    bool success = false;
                    if (xacnhanmua == DialogResult.Yes)
                    {
                        if (Cmb_Chieu.Text == "Chiều đi")
                        {
                            if (thututreem != -1)
                            {
                                khachHangTreEms[thututreem].Magoihanhlychieudi = Convert.ToInt32(goihanhly.Lbl_MaGoiHanhLy.Text);
                                khachHangTreEms[thututreem].Giatiengoihanhlychieudi = Convert.ToDouble(goihanhly.Lbl_Gia.Text);
                            }
                            else
                            {
                                khachHangNguoiLons[thutunguoilon].Magoihanhlychieudi = Convert.ToInt32(goihanhly.Lbl_MaGoiHanhLy.Text);
                                khachHangNguoiLons[thutunguoilon].Giatiengoihanhlychieudi= Convert.ToDouble(goihanhly.Lbl_Gia.Text);
                            }
                        }
                        else if (Cmb_Chieu.Text == "Chiều về")
                        {
                            if (thututreem != -1)
                            {
                                khachHangTreEms[thututreem].Magoihanhlychieuve = Convert.ToInt32(goihanhly.Lbl_MaGoiHanhLy.Text);
                                khachHangTreEms[thututreem].Giatiengoihanhlychieuve = Convert.ToDouble(goihanhly.Lbl_Gia.Text);
                            }
                            else
                            {
                                khachHangNguoiLons[thutunguoilon].Magoihanhlychieuve = Convert.ToInt32(goihanhly.Lbl_MaGoiHanhLy.Text);
                                khachHangNguoiLons[thutunguoilon].Giatiengoihanhlychieuve = Convert.ToDouble(goihanhly.Lbl_Gia.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn hướng bay");
                        }
                    }
                    if (success)
                    {
                        MessageBox.Show("Mua thành công");
                    }
                }
            }
        }

        private void Btn_XoaGoiHanhLy_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult xacnhanxoa = MessageBox.Show("Xác nhận xóa gói hành lý?", "Xóa gói hành lý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xacnhanxoa == DialogResult.Yes)
                {
                    if (Cmb_Chieu.Text == "Chiều đi")
                    {
                        if (thututreem != -1)
                        {
                            khachHangTreEms[thututreem].Magoihanhlychieudi = -1;
                            khachHangTreEms[thututreem].Giatiengoihanhlychieudi = 0;
                        }
                        else
                        {
                            khachHangNguoiLons[thutunguoilon].Magoihanhlychieudi = -1;
                            khachHangNguoiLons[thutunguoilon].Giatiengoihanhlychieudi = 0;
                        }
                    }
                    else if (Cmb_Chieu.Text == "Chiều về")
                    {
                        if (thututreem != -1)
                        {
                            khachHangTreEms[thututreem].Magoihanhlychieuve = -1;
                            khachHangTreEms[thututreem].Giatiengoihanhlychieuve = 0;
                        }
                        else
                        {
                            khachHangNguoiLons[thutunguoilon].Magoihanhlychieuve = -1;
                            khachHangNguoiLons[thutunguoilon].Giatiengoihanhlychieuve = 0;
                        }
                    }

                    MessageBox.Show("Xóa thành công");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi xóa gói hành lý");
            }
        }

        private void Btn_TiepTuc_GoiHanhLy_Click(object sender, EventArgs e)
        {
            if (thutunguoilon < khachHangNguoiLons.Count - 1)
            {
                thutunguoilon = thutunguoilon + 1;
                LayGoiHanhLy(thutunguoilon);
            }
            else
            {
                if (thututreem < khachHangTreEms.Count - 1)
                {
                    thututreem = thututreem + 1;
                    LayGoiHanhLy(thututreem);
                }
                else
                {
                    this.Hide();

                    Frm_ChonChoNgoi frm_ChonChoNgoi = new Frm_ChonChoNgoi(khachHangNguoiLons, khachHangTreEms, thongtinchuyenbay);
                    frm_ChonChoNgoi.ShowDialog();

                    if (Frm_ThanhToan.thanhtoanthanhcong == 999) this.Close();
                    this.Show();

                }
            }
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
    }
}
