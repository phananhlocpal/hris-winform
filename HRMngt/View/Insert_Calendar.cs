using HRMngt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMngt.View
{
    public partial class Insert_Calendar : Form
    {
        ConnectDB_Calendar db = new ConnectDB_Calendar();
        private readonly string connectionString = @"Data Source=VO-NHUT-HAO\SQLEXPRESS;Initial Catalog=hris;User ID=sa;Password=123";
        public Insert_Calendar()
        {
            InitializeComponent();

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

            load_Cbo_Id();
            load_Cbo_TrangThai();
        }
        void load_Cbo_Id()
        {
            string query = @"SELECT * FROM dbo.users";
            DataTable dt = db.getDataTable(query);

            cbo_ID.DataSource = dt;
            cbo_ID.DisplayMember = "userID";
            cbo_ID.ValueMember = "userID";

        }
        void load_Cbo_TrangThai()
        {
            string[] trangThai = { "Consider", "Late", "Attendance logged", "Deleted", "Rejected", "Approved", "Created" };

            cbo_TrangThai.Items.AddRange(trangThai);
            cbo_TrangThai.SelectedIndex = 0;
        }
        void xuLy()
        {
            if (db.insertCalendar(cbo_ID.SelectedValue.ToString(), dTP_Date.Value, dTP_TimeIn.Value, dTP_TimeOut.Value, dTP_In.Value, dTP_Out.Value, txt_CheckIn.Text, txt_CheckOut.Text, cbo_TrangThai.SelectedItem.ToString()))
            {
                MessageBox.Show("Thêm Thành Công");
                Calendar f = new Calendar();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thêm Không Thành Công");
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            xuLy();
        }
    }
}
