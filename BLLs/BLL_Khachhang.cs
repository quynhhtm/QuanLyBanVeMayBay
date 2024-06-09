using QuanLyBanVeMayBay.DAL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBanVeMayBay.BLLs
{
    public class BLL_KhachHang
    {
        DBConnectionSQlServer db = null;
        public BLL_KhachHang()
        {
            db = new DBConnectionSQlServer(ConstantDATA.stringConnection);
        }
        public int them_KhachHangNguoiLon(
            string hoten,
            string gioitinh,
            DateTime ngaysinh,
            string sodienthoai,
            string email,
            string diachi,
            int mave,
            int magoi,
            int mahoadon,
            ref string error)
        {
            string sql =
                "EXEC dbo.them_ThongTinKhachHangNguoiLon_PROC " +
                "@HoTen, " +
                "@GioiTinh, " +
                "@NgaySinh, " +
                "@SoDienThoai, " +
                "@Email, " +
                "@DiaChi, " +
                "@MaVe, " +
                "@MaGoi, " +
                "@MaHoaDon, " +
                "@MaNguoiLon OUTPUT";

            SqlParameter[] sqlParameter = new SqlParameter[10];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@HoTen",
                Value = hoten
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@GioiTinh",
                Value = gioitinh
            };

            sqlParameter[2] = new SqlParameter()
            {
                ParameterName = "@NgaySinh",
                Value = ngaysinh
            };

            sqlParameter[3] = new SqlParameter()
            {
                ParameterName = "@SoDienThoai",
                Value = sodienthoai

            };

            sqlParameter[4] = new SqlParameter()
            {
                ParameterName = "@Email",
                Value = email

            };

            sqlParameter[5] = new SqlParameter()
            {
                ParameterName = "@DiaChi",
                Value = ((diachi == "-1") ? DBNull.Value : (object)diachi)

            };

            sqlParameter[6] = new SqlParameter()
            {
                ParameterName = "@MaVe",
                Value = ((mave <= 0) ? DBNull.Value : (object)mave)

            };

            sqlParameter[7] = new SqlParameter()
            {
                ParameterName = "@MaGoi",
                Value = ((magoi <= 0) ? DBNull.Value : (object)magoi)

            };

            sqlParameter[8] = new SqlParameter()
            {
                ParameterName = "@MaHoaDon",
                Value = mahoadon

            };

            sqlParameter[9] = new SqlParameter()
            {
                ParameterName = "@MaNguoiLon",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output

            };

            bool success = db.executeNonQuery(sql, CommandType.Text, sqlParameter, ref error);
            int manguoilon = (int)sqlParameter[9].Value;

            if (success) return manguoilon;
            return -1;
        }

        public int them_KhachHangTreEm(
            string hoten,
            string gioitinh,
            DateTime ngaysinh,
            int mave,
            int magoi,
            int mahoadon,
            ref string error)
        {
            string sql =
                "EXEC dbo.them_ThongTinKhachHangTreEm_PROC " +
                "@HoTen, " +
                "@GioiTinh, " +
                "@NgaySinh, " +
                "@MaVe, " +
                "@MaGoi, " +
                "@MaHoaDon, " +
                "@MaTreEm OUTPUT";

            SqlParameter[] sqlParameter = new SqlParameter[7];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@HoTen",
                Value = hoten
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@GioiTinh",
                Value = gioitinh
            };

            sqlParameter[2] = new SqlParameter()
            {
                ParameterName = "@NgaySinh",
                Value = ngaysinh
            };

            sqlParameter[3] = new SqlParameter()
            {
                ParameterName = "@MaVe",
                Value = ((mave <= 0) ? DBNull.Value : (object)mave)

            };

            sqlParameter[4] = new SqlParameter()
            {
                ParameterName = "@MaGoi",
                Value = ((magoi <= 0) ? DBNull.Value : (object)magoi)

            };

            sqlParameter[5] = new SqlParameter()
            {
                ParameterName = "@MaHoaDon",
                Value = mahoadon

            };

            sqlParameter[6] = new SqlParameter()
            {
                ParameterName = "@MaTreEm",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output

            };

            bool success = db.executeNonQuery(sql, CommandType.Text, sqlParameter, ref error);
            int matreem = (int)sqlParameter[6].Value;

            if (success) return matreem;
            return -1;
        }

        public bool them_NguoiLonQuanLyTreEm(int manguoilon, int matreem, ref string error)
        {
            string sql =
                "EXEC dbo.them_NguoiLonQuanLyTreEm_PROC " +
                "@MaNguoiLon, " +
                "@MaTreEm";

            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@MaNguoiLon",
                Value = manguoilon
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@MaTreEm",
                Value = matreem
            };

            return db.executeNonQuery(sql, CommandType.Text, sqlParameter, ref error);
        }
    }
}
