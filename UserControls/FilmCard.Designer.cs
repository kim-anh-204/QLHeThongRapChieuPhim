namespace QuanLyRapChieuPhim.UserControls
{
    partial class FilmCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilmCard));
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelKhoiChieu = new System.Windows.Forms.Label();
            this.labelThoiLuong = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTenPhim = new System.Windows.Forms.Label();
            this.pictureBoxPoster = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.MaximumSize = new System.Drawing.Size(175, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Khởi chiếu: ";
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 20;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.panel1);
            this.bunifuPanel1.Controls.Add(this.pictureBoxPoster);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(175, 375);
            this.bunifuPanel1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.labelTenPhim);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 242);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 8, 2, 8);
            this.panel1.Size = new System.Drawing.Size(175, 133);
            this.panel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelKhoiChieu, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelThoiLuong, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 85);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(171, 40);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // labelKhoiChieu
            // 
            this.labelKhoiChieu.AutoSize = true;
            this.labelKhoiChieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKhoiChieu.Location = new System.Drawing.Point(88, 20);
            this.labelKhoiChieu.MaximumSize = new System.Drawing.Size(175, 0);
            this.labelKhoiChieu.Name = "labelKhoiChieu";
            this.labelKhoiChieu.Size = new System.Drawing.Size(65, 15);
            this.labelKhoiChieu.TabIndex = 6;
            this.labelKhoiChieu.Text = "16/10/2024";
            // 
            // labelThoiLuong
            // 
            this.labelThoiLuong.AutoSize = true;
            this.labelThoiLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThoiLuong.Location = new System.Drawing.Point(88, 0);
            this.labelThoiLuong.MaximumSize = new System.Drawing.Size(175, 0);
            this.labelThoiLuong.Name = "labelThoiLuong";
            this.labelThoiLuong.Size = new System.Drawing.Size(47, 15);
            this.labelThoiLuong.TabIndex = 5;
            this.labelThoiLuong.Text = "97 phút";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.MaximumSize = new System.Drawing.Size(175, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Thời lượng:";
            // 
            // labelTenPhim
            // 
            this.labelTenPhim.AutoSize = true;
            this.labelTenPhim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenPhim.Location = new System.Drawing.Point(2, 8);
            this.labelTenPhim.MaximumSize = new System.Drawing.Size(175, 0);
            this.labelTenPhim.Name = "labelTenPhim";
            this.labelTenPhim.Size = new System.Drawing.Size(174, 38);
            this.labelTenPhim.TabIndex = 8;
            this.labelTenPhim.Text = "TAEYONG: TỪ TAEYONG ĐẾN TY TRACK";
            // 
            // pictureBoxPoster
            // 
            this.pictureBoxPoster.AllowFocused = false;
            this.pictureBoxPoster.AutoSizeHeight = false;
            this.pictureBoxPoster.BorderRadius = 20;
            this.pictureBoxPoster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPoster.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxPoster.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPoster.Image")));
            this.pictureBoxPoster.IsCircle = false;
            this.pictureBoxPoster.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPoster.Name = "pictureBoxPoster";
            this.pictureBoxPoster.Size = new System.Drawing.Size(175, 242);
            this.pictureBoxPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPoster.TabIndex = 7;
            this.pictureBoxPoster.TabStop = false;
            this.pictureBoxPoster.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Custom;
            this.pictureBoxPoster.Click += new System.EventHandler(this.pictureBoxPoster_Click);
            // 
            // FilmCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.bunifuPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(16);
            this.Name = "FilmCard";
            this.Size = new System.Drawing.Size(175, 375);
            this.bunifuPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPoster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Bunifu.UI.WinForms.BunifuPictureBox pictureBoxPoster;
        private System.Windows.Forms.Label labelKhoiChieu;
        private System.Windows.Forms.Label labelThoiLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTenPhim;
        private System.Windows.Forms.Panel panel1;
    }
}
