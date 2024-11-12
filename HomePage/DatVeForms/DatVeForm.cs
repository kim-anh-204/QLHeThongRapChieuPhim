using QuanLyRapChieuPhim.UserControls;
using QuanLyRapChieuPhim.Util;
using System;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.Dashboard.DatVeForms
{
    public partial class DatVeForm : Form
    {
        private DatVe _datVe;
        private ChonGioChieu _chonGioChieu;
        private ChonChoNgoi _chonChoNgoi;
        public DatVeForm()
        {
            InitializeComponent();
        }

        private void DatVeForm_Load(object sender, EventArgs e)
        {
            LoadForm();
            bunifuPages1.SelectedIndex = 0;
        }

        private void LoadForm()
        {
            _datVe = new DatVe();
            _datVe.OnFilmCard_Click2 += OnFilmCard_Click2;
            Helper.HideUI(_datVe, null);
            _datVe.TopLevel = false;
            panel1.Controls.Add(_datVe);
            _datVe.Show();

            _chonGioChieu = new ChonGioChieu();
            _chonGioChieu.OnQuayLai_Click += OnQuayLai_Click;
            _chonGioChieu.OnGioChieu_Click += OnGioChieu_Click;
            Helper.HideUI(_chonGioChieu, null);
            _chonGioChieu.TopLevel = false;
            panel2.Controls.Add(_chonGioChieu);
            _chonGioChieu.Show();

            _chonChoNgoi = new ChonChoNgoi();
            _chonChoNgoi.OnQuayLai_Click += OnQuayLai_Click;
            Helper.HideUI(_chonChoNgoi, null);
            _chonChoNgoi.TopLevel = false;
            panel3.Controls.Add(_chonChoNgoi);
            _chonChoNgoi.Show();
        }

        private void OnQuayLai_Click()
        {
            bunifuPages1.SelectedIndex = Math.Max(0, bunifuPages1.SelectedIndex - 1);
        }

        private void OnFilmCard_Click2(FilmCard sender)
        {
            _chonGioChieu.ChangeInfo(sender.TenPhim);
            bunifuPages1.SelectedIndex = 1;
        }

        private void OnGioChieu_Click(string tenPhim, string ngayChieu, string gioChieu)
        {
            _chonChoNgoi.ChangeInfo(tenPhim, ngayChieu, gioChieu);
            bunifuPages1.SelectedIndex = 2;
        }
    }
}
