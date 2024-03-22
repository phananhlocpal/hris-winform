using HRMngt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMngt.View
{
    public partial class Detail_Calendar : Form
    {
        ConnectDB_Calendar db = new ConnectDB_Calendar();
        string connectionString = @"Data Source=VO-NHUT-HAO\SQLEXPRESS;Initial Catalog=hris;Persist Security Info=True;User ID=sa;Password=123";
        string userID;
        public Detail_Calendar(string id)
        {
            InitializeComponent();

            userID = id;
            xuLy();
        }

        void xuLy()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.calendar INNER JOIN dbo.users ON dbo.users.userID = dbo.calendar.userID WHERE dbo.calendar.userID = '"+ userID +"'";
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
                    lbl_TrangThai.Text = reader["status"].ToString();
                    DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    lbl_Date.Text = date.ToString("dd/MM/yyyy");
                    DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                    DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                    lbl_Time_Work.Text = registerCheckIn.ToString("HH:mm") + " - " + registerCheckOut.ToString("HH:mm");
                    DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                    DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                    lbl_Real_In.Text = realCheckIn.ToString("HH:mm");
                    lbl_Real_Out.Text = realCheckOut.ToString("HH:mm");
                    lbl_CheckIn_Location.Text = reader["checkIn_location"].ToString();
                    lbl_CheckOut_Location.Text = reader["checkOut_location"].ToString();
                }
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Calendar f = new Calendar();
            f.Show();
            this.Hide();
        }
    }
}
