namespace QuanLyRapChieuPhim.Dashboard.DatVeForms
{
    partial class DatVe
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
            this.flowLayoutPanelPhim = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPhim
            // 
            this.flowLayoutPanelPhim.AutoSize = true;
            this.flowLayoutPanelPhim.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelPhim.MaximumSize = new System.Drawing.Size(1051, 0);
            this.flowLayoutPanelPhim.MinimumSize = new System.Drawing.Size(0, 100);
            this.flowLayoutPanelPhim.Name = "flowLayoutPanelPhim";
            this.flowLayoutPanelPhim.Size = new System.Drawing.Size(1051, 100);
            this.flowLayoutPanelPhim.TabIndex = 0;
            // 
            // DatVeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1115, 682);
            this.Controls.Add(this.flowLayoutPanelPhim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DatVeForm";
            this.Text = "DatVe";
            this.Load += new System.EventHandler(this.DatVe_Load);
            this.Resize += new System.EventHandler(this.DatVe_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPhim;
    }
}