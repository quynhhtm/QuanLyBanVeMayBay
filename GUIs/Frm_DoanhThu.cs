using QuanLyBanVeMayBay.BLLs;
using System.Data;
using System.Windows.Forms;

namespace QuanLyBanVeMayBay.GUIs
{
    public partial class Frm_DoanhThu : Form
    {
        BLL_DoanhThu doanhThu = null;
        DataTable dt = null;

        public Frm_DoanhThu()
        {
            InitializeComponent();
        }

        private void BieuDoDoanhThu()
        {
            doanhThu = new BLL_DoanhThu();
            dt = new DataTable();
            dt = doanhThu.lay_DoanhThuTheoThang(int.Parse(Cmb_Nam.Text)).Tables[0];
            chart1.DataSource = dt;

            chart1.Titles.Clear();
            chart1.Series["Doanh Thu"].XValueMember = "Thang";
            chart1.Series["Doanh Thu"].YValueMembers = "DoanhThu";
            chart1.Titles.Add("Doanh thu vé bán theo tháng");
            chart1.Titles[0].Font = new System.Drawing.Font("Times New Roman", 18, System.Drawing.FontStyle.Bold);
        }

        private void Btn_DoanhThu_Click(object sender, System.EventArgs e)
        {
            BieuDoDoanhThu();
        }

        private void Frm_DoanhThu_Load(object sender, System.EventArgs e)
        {
            doanhThu = new BLL_DoanhThu();
            dt = doanhThu.lay_Nam().Tables[0];
            Cmb_Nam.DataSource = dt;
            Cmb_Nam.DisplayMember = "Nam";
        }
    }
}
