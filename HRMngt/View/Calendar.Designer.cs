
namespace HRMngt.View
{
    partial class Calendar
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
            this.panel_view = new System.Windows.Forms.Panel();
            this.btn_Tao = new System.Windows.Forms.Button();
            this.cbo_TrangThai = new System.Windows.Forms.ComboBox();
            this.cbo_PhongBan = new System.Windows.Forms.ComboBox();
            this.cbo_ThangKetThuc = new System.Windows.Forms.ComboBox();
            this.cbo_ThangBatDau = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel_view
            // 
            this.panel_view.AutoScroll = true;
            this.panel_view.Location = new System.Drawing.Point(47, 40);
            this.panel_view.Name = "panel_view";
            this.panel_view.Size = new System.Drawing.Size(1320, 550);
            this.panel_view.TabIndex = 9;
            // 
            // btn_Tao
            // 
            this.btn_Tao.BackColor = System.Drawing.Color.Lime;
            this.btn_Tao.Location = new System.Drawing.Point(1058, 2);
            this.btn_Tao.Name = "btn_Tao";
            this.btn_Tao.Size = new System.Drawing.Size(75, 32);
            this.btn_Tao.TabIndex = 10;
            this.btn_Tao.Text = "Tạo";
            this.btn_Tao.UseVisualStyleBackColor = false;
            this.btn_Tao.Click += new System.EventHandler(this.btn_Tao_Click);
            // 
            // cbo_TrangThai
            // 
            this.cbo_TrangThai.FormattingEnabled = true;
            this.cbo_TrangThai.Location = new System.Drawing.Point(428, 2);
            this.cbo_TrangThai.Name = "cbo_TrangThai";
            this.cbo_TrangThai.Size = new System.Drawing.Size(121, 24);
            this.cbo_TrangThai.TabIndex = 8;
            this.cbo_TrangThai.SelectedIndexChanged += new System.EventHandler(this.cbo_ThangBatDau_SelectedIndexChanged);
            // 
            // cbo_PhongBan
            // 
            this.cbo_PhongBan.FormattingEnabled = true;
            this.cbo_PhongBan.Location = new System.Drawing.Point(301, 2);
            this.cbo_PhongBan.Name = "cbo_PhongBan";
            this.cbo_PhongBan.Size = new System.Drawing.Size(121, 24);
            this.cbo_PhongBan.TabIndex = 7;
            this.cbo_PhongBan.SelectedIndexChanged += new System.EventHandler(this.cbo_ThangBatDau_SelectedIndexChanged);
            // 
            // cbo_ThangKetThuc
            // 
            this.cbo_ThangKetThuc.FormattingEnabled = true;
            this.cbo_ThangKetThuc.Location = new System.Drawing.Point(174, 2);
            this.cbo_ThangKetThuc.Name = "cbo_ThangKetThuc";
            this.cbo_ThangKetThuc.Size = new System.Drawing.Size(121, 24);
            this.cbo_ThangKetThuc.TabIndex = 6;
            this.cbo_ThangKetThuc.SelectedIndexChanged += new System.EventHandler(this.cbo_ThangBatDau_SelectedIndexChanged);
            // 
            // cbo_ThangBatDau
            // 
            this.cbo_ThangBatDau.FormattingEnabled = true;
            this.cbo_ThangBatDau.Location = new System.Drawing.Point(47, 2);
            this.cbo_ThangBatDau.Name = "cbo_ThangBatDau";
            this.cbo_ThangBatDau.Size = new System.Drawing.Size(121, 24);
            this.cbo_ThangBatDau.TabIndex = 5;
            this.cbo_ThangBatDau.SelectedIndexChanged += new System.EventHandler(this.cbo_ThangBatDau_SelectedIndexChanged);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 620);
            this.Controls.Add(this.btn_Tao);
            this.Controls.Add(this.panel_view);
            this.Controls.Add(this.cbo_TrangThai);
            this.Controls.Add(this.cbo_PhongBan);
            this.Controls.Add(this.cbo_ThangKetThuc);
            this.Controls.Add(this.cbo_ThangBatDau);
            this.Name = "Calendar";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_view;
        private System.Windows.Forms.ComboBox cbo_TrangThai;
        private System.Windows.Forms.ComboBox cbo_PhongBan;
        private System.Windows.Forms.ComboBox cbo_ThangKetThuc;
        private System.Windows.Forms.ComboBox cbo_ThangBatDau;
        private System.Windows.Forms.Button btn_Tao;
    }
}