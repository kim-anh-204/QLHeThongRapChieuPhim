namespace QuanLyRapChieuPhim.Dashboard.DatVeForms
{
    partial class DatVeForm
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
            Utilities.BunifuPages.BunifuAnimatorNS.Animation animation1 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatVeForm));
            this.bunifuPages1 = new Bunifu.UI.WinForms.BunifuPages();
            this.DatVePage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChonGioChieuPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChonChoNgoi = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuPages1.SuspendLayout();
            this.DatVePage.SuspendLayout();
            this.ChonGioChieuPage.SuspendLayout();
            this.ChonChoNgoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPages1
            // 
            this.bunifuPages1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.bunifuPages1.AllowTransitions = false;
            this.bunifuPages1.Controls.Add(this.DatVePage);
            this.bunifuPages1.Controls.Add(this.ChonGioChieuPage);
            this.bunifuPages1.Controls.Add(this.ChonChoNgoi);
            this.bunifuPages1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuPages1.Location = new System.Drawing.Point(0, 0);
            this.bunifuPages1.Multiline = true;
            this.bunifuPages1.Name = "bunifuPages1";
            this.bunifuPages1.Page = this.ChonChoNgoi;
            this.bunifuPages1.PageIndex = 2;
            this.bunifuPages1.PageName = "ChonChoNgoi";
            this.bunifuPages1.PageTitle = "Chọn chỗ ngồi";
            this.bunifuPages1.SelectedIndex = 0;
            this.bunifuPages1.Size = new System.Drawing.Size(1115, 682);
            this.bunifuPages1.TabIndex = 0;
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.bunifuPages1.Transition = animation1;
            this.bunifuPages1.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
            // 
            // DatVePage
            // 
            this.DatVePage.Controls.Add(this.panel1);
            this.DatVePage.Location = new System.Drawing.Point(4, 4);
            this.DatVePage.Name = "DatVePage";
            this.DatVePage.Padding = new System.Windows.Forms.Padding(3);
            this.DatVePage.Size = new System.Drawing.Size(1107, 656);
            this.DatVePage.TabIndex = 0;
            this.DatVePage.Text = "Đặt vé";
            this.DatVePage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 650);
            this.panel1.TabIndex = 0;
            // 
            // ChonGioChieuPage
            // 
            this.ChonGioChieuPage.Controls.Add(this.panel2);
            this.ChonGioChieuPage.Location = new System.Drawing.Point(4, 4);
            this.ChonGioChieuPage.Name = "ChonGioChieuPage";
            this.ChonGioChieuPage.Padding = new System.Windows.Forms.Padding(3);
            this.ChonGioChieuPage.Size = new System.Drawing.Size(1107, 656);
            this.ChonGioChieuPage.TabIndex = 1;
            this.ChonGioChieuPage.Text = "Chọn giờ chiếu";
            this.ChonGioChieuPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1101, 650);
            this.panel2.TabIndex = 0;
            // 
            // ChonChoNgoi
            // 
            this.ChonChoNgoi.Controls.Add(this.panel3);
            this.ChonChoNgoi.Location = new System.Drawing.Point(4, 4);
            this.ChonChoNgoi.Name = "ChonChoNgoi";
            this.ChonChoNgoi.Padding = new System.Windows.Forms.Padding(3);
            this.ChonChoNgoi.Size = new System.Drawing.Size(1107, 656);
            this.ChonChoNgoi.TabIndex = 2;
            this.ChonChoNgoi.Text = "Chọn chỗ ngồi";
            this.ChonChoNgoi.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1101, 650);
            this.panel3.TabIndex = 0;
            // 
            // DatVeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 682);
            this.Controls.Add(this.bunifuPages1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DatVeForm";
            this.Text = "DatVeForm";
            this.Load += new System.EventHandler(this.DatVeForm_Load);
            this.bunifuPages1.ResumeLayout(false);
            this.DatVePage.ResumeLayout(false);
            this.ChonGioChieuPage.ResumeLayout(false);
            this.ChonChoNgoi.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPages bunifuPages1;
        private System.Windows.Forms.TabPage DatVePage;
        private System.Windows.Forms.TabPage ChonGioChieuPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage ChonChoNgoi;
        private System.Windows.Forms.Panel panel3;
    }
}