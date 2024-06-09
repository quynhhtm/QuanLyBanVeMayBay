using QuanLyBanVeMayBay.GUIs;
using System;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.UCs
{
    public partial class UC_ThongTinChuyenBayDeXuat : UserControl
    {
        public UC_ThongTinChuyenBayDeXuat()
        {
            InitializeComponent();
        }

        private void UC_ChuyenBayDeXuat_Click(object sender, EventArgs e)
        {
            string diemdi = Lbl_DiemDi.Text;
            string diemden = Lbl_DiemDen.Text;
            DateTime ngaydi = DateTime.Parse(Lbl_NgayDi.Text);

            this.ParentForm.Hide();
            
            Frm_TimKiemChuyenBay TimKiemChuyenBay = new Frm_TimKiemChuyenBay(diemdi, diemden, ngaydi);
            TimKiemChuyenBay.ShowDialog();

            this.ParentForm.Show();
        }
    }
}
