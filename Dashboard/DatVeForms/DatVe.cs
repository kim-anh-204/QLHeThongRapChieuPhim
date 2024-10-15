using QuanLyRapChieuPhim.UserControls;
using QuanLyRapChieuPhim.Util;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.Dashboard.DatVeForms
{
    public partial class DatVe : Form
    {
        public delegate void FilmCard_Click(FilmCard sender);
        public FilmCard_Click OnFilmCard_Click2;
        public DatVe()
        {
            InitializeComponent();
        }

        private void DatVe_Load(object sender, EventArgs e)
        {
            LoadFilmCard();

        }

        private void LoadFilmCard()
        {
            string query = "SELECT DISTINCT HinhAnh, TenPhim, Thoiluong, NgayKhoiChieu from SUATCHIEU join PHIM on SUATCHIEU.MaPhim = PHIM.MaPhim";


            DataTable dt = Connection.GetDataTable(query);
            foreach (DataRow dr in dt.Rows)
            {
                FilmCard filmCard = new FilmCard(Helper.ConvertArrayToImage((byte[])dr[0]), (string)dr[1], (int)dr[2], (DateTime)dr[3]);
                filmCard.OnFilmCard_Click += OnFilmCard_Click;
                flowLayoutPanelPhim.Controls.Add(filmCard);
            }
        }
        private void OnFilmCard_Click(FilmCard sender)
        {
            OnFilmCard_Click2?.Invoke(sender);
        }

        private void DatVe_Resize(object sender, EventArgs e)
        {
            flowLayoutPanelPhim.MaximumSize = new Size(Size.Width, 0);
        }
    }
}
