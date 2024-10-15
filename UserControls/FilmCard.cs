using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UserControls
{
    public partial class FilmCard : UserControl
    {
        public delegate void FilmCard_Click(FilmCard sender);
        public FilmCard_Click OnFilmCard_Click;

        public string TenPhim { get => labelTenPhim.Text; }
        public FilmCard(Image poster, string tenPhim, int thoiLuong, DateTime ngayKhoiChieu)
        {
            InitializeComponent();
            pictureBoxPoster.Image = poster;
            labelTenPhim.Text = tenPhim;
            labelThoiLuong.Text = thoiLuong + " phút";
            labelKhoiChieu.Text = ngayKhoiChieu.ToString();
        }

        private void pictureBoxPoster_Click(object sender, EventArgs e)
        {
            OnFilmCard_Click?.Invoke(this);
        }
    }
}
