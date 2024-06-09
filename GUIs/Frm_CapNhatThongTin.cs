using QuanLyBanVeMayBay.BLLs;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_CapNhatThongTin : Form
    {
        BLL_ChuyenBay bll = null;
        DataSet ds = null;
        DataTable dt = null;
        string error = null;

        string MaChuyenBay = null;
        string DiemDi = null;
        string DiemDen = null;
        string TinhTrang = null;
        DateTime ThoiGianDi;
        DateTime ThoiGianDen;
        string GiaVePhoThong = null;
        string GiaVeThuongGia = null;

        public Frm_CapNhatThongTin()
        {
            InitializeComponent();
        }
        private void Init()
        {
            bll = new BLL_ChuyenBay();
            dt = new DataTable();
            ds = new DataSet();
        }
        public Frm_CapNhatThongTin(string macb, string diemdi, string diemden, string tinhtrang, DateTime giodi, DateTime gioden, string giavept, string giavetg)
        {
            InitializeComponent();
            Lbl_MaChuyenBay.Text = macb;
            Lbl_DiemDi.Text = diemdi;
            Lbl_DiemDen.Text = diemden;
            Cbb_TinhTrang.Text = tinhtrang;
            Dtp_ThoiGianDi.Value = giodi;
            Dtp_ThoiGianDen.Value = gioden;
            Txt_GiaVePhoThong.Text = giavept;
            Txt_GiaVeThuongGia.Text = giavetg;
        }

        private void LayThongTinChuyenBay()
        {
            MaChuyenBay = Lbl_MaChuyenBay.Text.Trim();
            DiemDi = Lbl_DiemDi.Text.Trim();
            DiemDen = Lbl_DiemDen.Text.Trim();
            TinhTrang = Cbb_TinhTrang.Text.Trim();
            ThoiGianDi = Dtp_ThoiGianDi.Value;
            ThoiGianDen = Dtp_ThoiGianDen.Value;
            GiaVePhoThong = Txt_GiaVePhoThong.Text.Trim();
            GiaVeThuongGia = Txt_GiaVeThuongGia.Text.Trim();
        }
        private bool KiemTraThongTin()
        {
            LayThongTinChuyenBay();
            return string.IsNullOrEmpty(TinhTrang)
                || string.IsNullOrEmpty(GiaVePhoThong)
                || !int.TryParse(GiaVePhoThong, out _)
                || !int.TryParse(GiaVeThuongGia, out _)
                || !int.TryParse(MaChuyenBay, out _)
                || string.IsNullOrEmpty(GiaVeThuongGia) ? false : true;
        }

        private void Btn_Xong_Click(object sender, EventArgs e)
        {
            LayThongTinChuyenBay();
            if (KiemTraThongTin())
            {
                if (sender is Button Btn_Xong)
                {
                    if (Btn_Xong.Parent is Frm_CapNhatThongTin frm)
                    {
                        Init();
                        bool success = bll.CapNhatChuyenBay(int.Parse(frm.Lbl_MaChuyenBay.Text), frm.Cbb_TinhTrang.Text,
                                                            frm.Dtp_ThoiGianDi.Value, frm.Dtp_ThoiGianDen.Value,
                                                            int.Parse(frm.Txt_GiaVePhoThong.Text),
                                                            int.Parse(frm.Txt_GiaVeThuongGia.Text), ref error);
                        if (success)
                        {
                            MessageBox.Show("Cập nhật thành công!");
                        }
                        else
                        {
                            MessageBox.Show(error);
                        }
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại thông tin!");
            }

        }
    }
}
