
namespace HRMngt.View
{
    partial class Update_Calendar
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
            this.dTP_TimeOut = new System.Windows.Forms.DateTimePicker();
            this.dTP_TimeIn = new System.Windows.Forms.DateTimePicker();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.txt_CheckOut = new System.Windows.Forms.TextBox();
            this.txt_CheckIn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_TrangThai = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.pic_ava = new System.Windows.Forms.PictureBox();
            this.cbo_TrangThai = new System.Windows.Forms.ComboBox();
            this.dTP_Out = new System.Windows.Forms.DateTimePicker();
            this.dTP_In = new System.Windows.Forms.DateTimePicker();
            this.dTP_Date = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Detail)).BeginInit();
            this.panel_Detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ava)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Detail
            // 
            this.panel_Detail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Detail.Controls.Add(this.dTP_Date);
            this.panel_Detail.Controls.Add(this.dTP_Out);
            this.panel_Detail.Controls.Add(this.dTP_In);
            this.panel_Detail.Controls.Add(this.cbo_TrangThai);
            this.panel_Detail.Controls.Add(this.pic_ava);
            this.panel_Detail.Controls.Add(this.dTP_TimeOut);
            this.panel_Detail.Controls.Add(this.dTP_TimeIn);
            this.panel_Detail.Controls.Add(this.btn_Back);
            this.panel_Detail.Controls.Add(this.btn_Update);
            this.panel_Detail.Controls.Add(this.txt_CheckOut);
            this.panel_Detail.Controls.Add(this.txt_CheckIn);
            this.panel_Detail.Controls.Add(this.label5);
            this.panel_Detail.Controls.Add(this.label12);
            this.panel_Detail.Controls.Add(this.label10);
            this.panel_Detail.Controls.Add(this.label8);
            this.panel_Detail.Controls.Add(this.label4);
            this.panel_Detail.Controls.Add(this.lbl_TrangThai);
            this.panel_Detail.Controls.Add(this.label1);
            this.panel_Detail.Controls.Add(this.lbl_ID);
            this.panel_Detail.Controls.Add(this.lbl_Name);
            this.panel_Detail.Location = new System.Drawing.Point(-1, 1);
            this.panel_Detail.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Detail.Name = "panel_Detail";
            this.panel_Detail.Size = new System.Drawing.Size(378, 494);
            this.panel_Detail.StateNormal.Color1 = System.Drawing.Color.White;
            this.panel_Detail.TabIndex = 3;
            // 
            // dTP_TimeOut
            // 
            this.dTP_TimeOut.Location = new System.Drawing.Point(242, 216);
            this.dTP_TimeOut.Name = "dTP_TimeOut";
            this.dTP_TimeOut.Size = new System.Drawing.Size(87, 22);
            this.dTP_TimeOut.TabIndex = 29;
            // 
            // dTP_TimeIn
            // 
            this.dTP_TimeIn.Location = new System.Drawing.Point(156, 216);
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
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(71, 412);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(79, 36);
            this.btn_Update.TabIndex = 26;
            this.btn_Update.Text = "Cập nhật";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // txt_CheckOut
            // 
            this.txt_CheckOut.Location = new System.Drawing.Point(156, 359);
            this.txt_CheckOut.Name = "txt_CheckOut";
            this.txt_CheckOut.Size = new System.Drawing.Size(173, 22);
            this.txt_CheckOut.TabIndex = 23;
            // 
            // txt_CheckIn
            // 
            this.txt_CheckIn.Location = new System.Drawing.Point(156, 324);
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
            this.label5.Location = new System.Drawing.Point(11, 362);
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
            this.label12.Location = new System.Drawing.Point(11, 327);
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
            this.label10.Location = new System.Drawing.Point(10, 291);
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
            this.label8.Location = new System.Drawing.Point(11, 256);
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
            this.label4.Location = new System.Drawing.Point(11, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thời gian làm việc:";
            // 
            // lbl_TrangThai
            // 
            this.lbl_TrangThai.AutoSize = true;
            this.lbl_TrangThai.BackColor = System.Drawing.Color.White;
            this.lbl_TrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TrangThai.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lbl_TrangThai.Location = new System.Drawing.Point(71, 143);
            this.lbl_TrangThai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TrangThai.Name = "lbl_TrangThai";
            this.lbl_TrangThai.Size = new System.Drawing.Size(17, 17);
            this.lbl_TrangThai.TabIndex = 5;
            this.lbl_TrangThai.Text = "• ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(10, 189);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date: ";
            // 
            // lbl_ID
            // 
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.lbl_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_ID.Location = new System.Drawing.Point(67, 110);
            this.lbl_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Padding = new System.Windows.Forms.Padding(6);
            this.lbl_ID.Size = new System.Drawing.Size(70, 29);
            this.lbl_ID.TabIndex = 2;
            this.lbl_ID.Text = "Mã NV: ";
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // pic_ava
            // 
            this.pic_ava.Location = new System.Drawing.Point(93, 11);
            this.pic_ava.Name = "pic_ava";
            this.pic_ava.Size = new System.Drawing.Size(66, 68);
            this.pic_ava.TabIndex = 30;
            this.pic_ava.TabStop = false;
            // 
            // cbo_TrangThai
            // 
            this.cbo_TrangThai.FormattingEnabled = true;
            this.cbo_TrangThai.Location = new System.Drawing.Point(93, 143);
            this.cbo_TrangThai.Name = "cbo_TrangThai";
            this.cbo_TrangThai.Size = new System.Drawing.Size(173, 24);
            this.cbo_TrangThai.TabIndex = 31;
            // 
            // dTP_Out
            // 
            this.dTP_Out.Location = new System.Drawing.Point(156, 296);
            this.dTP_Out.Name = "dTP_Out";
            this.dTP_Out.Size = new System.Drawing.Size(173, 22);
            this.dTP_Out.TabIndex = 33;
            // 
            // dTP_In
            // 
            this.dTP_In.Location = new System.Drawing.Point(156, 256);
            this.dTP_In.Name = "dTP_In";
            this.dTP_In.Size = new System.Drawing.Size(173, 22);
            this.dTP_In.TabIndex = 32;
            // 
            // dTP_Date
            // 
            this.dTP_Date.Location = new System.Drawing.Point(156, 184);
            this.dTP_Date.Name = "dTP_Date";
            this.dTP_Date.Size = new System.Drawing.Size(173, 22);
            this.dTP_Date.TabIndex = 34;
            // 
            // Update_Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 491);
            this.Controls.Add(this.panel_Detail);
            this.Name = "Update_Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update_Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.panel_Detail)).EndInit();
            this.panel_Detail.ResumeLayout(false);
            this.panel_Detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ava)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel panel_Detail;
        private System.Windows.Forms.DateTimePicker dTP_TimeOut;
        private System.Windows.Forms.DateTimePicker dTP_TimeIn;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.TextBox txt_CheckOut;
        private System.Windows.Forms.TextBox txt_CheckIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_TrangThai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.PictureBox pic_ava;
        private System.Windows.Forms.ComboBox cbo_TrangThai;
        private System.Windows.Forms.DateTimePicker dTP_Out;
        private System.Windows.Forms.DateTimePicker dTP_In;
        private System.Windows.Forms.DateTimePicker dTP_Date;
    }
}