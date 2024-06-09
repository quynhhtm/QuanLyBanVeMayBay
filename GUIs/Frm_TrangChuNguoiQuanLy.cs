using QuanLyBanVeMayBay.BLLs;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_TrangChuNguoiQuanLy : Form
    {
        BLL_ChuyenBay themChuyenBay = null;
        BLL_MayBay bLLMayBay = null;
        DataTable dt = null; 
       
        string MaMaybay = null;
        string LoaiChuyenBay = null;
        string DiemDi = null;
        string DiemDen = null;
        DateTime ThoiGianDi;
        DateTime ThoiGianDuKienDen;
        string ChiPhi = null;
        string GiaVePhoThong = null;
        string GiaVeThuongGia = null;
        string KhoiLuongHanhLy = null;

        public Frm_TrangChuNguoiQuanLy()
        {
            InitializeComponent();
        }
       
        private void LayThongTinChuyenBay()
        {
            MaMaybay = Cbb_MaMayBay.Text.Trim();
            LoaiChuyenBay = Cmb_LoaiChuyenBay.Text.Trim();
            DiemDi = Txt_DiemDi.Text.Trim();
            DiemDen = Txt_DiemDen.Text.Trim();
            ThoiGianDi = Dtp_ThoiGianDi.Value;
            ThoiGianDuKienDen = Dtp_ThoiGianDuKienDen.Value;
            ChiPhi = Txt_ChiPhi.Text.Trim();
            GiaVePhoThong = Txt_GiaVePhoThong.Text.Trim();
            GiaVeThuongGia = Txt_GiaVeThuongGia.Text.Trim();
            KhoiLuongHanhLy = Txt_KhoiLuongHanhLy.Text.Trim();
        }
        
        private bool KiemTraThongTin()
        {
            LayThongTinChuyenBay();
            return string.IsNullOrEmpty(MaMaybay)
                || string.IsNullOrEmpty(LoaiChuyenBay)
                || string.IsNullOrEmpty(DiemDi)
                || string.IsNullOrEmpty(DiemDen)
                || string.IsNullOrEmpty(ChiPhi)
                || string.IsNullOrEmpty(GiaVePhoThong)
                || !int.TryParse(GiaVePhoThong, out _)
                || !int.TryParse(ChiPhi, out _)
                || !int.TryParse(GiaVeThuongGia, out _)
                || !int.TryParse(KhoiLuongHanhLy, out _)
                || string.IsNullOrEmpty(GiaVeThuongGia)
                || string.IsNullOrEmpty(KhoiLuongHanhLy) ? false : true;
        }

        private void Reload()
        {
            Cbb_MaMayBay.ResetText();
            Cmb_LoaiChuyenBay.ResetText();
            Txt_DiemDi.ResetText();
            Txt_DiemDen.ResetText();
            Dtp_ThoiGianDi.ResetText();
            Dtp_ThoiGianDuKienDen.ResetText();
            Txt_ChiPhi.ResetText();
            Txt_GiaVePhoThong.ResetText();
            Txt_GiaVeThuongGia.ResetText(); ;
            Txt_KhoiLuongHanhLy.ResetText(); ;
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            string error = null;
            themChuyenBay = new BLL_ChuyenBay();

            LayThongTinChuyenBay();
            if (KiemTraThongTin())
            {
                bool success = themChuyenBay.ThemChuyenBay(int.Parse(MaMaybay),
                                            LoaiChuyenBay,
                                            DiemDi,
                                            DiemDen,
                                            ThoiGianDi,
                                            ThoiGianDuKienDen,
                                            ChiPhi,
                                            GiaVePhoThong,
                                            GiaVeThuongGia,
                                            KhoiLuongHanhLy,
                                            ref error);
                
                if(success)
                {
                    MessageBox.Show("Thêm chuyến bay thành công!");
                    Reload();
                }
                else
                {
                    MessageBox.Show("Thêm chuyến bay thất bại!\n" + error);
                }
                    
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin chuyến bay!");
            }
            
        }

        private void Frm_TrangChuNguoiQuanLy_Load(object sender, EventArgs e)
        {
            bLLMayBay = new BLL_MayBay();
            dt = bLLMayBay.DanhSachMayBay().Tables[0];
            Cbb_MaMayBay.DataSource = dt;
            Cbb_MaMayBay.DisplayMember = "MaMaybay";
        }

        private void Btn_CapNhatChuyenBay_Click(object sender, EventArgs e)
        {
            Frm_CapNhat frm_CapNhat = new Frm_CapNhat();
            frm_CapNhat.ShowDialog();   
        }

        private void Btn_DoanhThu_Click(object sender, EventArgs e)
        {
            Frm_DoanhThu frm_DoanhThu = new Frm_DoanhThu();
            frm_DoanhThu.ShowDialog();
        }

        private void Btn_QuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            this.Hide();

            Frm_QuanLyNguoiDung quanlynguoidung = new Frm_QuanLyNguoiDung();
            quanlynguoidung.ShowDialog();

            this.Show();
        }
    }
}
