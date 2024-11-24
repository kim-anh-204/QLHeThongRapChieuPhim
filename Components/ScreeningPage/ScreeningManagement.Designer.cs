using QuanLyRapChieuPhim.UserPage;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.ScreeningPage
{
    partial class Screening
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
      

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Screening));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            this.bunifuDataGridView1 = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.maSC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenPhim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayChieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sua = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.bunifuTextBox1 = new Bunifu.UI.WinForms.BunifuTextBox();
            this.timkiembtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.thoat = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDataGridView1
            // 
            this.bunifuDataGridView1.AllowCustomTheming = true;
            this.bunifuDataGridView1.AllowUserToAddRows = false;
            this.bunifuDataGridView1.AllowUserToDeleteRows = false;
            this.bunifuDataGridView1.AllowUserToResizeColumns = false;
            this.bunifuDataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.bunifuDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuDataGridView1.ColumnHeadersHeight = 40;
            this.bunifuDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSC,
            this.tenPhim,
            this.tenPhong,
            this.ngayChieu,
            this.gioBatDau,
            this.giaVe,
            this.Sua,
            this.Xoa});
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.GridColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.Name = null;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuDataGridView1.EnableHeadersVisualStyles = false;
            this.bunifuDataGridView1.GridColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.bunifuDataGridView1.HeaderBgColor = System.Drawing.Color.Empty;
            this.bunifuDataGridView1.HeaderForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.Location = new System.Drawing.Point(26, 98);
            this.bunifuDataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bunifuDataGridView1.Name = "bunifuDataGridView1";
            this.bunifuDataGridView1.ReadOnly = true;
            this.bunifuDataGridView1.RowHeadersVisible = false;
            this.bunifuDataGridView1.RowHeadersWidth = 51;
            this.bunifuDataGridView1.RowTemplate.Height = 40;
            this.bunifuDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuDataGridView1.Size = new System.Drawing.Size(1073, 561);
            this.bunifuDataGridView1.TabIndex = 0;
            this.bunifuDataGridView1.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.bunifuDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuDataGridView1_CellContentClick);
            // 
            // maSC
            // 
            this.maSC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.maSC.FillWeight = 7F;
            this.maSC.HeaderText = "Mã SC";
            this.maSC.MinimumWidth = 2;
            this.maSC.Name = "maSC";
            this.maSC.ReadOnly = true;
            this.maSC.Width = 79;
            // 
            // tenPhim
            // 
            this.tenPhim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenPhim.FillWeight = 10.31674F;
            this.tenPhim.HeaderText = "Tên Phim";
            this.tenPhim.MinimumWidth = 6;
            this.tenPhim.Name = "tenPhim";
            this.tenPhim.ReadOnly = true;
            // 
            // tenPhong
            // 
            this.tenPhong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.tenPhong.FillWeight = 10.31674F;
            this.tenPhong.HeaderText = "Tên Phòng";
            this.tenPhong.MinimumWidth = 6;
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.ReadOnly = true;
            this.tenPhong.Width = 109;
            // 
            // ngayChieu
            // 
            this.ngayChieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ngayChieu.FillWeight = 10.31674F;
            this.ngayChieu.HeaderText = "Ngày Chiếu";
            this.ngayChieu.MinimumWidth = 6;
            this.ngayChieu.Name = "ngayChieu";
            this.ngayChieu.ReadOnly = true;
            this.ngayChieu.Width = 116;
            // 
            // gioBatDau
            // 
            this.gioBatDau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.gioBatDau.FillWeight = 10.31674F;
            this.gioBatDau.HeaderText = "Giờ Bắt Đầu";
            this.gioBatDau.MinimumWidth = 6;
            this.gioBatDau.Name = "gioBatDau";
            this.gioBatDau.ReadOnly = true;
            this.gioBatDau.Width = 118;
            // 
            // giaVe
            // 
            this.giaVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.giaVe.FillWeight = 10.31674F;
            this.giaVe.HeaderText = "Giá Vé";
            this.giaVe.MinimumWidth = 6;
            this.giaVe.Name = "giaVe";
            this.giaVe.ReadOnly = true;
            this.giaVe.Width = 78;
            // 
            // Sua
            // 
            this.Sua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sua.FillWeight = 10.31674F;
            this.Sua.HeaderText = "";
            this.Sua.MinimumWidth = 50;
            this.Sua.Name = "Sua";
            this.Sua.ReadOnly = true;
            this.Sua.Text = "Sửa";
            this.Sua.UseColumnTextForButtonValue = true;
            this.Sua.Width = 50;
            // 
            // Xoa
            // 
            this.Xoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Xoa.FillWeight = 10.31674F;
            this.Xoa.HeaderText = "";
            this.Xoa.MinimumWidth = 50;
            this.Xoa.Name = "Xoa";
            this.Xoa.ReadOnly = true;
            this.Xoa.Text = "Xóa";
            this.Xoa.UseColumnTextForButtonValue = true;
            this.Xoa.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // Edit
            // 
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            this.Edit.Width = 125;
            // 
            // Delete
            // 
            this.Delete.MinimumWidth = 6;
            this.Delete.Name = "Delete";
            this.Delete.Width = 125;
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowAnimations = true;
            this.bunifuButton1.AllowMouseEffects = true;
            this.bunifuButton1.AllowToggling = false;
            this.bunifuButton1.AnimationSpeed = 200;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.AutoRoundBorders = false;
            this.bunifuButton1.AutoSizeLeftIcon = true;
            this.bunifuButton1.AutoSizeRightIcon = true;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.PaleGreen;
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton1.ButtonText = "Thêm";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.ColorContrastOnClick = 45;
            this.bunifuButton1.ColorContrastOnHover = 45;
            this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton1.CustomizableEdges = borderEdges1;
            this.bunifuButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.bunifuButton1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton1.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton1.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bunifuButton1.IconMarginLeft = 11;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bunifuButton1.IconSize = 25;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.RosyBrown;
            this.bunifuButton1.IdleBorderRadius = 20;
            this.bunifuButton1.IdleBorderThickness = 1;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.PaleGreen;
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(26, 27);
            this.bunifuButton1.Name = "bunifuButton1";
            this.bunifuButton1.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton1.OnDisabledState.BorderRadius = 20;
            this.bunifuButton1.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton1.OnDisabledState.BorderThickness = 1;
            this.bunifuButton1.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.OnDisabledState.IconLeftImage = null;
            this.bunifuButton1.OnDisabledState.IconRightImage = null;
            this.bunifuButton1.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton1.onHoverState.BorderRadius = 20;
            this.bunifuButton1.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton1.onHoverState.BorderThickness = 1;
            this.bunifuButton1.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton1.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.onHoverState.IconLeftImage = null;
            this.bunifuButton1.onHoverState.IconRightImage = null;
            this.bunifuButton1.OnIdleState.BorderColor = System.Drawing.Color.RosyBrown;
            this.bunifuButton1.OnIdleState.BorderRadius = 20;
            this.bunifuButton1.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton1.OnIdleState.BorderThickness = 1;
            this.bunifuButton1.OnIdleState.FillColor = System.Drawing.Color.PaleGreen;
            this.bunifuButton1.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton1.OnIdleState.IconLeftImage = null;
            this.bunifuButton1.OnIdleState.IconRightImage = null;
            this.bunifuButton1.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton1.OnPressedState.BorderRadius = 20;
            this.bunifuButton1.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton1.OnPressedState.BorderThickness = 1;
            this.bunifuButton1.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton1.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.OnPressedState.IconLeftImage = null;
            this.bunifuButton1.OnPressedState.IconRightImage = null;
            this.bunifuButton1.Size = new System.Drawing.Size(130, 37);
            this.bunifuButton1.TabIndex = 5;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // bunifuTextBox1
            // 
            this.bunifuTextBox1.AcceptsReturn = false;
            this.bunifuTextBox1.AcceptsTab = false;
            this.bunifuTextBox1.AnimationSpeed = 200;
            this.bunifuTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.bunifuTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.bunifuTextBox1.AutoSizeHeight = true;
            this.bunifuTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTextBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuTextBox1.BackgroundImage")));
            this.bunifuTextBox1.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.bunifuTextBox1.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuTextBox1.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuTextBox1.BorderColorIdle = System.Drawing.Color.Silver;
            this.bunifuTextBox1.BorderRadius = 20;
            this.bunifuTextBox1.BorderThickness = 1;
            this.bunifuTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bunifuTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.bunifuTextBox1.DefaultText = "";
            this.bunifuTextBox1.FillColor = System.Drawing.Color.White;
            this.bunifuTextBox1.HideSelection = true;
            this.bunifuTextBox1.IconLeft = null;
            this.bunifuTextBox1.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.IconPadding = 10;
            this.bunifuTextBox1.IconRight = null;
            this.bunifuTextBox1.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.Lines = new string[0];
            this.bunifuTextBox1.Location = new System.Drawing.Point(414, 27);
            this.bunifuTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bunifuTextBox1.MaxLength = 32767;
            this.bunifuTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.bunifuTextBox1.Modified = false;
            this.bunifuTextBox1.Multiline = false;
            this.bunifuTextBox1.Name = "bunifuTextBox1";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.bunifuTextBox1.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnIdleState = stateProperties4;
            this.bunifuTextBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bunifuTextBox1.PasswordChar = '\0';
            this.bunifuTextBox1.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.bunifuTextBox1.PlaceholderText = "Nhập tên phim ";
            this.bunifuTextBox1.ReadOnly = false;
            this.bunifuTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bunifuTextBox1.SelectedText = "";
            this.bunifuTextBox1.SelectionLength = 0;
            this.bunifuTextBox1.SelectionStart = 0;
            this.bunifuTextBox1.ShortcutsEnabled = true;
            this.bunifuTextBox1.Size = new System.Drawing.Size(263, 35);
            this.bunifuTextBox1.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.bunifuTextBox1.TabIndex = 6;
            this.bunifuTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuTextBox1.TextMarginBottom = 0;
            this.bunifuTextBox1.TextMarginLeft = 3;
            this.bunifuTextBox1.TextMarginTop = 1;
            this.bunifuTextBox1.TextPlaceholder = "Nhập tên phim ";
            this.bunifuTextBox1.UseSystemPasswordChar = false;
            this.bunifuTextBox1.WordWrap = true;
            this.bunifuTextBox1.TextChanged += new System.EventHandler(this.bunifuTextBox1_TextChanged);
            // 
            // timkiembtn
            // 
            this.timkiembtn.AllowAnimations = true;
            this.timkiembtn.AllowMouseEffects = true;
            this.timkiembtn.AllowToggling = false;
            this.timkiembtn.AnimationSpeed = 200;
            this.timkiembtn.AutoGenerateColors = false;
            this.timkiembtn.AutoRoundBorders = false;
            this.timkiembtn.AutoSizeLeftIcon = true;
            this.timkiembtn.AutoSizeRightIcon = true;
            this.timkiembtn.BackColor = System.Drawing.Color.Transparent;
            this.timkiembtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.timkiembtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("timkiembtn.BackgroundImage")));
            this.timkiembtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.timkiembtn.ButtonText = "Tìm kiếm";
            this.timkiembtn.ButtonTextMarginLeft = 0;
            this.timkiembtn.ColorContrastOnClick = 45;
            this.timkiembtn.ColorContrastOnHover = 45;
            this.timkiembtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.timkiembtn.CustomizableEdges = borderEdges2;
            this.timkiembtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.timkiembtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.timkiembtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.timkiembtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.timkiembtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.timkiembtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.timkiembtn.ForeColor = System.Drawing.Color.White;
            this.timkiembtn.IconLeft = null;
            this.timkiembtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timkiembtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.timkiembtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.timkiembtn.IconMarginLeft = 11;
            this.timkiembtn.IconPadding = 10;
            this.timkiembtn.IconRight = null;
            this.timkiembtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.timkiembtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.timkiembtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.timkiembtn.IconSize = 25;
            this.timkiembtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.timkiembtn.IdleBorderRadius = 0;
            this.timkiembtn.IdleBorderThickness = 0;
            this.timkiembtn.IdleFillColor = System.Drawing.Color.Empty;
            this.timkiembtn.IdleIconLeftImage = null;
            this.timkiembtn.IdleIconRightImage = null;
            this.timkiembtn.IndicateFocus = false;
            this.timkiembtn.Location = new System.Drawing.Point(681, 27);
            this.timkiembtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.timkiembtn.Name = "timkiembtn";
            this.timkiembtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.timkiembtn.OnDisabledState.BorderRadius = 30;
            this.timkiembtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.timkiembtn.OnDisabledState.BorderThickness = 1;
            this.timkiembtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.timkiembtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.timkiembtn.OnDisabledState.IconLeftImage = null;
            this.timkiembtn.OnDisabledState.IconRightImage = null;
            this.timkiembtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.timkiembtn.onHoverState.BorderRadius = 30;
            this.timkiembtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.timkiembtn.onHoverState.BorderThickness = 1;
            this.timkiembtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.timkiembtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.timkiembtn.onHoverState.IconLeftImage = null;
            this.timkiembtn.onHoverState.IconRightImage = null;
            this.timkiembtn.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.timkiembtn.OnIdleState.BorderRadius = 30;
            this.timkiembtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.timkiembtn.OnIdleState.BorderThickness = 1;
            this.timkiembtn.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.timkiembtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.timkiembtn.OnIdleState.IconLeftImage = null;
            this.timkiembtn.OnIdleState.IconRightImage = null;
            this.timkiembtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.timkiembtn.OnPressedState.BorderRadius = 30;
            this.timkiembtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.timkiembtn.OnPressedState.BorderThickness = 1;
            this.timkiembtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.timkiembtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.timkiembtn.OnPressedState.IconLeftImage = null;
            this.timkiembtn.OnPressedState.IconRightImage = null;
            this.timkiembtn.Size = new System.Drawing.Size(85, 35);
            this.timkiembtn.TabIndex = 7;
            this.timkiembtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timkiembtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.timkiembtn.TextMarginLeft = 0;
            this.timkiembtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.timkiembtn.UseDefaultRadiusAndThickness = true;
            this.timkiembtn.Click += new System.EventHandler(this.bunifuButton2_Click);
            // 
            // thoat
            // 
            this.thoat.AllowAnimations = true;
            this.thoat.AllowMouseEffects = true;
            this.thoat.AllowToggling = false;
            this.thoat.AnimationSpeed = 200;
            this.thoat.AutoGenerateColors = false;
            this.thoat.AutoRoundBorders = false;
            this.thoat.AutoSizeLeftIcon = true;
            this.thoat.AutoSizeRightIcon = true;
            this.thoat.BackColor = System.Drawing.Color.Transparent;
            this.thoat.BackColor1 = System.Drawing.Color.Red;
            this.thoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("thoat.BackgroundImage")));
            this.thoat.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.thoat.ButtonText = "Thoát";
            this.thoat.ButtonTextMarginLeft = 0;
            this.thoat.ColorContrastOnClick = 45;
            this.thoat.ColorContrastOnHover = 45;
            this.thoat.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.thoat.CustomizableEdges = borderEdges3;
            this.thoat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.thoat.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.thoat.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.thoat.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.thoat.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.thoat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.thoat.ForeColor = System.Drawing.Color.Transparent;
            this.thoat.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thoat.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.thoat.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.thoat.IconMarginLeft = 11;
            this.thoat.IconPadding = 10;
            this.thoat.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.thoat.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.thoat.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.thoat.IconSize = 25;
            this.thoat.IdleBorderColor = System.Drawing.Color.RosyBrown;
            this.thoat.IdleBorderRadius = 20;
            this.thoat.IdleBorderThickness = 1;
            this.thoat.IdleFillColor = System.Drawing.Color.Red;
            this.thoat.IdleIconLeftImage = null;
            this.thoat.IdleIconRightImage = null;
            this.thoat.IndicateFocus = false;
            this.thoat.Location = new System.Drawing.Point(857, 27);
            this.thoat.Name = "thoat";
            this.thoat.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.thoat.OnDisabledState.BorderRadius = 20;
            this.thoat.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.thoat.OnDisabledState.BorderThickness = 1;
            this.thoat.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.thoat.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.thoat.OnDisabledState.IconLeftImage = null;
            this.thoat.OnDisabledState.IconRightImage = null;
            this.thoat.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.thoat.onHoverState.BorderRadius = 20;
            this.thoat.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.thoat.onHoverState.BorderThickness = 1;
            this.thoat.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.thoat.onHoverState.ForeColor = System.Drawing.Color.White;
            this.thoat.onHoverState.IconLeftImage = null;
            this.thoat.onHoverState.IconRightImage = null;
            this.thoat.OnIdleState.BorderColor = System.Drawing.Color.RosyBrown;
            this.thoat.OnIdleState.BorderRadius = 20;
            this.thoat.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.thoat.OnIdleState.BorderThickness = 1;
            this.thoat.OnIdleState.FillColor = System.Drawing.Color.Red;
            this.thoat.OnIdleState.ForeColor = System.Drawing.Color.Transparent;
            this.thoat.OnIdleState.IconLeftImage = null;
            this.thoat.OnIdleState.IconRightImage = null;
            this.thoat.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.thoat.OnPressedState.BorderRadius = 20;
            this.thoat.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.thoat.OnPressedState.BorderThickness = 1;
            this.thoat.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.thoat.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.thoat.OnPressedState.IconLeftImage = null;
            this.thoat.OnPressedState.IconRightImage = null;
            this.thoat.Size = new System.Drawing.Size(88, 37);
            this.thoat.TabIndex = 13;
            this.thoat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.thoat.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.thoat.TextMarginLeft = 0;
            this.thoat.TextPadding = new System.Windows.Forms.Padding(0);
            this.thoat.UseDefaultRadiusAndThickness = true;
            this.thoat.Click += new System.EventHandler(this.thoat_Click);
            // 
            // Screening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 682);
            this.Controls.Add(this.thoat);
            this.Controls.Add(this.timkiembtn);
            this.Controls.Add(this.bunifuTextBox1);
            this.Controls.Add(this.bunifuButton1);
            this.Controls.Add(this.bunifuDataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Screening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Screening_Activated);
            this.Load += new System.EventHandler(this.UserManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuDataGridView bunifuDataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Delete;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 bunifuButton1;

        #endregion

        private DataGridViewTextBoxColumn maSC;
        private DataGridViewTextBoxColumn tenPhim;
        private DataGridViewTextBoxColumn tenPhong;
        private DataGridViewTextBoxColumn ngayChieu;
        private DataGridViewTextBoxColumn gioBatDau;
        private DataGridViewTextBoxColumn giaVe;
        private DataGridViewButtonColumn Sua;
        private DataGridViewButtonColumn Xoa;
        private Bunifu.UI.WinForms.BunifuTextBox bunifuTextBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton timkiembtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 thoat;
    }
}