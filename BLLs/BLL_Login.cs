using QuanLyBanVeMayBay.DAL;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyBanVeMayBay.BLLs
{
    public class BLL_Login
    {
        public DBConnectionSQlServer db = null;

        public BLL_Login()
        {
            db = new DBConnectionSQlServer(ConstantDATA.stringConnectionLogin);
        }

        public DataSet kiemtra_DangNhap(string sodienthoai, string matkhau, ref string error)
        {
            string sql = 
                "SELECT * " +
                "FROM kiemtra_DangNhap_FUNC(" +
                    "@SoDienThoai, " +
                    "@MatKhau" +
                ")";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter()
            {
                ParameterName = "@SoDienThoai", 
                Value = sodienthoai,
            };

            sqlParameters[1] = new SqlParameter()
            {
                ParameterName = "@MatKhau",
                Value = matkhau,
            };

            return db.executeQuery(sql, CommandType.Text, sqlParameters, ref error);
        }

        public bool dangky_TaiKhoan(string hoten, string sodienthoai, string email, string matkhau, ref string error)
        {
            string sql = "EXEC dangky_TaiKhoan_PROC " +
                        "@HoTen, " +
                        "@SoDienThoai, " +
                        "@Email, " +
                        "@MatKhau";

            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter()
            {
                ParameterName = "@HoTen",
                Value = hoten,
            };

            sqlParameters[1] = new SqlParameter()
            {
                ParameterName = "@SoDienThoai",
                Value = sodienthoai,
            };

            sqlParameters[2] = new SqlParameter()
            {
                ParameterName = "@Email",
                Value = email,
            };

            sqlParameters[3] = new SqlParameter()
            {
                ParameterName = "@MatKhau",
                Value = matkhau,
            };

            return db.executeNonQuery(sql, CommandType.Text, sqlParameters, ref error);
        }
    }
}
