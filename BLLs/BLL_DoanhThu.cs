using QuanLyBanVeMayBay.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanVeMayBay.BLLs
{
    public class BLL_DoanhThu
    {
        DBConnectionSQlServer db = null;
        SqlParameter[] parameters = null;
        string err = "";

        public BLL_DoanhThu()
        {
            db = new DBConnectionSQlServer(ConstantDATA.stringConnection);
        }
        public DataSet lay_Nam()
        {
            return db.executeQuery("SELECT * FROM lay_Nam_FUNC()", CommandType.Text, parameters, ref err);
        }

        public DataSet lay_DoanhThuTheoThang(int nam)
        {
            string sql = "SELECT * FROM lay_DoanhThuTheoThang_FUNC(@nam)";

            parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter()
            {
                ParameterName = "@nam",
                Value = nam
            };
            return db.executeQuery(sql, CommandType.Text, parameters, ref err);
        }
    }
}
