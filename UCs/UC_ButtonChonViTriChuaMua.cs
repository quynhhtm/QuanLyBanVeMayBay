using System;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.UCs
{
    public partial class UC_ButtonChonViTriChuaMua : UserControl
    {
        public event EventHandler ButtonClicked;
        public UC_ButtonChonViTriChuaMua()
        {
            InitializeComponent();
            Btn_MaGhe.Click += (sender, e) => ButtonClicked?.Invoke(this, e);
        }
    }
}
