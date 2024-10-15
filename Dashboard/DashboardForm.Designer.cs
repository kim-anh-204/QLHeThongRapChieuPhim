namespace QuanLyRapChieuPhim.MainForm
{
    partial class DashboardForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Indicator_Animation = new System.Windows.Forms.Timer(this.components);
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuButton21 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.indicator = new System.Windows.Forms.PictureBox();
            this.buttonNhanVien = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.buttonPhim = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.buttonTrangChu = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.bunifuDataGridView1 = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicator)).BeginInit();
            this.bunifuPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Indicator_Animation
            // 
            this.Indicator_Animation.Interval = 10;
            this.Indicator_Animation.Tick += new System.EventHandler(this.Indicator_Animation_Tick);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.bunifuPanel1.BorderRadius = 0;
            this.bunifuPanel1.BorderThickness = 0;
            this.bunifuPanel1.Controls.Add(this.bunifuButton21);
            this.bunifuPanel1.Controls.Add(this.indicator);
            this.bunifuPanel1.Controls.Add(this.buttonNhanVien);
            this.bunifuPanel1.Controls.Add(this.buttonPhim);
            this.bunifuPanel1.Controls.Add(this.buttonTrangChu);
            this.bunifuPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuPanel1.Location = new System.Drawing.Point(0, 98);
            this.bunifuPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = false;
            this.bunifuPanel1.Size = new System.Drawing.Size(267, 847);
            this.bunifuPanel1.TabIndex = 0;
            this.bunifuPanel1.Click += new System.EventHandler(this.bunifuPanel1_Click);
            // 
            // bunifuButton21
            // 
            this.bunifuButton21.AllowAnimations = true;
            this.bunifuButton21.AllowMouseEffects = true;
            this.bunifuButton21.AllowToggling = true;
            this.bunifuButton21.AnimationSpeed = 200;
            this.bunifuButton21.AutoGenerateColors = false;
            this.bunifuButton21.AutoRoundBorders = false;
            this.bunifuButton21.AutoSizeLeftIcon = true;
            this.bunifuButton21.AutoSizeRightIcon = true;
            this.bunifuButton21.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton21.BackColor1 = System.Drawing.Color.White;
            this.bunifuButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton21.BackgroundImage")));
            this.bunifuButton21.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton21.ButtonText = "Quản lí tài khoản";
            this.bunifuButton21.ButtonTextMarginLeft = 0;
            this.bunifuButton21.ColorContrastOnClick = 45;
            this.bunifuButton21.ColorContrastOnHover = 45;
            this.bunifuButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton21.CustomizableEdges = borderEdges1;
            this.bunifuButton21.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton21.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton21.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton21.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton21.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.bunifuButton21.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton21.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuButton21.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton21.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton21.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bunifuButton21.IconMarginLeft = 11;
            this.bunifuButton21.IconPadding = 10;
            this.bunifuButton21.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton21.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton21.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bunifuButton21.IconSize = 25;
            this.bunifuButton21.IdleBorderColor = System.Drawing.Color.White;
            this.bunifuButton21.IdleBorderRadius = 1;
            this.bunifuButton21.IdleBorderThickness = 1;
            this.bunifuButton21.IdleFillColor = System.Drawing.Color.White;
            this.bunifuButton21.IdleIconLeftImage = null;
            this.bunifuButton21.IdleIconRightImage = null;
            this.bunifuButton21.IndicateFocus = true;
            this.bunifuButton21.Location = new System.Drawing.Point(0, 186);
            this.bunifuButton21.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuButton21.Name = "bunifuButton21";
            this.bunifuButton21.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton21.OnDisabledState.BorderRadius = 1;
            this.bunifuButton21.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton21.OnDisabledState.BorderThickness = 1;
            this.bunifuButton21.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton21.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton21.OnDisabledState.IconLeftImage = null;
            this.bunifuButton21.OnDisabledState.IconRightImage = null;
            this.bunifuButton21.onHoverState.BorderColor = System.Drawing.Color.White;
            this.bunifuButton21.onHoverState.BorderRadius = 1;
            this.bunifuButton21.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton21.onHoverState.BorderThickness = 1;
            this.bunifuButton21.onHoverState.FillColor = System.Drawing.Color.White;
            this.bunifuButton21.onHoverState.ForeColor = System.Drawing.Color.Red;
            this.bunifuButton21.onHoverState.IconLeftImage = null;
            this.bunifuButton21.onHoverState.IconRightImage = null;
            this.bunifuButton21.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.bunifuButton21.OnIdleState.BorderRadius = 1;
            this.bunifuButton21.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton21.OnIdleState.BorderThickness = 1;
            this.bunifuButton21.OnIdleState.FillColor = System.Drawing.Color.White;
            this.bunifuButton21.OnIdleState.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuButton21.OnIdleState.IconLeftImage = null;
            this.bunifuButton21.OnIdleState.IconRightImage = null;
            this.bunifuButton21.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.bunifuButton21.OnPressedState.BorderRadius = 1;
            this.bunifuButton21.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.bunifuButton21.OnPressedState.BorderThickness = 1;
            this.bunifuButton21.OnPressedState.FillColor = System.Drawing.Color.White;
            this.bunifuButton21.OnPressedState.ForeColor = System.Drawing.Color.Red;
            this.bunifuButton21.OnPressedState.IconLeftImage = null;
            this.bunifuButton21.OnPressedState.IconRightImage = null;
            this.bunifuButton21.Size = new System.Drawing.Size(267, 55);
            this.bunifuButton21.TabIndex = 13;
            this.bunifuButton21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton21.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton21.TextMarginLeft = 0;
            this.bunifuButton21.TextPadding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.bunifuButton21.UseDefaultRadiusAndThickness = true;
            this.bunifuButton21.Click += new System.EventHandler(this.bunifuButton21_Click);
            // 
            // indicator
            // 
            this.indicator.BackColor = System.Drawing.Color.Red;
            this.indicator.Location = new System.Drawing.Point(0, 0);
            this.indicator.Margin = new System.Windows.Forms.Padding(4);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(13, 62);
            this.indicator.TabIndex = 4;
            this.indicator.TabStop = false;
            // 
            // buttonNhanVien
            // 
            this.buttonNhanVien.AllowAnimations = true;
            this.buttonNhanVien.AllowMouseEffects = true;
            this.buttonNhanVien.AllowToggling = true;
            this.buttonNhanVien.AnimationSpeed = 200;
            this.buttonNhanVien.AutoGenerateColors = false;
            this.buttonNhanVien.AutoRoundBorders = false;
            this.buttonNhanVien.AutoSizeLeftIcon = true;
            this.buttonNhanVien.AutoSizeRightIcon = true;
            this.buttonNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.buttonNhanVien.BackColor1 = System.Drawing.Color.White;
            this.buttonNhanVien.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNhanVien.BackgroundImage")));
            this.buttonNhanVien.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonNhanVien.ButtonText = "Nhân viên";
            this.buttonNhanVien.ButtonTextMarginLeft = 0;
            this.buttonNhanVien.ColorContrastOnClick = 45;
            this.buttonNhanVien.ColorContrastOnHover = 45;
            this.buttonNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.buttonNhanVien.CustomizableEdges = borderEdges2;
            this.buttonNhanVien.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonNhanVien.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonNhanVien.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonNhanVien.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.buttonNhanVien.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.buttonNhanVien.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNhanVien.ForeColor = System.Drawing.Color.DimGray;
            this.buttonNhanVien.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNhanVien.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.buttonNhanVien.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.buttonNhanVien.IconMarginLeft = 11;
            this.buttonNhanVien.IconPadding = 10;
            this.buttonNhanVien.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonNhanVien.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.buttonNhanVien.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonNhanVien.IconSize = 25;
            this.buttonNhanVien.IdleBorderColor = System.Drawing.Color.White;
            this.buttonNhanVien.IdleBorderRadius = 1;
            this.buttonNhanVien.IdleBorderThickness = 1;
            this.buttonNhanVien.IdleFillColor = System.Drawing.Color.White;
            this.buttonNhanVien.IdleIconLeftImage = null;
            this.buttonNhanVien.IdleIconRightImage = null;
            this.buttonNhanVien.IndicateFocus = true;
            this.buttonNhanVien.Location = new System.Drawing.Point(0, 123);
            this.buttonNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.buttonNhanVien.Name = "buttonNhanVien";
            this.buttonNhanVien.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonNhanVien.OnDisabledState.BorderRadius = 1;
            this.buttonNhanVien.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonNhanVien.OnDisabledState.BorderThickness = 1;
            this.buttonNhanVien.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonNhanVien.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.buttonNhanVien.OnDisabledState.IconLeftImage = null;
            this.buttonNhanVien.OnDisabledState.IconRightImage = null;
            this.buttonNhanVien.onHoverState.BorderColor = System.Drawing.Color.White;
            this.buttonNhanVien.onHoverState.BorderRadius = 1;
            this.buttonNhanVien.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonNhanVien.onHoverState.BorderThickness = 1;
            this.buttonNhanVien.onHoverState.FillColor = System.Drawing.Color.White;
            this.buttonNhanVien.onHoverState.ForeColor = System.Drawing.Color.Red;
            this.buttonNhanVien.onHoverState.IconLeftImage = null;
            this.buttonNhanVien.onHoverState.IconRightImage = null;
            this.buttonNhanVien.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.buttonNhanVien.OnIdleState.BorderRadius = 1;
            this.buttonNhanVien.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonNhanVien.OnIdleState.BorderThickness = 1;
            this.buttonNhanVien.OnIdleState.FillColor = System.Drawing.Color.White;
            this.buttonNhanVien.OnIdleState.ForeColor = System.Drawing.Color.DimGray;
            this.buttonNhanVien.OnIdleState.IconLeftImage = null;
            this.buttonNhanVien.OnIdleState.IconRightImage = null;
            this.buttonNhanVien.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.buttonNhanVien.OnPressedState.BorderRadius = 1;
            this.buttonNhanVien.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonNhanVien.OnPressedState.BorderThickness = 1;
            this.buttonNhanVien.OnPressedState.FillColor = System.Drawing.Color.White;
            this.buttonNhanVien.OnPressedState.ForeColor = System.Drawing.Color.Red;
            this.buttonNhanVien.OnPressedState.IconLeftImage = null;
            this.buttonNhanVien.OnPressedState.IconRightImage = null;
            this.buttonNhanVien.Size = new System.Drawing.Size(267, 55);
            this.buttonNhanVien.TabIndex = 12;
            this.buttonNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNhanVien.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonNhanVien.TextMarginLeft = 0;
            this.buttonNhanVien.TextPadding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.buttonNhanVien.UseDefaultRadiusAndThickness = true;
            this.buttonNhanVien.Click += new System.EventHandler(this.buttonNhanVien_Click);
            this.buttonNhanVien.MouseLeave += new System.EventHandler(this.buttonNhanVien_MouseLeave);
            this.buttonNhanVien.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonNhanVien_MouseMove);
            // 
            // buttonPhim
            // 
            this.buttonPhim.AllowAnimations = true;
            this.buttonPhim.AllowMouseEffects = true;
            this.buttonPhim.AllowToggling = true;
            this.buttonPhim.AnimationSpeed = 200;
            this.buttonPhim.AutoGenerateColors = false;
            this.buttonPhim.AutoRoundBorders = false;
            this.buttonPhim.AutoSizeLeftIcon = true;
            this.buttonPhim.AutoSizeRightIcon = true;
            this.buttonPhim.BackColor = System.Drawing.Color.Transparent;
            this.buttonPhim.BackColor1 = System.Drawing.Color.White;
            this.buttonPhim.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPhim.BackgroundImage")));
            this.buttonPhim.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonPhim.ButtonText = "Phim";
            this.buttonPhim.ButtonTextMarginLeft = 0;
            this.buttonPhim.ColorContrastOnClick = 45;
            this.buttonPhim.ColorContrastOnHover = 45;
            this.buttonPhim.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.buttonPhim.CustomizableEdges = borderEdges3;
            this.buttonPhim.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonPhim.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonPhim.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonPhim.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.buttonPhim.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Pressed;
            this.buttonPhim.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPhim.ForeColor = System.Drawing.Color.DimGray;
            this.buttonPhim.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPhim.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.buttonPhim.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.buttonPhim.IconMarginLeft = 11;
            this.buttonPhim.IconPadding = 10;
            this.buttonPhim.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPhim.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.buttonPhim.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonPhim.IconSize = 25;
            this.buttonPhim.IdleBorderColor = System.Drawing.Color.White;
            this.buttonPhim.IdleBorderRadius = 1;
            this.buttonPhim.IdleBorderThickness = 1;
            this.buttonPhim.IdleFillColor = System.Drawing.Color.White;
            this.buttonPhim.IdleIconLeftImage = null;
            this.buttonPhim.IdleIconRightImage = null;
            this.buttonPhim.IndicateFocus = true;
            this.buttonPhim.Location = new System.Drawing.Point(0, 62);
            this.buttonPhim.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPhim.Name = "buttonPhim";
            this.buttonPhim.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonPhim.OnDisabledState.BorderRadius = 1;
            this.buttonPhim.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonPhim.OnDisabledState.BorderThickness = 1;
            this.buttonPhim.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonPhim.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.buttonPhim.OnDisabledState.IconLeftImage = null;
            this.buttonPhim.OnDisabledState.IconRightImage = null;
            this.buttonPhim.onHoverState.BorderColor = System.Drawing.Color.White;
            this.buttonPhim.onHoverState.BorderRadius = 1;
            this.buttonPhim.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonPhim.onHoverState.BorderThickness = 1;
            this.buttonPhim.onHoverState.FillColor = System.Drawing.Color.White;
            this.buttonPhim.onHoverState.ForeColor = System.Drawing.Color.Red;
            this.buttonPhim.onHoverState.IconLeftImage = null;
            this.buttonPhim.onHoverState.IconRightImage = null;
            this.buttonPhim.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.buttonPhim.OnIdleState.BorderRadius = 1;
            this.buttonPhim.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonPhim.OnIdleState.BorderThickness = 1;
            this.buttonPhim.OnIdleState.FillColor = System.Drawing.Color.White;
            this.buttonPhim.OnIdleState.ForeColor = System.Drawing.Color.DimGray;
            this.buttonPhim.OnIdleState.IconLeftImage = null;
            this.buttonPhim.OnIdleState.IconRightImage = null;
            this.buttonPhim.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.buttonPhim.OnPressedState.BorderRadius = 1;
            this.buttonPhim.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonPhim.OnPressedState.BorderThickness = 1;
            this.buttonPhim.OnPressedState.FillColor = System.Drawing.Color.White;
            this.buttonPhim.OnPressedState.ForeColor = System.Drawing.Color.Red;
            this.buttonPhim.OnPressedState.IconLeftImage = null;
            this.buttonPhim.OnPressedState.IconRightImage = null;
            this.buttonPhim.Size = new System.Drawing.Size(267, 55);
            this.buttonPhim.TabIndex = 11;
            this.buttonPhim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPhim.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonPhim.TextMarginLeft = 0;
            this.buttonPhim.TextPadding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.buttonPhim.UseDefaultRadiusAndThickness = true;
            this.buttonPhim.Click += new System.EventHandler(this.buttonPhim_Click);
            this.buttonPhim.MouseLeave += new System.EventHandler(this.buttonPhim_MouseLeave);
            this.buttonPhim.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonPhim_MouseMove);
            // 
            // buttonTrangChu
            // 
            this.buttonTrangChu.AllowAnimations = true;
            this.buttonTrangChu.AllowMouseEffects = true;
            this.buttonTrangChu.AllowToggling = true;
            this.buttonTrangChu.AnimationSpeed = 200;
            this.buttonTrangChu.AutoGenerateColors = false;
            this.buttonTrangChu.AutoRoundBorders = false;
            this.buttonTrangChu.AutoSizeLeftIcon = true;
            this.buttonTrangChu.AutoSizeRightIcon = true;
            this.buttonTrangChu.BackColor = System.Drawing.Color.Transparent;
            this.buttonTrangChu.BackColor1 = System.Drawing.Color.White;
            this.buttonTrangChu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonTrangChu.BackgroundImage")));
            this.buttonTrangChu.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonTrangChu.ButtonText = "Trang chủ";
            this.buttonTrangChu.ButtonTextMarginLeft = 0;
            this.buttonTrangChu.ColorContrastOnClick = 45;
            this.buttonTrangChu.ColorContrastOnHover = 45;
            this.buttonTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.buttonTrangChu.CustomizableEdges = borderEdges4;
            this.buttonTrangChu.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonTrangChu.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonTrangChu.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonTrangChu.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.buttonTrangChu.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Hover;
            this.buttonTrangChu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTrangChu.ForeColor = System.Drawing.Color.DimGray;
            this.buttonTrangChu.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTrangChu.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTrangChu.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.buttonTrangChu.IconMarginLeft = 11;
            this.buttonTrangChu.IconPadding = 10;
            this.buttonTrangChu.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTrangChu.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTrangChu.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.buttonTrangChu.IconSize = 25;
            this.buttonTrangChu.IdleBorderColor = System.Drawing.Color.White;
            this.buttonTrangChu.IdleBorderRadius = 1;
            this.buttonTrangChu.IdleBorderThickness = 1;
            this.buttonTrangChu.IdleFillColor = System.Drawing.Color.White;
            this.buttonTrangChu.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("buttonTrangChu.IdleIconLeftImage")));
            this.buttonTrangChu.IdleIconRightImage = null;
            this.buttonTrangChu.IndicateFocus = true;
            this.buttonTrangChu.Location = new System.Drawing.Point(0, 0);
            this.buttonTrangChu.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTrangChu.Name = "buttonTrangChu";
            this.buttonTrangChu.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.buttonTrangChu.OnDisabledState.BorderRadius = 1;
            this.buttonTrangChu.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonTrangChu.OnDisabledState.BorderThickness = 1;
            this.buttonTrangChu.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.buttonTrangChu.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.buttonTrangChu.OnDisabledState.IconLeftImage = null;
            this.buttonTrangChu.OnDisabledState.IconRightImage = null;
            this.buttonTrangChu.onHoverState.BorderColor = System.Drawing.Color.White;
            this.buttonTrangChu.onHoverState.BorderRadius = 1;
            this.buttonTrangChu.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonTrangChu.onHoverState.BorderThickness = 1;
            this.buttonTrangChu.onHoverState.FillColor = System.Drawing.Color.White;
            this.buttonTrangChu.onHoverState.ForeColor = System.Drawing.Color.Red;
            this.buttonTrangChu.onHoverState.IconLeftImage = null;
            this.buttonTrangChu.onHoverState.IconRightImage = null;
            this.buttonTrangChu.OnIdleState.BorderColor = System.Drawing.Color.White;
            this.buttonTrangChu.OnIdleState.BorderRadius = 1;
            this.buttonTrangChu.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonTrangChu.OnIdleState.BorderThickness = 1;
            this.buttonTrangChu.OnIdleState.FillColor = System.Drawing.Color.White;
            this.buttonTrangChu.OnIdleState.ForeColor = System.Drawing.Color.DimGray;
            this.buttonTrangChu.OnIdleState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("buttonTrangChu.OnIdleState.IconLeftImage")));
            this.buttonTrangChu.OnIdleState.IconRightImage = null;
            this.buttonTrangChu.OnPressedState.BorderColor = System.Drawing.Color.White;
            this.buttonTrangChu.OnPressedState.BorderRadius = 1;
            this.buttonTrangChu.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderStyles.Solid;
            this.buttonTrangChu.OnPressedState.BorderThickness = 1;
            this.buttonTrangChu.OnPressedState.FillColor = System.Drawing.Color.White;
            this.buttonTrangChu.OnPressedState.ForeColor = System.Drawing.Color.Red;
            this.buttonTrangChu.OnPressedState.IconLeftImage = ((System.Drawing.Image)(resources.GetObject("resource.IconLeftImage")));
            this.buttonTrangChu.OnPressedState.IconRightImage = null;
            this.buttonTrangChu.Size = new System.Drawing.Size(267, 62);
            this.buttonTrangChu.TabIndex = 10;
            this.buttonTrangChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTrangChu.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttonTrangChu.TextMarginLeft = 0;
            this.buttonTrangChu.TextPadding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.buttonTrangChu.UseDefaultRadiusAndThickness = true;
            this.buttonTrangChu.Click += new System.EventHandler(this.buttonTrangChu_Click);
            this.buttonTrangChu.MouseLeave += new System.EventHandler(this.buttonTrangChu_MouseLeave);
            this.buttonTrangChu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonTrangChu_MouseMove);
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.White;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.bunifuPanel2.BorderRadius = 0;
            this.bunifuPanel2.BorderThickness = 0;
            this.bunifuPanel2.Controls.Add(this.bunifuPictureBox1);
            this.bunifuPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuPanel2.Location = new System.Drawing.Point(0, 0);
            this.bunifuPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = false;
            this.bunifuPanel2.Size = new System.Drawing.Size(1813, 98);
            this.bunifuPanel2.TabIndex = 1;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 33;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(1731, 15);
            this.bunifuPictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(67, 67);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 0;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // bunifuDataGridView1
            // 
            this.bunifuDataGridView1.AllowCustomTheming = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.bunifuDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuDataGridView1.ColumnHeadersHeight = 40;
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.Name = null;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuDataGridView1.EnableHeadersVisualStyles = false;
            this.bunifuDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.bunifuDataGridView1.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDataGridView1.HeaderBgColor = System.Drawing.Color.Empty;
            this.bunifuDataGridView1.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.Location = new System.Drawing.Point(433, 206);
            this.bunifuDataGridView1.Name = "bunifuDataGridView1";
            this.bunifuDataGridView1.RowHeadersVisible = false;
            this.bunifuDataGridView1.RowHeadersWidth = 51;
            this.bunifuDataGridView1.RowTemplate.Height = 40;
            this.bunifuDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuDataGridView1.Size = new System.Drawing.Size(240, 150);
            this.bunifuDataGridView1.TabIndex = 3;
            this.bunifuDataGridView1.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1813, 945);
            this.Controls.Add(this.bunifuDataGridView1);
            this.Controls.Add(this.bunifuPanel1);
            this.Controls.Add(this.bunifuPanel2);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng điều khiển";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DashboardForm_FormClosed);
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.bunifuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.indicator)).EndInit();
            this.bunifuPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private System.Windows.Forms.PictureBox indicator;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 buttonTrangChu;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 buttonNhanVien;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 buttonPhim;
        private System.Windows.Forms.Timer Indicator_Animation;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 bunifuButton21;
        private Bunifu.UI.WinForms.BunifuDataGridView bunifuDataGridView1;
    }
}