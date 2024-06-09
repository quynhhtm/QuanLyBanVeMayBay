using QuanLyBanVeMayBay.BLLs;
using QuanLyBanVeMayBay.UCs;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs    
{
    public partial class Frm_TraCuuHoaDon : Form
    {
        BLL_HoaDon HoaDon = null;
        DataSet ds = null;
        DataTable dt = null;

        public Frm_TraCuuHoaDon()
        {
            InitializeComponent();
        }
        private void Init()
        {
            HoaDon = new BLL_HoaDon();
            dt = new DataTable();
            ds = new DataSet();
        }

        private bool Check(ref string message)
        {
            var isNumeric = int.TryParse(Txt_MaHoaDon.Text.Trim(), out _);
            bool isNull = string.IsNullOrEmpty(Txt_MaHoaDon.Text);
            if (isNull)
            {
                message = "Nhập mã hóa đơn!";
                Txt_MaHoaDon.Focus();
                return false;
            }
            else if (!isNumeric)
            {
                message = "Mã hóa đơn không phù hợp! Vui lòng nhập lại";
                Txt_MaHoaDon.ResetText();
                Txt_MaHoaDon.Focus();
                return false;
            }
            return true;
        }


        private void Btn_TimKiem_Click(object sender, EventArgs e)
        {
            string error = null;
            string message = null;
            if(Check(ref message))
            {
                Init();
                ds = HoaDon.ThongTinHoaDon(Txt_MaHoaDon.Text.Trim(), ref error);
                dt = ds.Tables[0];
                if (string.IsNullOrEmpty(error) && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        UC_ThongTinHoaDon thongTinHoaDon = new UC_ThongTinHoaDon();
                        DataRow row = dt.Rows[i];

                        thongTinHoaDon.Lbl_MaChuyenBay.Text = row["MaChuyenBay"].ToString();
                        thongTinHoaDon.Lbl_MaVe.Text = row["MaVe"].ToString();
                        thongTinHoaDon.Lbl_ThoiGianDen.Text = row["ThoiGianDuKienDen"].ToString();
                        thongTinHoaDon.Lbl_ThoiGianDi.Text = row["ThoiGianDi"].ToString();
                        thongTinHoaDon.Lbl_DiemDi.Text = row["DiemDi"].ToString();
                        thongTinHoaDon.Lbl_DiemDen.Text = row["DiemDen"].ToString();
                        thongTinHoaDon.Lbl_ChoNgoi.Text = row["ChoNgoi"].ToString();
                        thongTinHoaDon.Lbl_GiaVe.Text = row["GiaVe"].ToString();
                        thongTinHoaDon.Lbl_HanhLyMuaThem.Text = row["KhoiLuongMuaThem"].ToString();
                        thongTinHoaDon.Lbl_GiaHanhLy.Text = row["GiaTien"].ToString();
                        thongTinHoaDon.Btn_HuyVe.Click += UC_ThongTinHoaDon_BtnHuyVeClick;

                        thongTinHoaDon.Location = new Point(3, 315 * i);
                        Pnl_ThongTinHoaDon.Controls.Add(thongTinHoaDon);
                    }
                    this.Lbl_TongTienHoaDon.Text = dt.Rows[0]["TongTien"].ToString();
                    this.Lbl_ThoiGianThanhToan.Text = dt.Rows[0]["ThoiGianThanhToan"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tồn tại thông tin mã hóa đơn!!");
                }
            }
            else
            {
                MessageBox.Show(message);
                
            }
        }

        private void UC_ThongTinHoaDon_BtnHuyVeClick(object sender, EventArgs e)
        {
            string error = null;
            if (sender is Button btn_HuyVe)
            {
                if (btn_HuyVe.Parent is UC_ThongTinHoaDon thongTinHoaDon)
                {
                    Init();
                    bool success = HoaDon.HuyVe(thongTinHoaDon.Lbl_MaVe.Text, ref error);
                    if(success)
                    {
                        MessageBox.Show("Hủy vé thành công!");
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
            }
        }
    }
}
