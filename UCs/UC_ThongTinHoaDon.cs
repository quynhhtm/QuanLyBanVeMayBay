using System;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.UCs
{
    public partial class UC_ThongTinHoaDon : UserControl
    {
        // Khai báo một sự kiện click cho Button
        public event EventHandler ButtonClicked;
        public UC_ThongTinHoaDon()
        {
            InitializeComponent();
            Btn_HuyVe.Click += (sender, e) => ButtonClicked?.Invoke(this, e);
        }
    }
}
