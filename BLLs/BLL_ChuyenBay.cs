using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBanVeMayBay.DAL;

namespace QuanLyBanVeMayBay.BLLs
{
    public class BLL_ChuyenBay
    {
        public DBConnectionSQlServer db = null;

        public BLL_ChuyenBay() 
        {
            db = new DBConnectionSQlServer(ConstantDATA.stringConnection);
        }

        // Hàm này trả về một DataSet chứa các điểm đi có trong cơ sở dữ liệu
        public DataSet lay_DiemDi(ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM lay_DiemDi()";

            return db.executeQuery(sql, CommandType.Text, null, ref error);
        }

        // Hàm này trả về một DataSet chứa các điểm đến có trong cơ sở dữ liệu
        public DataSet lay_DiemDen(ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM lay_DiemDen()";

            return db.executeQuery(sql, CommandType.Text, null, ref error);
        }

        // Hàm này trả về một DataSet chứa các tình trạng của 1 chuyến bay có trong cơ sở dữ liệu
        public DataSet lay_TinhTrang(ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM lay_TinhTrang()";
            return db.executeQuery(sql, CommandType.Text, null, ref error);
        }

        // Hàm này nhận vào 1 mã chuyến bay và trả về một DataSet chứa danh sách chỗ ngồi của 1 chuyến bay nào đó cơ sở dữ liệu
        public DataSet lay_DanhSachChoNgoi(int machuyenbay, ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM lay_DanhSachChoNgoi_FUNC(@MaChuyenBay)";
            SqlParameter[] sqlParameter = new SqlParameter[1];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@MaChuyenBay",
                Value = machuyenbay
            };
            return db.executeQuery(sql, CommandType.Text, sqlParameter, ref error);
        }

        // Hàm này nhận vào
        // số lượng đề xuất,
        // điểm đi đi,
        // điểm đếnn,
        // ngân sách
        // và trả về một DataSet chứa danh sách các chuyến bay được đề xuất trong cơ sở dữ liệu
        public DataSet lay_DeXuatChuyenBay(
            int soluongdexuat, 
            string diemdi,
            string diemden,
            float ngansach,
            ref string error)
        {
            string sql = 
                "SELECT * " +
                "FROM lay_DeXuatChuyenBay_FUNC(" +
                    "@SoLuongDeXuat, " +
                    "@DiemDi, " +
                    "@DiemDen, " +
                    "@NganSach" +
                ")";

            SqlParameter[] sqlParameter = new SqlParameter[4];
            sqlParameter[0] = new SqlParameter() 
            { 
                ParameterName = "@SoLuongDeXuat",
                Value = soluongdexuat
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@DiemDi",
                Value = ((diemdi == "-1") ? DBNull.Value : (object)diemdi)
            };

            sqlParameter[2] = new SqlParameter()
            {
                ParameterName = "@DiemDen",
                Value = ((diemden == "-1") ? DBNull.Value : (object)diemden)
            };

            sqlParameter[3] = new SqlParameter()
            {
                ParameterName = "@NganSach",
                Value = ((ngansach <= 0) ? DBNull.Value : (object)ngansach)

            };

            return db.executeQuery(sql, CommandType.Text, sqlParameter, ref error);
        }

        // Hàm này nhận vào
        // điểm đi,
        // điểm đến,
        // ngày đi, 
        // số hành khách
        // và trả về một DataSet chứa danh sách các chuyến bay được tìm thấy trong cơ sở dữ liệu
        public DataSet timkiem_VeMayBay(
            string diemdi,
            string diemden,
            DateTime ngaydi,
            int sohanhkhach,
            ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM timkiem_VeMayBay_FUNC(" +
                    "@DiemDi, " +
                    "@DiemDen, " +
                    "@NgayDi, " +
                    "@SoHanhKhach" +
                ")";

            SqlParameter[] sqlParameter = new SqlParameter[4];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@DiemDi",
                Value = ((diemdi == "-1") ? DBNull.Value : (object)diemdi)
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@DiemDen",
                Value = ((diemden == "-1") ? DBNull.Value : (object)diemden)
            };

            sqlParameter[2] = new SqlParameter()
            {
                ParameterName = "@NgayDi",
                Value = (ngaydi.Equals(new DateTime(2010, 1, 1)) ? DBNull.Value : (object) ngaydi)
            };

            sqlParameter[3] = new SqlParameter()
            {
                ParameterName = "@SoHanhKhach",
                Value = ((sohanhkhach <= 0) ? DBNull.Value : (object)sohanhkhach)

            };

            return db.executeQuery(sql, CommandType.Text, sqlParameter, ref error);
        }

        // Hàm này nhận vào
        // điểm đi,
        // điểm đến,
        // ngày đi, 
        // tình trạng chuyến bay
        // và trả về một DataSet chứa danh sách các chuyến bay được tìm thấy trong cơ sở dữ liệu
        public DataSet timkiem_ChuyenBay(
            string DiemDi, 
            string DiemDen,
            DateTime NgayDi,
            string TinhTrangChuyenBay,
            ref string error)
        {
            string sql =
                "SELECT * " +
                "FROM timkiem_ChuyenBay_FUNC(" +
                    "@DiemDi, " +
                    "@DiemDen, " +
                    "@NgayDi, " +
                    "@TinhTrangChuyenBay" +
                ")";

            SqlParameter[] sqlParameter = new SqlParameter[4];
            sqlParameter[0] = new SqlParameter()
            {
                ParameterName = "@DiemDi",
                Value = ((DiemDi == "-1") ? DBNull.Value : (object)DiemDi)
            };

            sqlParameter[1] = new SqlParameter()
            {
                ParameterName = "@DiemDen",
                Value = ((DiemDen == "-1") ? DBNull.Value : (object)DiemDen)
            };

            sqlParameter[2] = new SqlParameter()
            {
                ParameterName = "@NgayDi",
                Value = (NgayDi.Equals(new DateTime(2010, 1, 1)) ? DBNull.Value : (object)NgayDi)
            };

            sqlParameter[3] = new SqlParameter()
            {
                ParameterName = "@TinhTrangChuyenBay",
                Value = ((TinhTrangChuyenBay == "-1") ? DBNull.Value : (object)TinhTrangChuyenBay)
            };

            return db.executeQuery(sql, CommandType.Text, sqlParameter, ref error);
        }

        // Hàm này nhận vào các thông tin của 1 chuyến bay 
        // sau đó thêm chuyến bay này vào trong cơ sở dữ liệu
        public bool ThemChuyenBay(
            int MaMayMay,
            string LoaiChuyenBay,
            string DiemDi,
            string DiemDen,
            DateTime ThoiGiandi,
            DateTime ThoiGianDuKienDen,
            string ChiPhi,
            string GiaVePhoThong,
            string GiaVeThuongGia,
            string KhoiLuongHanhLy,
            ref string error)
        {
            string sql = "DECLARE @MaChuyenBay INT " +
                         "EXEC them_ChuyenBay_PROC " +
                         "@MaChuyenBay OUTPUT, " +
                         "@LoaiChuyenBay, " +
                         "@DiemDi, " +
                         "@DiemDen, " +
                         "@ThoiGiandi, " +
                         "@ThoiGianDuKienDen, " +
                         "N'Chưa cất cánh', " +
                         "@ChiPhi " +
                         "SELECT @MaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@LoaiChuyenBay", LoaiChuyenBay),
                new SqlParameter("@DiemDi", DiemDi),
                new SqlParameter("@DiemDen", DiemDen),
                new SqlParameter("@ThoiGiandi", ThoiGiandi),
                new SqlParameter("@ThoiGianDuKienDen", ThoiGianDuKienDen),
                new SqlParameter("@ChiPhi", ChiPhi)
            };

            DataSet ds = new DataSet();
            ds = db.executeQuery(sql, CommandType.Text, sqlParameters, ref error);

            if(string.IsNullOrEmpty(error))
            {
                string MaChuyenBay = ds.Tables[0].Rows[0][0].ToString();

                ThemMayBayKhoiTaoChuyenBay(MaMayMay.ToString(), MaChuyenBay, ref error);
                ThemChuyenBayPhatHanhVeMayBay(GiaVeThuongGia, GiaVePhoThong, KhoiLuongHanhLy, MaChuyenBay, ref error);
                return true;
            }
            return false;
        }

        // Hàm này nhận vào 
        // mã máy bay và mã chuyến bay để thêm vào bảng quan hệ khởi tạo 
        private bool ThemMayBayKhoiTaoChuyenBay(string MaMayBay, string MaChuyenBay, ref string error)
        {
            string sql = "EXEC khoitao_ChuyenBay_PROC " +
                         "@MaMayBay, " +
                         "@MaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaMayBay", MaMayBay),
                new SqlParameter("@MaChuyenBay", MaChuyenBay),
            };
            return db.executeNonQuery(sql, CommandType.Text, sqlParameters, ref error);
        }

        //Hàm này nhận vào thông tin về chuyến bay như
        // giá vé thương gia
        // giá vé phổ thông
        // khối lượng hành lý mặc định
        // mã chuyến bay 
        // để thực hiện phát hành vé máy bay
        private bool ThemChuyenBayPhatHanhVeMayBay(string GiaVeThuongGia, string GiaVePhoThong, string KhoiLuongHanhLy, string MaChuyenMay, ref string error)
        {
            string sql = "EXEC phathanh_VeMayBay_PROC " +
                         "@GiaVeThuongGia, " +
                         "@GiaVePhoThong, " +
                         "@KhoiLuongHanhLy, " +
                         "@MaChuyenBay";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@GiaVeThuongGia", GiaVeThuongGia),
                new SqlParameter("@GiaVePhoThong", GiaVePhoThong),
                new SqlParameter("@KhoiLuongHanhLy", KhoiLuongHanhLy),
                new SqlParameter("@MaChuyenBay", MaChuyenMay)
            };
            return db.executeNonQuery(sql, CommandType.Text, sqlParameters, ref error);
        }

        public bool CapNhatChuyenBay(
                    int MaChuyenBay,
                    string TinhTrangChuyenBay,
                    DateTime ThoiGianDi,
                    DateTime ThoiGianDuKienDen,
                    float GiaVePhoThong,
                    float GiaVeThuongGia,
                    ref string error)
        {
            string sql =
                         "EXEC capnhat_ThongTinChuyenBay_PROC " +
                         "@MaChuyenBay, " +
                         "@TinhTrangChuyenBay, " +
                         "@ThoiGianDi, " +
                         "@ThoiGianDuKienDen, " +
                         "@GiaVePhoThong, " +
                         "@GiaVeThuongGia ";
               
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@MaChuyenBay", MaChuyenBay),
                new SqlParameter("@TinhTrangChuyenBay", TinhTrangChuyenBay),
                new SqlParameter("@ThoiGianDi", ThoiGianDi),
                new SqlParameter("@ThoiGianDuKienDen", ThoiGianDuKienDen),
                new SqlParameter("@GiaVePhoThong", GiaVePhoThong),
                new SqlParameter("GiaVeThuongGia", GiaVeThuongGia)
            };
            return db.executeNonQuery(sql, CommandType.Text, sqlParameters, ref error);
        }
    }
}