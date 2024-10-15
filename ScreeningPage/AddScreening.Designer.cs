using System.Windows.Forms;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace QuanLyRapChieuPhim.ScreeningPage
{
    partial class AddScreening
    {
        private DateTimePicker dateTimePicker1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddScreening));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.priceTextBox = new Bunifu.UI.WinForms.BunifuTextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMovies = new System.Windows.Forms.ComboBox();
            this.movieType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bunifuDatePicker1
            // 
            this.bunifuDatePicker1.BackColor = System.Drawing.Color.White;
            this.bunifuDatePicker1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.BorderRadius = 9;
            this.bunifuDatePicker1.CalendarForeColor = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.CalendarMonthBackground = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.CalendarTitleBackColor = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.CalendarTitleForeColor = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.CalendarTrailingForeColor = System.Drawing.Color.IndianRed;
            this.bunifuDatePicker1.Color = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuDatePicker1.DisabledColor = System.Drawing.SystemColors.InactiveBorder;
            this.bunifuDatePicker1.DisplayWeekNumbers = false;
            this.bunifuDatePicker1.DPHeight = 0;
            this.bunifuDatePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuDatePicker1.FillDatePicker = false;
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(101, 107);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(4, 32);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(308, 32);
            this.bunifuDatePicker1.TabIndex = 15;
            this.bunifuDatePicker1.Value = new System.DateTime(2024, 10, 15, 8, 41, 14, 253);
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowAnimations = true;
            this.bunifuButton1.AllowMouseEffects = true;
            this.bunifuButton1.AllowToggling = false;
            this.bunifuButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuButton1.AnimationSpeed = 200;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.AutoRoundBorders = false;
            this.bunifuButton1.AutoSizeLeftIcon = true;
            this.bunifuButton1.AutoSizeRightIcon = true;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.Salmon;
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
            this.bunifuButton1.ForeColor = System.Drawing.Color.White;
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
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.Salmon;
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(104, 385);
            this.bunifuButton1.Margin = new System.Windows.Forms.Padding(4);
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
            this.bunifuButton1.OnIdleState.FillColor = System.Drawing.Color.Salmon;
            this.bunifuButton1.OnIdleState.ForeColor = System.Drawing.Color.White;
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
            this.bunifuButton1.Size = new System.Drawing.Size(305, 46);
            this.bunifuButton1.TabIndex = 10;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // comboBoxRoom
            // 
            this.comboBoxRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxRoom.FormattingEnabled = true;
            this.comboBoxRoom.Items.AddRange(new object[] {
            "PC-01",
            "PC-02",
            "PC-03",
            "PC-04"});
            this.comboBoxRoom.Location = new System.Drawing.Point(284, 173);
            this.comboBoxRoom.Name = "comboBoxRoom";
            this.comboBoxRoom.Size = new System.Drawing.Size(125, 28);
            this.comboBoxRoom.TabIndex = 16;
            this.comboBoxRoom.Text = "Chọn phòng ";
            // 
            // priceTextBox
            // 
            this.priceTextBox.AcceptsReturn = false;
            this.priceTextBox.AcceptsTab = false;
            this.priceTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.priceTextBox.AnimationSpeed = 200;
            this.priceTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.priceTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.priceTextBox.AutoSizeHeight = true;
            this.priceTextBox.BackColor = System.Drawing.Color.Transparent;
            this.priceTextBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("priceTextBox.BackgroundImage")));
            this.priceTextBox.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.priceTextBox.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.priceTextBox.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.priceTextBox.BorderColorIdle = System.Drawing.Color.Silver;
            this.priceTextBox.BorderRadius = 20;
            this.priceTextBox.BorderThickness = 1;
            this.priceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.priceTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.priceTextBox.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.priceTextBox.DefaultText = "";
            this.priceTextBox.FillColor = System.Drawing.Color.White;
            this.priceTextBox.HideSelection = true;
            this.priceTextBox.IconLeft = null;
            this.priceTextBox.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.priceTextBox.IconPadding = 10;
            this.priceTextBox.IconRight = null;
            this.priceTextBox.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.priceTextBox.Lines = new string[0];
            this.priceTextBox.Location = new System.Drawing.Point(101, 298);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.priceTextBox.MaxLength = 32767;
            this.priceTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.priceTextBox.Modified = false;
            this.priceTextBox.Multiline = false;
            this.priceTextBox.Name = "priceTextBox";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.priceTextBox.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.priceTextBox.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.priceTextBox.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.priceTextBox.OnIdleState = stateProperties4;
            this.priceTextBox.Padding = new System.Windows.Forms.Padding(4);
            this.priceTextBox.PasswordChar = '\0';
            this.priceTextBox.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.priceTextBox.PlaceholderText = "Nhập giá vé";
            this.priceTextBox.ReadOnly = false;
            this.priceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.priceTextBox.SelectedText = "";
            this.priceTextBox.SelectionLength = 0;
            this.priceTextBox.SelectionStart = 0;
            this.priceTextBox.ShortcutsEnabled = true;
            this.priceTextBox.Size = new System.Drawing.Size(308, 46);
            this.priceTextBox.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.priceTextBox.TabIndex = 17;
            this.priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.priceTextBox.TextMarginBottom = 0;
            this.priceTextBox.TextMarginLeft = 3;
            this.priceTextBox.TextMarginTop = 1;
            this.priceTextBox.TextPlaceholder = "Nhập giá vé";
            this.priceTextBox.UseSystemPasswordChar = false;
            this.priceTextBox.WordWrap = true;
            this.priceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTextBox_KeyPress);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePicker1.CustomFormat = "HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 173);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 30);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2024, 10, 14, 16, 6, 37, 527);
            // 
            // comboBoxMovies
            // 
            this.comboBoxMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxMovies.FormattingEnabled = true;
            this.comboBoxMovies.Items.AddRange(new object[] {
            "PC-01",
            "PC-02",
            "PC-03",
            "PC-04"});
            this.comboBoxMovies.Location = new System.Drawing.Point(101, 49);
            this.comboBoxMovies.Name = "comboBoxMovies";
            this.comboBoxMovies.Size = new System.Drawing.Size(308, 28);
            this.comboBoxMovies.TabIndex = 18;
            this.comboBoxMovies.Text = "Chọn tên phim";
            // 
            // movieType
            // 
            this.movieType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.movieType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.movieType.FormattingEnabled = true;
            this.movieType.Items.AddRange(new object[] {
            "2D",
            "3D"});
            this.movieType.Location = new System.Drawing.Point(104, 235);
            this.movieType.Name = "movieType";
            this.movieType.Size = new System.Drawing.Size(150, 28);
            this.movieType.TabIndex = 20;
            this.movieType.Text = "Chọn loại chiếu";
            // 
            // AddScreening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(494, 484);
            this.Controls.Add(this.movieType);
            this.Controls.Add(this.comboBoxMovies);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.comboBoxRoom);
            this.Controls.Add(this.bunifuDatePicker1);
            this.Controls.Add(this.bunifuButton1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "AddScreening";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);

        }
        private void AddScreening_Load(object sender, EventArgs e)
        {
            // Lấy focus ra khỏi DateTimePicker
            this.ActiveControl = null; // Hoặc sử dụng control khác không phải là DateTimePicker
        }
        #endregion

        private Bunifu.UI.WinForms.BunifuButton.BunifuButton2 bunifuButton1;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker1;
        private ComboBox comboBoxRoom;
        private Bunifu.UI.WinForms.BunifuTextBox priceTextBox;
        private ComboBox comboBoxMovies;
        private ComboBox movieType;
    }
}