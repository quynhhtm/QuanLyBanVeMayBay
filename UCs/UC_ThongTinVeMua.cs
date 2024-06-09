using System;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.UCs
{
    public partial class UC_ThongTinVeMua : UserControl
    {
        public event EventHandler chonchuyenbayClick;

        public UC_ThongTinVeMua()
        {
            InitializeComponent();
        }

        private void UC_ThongTinVeMua_Click(object sender, EventArgs e)
        {
            chonchuyenbayClick(sender, e);
            this.ParentForm.Close();
        }
    }
}
