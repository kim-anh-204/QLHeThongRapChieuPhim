using Bunifu.UI.WinForms.BunifuButton;
using QuanLyRapChieuPhim.UserControls;
using QuanLyRapChieuPhim.Util;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.Dashboard.DatVeForms
{
    public partial class ChonGioChieu : Form
    {
        private string _selectedFilmName;

        public string SelectedFilmName { get => _selectedFilmName; }

        public delegate void QuayLai_Click();
        public QuayLai_Click OnQuayLai_Click;

        public delegate void GioChieu_Click(string tenPhim, string ngayChieu, string gioChieu);
        public GioChieu_Click OnGioChieu_Click;
        public ChonGioChieu()
        {
            InitializeComponent();
        }
        private void ChonGioChieu_Load(object sender, EventArgs e)
        {
        }
        private void buttonQuayLai_Click(object sender, EventArgs e)
        {
            OnQuayLai_Click?.Invoke();
        }

        public void ChangeInfo(string filmName)
        {
            _selectedFilmName = filmName;
            flowPanelContent.Controls.Clear();
            string query = "SELECT Ngaychieu, GioBatdau FROM SUATCHIEU JOIN PHIM on SUATCHIEU.MaPhim = PHIM.MaPhim WHERE TenPhim = @TenPhim ORDER BY Ngaychieu";
            DataTable dt = Connection.GetDataTable(query, new (string, object)[]
            {
                ("@TenPhim", filmName)
            });
            DateTime date = DateTime.MinValue;
            FlowLayoutPanel flowLayoutPanel = null;
            foreach (DataRow dr in dt.Rows)
            {
                DateTime curDate = (DateTime)dr[0];
                if (date != curDate)
                {
                    date = curDate;
                    flowPanelContent.Controls.Add(CreateHourPanel(date.ToString("dd/MM/yyyy")));
                    flowLayoutPanel = new FlowLayoutPanel();
                    flowPanelContent.Controls.Add(flowLayoutPanel);
                }
                BunifuButton2 button = CreateHourButton(dr[1].ToString(), dr[1].ToString() + "~" + date.ToString("yyyy-MM-dd"));
                button.Click += OnGioChieuButton_Click;
                flowLayoutPanel.Controls.Add(button);
            }
        }

        private void OnGioChieuButton_Click(object sender, EventArgs e)
        {
            BunifuButton2 button = (BunifuButton2)sender;
            string[] parts = button.Name.Split('~');
            OnGioChieu_Click?.Invoke(SelectedFilmName, parts[1], parts[0]);
        }

        private Panel CreateHourPanel(string date)
        {
            Label label = new Label
            {
                Text = date,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
            };

            Panel panel = new Panel
            {
                BackColor = Color.Transparent,
                Width = 1045,
                Height = 35,
            };
            panel.Controls.Add(label);
            return panel;
        }
        private BunifuButton2 CreateHourButton(string buttonText, string buttonName)
        {
            BunifuButton2 button = new BunifuButton2
            {
                Text = buttonText,
                Name = buttonName,
                IdleBorderRadius = 20,
                IdleFillColor = Color.White,
                IdleBorderThickness = 1,
                IdleBorderColor = Color.Gray,
                ForeColor = Color.Black,
            };
            button.onHoverState.FillColor = Color.Red;
            button.onHoverState.BorderColor = Color.Red;
            button.OnPressedState.FillColor = Color.FromArgb(192, 0, 0);
            button.OnPressedState.BorderColor = Color.FromArgb(192, 0, 0);

            return button;
        }
    }
}
