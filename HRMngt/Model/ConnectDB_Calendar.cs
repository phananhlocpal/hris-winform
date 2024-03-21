using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMngt.Model
{
    class ConnectDB_Calendar
    {
        private readonly string conStr = @"Data Source=VO-NHUT-HAO\SQLEXPRESS;Initial Catalog=hris;User ID=sa;Password=123";
        public SqlConnection con;

        public ConnectDB_Calendar()
        {
            con = new SqlConnection(conStr);
        }
        public ConnectDB_Calendar(string conStr)
        {
            con = new SqlConnection(conStr);
        }

        public void OpenDB()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void CloseDB()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public int getExecuteNonQuery(string query)
        {
            OpenDB();
            SqlCommand cmd = new SqlCommand(query, con);

            int kq = cmd.ExecuteNonQuery();

            return kq;
        }
        public object getExecuteScalar(string query)
        {
            OpenDB();
            SqlCommand cmd = new SqlCommand(query, con);

            object kq = cmd.ExecuteScalar();

            return kq;
        }
        public DataTable getDataTable(string query)
        {
            SqlDataAdapter dataAdap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            dataAdap.Fill(ds);
            return ds.Tables[0];
        }
        public int updateDataTable(DataTable dt, string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kq = da.Update(dt);
            return kq;
        }
        public bool check_ID(string userID)
        {
            int check = 0;

            ConnectDB_Calendar db = new ConnectDB_Calendar();
            db.OpenDB();

            string query = "SELECT COUNT(*) FROM dbo.users WHERE userID = " + userID + "";
            check = (int)getExecuteScalar(query);

            db.CloseDB();

            if (check == 0)
                return false;
            return true;
        }
        public bool check_Gender(string userID)
        {
            int check = 0;

            ConnectDB_Calendar db = new ConnectDB_Calendar();
            db.OpenDB();

            string query = "SELECT COUNT(*) FROM dbo.users WHERE userID = '" + userID + "' AND sex = 1"; // nam
            check = (int)getExecuteScalar(query);

            db.CloseDB();

            if (check == 0)
                return false;
            return true;
        }
        public string layHoTen(string userID)
        {
            string ketQua = "";
            OpenDB();
            string query = "SELECT name FROM dbo.users where userID = '" + userID + "'";

            ketQua = (string)getExecuteScalar(query);

            CloseDB();
            return ketQua;
        }
        public string layPhongBan(string userID)
        {
            string ketQua = "";
            OpenDB();
            string query = "SELECT dbo.department.name FROM department INNER JOIN dbo.users ON dbo.users.departmentID = dbo.department.departmentID WHERE userID = '" + userID + "'";

            ketQua = (string)getExecuteScalar(query);

            CloseDB();
            return ketQua;
        }
        public string layPhongBan_ID(string userID)
        {
            string ketQua = "";
            OpenDB();
            string query = "SELECT dbo.department.departmentID FROM department INNER JOIN dbo.users ON dbo.users.departmentID = dbo.department.departmentID WHERE userID = '" + userID + "'";

            ketQua = (string)getExecuteScalar(query);

            CloseDB();
            return ketQua;
        }
        public string layAvatar(string userID)
        {
            string ketQua = "";
            OpenDB();
            string query = "SELECT ava FROM dbo.users where userID = '" + userID + "'";

            ketQua = (string)getExecuteScalar(query);

            CloseDB();
            return ketQua;
        }

        public bool xoaCalendar(string userID)
        {
            int check = 0;

            ConnectDB_Calendar db = new ConnectDB_Calendar();
            db.OpenDB();

            string query = "DELETE dbo.calendar WHERE userID = '" + userID + "'"; // nam
            check = (int)getExecuteNonQuery(query);

            db.CloseDB();

            if (check == 0)
                return false;
            return true;
        }
        public bool updateCalendar(string userID, DateTime date, DateTime res_in, DateTime res_out, DateTime real_in, DateTime real_out, string checkin_location, string checkout_location, string status)
        {
            OpenDB();
            string query = "SET DATEFORMAT dmy UPDATE dbo.calendar SET date = '" + date.ToString("dd/MM/yyyy") + "', register_checkIn = '" + res_in.ToString("HH:mm") + "', register_checkOut = '" + res_out.ToString("HH:mm") + "', real_checkIn = '" + real_in.ToString("HH:mm") + "', real_checkOut = '" + real_out.ToString("HH:mm") + "', checkIn_location = '" + checkin_location + "', checkOut_location = '" + checkout_location + "', status = '" + status + "' WHERE userID = '" + userID + "'";


            int kq = getExecuteNonQuery(query);


            CloseDB();
            return true;
        }
        public bool insertCalendar(string userID, DateTime date, DateTime res_in, DateTime res_out, DateTime real_in, DateTime real_out, string checkin_location, string checkout_location, string status)
        {
            OpenDB();
            string query = "SET DATEFORMAT dmy INSERT INTO dbo.calendar (userID, date, register_checkIn, register_checkOut, real_checkIn, real_checkOut, checkIn_location, checkOut_location, status) VALUES ('" + userID +"', '"+ date.ToString("dd/MM/yyyy") + "', '" + res_in.ToString("HH:mm") + "', '" + res_out.ToString("HH:mm") + "', '" + real_in.ToString("HH:mm") + "', '" + real_out.ToString("HH:mm") + "', '" + checkin_location + "', '" + checkout_location + "', '" + status + "')";


            int kq = getExecuteNonQuery(query);


            CloseDB();
            return true;
        }
        public bool updateWorkDay(string userID)
        {
            OpenDB();

            string query = "UPDATE dbo.salary SET workday += workday + 1 , real_workday += real_workday + 1 WHERE userID = '" + userID + "'";


            int kq = getExecuteNonQuery(query);


            CloseDB();
            return true;
        }
        public bool updateWorkDay(string userID, bool kiemTra)
        {
            OpenDB();

            string query = "UPDATE dbo.salary SET workday += workday + 1 WHERE userID = '" + userID + "'";


            int kq = getExecuteNonQuery(query);


            CloseDB();
            return true;
        }
        public int layWorkDay(string userID)
        {
            int ketQua;
            OpenDB();
            string query = "SELECT workday FROM dbo.salary where userID = '" + userID + "'";

            ketQua = Convert.ToInt32(getExecuteScalar(query));

            CloseDB();
            return ketQua;
        }
        public int layRealWorkDay(string userID)
        {
            int ketQua;
            OpenDB();
            string query = "SELECT real_workday FROM dbo.salary where userID = '" + userID + "'";

            ketQua = Convert.ToInt32(getExecuteScalar(query));

            CloseDB();
            return ketQua;
        }
        public int laySoCalendar()
        {
            int ketQua;
            OpenDB();
            string query = "SELECT COUNT(*) FROM dbo.calendar";

            ketQua = Convert.ToInt32(getExecuteScalar(query));

            CloseDB();
            return ketQua;
        }
    }
}
