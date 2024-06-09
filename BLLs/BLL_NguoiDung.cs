using QuanLyBanVeMayBay.DAL;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyBanVeMayBay.BLLs
{
    public class BLL_NguoiDung
    {
        public DBConnectionSQlServer db = null;

        public BLL_NguoiDung()
        {
            db = new DBConnectionSQlServer(ConstantDATA.stringConnection);
        }

        public bool them_ThongTinNguoiDungMuaVe(int mave, int manguoidung, ref string error)
        {
            string sql =
                "EXEC dbo.them_ThongTinNguoiDungMuaVe_PROC " +
                "@MaVe, " +
                "@MaNguoiDung";

            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@MaVe",
                Value = mave
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@MaNguoiDung",
                Value = manguoidung
            };

            return db.executeNonQuery(sql, CommandType.Text, sqlParameter, ref error);
        }

        public DataSet timkiem_ThongTinCaNhan(int manguoidung, ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM timkiem_ThongTinCaNhan_PROC(" +
                    "@MaNguoiDung" +
                ")";

            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@MaNguoiDung",
                Value = manguoidung
            };

            return db.executeQuery(sql, CommandType.Text, sqlParameter, ref error);
        }

        public DataSet timkiem_LichSuGiaoDich(int manguoidung, int mahoadon, ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM timkiem_LichSuGiaoDich_FUNC(" +
                    "@MaNguoiDung, " +
                    "@MaHoaDon" +
                ")";

            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@MaNguoiDung",
                Value = manguoidung
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@MaHoaDon",
                Value = mahoadon
            };

            return db.executeQuery(sql, CommandType.Text, sqlParameter, ref error);
        }
    }
}
