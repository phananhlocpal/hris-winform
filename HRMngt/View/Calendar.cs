using HRMngt.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HRMngt.View
{
    public partial class Calendar : Form
    {
        ConnectDB_Calendar db = new ConnectDB_Calendar();
        private readonly string connectionString = @"Data Source=VO-NHUT-HAO\SQLEXPRESS;Initial Catalog=hris;Persist Security Info=True;User ID=sa;Password=123";


        string font1 = @"D:\Job\hris-winform\HRMngt\Font\DesignerVN-Poppins-Regular.ttf";
        string font2 = @"D:\Job\hris-winform\HRMngt\Font\DesignerVN-Poppins-ExtraBold.ttf";
        List<CalendarModel> listCalendar = new List<CalendarModel>();


        PrivateFontCollection privateFonts = new PrivateFontCollection();
        public Calendar()
        {
            InitializeComponent();

            //privateFonts.AddFontFile(font1);


            panel_view.BorderStyle = BorderStyle.None;

            AddHeader();
            load_Cbo_PhongBan();
            load_Cbo_TrangThai();
            load_Cbo_ThangBatDau();
            load_Cbo_ThangKetThuc();
            cbo_PhongBan.SelectedIndex = -1;
        }
        string[] thang = { "", "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
        void load_Cbo_ThangBatDau()
        {
            cbo_ThangBatDau.Items.AddRange(thang);
            cbo_ThangBatDau.SelectedIndex = 0;
        }

        void load_Cbo_ThangKetThuc()
        {
            cbo_ThangKetThuc.Items.AddRange(thang);
            cbo_ThangKetThuc.SelectedIndex = 0;
        }

        void load_Cbo_PhongBan()
        {
            string query = "SELECT * FROM dbo.department";
            ConnectDB_Calendar db = new ConnectDB_Calendar();
            DataTable dt = db.getDataTable(query);

            // Thêm một hàng trống vào đầu của DataTable
            DataRow emptyRow = dt.NewRow();
            emptyRow["departmentID"] = ""; // Giá trị của cột "departmentID" là rỗng
            dt.Rows.InsertAt(emptyRow, 0);

            cbo_PhongBan.DataSource = dt;
            cbo_PhongBan.DisplayMember = "name";
            cbo_PhongBan.ValueMember = "departmentID";
            cbo_PhongBan.SelectedIndex = -1;
        }

        
        void load_Cbo_TrangThai()
        {
            string[] trangThai = {"", "Consider", "Late", "Attendance logged", "Deleted", "Rejected", "Approved", "Created" };

            cbo_TrangThai.Items.AddRange(trangThai);
            cbo_TrangThai.SelectedIndex = 0;
        }

        void AddHeader()
        {
            Label lblUserIDHeader = new Label();
            lblUserIDHeader.Text = "Nhân viên";
            lblUserIDHeader.AutoSize = true;
            lblUserIDHeader.Location = new Point(0, 0);
            panel_view.Controls.Add(lblUserIDHeader);

            Label lblDateHeader = new Label();
            lblDateHeader.Text = "Ngày";
            lblDateHeader.AutoSize = true;
            lblDateHeader.Location = new Point(200, 0);
            panel_view.Controls.Add(lblDateHeader);

            Label lblWorkTimeHeader = new Label();
            lblWorkTimeHeader.Text = "Thời gian \nlàm việc";
            lblWorkTimeHeader.AutoSize = true;
            lblWorkTimeHeader.Location = new Point(300, 0);
            panel_view.Controls.Add(lblWorkTimeHeader);

            Label lblIn = new Label();
            lblIn.Text = "In";
            lblIn.AutoSize = true;
            lblIn.Location = new Point(400, 0);
            panel_view.Controls.Add(lblIn);

            Label lblOut = new Label();
            lblOut.Text = "Out";
            lblOut.AutoSize = true;
            lblOut.Location = new Point(470, 0);
            panel_view.Controls.Add(lblOut);

            Label lblStatusHeader = new Label();
            lblStatusHeader.Text = "Trạng thái";
            lblStatusHeader.AutoSize = true;
            lblStatusHeader.Location = new Point(520, 0);
            panel_view.Controls.Add(lblStatusHeader);

        }


        void AddControls()
        {
            panel_view.Controls.Clear();
            AddHeader();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.calendar";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int rowIndex = 1;
                int verticalSpacing = 60;


                while (reader.Read())
                {
                    string userID = reader["userID"].ToString();

                    PictureBox pictureBox = new PictureBox();

                    string imageResourceName = db.layAvatar(userID);

                    if (!string.IsNullOrEmpty(imageResourceName))
                    {
                        try
                        {
                            // Lấy hình ảnh từ tài nguyên của ứng dụng và gán cho PictureBox
                            Image img = (Image)Properties.Resources.ResourceManager.GetObject(imageResourceName);

                            if (img != null)
                            {
                                pictureBox.Image = img;
                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox.Size = new Size(20, 20);
                                pictureBox.Location = new Point(0, rowIndex * verticalSpacing);

                                panel_view.Controls.Add(pictureBox);
                                panel_view.Controls.SetChildIndex(pictureBox, 0);
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


                    //if (db.check_Gender(userID)) // True -> nam | False -> nữ
                    //{
                    //    Image img = Properties.Resources.image_38;
                    //    PictureBox pictureBox = new PictureBox();
                    //    pictureBox.Image = img;
                    //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //    pictureBox.Size = new Size(20, 20);
                    //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                    //    panel_view.Controls.Add(pictureBox);
                    //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                    //}
                    //else
                    //{
                    //    Image img = Properties.Resources.image_39;
                    //    PictureBox pictureBox = new PictureBox();
                    //    pictureBox.Image = img;
                    //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //    pictureBox.Size = new Size(20, 20);
                    //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                    //    panel_view.Controls.Add(pictureBox);
                    //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                    //}


                    Label lblNhanVien = new Label();
                    string nhanVien = userID;
                    nhanVien += "\n" + db.layHoTen(userID) + "\n" + db.layPhongBan(userID);
                    lblNhanVien.Text = nhanVien;
                    lblNhanVien.AutoSize = true;
                    lblNhanVien.Location = new Point(40, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblNhanVien);
                    panel_view.Controls.SetChildIndex(lblNhanVien, 0);


                    DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    Label lblDate = new Label();
                    lblDate.Text = date.ToString("dd/MM/yyyy");
                    lblDate.AutoSize = false;
                    lblDate.Location = new Point(200, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblDate);

                    DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                    DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                    Label lblWorkTime = new Label();
                    lblWorkTime.Text = registerCheckIn.ToString("HH:mm") + " - " + registerCheckOut.ToString("HH:mm");
                    lblWorkTime.AutoSize = true;
                    lblWorkTime.Location = new Point(300, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblWorkTime);

                    DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                    DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                    Label lblIn = new Label();
                    lblIn.Text = realCheckIn.ToString("HH:mm");
                    lblIn.AutoSize = true;
                    lblIn.Location = new Point(400, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblIn);

                    Label lblOut = new Label();
                    lblOut.Text = realCheckOut.ToString("HH:mm");
                    lblOut.AutoSize = true;
                    lblOut.Location = new Point(470, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblOut);

                    Label lblStatus = new Label();
                    lblStatus.Text = reader["status"].ToString();
                    lblStatus.AutoSize = true;
                    lblStatus.Location = new Point(510, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblStatus);

                    // Details
                    Button btnDetails = new Button();
                    btnDetails.Size = new Size(15, 15);
                    btnDetails.Image = Properties.Resources.eye_15;
                    btnDetails.ImageAlign = ContentAlignment.MiddleCenter;
                    btnDetails.Location = new Point(650, rowIndex * verticalSpacing);
                    btnDetails.FlatStyle = FlatStyle.Flat;
                    btnDetails.FlatAppearance.BorderSize = 0;
                    btnDetails.Click += (sender, e) => {
                        Detail_Calendar detail = new Detail_Calendar(userID);
                        detail.Show();
                        this.Hide();
                    };
                    panel_view.Controls.Add(btnDetails);

                    // Edit
                    Button btnEdit = new Button();
                    btnEdit.Size = new Size(15, 15);
                    btnEdit.Image = Properties.Resources.edit_15;
                    btnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                    btnEdit.Location = new Point(690, rowIndex * verticalSpacing);
                    btnEdit.FlatStyle = FlatStyle.Flat;
                    btnEdit.FlatAppearance.BorderSize = 0;
                    btnEdit.Click += (sender, e) => {
                        Update_Calendar update_Calendar = new Update_Calendar(userID);
                        update_Calendar.Show();
                        this.Hide();
                    };
                    panel_view.Controls.Add(btnEdit);

                    // Delete
                    Button btnDelete = new Button();
                    btnDelete.Size = new Size(15, 15);
                    btnDelete.Image = Properties.Resources.delete_15;
                    btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
                    btnDelete.Location = new Point(730, rowIndex * verticalSpacing);
                    btnDelete.FlatStyle = FlatStyle.Flat;
                    btnDelete.FlatAppearance.BorderSize = 0;
                    btnDelete.Click += (sender, e) => {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            db.xoaCalendar(userID);
                            MessageBox.Show(string.Format("Bạn đã xoá {0}", db.layHoTen(userID)));
                            AddControls();
                        }
                    };
                    panel_view.Controls.Add(btnDelete);


                    // Duyệt
                    Button btnDuyet = new Button();
                    btnDuyet.Text = "Duyệt";
                    btnDuyet.FlatStyle = FlatStyle.Flat;
                    btnDuyet.ForeColor = Color.Green;
                    btnDuyet.FlatAppearance.BorderSize = 1;
                    btnDuyet.FlatAppearance.BorderColor = Color.Green;
                    btnDuyet.Location = new Point(750, rowIndex * verticalSpacing);
                    btnDuyet.Click += (sender, e) => {
                        if (db.updateWorkDay(userID))
                        {
                            MessageBox.Show(string.Format("Duyệt thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));

                        }
                    };
                    panel_view.Controls.Add(btnDuyet);


                    // Từ chối
                    Button btnTuChoi = new Button();
                    btnTuChoi.Text = "Từ chối";
                    btnTuChoi.FlatStyle = FlatStyle.Flat;
                    btnTuChoi.ForeColor = Color.Red;
                    btnTuChoi.FlatAppearance.BorderSize = 1;
                    btnTuChoi.FlatAppearance.BorderColor = Color.Red;
                    btnTuChoi.Location = new Point(850, rowIndex * verticalSpacing);
                    btnTuChoi.Click += (sender, e) => {
                        if(db.updateWorkDay(userID, true))
                        {
                            MessageBox.Show(string.Format("Từ chối thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));
                        }
                    };
                    panel_view.Controls.Add(btnTuChoi);

                    rowIndex++; 
                }
            }
        }

        void AddControls_TheoDieuKien(int thangBatDau, int thangKetThuc)
        {
            AddHeader();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.calendar";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int rowIndex = 1;
                int verticalSpacing = 60;


                while (reader.Read())
                {
                    DateTime ngay = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    if (ngay.Month >= thangBatDau && ngay.Month <= thangKetThuc)
                    {
                        string userID = reader["userID"].ToString();

                        PictureBox pictureBox = new PictureBox();

                        string imageResourceName = db.layAvatar(userID);

                        if (!string.IsNullOrEmpty(imageResourceName))
                        {
                            try
                            {
                                // Lấy hình ảnh từ tài nguyên của ứng dụng và gán cho PictureBox
                                Image img = (Image)Properties.Resources.ResourceManager.GetObject(imageResourceName);

                                if (img != null)
                                {
                                    pictureBox.Image = img;
                                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox.Size = new Size(20, 20);
                                    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);

                                    panel_view.Controls.Add(pictureBox);
                                    panel_view.Controls.SetChildIndex(pictureBox, 0);
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


                        //if (db.check_Gender(userID)) // True -> nam | False -> nữ
                        //{
                        //    Image img = Properties.Resources.image_38;
                        //    PictureBox pictureBox = new PictureBox();
                        //    pictureBox.Image = img;
                        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    pictureBox.Size = new Size(20, 20);
                        //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                        //    panel_view.Controls.Add(pictureBox);
                        //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                        //}
                        //else
                        //{
                        //    Image img = Properties.Resources.image_39;
                        //    PictureBox pictureBox = new PictureBox();
                        //    pictureBox.Image = img;
                        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    pictureBox.Size = new Size(20, 20);
                        //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                        //    panel_view.Controls.Add(pictureBox);
                        //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                        //}


                        Label lblNhanVien = new Label();
                        string nhanVien = userID;
                        nhanVien += "\n" + db.layHoTen(userID) + "\n" + db.layPhongBan(userID);
                        lblNhanVien.Text = nhanVien;
                        lblNhanVien.AutoSize = true;
                        lblNhanVien.Location = new Point(40, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblNhanVien);
                        panel_view.Controls.SetChildIndex(lblNhanVien, 0);


                        DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                        Label lblDate = new Label();
                        lblDate.Text = date.ToString("dd/MM/yyyy");
                        lblDate.AutoSize = false;
                        lblDate.Location = new Point(200, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblDate);

                        DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                        DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                        Label lblWorkTime = new Label();
                        lblWorkTime.Text = registerCheckIn.ToString("HH:mm") + " - " + registerCheckOut.ToString("HH:mm");
                        lblWorkTime.AutoSize = true;
                        lblWorkTime.Location = new Point(300, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblWorkTime);

                        DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                        DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                        Label lblIn = new Label();
                        lblIn.Text = realCheckIn.ToString("HH:mm");
                        lblIn.AutoSize = true;
                        lblIn.Location = new Point(400, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblIn);

                        Label lblOut = new Label();
                        lblOut.Text = realCheckOut.ToString("HH:mm");
                        lblOut.AutoSize = true;
                        lblOut.Location = new Point(470, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblOut);

                        Label lblStatus = new Label();
                        lblStatus.Text = reader["status"].ToString();
                        lblStatus.AutoSize = true;
                        lblStatus.Location = new Point(510, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblStatus);

                        // Details
                        Button btnDetails = new Button();
                        btnDetails.Size = new Size(15, 15);
                        btnDetails.Image = Properties.Resources.eye_15;
                        btnDetails.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDetails.Location = new Point(650, rowIndex * verticalSpacing);
                        btnDetails.FlatStyle = FlatStyle.Flat;
                        btnDetails.FlatAppearance.BorderSize = 0;
                        btnDetails.Click += (sender, e) =>
                        {
                            Detail_Calendar detail = new Detail_Calendar(userID);
                            detail.Show();
                            this.Hide();
                        };
                        panel_view.Controls.Add(btnDetails);

                        // Edit
                        Button btnEdit = new Button();
                        btnEdit.Size = new Size(15, 15);
                        btnEdit.Image = Properties.Resources.edit_15;
                        btnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                        btnEdit.Location = new Point(690, rowIndex * verticalSpacing);
                        btnEdit.FlatStyle = FlatStyle.Flat;
                        btnEdit.FlatAppearance.BorderSize = 0;
                        btnEdit.Click += (sender, e) =>
                        {
                            Update_Calendar update_Calendar = new Update_Calendar(userID);
                            update_Calendar.Show();
                            this.Hide();
                        };
                        panel_view.Controls.Add(btnEdit);

                        // Delete
                        Button btnDelete = new Button();
                        btnDelete.Size = new Size(15, 15);
                        btnDelete.Image = Properties.Resources.delete_15;
                        btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDelete.Location = new Point(730, rowIndex * verticalSpacing);
                        btnDelete.FlatStyle = FlatStyle.Flat;
                        btnDelete.FlatAppearance.BorderSize = 0;
                        btnDelete.Click += (sender, e) =>
                        {
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                db.xoaCalendar(userID);
                                MessageBox.Show(string.Format("Bạn đã xoá {0}", db.layHoTen(userID)));
                                AddControls();
                            }
                        };
                        panel_view.Controls.Add(btnDelete);


                        // Duyệt
                        Button btnDuyet = new Button();
                        btnDuyet.Text = "Duyệt";
                        btnDuyet.FlatStyle = FlatStyle.Flat;
                        btnDuyet.ForeColor = Color.Green;
                        btnDuyet.FlatAppearance.BorderSize = 1;
                        btnDuyet.FlatAppearance.BorderColor = Color.Green;
                        btnDuyet.Location = new Point(750, rowIndex * verticalSpacing);
                        btnDuyet.Click += (sender, e) =>
                        {
                            if (db.updateWorkDay(userID))
                            {
                                MessageBox.Show(string.Format("Duyệt thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));

                            }
                        };
                        panel_view.Controls.Add(btnDuyet);


                        // Từ chối
                        Button btnTuChoi = new Button();
                        btnTuChoi.Text = "Từ chối";
                        btnTuChoi.FlatStyle = FlatStyle.Flat;
                        btnTuChoi.ForeColor = Color.Red;
                        btnTuChoi.FlatAppearance.BorderSize = 1;
                        btnTuChoi.FlatAppearance.BorderColor = Color.Red;
                        btnTuChoi.Location = new Point(850, rowIndex * verticalSpacing);
                        btnTuChoi.Click += (sender, e) =>
                        {
                            MessageBox.Show(string.Format("Từ chối thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));
                        };
                        panel_view.Controls.Add(btnTuChoi);

                        rowIndex++;
                    }
                }
            }
        }
        void AddControls_TheoDieuKien(int thangBatDau, int thangKetThuc, string phongBan)
        {
            AddHeader();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string result_phongBan = Regex.Replace(phongBan, @"\s+", " ").TrimEnd();
                string query = "SELECT ca.userID, ca.date, ca.register_checkIn, ca.register_checkOut, ca.real_checkIn, ca.real_checkOut, ca.checkIn_location, ca.checkOut_location, ca.status FROM calendar ca LEFT JOIN users ON users.userID = ca.userID LEFT JOIN department ON users.departmentID = department.departmentID WHERE department.departmentID = '" + result_phongBan + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int rowIndex = 1;
                int verticalSpacing = 60;


                while (reader.Read())
                {
                    string userID = reader["userID"].ToString();
                    DateTime ngay = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    if (ngay.Month >= thangBatDau && ngay.Month <= thangKetThuc)
                    {
                        PictureBox pictureBox = new PictureBox();

                        string imageResourceName = db.layAvatar(userID);

                        if (!string.IsNullOrEmpty(imageResourceName))
                        {
                            try
                            {
                                // Lấy hình ảnh từ tài nguyên của ứng dụng và gán cho PictureBox
                                Image img = (Image)Properties.Resources.ResourceManager.GetObject(imageResourceName);

                                if (img != null)
                                {
                                    pictureBox.Image = img;
                                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox.Size = new Size(20, 20);
                                    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);

                                    panel_view.Controls.Add(pictureBox);
                                    panel_view.Controls.SetChildIndex(pictureBox, 0);
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


                        //if (db.check_Gender(userID)) // True -> nam | False -> nữ
                        //{
                        //    Image img = Properties.Resources.image_38;
                        //    PictureBox pictureBox = new PictureBox();
                        //    pictureBox.Image = img;
                        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    pictureBox.Size = new Size(20, 20);
                        //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                        //    panel_view.Controls.Add(pictureBox);
                        //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                        //}
                        //else
                        //{
                        //    Image img = Properties.Resources.image_39;
                        //    PictureBox pictureBox = new PictureBox();
                        //    pictureBox.Image = img;
                        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    pictureBox.Size = new Size(20, 20);
                        //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                        //    panel_view.Controls.Add(pictureBox);
                        //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                        //}


                        Label lblNhanVien = new Label();
                        string nhanVien = userID;
                        nhanVien += "\n" + db.layHoTen(userID) + "\n" + db.layPhongBan(userID);
                        lblNhanVien.Text = nhanVien;
                        lblNhanVien.AutoSize = true;
                        lblNhanVien.Location = new Point(40, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblNhanVien);
                        panel_view.Controls.SetChildIndex(lblNhanVien, 0);


                        DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                        Label lblDate = new Label();
                        lblDate.Text = date.ToString("dd/MM/yyyy");
                        lblDate.AutoSize = false;
                        lblDate.Location = new Point(200, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblDate);

                        DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                        DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                        Label lblWorkTime = new Label();
                        lblWorkTime.Text = registerCheckIn.ToString("HH:mm") + " - " + registerCheckOut.ToString("HH:mm");
                        lblWorkTime.AutoSize = true;
                        lblWorkTime.Location = new Point(300, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblWorkTime);

                        DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                        DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                        Label lblIn = new Label();
                        lblIn.Text = realCheckIn.ToString("HH:mm");
                        lblIn.AutoSize = true;
                        lblIn.Location = new Point(400, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblIn);

                        Label lblOut = new Label();
                        lblOut.Text = realCheckOut.ToString("HH:mm");
                        lblOut.AutoSize = true;
                        lblOut.Location = new Point(470, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblOut);

                        Label lblStatus = new Label();
                        lblStatus.Text = reader["status"].ToString();
                        lblStatus.AutoSize = true;
                        lblStatus.Location = new Point(510, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblStatus);

                        // Details
                        Button btnDetails = new Button();
                        btnDetails.Size = new Size(15, 15);
                        btnDetails.Image = Properties.Resources.eye_15;
                        btnDetails.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDetails.Location = new Point(650, rowIndex * verticalSpacing);
                        btnDetails.FlatStyle = FlatStyle.Flat;
                        btnDetails.FlatAppearance.BorderSize = 0;
                        btnDetails.Click += (sender, e) =>
                        {
                            Detail_Calendar detail = new Detail_Calendar(userID);
                            detail.Show();
                            this.Hide();
                        };
                        panel_view.Controls.Add(btnDetails);

                        // Edit
                        Button btnEdit = new Button();
                        btnEdit.Size = new Size(15, 15);
                        btnEdit.Image = Properties.Resources.edit_15;
                        btnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                        btnEdit.Location = new Point(690, rowIndex * verticalSpacing);
                        btnEdit.FlatStyle = FlatStyle.Flat;
                        btnEdit.FlatAppearance.BorderSize = 0;
                        btnEdit.Click += (sender, e) =>
                        {
                            Update_Calendar update_Calendar = new Update_Calendar(userID);
                            update_Calendar.Show();
                            this.Hide();
                        };
                        panel_view.Controls.Add(btnEdit);

                        // Delete
                        Button btnDelete = new Button();
                        btnDelete.Size = new Size(15, 15);
                        btnDelete.Image = Properties.Resources.delete_15;
                        btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDelete.Location = new Point(730, rowIndex * verticalSpacing);
                        btnDelete.FlatStyle = FlatStyle.Flat;
                        btnDelete.FlatAppearance.BorderSize = 0;
                        btnDelete.Click += (sender, e) =>
                        {
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                db.xoaCalendar(userID);
                                MessageBox.Show(string.Format("Bạn đã xoá {0}", db.layHoTen(userID)));
                                AddControls();
                            }
                        };
                        panel_view.Controls.Add(btnDelete);


                        // Duyệt
                        Button btnDuyet = new Button();
                        btnDuyet.Text = "Duyệt";
                        btnDuyet.FlatStyle = FlatStyle.Flat;
                        btnDuyet.ForeColor = Color.Green;
                        btnDuyet.FlatAppearance.BorderSize = 1;
                        btnDuyet.FlatAppearance.BorderColor = Color.Green;
                        btnDuyet.Location = new Point(750, rowIndex * verticalSpacing);
                        btnDuyet.Click += (sender, e) =>
                        {
                            if (db.updateWorkDay(userID))
                            {
                                MessageBox.Show(string.Format("Duyệt thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));

                            }
                        };
                        panel_view.Controls.Add(btnDuyet);


                        // Từ chối
                        Button btnTuChoi = new Button();
                        btnTuChoi.Text = "Từ chối";
                        btnTuChoi.FlatStyle = FlatStyle.Flat;
                        btnTuChoi.ForeColor = Color.Red;
                        btnTuChoi.FlatAppearance.BorderSize = 1;
                        btnTuChoi.FlatAppearance.BorderColor = Color.Red;
                        btnTuChoi.Location = new Point(850, rowIndex * verticalSpacing);
                        btnTuChoi.Click += (sender, e) =>
                        {
                            MessageBox.Show(string.Format("Từ chối thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));
                        };
                        panel_view.Controls.Add(btnTuChoi);

                        rowIndex++;
                    }
                }
            }
        }
        void AddControls_TheoDieuKien(string phongBan)
        {
            AddHeader();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string result_phongBan = Regex.Replace(phongBan, @"\s+", " ").TrimEnd();
                string query = "SELECT ca.userID, ca.date, ca.register_checkIn, ca.register_checkOut, ca.real_checkIn, ca.real_checkOut, ca.checkIn_location, ca.checkOut_location, ca.status FROM calendar ca LEFT JOIN users ON users.userID = ca.userID LEFT JOIN department ON users.departmentID = department.departmentID WHERE department.departmentID = '" + result_phongBan + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int rowIndex = 1;
                int verticalSpacing = 60;


                while (reader.Read())
                {
                    string userID = reader["userID"].ToString();
                    PictureBox pictureBox = new PictureBox();

                    string imageResourceName = db.layAvatar(userID);

                    if (!string.IsNullOrEmpty(imageResourceName))
                    {
                        try
                        {
                            // Lấy hình ảnh từ tài nguyên của ứng dụng và gán cho PictureBox
                            Image img = (Image)Properties.Resources.ResourceManager.GetObject(imageResourceName);

                            if (img != null)
                            {
                                pictureBox.Image = img;
                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox.Size = new Size(20, 20);
                                pictureBox.Location = new Point(0, rowIndex * verticalSpacing);

                                panel_view.Controls.Add(pictureBox);
                                panel_view.Controls.SetChildIndex(pictureBox, 0);
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


                    //if (db.check_Gender(userID)) // True -> nam | False -> nữ
                    //{
                    //    Image img = Properties.Resources.image_38;
                    //    PictureBox pictureBox = new PictureBox();
                    //    pictureBox.Image = img;
                    //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //    pictureBox.Size = new Size(20, 20);
                    //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                    //    panel_view.Controls.Add(pictureBox);
                    //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                    //}
                    //else
                    //{
                    //    Image img = Properties.Resources.image_39;
                    //    PictureBox pictureBox = new PictureBox();
                    //    pictureBox.Image = img;
                    //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //    pictureBox.Size = new Size(20, 20);
                    //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                    //    panel_view.Controls.Add(pictureBox);
                    //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                    //}


                    Label lblNhanVien = new Label();
                    string nhanVien = userID;
                    nhanVien += "\n" + db.layHoTen(userID) + "\n" + db.layPhongBan(userID);
                    lblNhanVien.Text = nhanVien;
                    lblNhanVien.AutoSize = true;
                    lblNhanVien.Location = new Point(40, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblNhanVien);
                    panel_view.Controls.SetChildIndex(lblNhanVien, 0);


                    DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    Label lblDate = new Label();
                    lblDate.Text = date.ToString("dd/MM/yyyy");
                    lblDate.AutoSize = false;
                    lblDate.Location = new Point(200, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblDate);

                    DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                    DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                    Label lblWorkTime = new Label();
                    lblWorkTime.Text = registerCheckIn.ToString("HH:mm") + " - " + registerCheckOut.ToString("HH:mm");
                    lblWorkTime.AutoSize = true;
                    lblWorkTime.Location = new Point(300, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblWorkTime);

                    DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                    DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                    Label lblIn = new Label();
                    lblIn.Text = realCheckIn.ToString("HH:mm");
                    lblIn.AutoSize = true;
                    lblIn.Location = new Point(400, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblIn);

                    Label lblOut = new Label();
                    lblOut.Text = realCheckOut.ToString("HH:mm");
                    lblOut.AutoSize = true;
                    lblOut.Location = new Point(470, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblOut);

                    Label lblStatus = new Label();
                    lblStatus.Text = reader["status"].ToString();
                    lblStatus.AutoSize = true;
                    lblStatus.Location = new Point(510, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblStatus);

                    // Details
                    Button btnDetails = new Button();
                    btnDetails.Size = new Size(15, 15);
                    btnDetails.Image = Properties.Resources.eye_15;
                    btnDetails.ImageAlign = ContentAlignment.MiddleCenter;
                    btnDetails.Location = new Point(650, rowIndex * verticalSpacing);
                    btnDetails.FlatStyle = FlatStyle.Flat;
                    btnDetails.FlatAppearance.BorderSize = 0;
                    btnDetails.Click += (sender, e) =>
                    {
                        Detail_Calendar detail = new Detail_Calendar(userID);
                        detail.Show();
                        this.Hide();
                    };
                    panel_view.Controls.Add(btnDetails);

                    // Edit
                    Button btnEdit = new Button();
                    btnEdit.Size = new Size(15, 15);
                    btnEdit.Image = Properties.Resources.edit_15;
                    btnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                    btnEdit.Location = new Point(690, rowIndex * verticalSpacing);
                    btnEdit.FlatStyle = FlatStyle.Flat;
                    btnEdit.FlatAppearance.BorderSize = 0;
                    btnEdit.Click += (sender, e) =>
                    {
                        Update_Calendar update_Calendar = new Update_Calendar(userID);
                        update_Calendar.Show();
                        this.Hide();
                    };
                    panel_view.Controls.Add(btnEdit);

                    // Delete
                    Button btnDelete = new Button();
                    btnDelete.Size = new Size(15, 15);
                    btnDelete.Image = Properties.Resources.delete_15;
                    btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
                    btnDelete.Location = new Point(730, rowIndex * verticalSpacing);
                    btnDelete.FlatStyle = FlatStyle.Flat;
                    btnDelete.FlatAppearance.BorderSize = 0;
                    btnDelete.Click += (sender, e) =>
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            db.xoaCalendar(userID);
                            MessageBox.Show(string.Format("Bạn đã xoá {0}", db.layHoTen(userID)));
                            AddControls();
                        }
                    };
                    panel_view.Controls.Add(btnDelete);


                    // Duyệt
                    Button btnDuyet = new Button();
                    btnDuyet.Text = "Duyệt";
                    btnDuyet.FlatStyle = FlatStyle.Flat;
                    btnDuyet.ForeColor = Color.Green;
                    btnDuyet.FlatAppearance.BorderSize = 1;
                    btnDuyet.FlatAppearance.BorderColor = Color.Green;
                    btnDuyet.Location = new Point(750, rowIndex * verticalSpacing);
                    btnDuyet.Click += (sender, e) =>
                    {
                        if (db.updateWorkDay(userID))
                        {
                            MessageBox.Show(string.Format("Duyệt thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));

                        }
                    };
                    panel_view.Controls.Add(btnDuyet);


                    // Từ chối
                    Button btnTuChoi = new Button();
                    btnTuChoi.Text = "Từ chối";
                    btnTuChoi.FlatStyle = FlatStyle.Flat;
                    btnTuChoi.ForeColor = Color.Red;
                    btnTuChoi.FlatAppearance.BorderSize = 1;
                    btnTuChoi.FlatAppearance.BorderColor = Color.Red;
                    btnTuChoi.Location = new Point(850, rowIndex * verticalSpacing);
                    btnTuChoi.Click += (sender, e) =>
                    {
                        MessageBox.Show(string.Format("Từ chối thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));
                    };
                    panel_view.Controls.Add(btnTuChoi);

                    rowIndex++;
                }
            }
        }
        void AddControls_TheoDieuKien(string trangThai, bool kiemTra)
        {
            AddHeader();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string result_trangThai = Regex.Replace(trangThai, @"\s+", " ").TrimEnd();
                string query = "SELECT * FROM dbo.calendar where status = '"+ result_trangThai + "'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int rowIndex = 1;
                int verticalSpacing = 60;
                while (reader.Read())
                {
                    string userID = reader["userID"].ToString();
                    PictureBox pictureBox = new PictureBox();

                    string imageResourceName = db.layAvatar(userID);

                    if (!string.IsNullOrEmpty(imageResourceName))
                    {
                        try
                        {
                            // Lấy hình ảnh từ tài nguyên của ứng dụng và gán cho PictureBox
                            Image img = (Image)Properties.Resources.ResourceManager.GetObject(imageResourceName);

                            if (img != null)
                            {
                                pictureBox.Image = img;
                                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox.Size = new Size(20, 20);
                                pictureBox.Location = new Point(0, rowIndex * verticalSpacing);

                                panel_view.Controls.Add(pictureBox);
                                panel_view.Controls.SetChildIndex(pictureBox, 0);
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


                    //if (db.check_Gender(userID)) // True -> nam | False -> nữ
                    //{
                    //    Image img = Properties.Resources.image_38;
                    //    PictureBox pictureBox = new PictureBox();
                    //    pictureBox.Image = img;
                    //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //    pictureBox.Size = new Size(20, 20);
                    //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                    //    panel_view.Controls.Add(pictureBox);
                    //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                    //}
                    //else
                    //{
                    //    Image img = Properties.Resources.image_39;
                    //    PictureBox pictureBox = new PictureBox();
                    //    pictureBox.Image = img;
                    //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //    pictureBox.Size = new Size(20, 20);
                    //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                    //    panel_view.Controls.Add(pictureBox);
                    //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                    //}


                    Label lblNhanVien = new Label();
                    string nhanVien = userID;
                    nhanVien += "\n" + db.layHoTen(userID) + "\n" + db.layPhongBan(userID);
                    lblNhanVien.Text = nhanVien;
                    lblNhanVien.AutoSize = true;
                    lblNhanVien.Location = new Point(40, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblNhanVien);
                    panel_view.Controls.SetChildIndex(lblNhanVien, 0);


                    DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    Label lblDate = new Label();
                    lblDate.Text = date.ToString("dd/MM/yyyy");
                    lblDate.AutoSize = false;
                    lblDate.Location = new Point(200, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblDate);

                    DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                    DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                    Label lblWorkTime = new Label();
                    lblWorkTime.Text = registerCheckIn.ToString("HH:mm") + " - " + registerCheckOut.ToString("HH:mm");
                    lblWorkTime.AutoSize = true;
                    lblWorkTime.Location = new Point(300, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblWorkTime);

                    DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                    DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                    Label lblIn = new Label();
                    lblIn.Text = realCheckIn.ToString("HH:mm");
                    lblIn.AutoSize = true;
                    lblIn.Location = new Point(400, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblIn);

                    Label lblOut = new Label();
                    lblOut.Text = realCheckOut.ToString("HH:mm");
                    lblOut.AutoSize = true;
                    lblOut.Location = new Point(470, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblOut);

                    Label lblStatus = new Label();
                    lblStatus.Text = reader["status"].ToString();
                    lblStatus.AutoSize = true;
                    lblStatus.Location = new Point(510, rowIndex * verticalSpacing);
                    panel_view.Controls.Add(lblStatus);

                    // Details
                    Button btnDetails = new Button();
                    btnDetails.Size = new Size(15, 15);
                    btnDetails.Image = Properties.Resources.eye_15;
                    btnDetails.ImageAlign = ContentAlignment.MiddleCenter;
                    btnDetails.Location = new Point(650, rowIndex * verticalSpacing);
                    btnDetails.FlatStyle = FlatStyle.Flat;
                    btnDetails.FlatAppearance.BorderSize = 0;
                    btnDetails.Click += (sender, e) =>
                    {
                        Detail_Calendar detail = new Detail_Calendar(userID);
                        detail.Show();
                        this.Hide();
                    };
                    panel_view.Controls.Add(btnDetails);

                    // Edit
                    Button btnEdit = new Button();
                    btnEdit.Size = new Size(15, 15);
                    btnEdit.Image = Properties.Resources.edit_15;
                    btnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                    btnEdit.Location = new Point(690, rowIndex * verticalSpacing);
                    btnEdit.FlatStyle = FlatStyle.Flat;
                    btnEdit.FlatAppearance.BorderSize = 0;
                    btnEdit.Click += (sender, e) =>
                    {
                        Update_Calendar update_Calendar = new Update_Calendar(userID);
                        update_Calendar.Show();
                        this.Hide();
                    };
                    panel_view.Controls.Add(btnEdit);

                    // Delete
                    Button btnDelete = new Button();
                    btnDelete.Size = new Size(15, 15);
                    btnDelete.Image = Properties.Resources.delete_15;
                    btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
                    btnDelete.Location = new Point(730, rowIndex * verticalSpacing);
                    btnDelete.FlatStyle = FlatStyle.Flat;
                    btnDelete.FlatAppearance.BorderSize = 0;
                    btnDelete.Click += (sender, e) =>
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            db.xoaCalendar(userID);
                            MessageBox.Show(string.Format("Bạn đã xoá {0}", db.layHoTen(userID)));
                            AddControls();
                        }
                    };
                    panel_view.Controls.Add(btnDelete);


                    // Duyệt
                    Button btnDuyet = new Button();
                    btnDuyet.Text = "Duyệt";
                    btnDuyet.FlatStyle = FlatStyle.Flat;
                    btnDuyet.ForeColor = Color.Green;
                    btnDuyet.FlatAppearance.BorderSize = 1;
                    btnDuyet.FlatAppearance.BorderColor = Color.Green;
                    btnDuyet.Location = new Point(750, rowIndex * verticalSpacing);
                    btnDuyet.Click += (sender, e) =>
                    {
                        if (db.updateWorkDay(userID))
                        {
                            MessageBox.Show(string.Format("Duyệt thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));

                        }
                    };
                    panel_view.Controls.Add(btnDuyet);


                    // Từ chối
                    Button btnTuChoi = new Button();
                    btnTuChoi.Text = "Từ chối";
                    btnTuChoi.FlatStyle = FlatStyle.Flat;
                    btnTuChoi.ForeColor = Color.Red;
                    btnTuChoi.FlatAppearance.BorderSize = 1;
                    btnTuChoi.FlatAppearance.BorderColor = Color.Red;
                    btnTuChoi.Location = new Point(850, rowIndex * verticalSpacing);
                    btnTuChoi.Click += (sender, e) =>
                    {
                        MessageBox.Show(string.Format("Từ chối thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));
                    };
                    panel_view.Controls.Add(btnTuChoi);

                    rowIndex++;
                }
            }
        }
        void AddControls_TheoDieuKien(int thangBatDau, int thangKetThuc, string trangThai, bool kiemTra)
        {
            AddHeader();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.calendar";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int rowIndex = 1;
                int verticalSpacing = 60;


                while (reader.Read())
                {
                    string userID = reader["userID"].ToString();
                    DateTime ngay = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    string trangThai_data = reader["status"].ToString(); ;
                    string result_trangThai = Regex.Replace(trangThai_data, @"\s+", " ").TrimEnd();
                    if (ngay.Month >= thangBatDau && ngay.Month <= thangKetThuc && trangThai.Equals(result_trangThai))
                    {
                        PictureBox pictureBox = new PictureBox();

                        string imageResourceName = db.layAvatar(userID);

                        if (!string.IsNullOrEmpty(imageResourceName))
                        {
                            try
                            {
                                // Lấy hình ảnh từ tài nguyên của ứng dụng và gán cho PictureBox
                                Image img = (Image)Properties.Resources.ResourceManager.GetObject(imageResourceName);

                                if (img != null)
                                {
                                    pictureBox.Image = img;
                                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox.Size = new Size(20, 20);
                                    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);

                                    panel_view.Controls.Add(pictureBox);
                                    panel_view.Controls.SetChildIndex(pictureBox, 0);
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


                        //if (db.check_Gender(userID)) // True -> nam | False -> nữ
                        //{
                        //    Image img = Properties.Resources.image_38;
                        //    PictureBox pictureBox = new PictureBox();
                        //    pictureBox.Image = img;
                        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    pictureBox.Size = new Size(20, 20);
                        //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                        //    panel_view.Controls.Add(pictureBox);
                        //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                        //}
                        //else
                        //{
                        //    Image img = Properties.Resources.image_39;
                        //    PictureBox pictureBox = new PictureBox();
                        //    pictureBox.Image = img;
                        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    pictureBox.Size = new Size(20, 20);
                        //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                        //    panel_view.Controls.Add(pictureBox);
                        //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                        //}


                        Label lblNhanVien = new Label();
                        string nhanVien = userID;
                        nhanVien += "\n" + db.layHoTen(userID) + "\n" + db.layPhongBan(userID);
                        lblNhanVien.Text = nhanVien;
                        lblNhanVien.AutoSize = true;
                        lblNhanVien.Location = new Point(40, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblNhanVien);
                        panel_view.Controls.SetChildIndex(lblNhanVien, 0);


                        DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                        Label lblDate = new Label();
                        lblDate.Text = date.ToString("dd/MM/yyyy");
                        lblDate.AutoSize = false;
                        lblDate.Location = new Point(200, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblDate);

                        DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                        DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                        Label lblWorkTime = new Label();
                        lblWorkTime.Text = registerCheckIn.ToString("HH:mm") + " - " + registerCheckOut.ToString("HH:mm");
                        lblWorkTime.AutoSize = true;
                        lblWorkTime.Location = new Point(300, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblWorkTime);

                        DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                        DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                        Label lblIn = new Label();
                        lblIn.Text = realCheckIn.ToString("HH:mm");
                        lblIn.AutoSize = true;
                        lblIn.Location = new Point(400, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblIn);

                        Label lblOut = new Label();
                        lblOut.Text = realCheckOut.ToString("HH:mm");
                        lblOut.AutoSize = true;
                        lblOut.Location = new Point(470, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblOut);

                        Label lblStatus = new Label();
                        lblStatus.Text = reader["status"].ToString();
                        lblStatus.AutoSize = true;
                        lblStatus.Location = new Point(510, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblStatus);

                        // Details
                        Button btnDetails = new Button();
                        btnDetails.Size = new Size(15, 15);
                        btnDetails.Image = Properties.Resources.eye_15;
                        btnDetails.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDetails.Location = new Point(650, rowIndex * verticalSpacing);
                        btnDetails.FlatStyle = FlatStyle.Flat;
                        btnDetails.FlatAppearance.BorderSize = 0;
                        btnDetails.Click += (sender, e) =>
                        {
                            Detail_Calendar detail = new Detail_Calendar(userID);
                            detail.Show();
                            this.Hide();
                        };
                        panel_view.Controls.Add(btnDetails);

                        // Edit
                        Button btnEdit = new Button();
                        btnEdit.Size = new Size(15, 15);
                        btnEdit.Image = Properties.Resources.edit_15;
                        btnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                        btnEdit.Location = new Point(690, rowIndex * verticalSpacing);
                        btnEdit.FlatStyle = FlatStyle.Flat;
                        btnEdit.FlatAppearance.BorderSize = 0;
                        btnEdit.Click += (sender, e) =>
                        {
                            Update_Calendar update_Calendar = new Update_Calendar(userID);
                            update_Calendar.Show();
                            this.Hide();
                        };
                        panel_view.Controls.Add(btnEdit);

                        // Delete
                        Button btnDelete = new Button();
                        btnDelete.Size = new Size(15, 15);
                        btnDelete.Image = Properties.Resources.delete_15;
                        btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDelete.Location = new Point(730, rowIndex * verticalSpacing);
                        btnDelete.FlatStyle = FlatStyle.Flat;
                        btnDelete.FlatAppearance.BorderSize = 0;
                        btnDelete.Click += (sender, e) =>
                        {
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                db.xoaCalendar(userID);
                                MessageBox.Show(string.Format("Bạn đã xoá {0}", db.layHoTen(userID)));
                                AddControls();
                            }
                        };
                        panel_view.Controls.Add(btnDelete);


                        // Duyệt
                        Button btnDuyet = new Button();
                        btnDuyet.Text = "Duyệt";
                        btnDuyet.FlatStyle = FlatStyle.Flat;
                        btnDuyet.ForeColor = Color.Green;
                        btnDuyet.FlatAppearance.BorderSize = 1;
                        btnDuyet.FlatAppearance.BorderColor = Color.Green;
                        btnDuyet.Location = new Point(750, rowIndex * verticalSpacing);
                        btnDuyet.Click += (sender, e) =>
                        {
                            if (db.updateWorkDay(userID))
                            {
                                MessageBox.Show(string.Format("Duyệt thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));

                            }
                        };
                        panel_view.Controls.Add(btnDuyet);


                        // Từ chối
                        Button btnTuChoi = new Button();
                        btnTuChoi.Text = "Từ chối";
                        btnTuChoi.FlatStyle = FlatStyle.Flat;
                        btnTuChoi.ForeColor = Color.Red;
                        btnTuChoi.FlatAppearance.BorderSize = 1;
                        btnTuChoi.FlatAppearance.BorderColor = Color.Red;
                        btnTuChoi.Location = new Point(850, rowIndex * verticalSpacing);
                        btnTuChoi.Click += (sender, e) =>
                        {
                            MessageBox.Show(string.Format("Từ chối thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));
                        };
                        panel_view.Controls.Add(btnTuChoi);

                        rowIndex++;
                    }
                }
            }
        }
        void AddControls_TheoDieuKien(int thangBatDau, int thangKetThuc, string phongBan, string trangThai)
        {
            AddHeader();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM dbo.calendar";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int rowIndex = 1;
                int verticalSpacing = 60;


                while (reader.Read())
                {
                    string userID = reader["userID"].ToString();
                    DateTime ngay = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                    string phongBan_data = db.layPhongBan_ID(userID);
                    string result_phongBan = Regex.Replace(phongBan_data, @"\s+", " ").TrimEnd();
                    string trangThai_data = reader["status"].ToString(); ;
                    string result_trangThai = Regex.Replace(trangThai_data, @"\s+", " ").TrimEnd();
                    if (ngay.Month >= thangBatDau && ngay.Month <= thangKetThuc && phongBan.Equals(result_phongBan) && trangThai.Equals(result_trangThai))
                    {
                        PictureBox pictureBox = new PictureBox();

                        string imageResourceName = db.layAvatar(userID);

                        if (!string.IsNullOrEmpty(imageResourceName))
                        {
                            try
                            {
                                // Lấy hình ảnh từ tài nguyên của ứng dụng và gán cho PictureBox
                                Image img = (Image)Properties.Resources.ResourceManager.GetObject(imageResourceName);

                                if (img != null)
                                {
                                    pictureBox.Image = img;
                                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox.Size = new Size(20, 20);
                                    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);

                                    panel_view.Controls.Add(pictureBox);
                                    panel_view.Controls.SetChildIndex(pictureBox, 0);
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


                        //if (db.check_Gender(userID)) // True -> nam | False -> nữ
                        //{
                        //    Image img = Properties.Resources.image_38;
                        //    PictureBox pictureBox = new PictureBox();
                        //    pictureBox.Image = img;
                        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    pictureBox.Size = new Size(20, 20);
                        //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                        //    panel_view.Controls.Add(pictureBox);
                        //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                        //}
                        //else
                        //{
                        //    Image img = Properties.Resources.image_39;
                        //    PictureBox pictureBox = new PictureBox();
                        //    pictureBox.Image = img;
                        //    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        //    pictureBox.Size = new Size(20, 20);
                        //    pictureBox.Location = new Point(0, rowIndex * verticalSpacing);
                        //    panel_view.Controls.Add(pictureBox);
                        //    panel_view.Controls.SetChildIndex(pictureBox, 0);
                        //}


                        Label lblNhanVien = new Label();
                        string nhanVien = userID;
                        nhanVien += "\n" + db.layHoTen(userID) + "\n" + db.layPhongBan(userID);
                        lblNhanVien.Text = nhanVien;
                        lblNhanVien.AutoSize = true;
                        lblNhanVien.Location = new Point(40, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblNhanVien);
                        panel_view.Controls.SetChildIndex(lblNhanVien, 0);


                        DateTime date = reader["date"] != DBNull.Value ? (DateTime)reader["date"] : DateTime.MinValue;
                        Label lblDate = new Label();
                        lblDate.Text = date.ToString("dd/MM/yyyy");
                        lblDate.AutoSize = false;
                        lblDate.Location = new Point(200, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblDate);

                        DateTime registerCheckIn = reader["register_checkIn"] != DBNull.Value ? (DateTime)reader["register_checkIn"] : DateTime.MinValue;
                        DateTime registerCheckOut = reader["register_checkOut"] != DBNull.Value ? (DateTime)reader["register_checkOut"] : DateTime.MinValue;
                        Label lblWorkTime = new Label();
                        lblWorkTime.Text = registerCheckIn.ToString("HH:mm") + " - " + registerCheckOut.ToString("HH:mm");
                        lblWorkTime.AutoSize = true;
                        lblWorkTime.Location = new Point(300, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblWorkTime);

                        DateTime realCheckIn = reader["real_checkIn"] != DBNull.Value ? (DateTime)reader["real_checkIn"] : DateTime.MinValue;
                        DateTime realCheckOut = reader["real_checkOut"] != DBNull.Value ? (DateTime)reader["real_checkOut"] : DateTime.MinValue;
                        Label lblIn = new Label();
                        lblIn.Text = realCheckIn.ToString("HH:mm");
                        lblIn.AutoSize = true;
                        lblIn.Location = new Point(400, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblIn);

                        Label lblOut = new Label();
                        lblOut.Text = realCheckOut.ToString("HH:mm");
                        lblOut.AutoSize = true;
                        lblOut.Location = new Point(470, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblOut);

                        Label lblStatus = new Label();
                        lblStatus.Text = reader["status"].ToString();
                        lblStatus.AutoSize = true;
                        lblStatus.Location = new Point(510, rowIndex * verticalSpacing);
                        panel_view.Controls.Add(lblStatus);

                        // Details
                        Button btnDetails = new Button();
                        btnDetails.Size = new Size(15, 15);
                        btnDetails.Image = Properties.Resources.eye_15;
                        btnDetails.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDetails.Location = new Point(650, rowIndex * verticalSpacing);
                        btnDetails.FlatStyle = FlatStyle.Flat;
                        btnDetails.FlatAppearance.BorderSize = 0;
                        btnDetails.Click += (sender, e) =>
                        {
                            Detail_Calendar detail = new Detail_Calendar(userID);
                            detail.Show();
                            this.Hide();
                        };
                        panel_view.Controls.Add(btnDetails);

                        // Edit
                        Button btnEdit = new Button();
                        btnEdit.Size = new Size(15, 15);
                        btnEdit.Image = Properties.Resources.edit_15;
                        btnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                        btnEdit.Location = new Point(690, rowIndex * verticalSpacing);
                        btnEdit.FlatStyle = FlatStyle.Flat;
                        btnEdit.FlatAppearance.BorderSize = 0;
                        btnEdit.Click += (sender, e) =>
                        {
                            Update_Calendar update_Calendar = new Update_Calendar(userID);
                            update_Calendar.Show();
                            this.Hide();
                        };
                        panel_view.Controls.Add(btnEdit);

                        // Delete
                        Button btnDelete = new Button();
                        btnDelete.Size = new Size(15, 15);
                        btnDelete.Image = Properties.Resources.delete_15;
                        btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
                        btnDelete.Location = new Point(730, rowIndex * verticalSpacing);
                        btnDelete.FlatStyle = FlatStyle.Flat;
                        btnDelete.FlatAppearance.BorderSize = 0;
                        btnDelete.Click += (sender, e) =>
                        {
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                db.xoaCalendar(userID);
                                MessageBox.Show(string.Format("Bạn đã xoá {0}", db.layHoTen(userID)));
                                AddControls();
                            }
                        };
                        panel_view.Controls.Add(btnDelete);


                        // Duyệt
                        Button btnDuyet = new Button();
                        btnDuyet.Text = "Duyệt";
                        btnDuyet.FlatStyle = FlatStyle.Flat;
                        btnDuyet.ForeColor = Color.Green;
                        btnDuyet.FlatAppearance.BorderSize = 1;
                        btnDuyet.FlatAppearance.BorderColor = Color.Green;
                        btnDuyet.Location = new Point(750, rowIndex * verticalSpacing);
                        btnDuyet.Click += (sender, e) =>
                        {
                            if (db.updateWorkDay(userID))
                            {
                                MessageBox.Show(string.Format("Duyệt thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));

                            }
                        };
                        panel_view.Controls.Add(btnDuyet);


                        // Từ chối
                        Button btnTuChoi = new Button();
                        btnTuChoi.Text = "Từ chối";
                        btnTuChoi.FlatStyle = FlatStyle.Flat;
                        btnTuChoi.ForeColor = Color.Red;
                        btnTuChoi.FlatAppearance.BorderSize = 1;
                        btnTuChoi.FlatAppearance.BorderColor = Color.Red;
                        btnTuChoi.Location = new Point(850, rowIndex * verticalSpacing);
                        btnTuChoi.Click += (sender, e) =>
                        {
                            MessageBox.Show(string.Format("Từ chối thành công\nWorkDay = {0}\nReal WorkDay = {1}", db.layWorkDay(userID), db.layRealWorkDay(userID)));
                        };
                        panel_view.Controls.Add(btnTuChoi);

                        rowIndex++;
                    }
                }
            }
        }
        private void btn_Tao_Click(object sender, EventArgs e)
        {
            Insert_Calendar f = new Insert_Calendar();
            f.Show();
            this.Hide();
        }

        private void cbo_ThangBatDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thangBatDau = cbo_ThangBatDau.SelectedIndex;
            int thangKetThuc = cbo_ThangKetThuc.SelectedIndex;
            int phongBan = cbo_PhongBan.SelectedIndex;
            int trangThai = cbo_TrangThai.SelectedIndex;

            panel_view.Controls.Clear();

            if (thangBatDau < 0 && thangKetThuc < 0 && phongBan < 1 && trangThai <= 0)
            {
                AddControls();
            }
            else if(thangBatDau == 0 && phongBan <= 0 && trangThai <= 0)
            {
                if(thangKetThuc == 0)
                {
                    AddControls();
                }
                else
                {

                    AddControls_TheoDieuKien(1, thangKetThuc);
                }
            }
            else if (thangBatDau > 0 && thangKetThuc <= 0 && phongBan <= 0 && trangThai <= 0)
            {
                AddControls_TheoDieuKien(thangBatDau, 12);
            }
            else if (thangBatDau > 0 && thangKetThuc > 0 && phongBan <= 0 && trangThai <= 0)
            {
                AddControls_TheoDieuKien(thangBatDau, thangKetThuc);
            }
            else if(thangBatDau < 1 && thangKetThuc < 1 && phongBan >= 0 && trangThai <= 0)
            {
                string giaTri_PhongBan = cbo_PhongBan.SelectedValue.ToString();

                AddControls_TheoDieuKien(giaTri_PhongBan);
            }
            else if (thangBatDau >= 1 && thangKetThuc < 1 && phongBan >= 0 && trangThai <= 0)
            {
                string giaTri_PhongBan = cbo_PhongBan.SelectedValue.ToString();

                AddControls_TheoDieuKien(thangBatDau , 12, giaTri_PhongBan);
            }
            else if (thangBatDau >= 1 && thangKetThuc >= 1 && phongBan >= 0 && trangThai <= 0)
            {
                string giaTri_PhongBan = cbo_PhongBan.SelectedValue.ToString();

                AddControls_TheoDieuKien(thangBatDau, thangKetThuc, giaTri_PhongBan);
            }
            else if (thangBatDau >= 1 && thangKetThuc >= 1 && phongBan >= 0 && trangThai >= 1)
            {
                string giaTri_PhongBan = cbo_PhongBan.SelectedValue.ToString();
                string giaTri_TrangThai = cbo_TrangThai.SelectedItem.ToString();
                AddControls_TheoDieuKien(thangBatDau, thangKetThuc, giaTri_PhongBan, giaTri_TrangThai);
            }
            else if (thangBatDau < 1 && thangKetThuc < 1 && phongBan < 1 && trangThai >= 1)
            {
                string giaTri_TrangThai = cbo_TrangThai.SelectedItem.ToString();

                AddControls_TheoDieuKien(giaTri_TrangThai, true);
            }
            else if(thangBatDau >= 1 && thangKetThuc < 1 && phongBan < 1 && trangThai >= 1)
            {
                string giaTri_TrangThai = cbo_TrangThai.SelectedItem.ToString();
                AddControls_TheoDieuKien(thangBatDau, 12, giaTri_TrangThai, true);
            }
            else if (thangBatDau >= 1 && thangKetThuc >= 1 && phongBan < 1 && trangThai >= 1)
            {
                string giaTri_TrangThai = cbo_TrangThai.SelectedItem.ToString();
                AddControls_TheoDieuKien(thangBatDau, thangKetThuc, giaTri_TrangThai, true);
            }
            else if (thangBatDau >= 1 && thangKetThuc < 1 && phongBan >= 0 && trangThai >= 0)
            {
                string giaTri_PhongBan = cbo_PhongBan.SelectedValue.ToString();
                string giaTri_TrangThai = cbo_TrangThai.SelectedItem.ToString();
                AddControls_TheoDieuKien(thangBatDau, 12, giaTri_PhongBan, giaTri_TrangThai);
            }
        }
    }
}
