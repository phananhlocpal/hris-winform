
namespace HRMngt.View
{
    partial class Insert_Calendar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Detail = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dTP_Date = new System.Windows.Forms.DateTimePicker();
            this.dTP_Out = new System.Windows.Forms.DateTimePicker();
            this.dTP_In = new System.Windows.Forms.DateTimePicker();
            this.dTP_TimeOut = new System.Windows.Forms.DateTimePicker();
            this.dTP_TimeIn = new System.Windows.Forms.DateTimePicker();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.txt_CheckOut = new System.Windows.Forms.TextBox();
            this.txt_CheckIn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_TrangThai = new System.Windows.Forms.ComboBox();
            this.cbo_ID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Detail)).BeginInit();
            this.panel_Detail.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Detail
            // 
            this.panel_Detail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Detail.Controls.Add(this.cbo_TrangThai);
            this.panel_Detail.Controls.Add(this.label3);
            this.panel_Detail.Controls.Add(this.label2);
            this.panel_Detail.Controls.Add(this.dTP_Date);
            this.panel_Detail.Controls.Add(this.dTP_Out);
            this.panel_Detail.Controls.Add(this.dTP_In);
            this.panel_Detail.Controls.Add(this.cbo_ID);
            this.panel_Detail.Controls.Add(this.dTP_TimeOut);
            this.panel_Detail.Controls.Add(this.dTP_TimeIn);
            this.panel_Detail.Controls.Add(this.btn_Back);
            this.panel_Detail.Controls.Add(this.btn_Them);
            this.panel_Detail.Controls.Add(this.txt_CheckOut);
            this.panel_Detail.Controls.Add(this.txt_CheckIn);
            this.panel_Detail.Controls.Add(this.label5);
            this.panel_Detail.Controls.Add(this.label12);
            this.panel_Detail.Controls.Add(this.label10);
            this.panel_Detail.Controls.Add(this.label8);
            this.panel_Detail.Controls.Add(this.label4);
            this.panel_Detail.Controls.Add(this.label1);
            this.panel_Detail.Controls.Add(this.lbl_Name);
            this.panel_Detail.Location = new System.Drawing.Point(3, 3);
            this.panel_Detail.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Detail.Name = "panel_Detail";
            this.panel_Detail.Size = new System.Drawing.Size(378, 494);
            this.panel_Detail.StateNormal.Color1 = System.Drawing.Color.White;
            this.panel_Detail.TabIndex = 4;
            // 
            // dTP_Date
            // 
            this.dTP_Date.Location = new System.Drawing.Point(156, 99);
            this.dTP_Date.Name = "dTP_Date";
            this.dTP_Date.Size = new System.Drawing.Size(173, 22);
            this.dTP_Date.TabIndex = 34;
            // 
            // dTP_Out
            // 
            this.dTP_Out.Location = new System.Drawing.Point(156, 211);
            this.dTP_Out.Name = "dTP_Out";
            this.dTP_Out.Size = new System.Drawing.Size(173, 22);
            this.dTP_Out.TabIndex = 33;
            // 
            // dTP_In
            // 
            this.dTP_In.Location = new System.Drawing.Point(156, 171);
            this.dTP_In.Name = "dTP_In";
            this.dTP_In.Size = new System.Drawing.Size(173, 22);
            this.dTP_In.TabIndex = 32;
            // 
            // dTP_TimeOut
            // 
            this.dTP_TimeOut.Location = new System.Drawing.Point(242, 131);
            this.dTP_TimeOut.Name = "dTP_TimeOut";
            this.dTP_TimeOut.Size = new System.Drawing.Size(87, 22);
            this.dTP_TimeOut.TabIndex = 29;
            // 
            // dTP_TimeIn
            // 
            this.dTP_TimeIn.Location = new System.Drawing.Point(156, 131);
            this.dTP_TimeIn.Name = "dTP_TimeIn";
            this.dTP_TimeIn.Size = new System.Drawing.Size(80, 22);
            this.dTP_TimeIn.TabIndex = 28;
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(226, 412);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 36);
            this.btn_Back.TabIndex = 27;
            this.btn_Back.Text = "Quay lại";
            this.btn_Back.UseVisualStyleBackColor = true;
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(71, 412);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(79, 36);
            this.btn_Them.TabIndex = 26;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // txt_CheckOut
            // 
            this.txt_CheckOut.Location = new System.Drawing.Point(156, 274);
            this.txt_CheckOut.Name = "txt_CheckOut";
            this.txt_CheckOut.Size = new System.Drawing.Size(173, 22);
            this.txt_CheckOut.TabIndex = 23;
            // 
            // txt_CheckIn
            // 
            this.txt_CheckIn.Location = new System.Drawing.Point(156, 239);
            this.txt_CheckIn.Name = "txt_CheckIn";
            this.txt_CheckIn.Size = new System.Drawing.Size(173, 22);
            this.txt_CheckIn.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(11, 277);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Check out location:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(11, 242);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 17);
            this.label12.TabIndex = 14;
            this.label12.Text = "Check in location:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(10, 206);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Out:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(11, 171);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "In:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(11, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thời gian làm việc:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(10, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date: ";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.BackColor = System.Drawing.Color.White;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(84, 89);
            this.lbl_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(0, 17);
            this.lbl_Name.TabIndex = 1;
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "User ID: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(11, 315);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 36;
            this.label3.Text = "Trạng thái:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbo_TrangThai
            // 
            this.cbo_TrangThai.FormattingEnabled = true;
            this.cbo_TrangThai.Location = new System.Drawing.Point(156, 312);
            this.cbo_TrangThai.Name = "cbo_TrangThai";
            this.cbo_TrangThai.Size = new System.Drawing.Size(173, 24);
            this.cbo_TrangThai.TabIndex = 37;
            // 
            // cbo_ID
            // 
            this.cbo_ID.FormattingEnabled = true;
            this.cbo_ID.Location = new System.Drawing.Point(156, 60);
            this.cbo_ID.Name = "cbo_ID";
            this.cbo_ID.Size = new System.Drawing.Size(173, 24);
            this.cbo_ID.TabIndex = 31;
            // 
            // Insert_Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 500);
            this.Controls.Add(this.panel_Detail);
            this.Name = "Insert_Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert_Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.panel_Detail)).EndInit();
            this.panel_Detail.ResumeLayout(false);
            this.panel_Detail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel panel_Detail;
        private System.Windows.Forms.DateTimePicker dTP_Date;
        private System.Windows.Forms.DateTimePicker dTP_Out;
        private System.Windows.Forms.DateTimePicker dTP_In;
        private System.Windows.Forms.DateTimePicker dTP_TimeOut;
        private System.Windows.Forms.DateTimePicker dTP_TimeIn;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.TextBox txt_CheckOut;
        private System.Windows.Forms.TextBox txt_CheckIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.ComboBox cbo_TrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_ID;
    }
}