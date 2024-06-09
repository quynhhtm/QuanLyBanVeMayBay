using QuanLyBanVeMayBay.DAL;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanVeMayBay.BLLs
{
    public class BLL_HoaDon
    {
        DBConnectionSQlServer db = null;
        public BLL_HoaDon()
        {
            db = new DBConnectionSQlServer(ConstantDATA.stringConnection);
        }

        // Hàm nhận tham số mã hóa đơn và trả về danh sách chi tiết vé máy bay
        public DataSet ThongTinHoaDon(string MaHoaDon, ref string error)
        {
            string sql = "SELECT * FROM tracuu_HoaDon_FUNC(@MaHoaDon)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter()
            {
                ParameterName = "@MaHoaDon",
                Value = MaHoaDon
            };
            return db.executeQuery(sql, CommandType.Text, sqlParameters, ref error);
        }

        // Hàm nhận tham số mã vé máy bay và thực hiện hủy vé trong cơ sở dữ liệu
        public bool HuyVe(string MaVe, ref string error)
        {
            string sql = "EXEC huy_Ve_PROC @MaVe";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter()
            {
                ParameterName = "@MaVe",
                Value = MaVe
            };
            return db.executeNonQuery(sql, CommandType.Text, sqlParameters, ref error);
        }

        // Hàm khởi tạo hóa đơn mới và trả về mã hóa đơn vừa tạo
        public Pair khoitao_HoaDon(ref string error)
        {
            string sql = 
                "EXEC dbo.khoitao_HoaDon_PROC " +
                "@MaHoaDon OUTPUT, " +
                "@Thue OUTPUT";

            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@MaHoaDon",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@Thue",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Output
            };

            bool success = db.executeNonQuery(sql, CommandType.Text, sqlParameter, ref error);
            int mahoadon = (int)sqlParameter[0].Value;
            double thue = (double)sqlParameter[1].Value;

            Pair pair = new Pair(mahoadon, thue);

            if (success) return pair;
            return null;
        }

        // Hàm nhận vào 2 tham số: mã người dùng, mã hóa đơn
        // Trả về thông tin lịch sử giao dịch của người dùng bao gồm: 
        // số điện thoại, mã hóa đơn, tổng tiền thanh toán, thời gian thanh toán
        public DataSet timkiem_LichSuGiaoDich(string sodienthoai, ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM timkiem_LichSuGiaoDich_FUNC(" +
                    "@SoDienThoai " +
                ")";

            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@SoDienThoai",
                Value = sodienthoai
            };

            return db.executeQuery(sql, CommandType.Text, sqlParameter, ref error);
        }
    }
}