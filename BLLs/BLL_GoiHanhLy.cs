using QuanLyBanVeMayBay.DAL;
using System.Data;
using System.Data.SqlClient;


namespace QuanLyBanVeMayBay.BLLs
{
    public class BLL_GoiHanhLy
    {
        DBConnectionSQlServer db = null;
        SqlParameter[] parameters = null;
        string err = "";
        public BLL_GoiHanhLy()
        {
            db = new DBConnectionSQlServer(ConstantDATA.stringConnection);
        }
        
        // Hàm này trả về 1 DataSet chứa các gói hành lý được lấy cơ sở dữ liệu
        public DataSet LayGoiHanhLy()
        {
            return db.executeQuery("select * from lay_GoiHanhLy_FUNC()", CommandType.Text, parameters, ref err);
        }

        // Hàm này thực hiện việc thêm gói hành lý vào mã vé và trả về kết quả thực hiện kiểu bool
        public bool them_GoiHanhLy(string MaGoiHanhLy, string MaVe)
        {
            string sql = "EXEC them_GoiHanhLy_PROC @MaGoiHanhLy = " + MaGoiHanhLy + " , @MaVe = " + MaVe + ";";
            return db.executeNonQuery(sql, CommandType.Text, parameters, ref err);
        }
    }
}
