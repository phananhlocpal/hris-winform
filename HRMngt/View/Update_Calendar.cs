using HRMngt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMngt.View
{
    public partial class Update_Calendar : Form
    {
        ConnectDB_Calendar db = new ConnectDB_Calendar();
        string connectionString = @"Data Source=VO-NHUT-HAO\SQLEXPRESS;Initial Catalog=hris;Persist Security Info=True;User ID=sa;Password=123";
        string userID;
        string[] trangThai = { "Consider", "Late", "Attendance logged", "Deleted", "Rejected", "Approved", "Created" };

        public Update_Calendar(string id)
        {
            InitializeComponent();

            userID = id;

            dTP_Date.Format = DateTimePickerFormat.Custom;
            dTP_Date.CustomFormat = "dd/MM/yyyy";
            dTP_Date.ShowUpDown = true;

            dTP_TimeIn.Format = DateTimePickerFormat.Custom;
            dTP_TimeIn.CustomFormat = "HH:mm";
            dTP_TimeIn.ShowUpDown = true;

            dTP_TimeOut.Format = DateTimePickerFormat.Custom;
            dTP_TimeOut.CustomFormat = "HH:mm";
            dTP_TimeOut.ShowUpDown = true;

            dTP_In.Format = DateTimePickerFormat.Custom;
            dTP_In.CustomFormat = "HH:mm";
            dTP_In.ShowUpDown = true;

            dTP_Out.Format = DateTimePickerFormat.Custom;
            dTP_Out.CustomFormat = "HH:mm";
            dTP_Out.ShowUpDown = true;
            xuLy();
        }

        void xuLy()
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.calendar INNER JOIN dbo.users ON dbo.users.userID = dbo.calendar.userID WHERE dbo.calendar.userID = '" + userID + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    string imageResourceName = db.layAvatar(userID);

                    if (!string.IsNullOrEmpty(imageResourceName))
                    {
                        try
                        {
                            // Lấy hình ảnh từ tài nguyên của ứng dụng và gán cho PictureBox
                            Image img = (Image)Properties.Resources.ResourceManager.GetObject(imageResourceName);

                            if (img != null)
                            {
                                pic_ava.Image = img;
                                pic_ava.SizeMode = PictureBoxSizeMode.StretchImage;

                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy hình ảnh cho userID: " + userID);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên hình ảnh không hợp lệ!");
                    }

                    lbl_ID.Text += userID;

                    lbl_Name.Text = reader["name"].ToString();
                    load_Cbo_TrangThai(reader["status"].ToString());
                    DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    dTP_Date.Value = date;
                    DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                    DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                    dTP_TimeIn.Text = registerCheckIn.ToString("HH:mm");
                    dTP_TimeOut.Text = registerCheckOut.ToString("HH:mm");
                    DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                    DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                    dTP_In.Text = realCheckIn.ToString("HH:mm");
                    dTP_Out.Text = realCheckOut.ToString("HH:mm");
                    txt_CheckIn.Text = reader["checkIn_location"].ToString();
                    txt_CheckOut.Text = reader["checkOut_location"].ToString();
                }
            }
        }

        void load_Cbo_TrangThai(string status)
        {
            string result = Regex.Replace(status, @"\s+", " ");
            int i = Array.IndexOf(trangThai, result.TrimEnd());

            cbo_TrangThai.Items.AddRange(trangThai);
            cbo_TrangThai.SelectedIndex = i;
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            DateTime date = dTP_Date.Value;

            DateTime res_in = dTP_TimeIn.Value;
            DateTime res_out = dTP_TimeOut.Value;

            DateTime real_in = dTP_In.Value;
            DateTime real_out = dTP_Out.Value;

            string checkin_location = txt_CheckIn.Text;
            string checkout_location = txt_CheckOut.Text;

            string status = cbo_TrangThai.SelectedItem.ToString();

            bool result = db.updateCalendar(userID, date, res_in, res_out, real_in, real_out, checkin_location, checkout_location, status);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
                xuLy();
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Calendar f = new Calendar();
            f.Show();
            this.Hide();
        }
    }
}
