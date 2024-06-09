using QuanLyBanVeMayBay.DAL;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyBanVeMayBay.BLLs
{
    public class BLL_MayBay
    {
        DBConnectionSQlServer db = null;
        SqlParameter[] parameters = null;
        string err = "";

        public BLL_MayBay()
        {
            db = new DBConnectionSQlServer(ConstantDATA.stringConnection);
        }

        // Lấy danh sach mã máy bay
        public DataSet DanhSachMayBay()
        {
            return db.executeQuery("SELECT * FROM lay_MaMayBay_FUNC()", CommandType.Text, parameters, ref err);
        }
    }
}
